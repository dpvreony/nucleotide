using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeGeneration.Roslyn;
using Dhgms.Nucleotide.Helpers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Validation;

namespace Dhgms.Nucleotide.Generators
{
    /// <summary>
    /// Generates the Web API service
    /// </summary>
    public sealed class WebApiServiceGenerator : BaseClassLevelCodeGenerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebApiServiceGenerator"/> class.
        /// </summary>
        public WebApiServiceGenerator(AttributeData attributeData) : base(attributeData)
        {
        }

        /// <inheritdoc />
        protected override string GetClassSuffix()
        {
            return "Controller";
        }

        protected override string GetNamespace()
        {
            return "Controllers";
        }

        /// <inheritdoc />
        protected override string GetBaseClass()
        {
#if NET46
            return "System.Web.Http.ApiController";
#else
            return "Microsoft.AspNetCore.Mvc.Controller";
#endif
        }

        /// <inheritdoc />
        protected override IList<Tuple<Func<string, string>, string, Accessibility>> GetConstructorArguments()
        {
            var result = new List<Tuple<Func<string, string>, string, Accessibility>>
            {
                new Tuple<Func<string, string>, string, Accessibility>(entityName => $"Hubs.I{entityName}Hub", "signalRHub", Accessibility.Private),
                new Tuple<Func<string, string>, string, Accessibility>(entityName => $"CommandFactories.I{entityName}CommandFactory", "commandFactory", Accessibility.Private),
                new Tuple<Func<string, string>, string, Accessibility>(entityName => $"QueryFactories.I{entityName}QueryFactory", "queryFactory", Accessibility.Private),
            };

            return result;
        }

        /// <inheritdoc />
        protected override MemberDeclarationSyntax[] GetMethodDeclarations(string entityName)
        {
            var result = new List<MemberDeclarationSyntax>
            {
                GetAddMethodDeclaration(entityName),
                GetDeleteMethodDeclaration(entityName),
                GetListMethodDeclaration(entityName),
                GetUpdateMethodDeclaration(entityName),
                GetViewMethodDeclaration(entityName)
            };


            return result.ToArray();
        }

        private MemberDeclarationSyntax GetAddMethodDeclaration(string entityName)
        {
            var methodName = "AddAsync";
            var commandLocalDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromMethodOnFieldSyntax("command", "_commandFactory", "GetAddCommandAsync");
            var commandExecutionDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromVariableInvocationSyntax("result", "command", "ExecuteAsync");

            var signalRNotificationExecution = RoslynGenerationHelpers.GetMethodOnFieldInvocationSyntax("_signalRHub", "OnAddAsync", new [] { "result" });

            var catchDeclaration = SyntaxFactory.CatchDeclaration(SyntaxFactory.IdentifierName("Exception"),
                    SyntaxFactory.Identifier("ex"));

            var exceptionLoggingInvocation = RoslynGenerationHelpers.GetMethodOnFieldInvocationSyntax("Logger", "WarnException", new [] { $"\"Exception in {methodName} for SignalR OnAdd\"", "ex" });
            var catchBlockStatements = new [] {exceptionLoggingInvocation};

            var catchBlock = SyntaxFactory.Block(catchBlockStatements);
            var catchClause = SyntaxFactory.CatchClause(catchDeclaration, null, catchBlock);

            var trySignalRNotification = SyntaxFactory.TryStatement(SyntaxFactory.Block(signalRNotificationExecution), new SyntaxList<CatchClauseSyntax>().Add(catchClause), null);

            var returnStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("result.Id"));

            var body = new [] { commandLocalDeclaration, commandExecutionDeclaration, trySignalRNotification, returnStatement };

            var attributeName = "Microsoft​.AspNetCore​.Mvc.HttpPost";
            var attributeListSyntax = GetAttributeListSyntax(attributeName);

            var returnType = SyntaxFactory.ParseTypeName("System.Threading.Tasks.Task<int>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName)
                //.WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddAttributeLists(attributeListSyntax)
                .AddBodyStatements(body);
            return declaration;
        }

        private static AttributeListSyntax GetAttributeListSyntax(string attributeName)
        {
            var name = SyntaxFactory.ParseName(attributeName);
            var attribute2 = SyntaxFactory.Attribute(name);

            var attributeList = new SeparatedSyntaxList<AttributeSyntax>();
            attributeList = attributeList.Add(attribute2);
            var list = SyntaxFactory.AttributeList(attributeList);
            return list;
        }

        private MemberDeclarationSyntax GetDeleteMethodDeclaration(string entityName)
        {
            var commandLocalDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromMethodOnFieldSyntax("command", "_commandFactory", "GetDeleteCommandAsync");
            var commandExecutionDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromVariableInvocationSyntax("result", "command", "ExecuteAsync");
            var returnStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("result"));

            var body = new StatementSyntax[] { commandLocalDeclaration, commandExecutionDeclaration, returnStatement };

            var attributeName = "Microsoft​.AspNetCore​.Mvc.HttpDelete";
            var attributeListSyntax = GetAttributeListSyntax(attributeName);

            var returnType = SyntaxFactory.ParseTypeName("System.Threading.Tasks.Task");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, "DeleteAsync")
                //.WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddAttributeLists(attributeListSyntax)
                .AddBodyStatements(body);
            return declaration;
        }

        private MemberDeclarationSyntax GetListMethodDeclaration(string entityName)
        {
            var commandLocalDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromMethodOnFieldSyntax("query", "_queryFactory", "GetListQueryAsync");
            var commandExecutionDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromVariableInvocationSyntax("result", "query");
            var returnStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("result"));

            var body = new StatementSyntax[] { commandLocalDeclaration, commandExecutionDeclaration, returnStatement };

            var attributeName = "Microsoft​.AspNetCore​.Mvc.HttpGet";
            var attributeListSyntax = GetAttributeListSyntax(attributeName);

            var returnType = SyntaxFactory.ParseTypeName($"System.Threading.Tasks.Task<ResponseDtos.List{entityName}ResponseDto>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, "ListAsync")
                //.WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddAttributeLists(attributeListSyntax)
                .AddBodyStatements(body);
            return declaration;
        }

        private MemberDeclarationSyntax GetUpdateMethodDeclaration(string entityName)
        {
            var commandLocalDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromMethodOnFieldSyntax("command", "_commandFactory", "GetUpdateCommandAsync");
            var commandExecutionDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromVariableInvocationSyntax("result", "command", "ExecuteAsync");
            var returnStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("result"));

            var body = new StatementSyntax[] { commandLocalDeclaration, commandExecutionDeclaration, returnStatement };

            var attributeName = "Microsoft​.AspNetCore​.Mvc.HttpPatch";
            var attributeListSyntax = GetAttributeListSyntax(attributeName);

            var returnType = SyntaxFactory.ParseTypeName("System.Threading.Tasks.Task");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, "UpdateAsync")
                //.WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddAttributeLists(attributeListSyntax)
                .AddBodyStatements(body);
            return declaration;
        }

        private MemberDeclarationSyntax GetViewMethodDeclaration(string entityName)
        {
            var commandLocalDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromMethodOnFieldSyntax("query", "_queryFactory", "GetViewQueryAsync");
            var commandExecutionDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromVariableInvocationSyntax("result", "query");
            var returnStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("result"));

            var body = new StatementSyntax[] { commandLocalDeclaration, commandExecutionDeclaration, returnStatement };

            var attributeName = "Microsoft​.AspNetCore​.Mvc.HttpGet";
            var attributeListSyntax = GetAttributeListSyntax(attributeName);

            var returnType = SyntaxFactory.ParseTypeName($"System.Threading.Tasks.Task<ResponseDtos.View{entityName}ResponseDto>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, "ViewAsync")
                //.WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddAttributeLists(attributeListSyntax)
                .AddBodyStatements(body);
            return declaration;
        }
    }
}
