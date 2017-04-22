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

        protected override IList<string> GetImplementedInterfaces(string entityName)
        {
            return new List<string>
            {
                $"Services.I{entityName}Service"
            };
        }

        /// <inheritdoc />
        protected override IList<Tuple<Func<string, string>, string, Accessibility>> GetConstructorArguments()
        {
            var result = new List<Tuple<Func<string, string>, string, Accessibility>>
            {
                new Tuple<Func<string, string>, string, Accessibility>(entityName => $"Hubs.I{entityName}Hub", "signalRHub", Accessibility.Private),
                new Tuple<Func<string, string>, string, Accessibility>(entityName => $"CommandFactories.I{entityName}CommandFactory", "commandFactory", Accessibility.Private),
                new Tuple<Func<string, string>, string, Accessibility>(entityName => $"QueryFactories.I{entityName}QueryFactory", "queryFactory", Accessibility.Private),
                new Tuple<Func<string, string>, string, Accessibility>(entityName => $"Microsoft.AspNetCore.Authorization.IAuthorizationService", "authorizationService", Accessibility.Private),
            };

            return result;
        }

        protected override List<Tuple<string, IList<string>>> GetClassAttributes()
        {
            return new List<Tuple<string, IList<string>>>
            {
                new Tuple<string, IList<string>>("Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryToken", null)
            };
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

            var attributes = new List<Tuple<string, IList<string>>>
            {
                new Tuple<string, IList<string>>("Microsoft​.AspNetCore​.Mvc.HttpPost", null),
                new Tuple<string, IList<string>>("Microsoft.AspNetCore.Authorization.Authorize", new List<string> { $"Roles=\"API_{entityName}_Add\""}),
            };

            var attributeListSyntax = GetAttributeListSyntax(attributes);

            var parameters = GetParams(new []{ $"RequestDtos.Add{entityName}RequestDto requestDto"});

            var returnType = SyntaxFactory.ParseTypeName("System.Threading.Tasks.Task<int>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName)
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddAttributeLists(attributeListSyntax)
                .AddBodyStatements(body);
            return declaration;
        }

        private MemberDeclarationSyntax GetDeleteMethodDeclaration(string entityName)
        {
            var commandLocalDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromMethodOnFieldSyntax("command", "_commandFactory", "GetDeleteCommandAsync");
            var commandExecutionDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromVariableInvocationSyntax("result", "command", "ExecuteAsync");
            var returnStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("result"));

            var body = new StatementSyntax[] { commandLocalDeclaration, commandExecutionDeclaration, returnStatement };

            var attributes = new List<Tuple<string, IList<string>>>
            {
                new Tuple<string, IList<string>>("Microsoft​.AspNetCore​.Mvc.HttpDelete", null),
                new Tuple<string, IList<string>>("Microsoft.AspNetCore.Authorization.Authorize", new List<string> { $"Roles=\"API_{entityName}_Delete\""}),
            };

            var attributeListSyntax = GetAttributeListSyntax(attributes);

            var parameters = GetParams(new[] { $"int {OldHelpers.GetVariableName(entityName)}Id" });

            var returnType = SyntaxFactory.ParseTypeName("System.Threading.Tasks.Task");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, "DeleteAsync")
                .WithParameterList(parameters)
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

            var attributes = new List<Tuple<string, IList<string>>>
            {
                new Tuple<string, IList<string>>("Microsoft​.AspNetCore​.Mvc.HttpGet", null),
                new Tuple<string, IList<string>>("Microsoft.AspNetCore.Authorization.Authorize", new List<string> { $"Roles=\"API_{entityName}_List\""}),
            };

            var attributeListSyntax = GetAttributeListSyntax(attributes);

            var parameters = GetParams(new[] { $"RequestDtos.List{entityName}RequestDto requestDto" });

            var returnType = SyntaxFactory.ParseTypeName($"System.Threading.Tasks.Task<ResponseDtos.List{entityName}ResponseDto>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, "ListAsync")
                .WithParameterList(parameters)
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

            var attributes = new List<Tuple<string, IList<string>>>
            {
                new Tuple<string, IList<string>>("Microsoft​.AspNetCore​.Mvc.HttpPatch", null),
                new Tuple<string, IList<string>>("Microsoft.AspNetCore.Authorization.Authorize", new List<string> { $"Roles=\"API_{entityName}_Update\""}),
            };

            var attributeListSyntax = GetAttributeListSyntax(attributes);

            var parameters = GetParams(new[]
            {
                $"int {OldHelpers.GetVariableName(entityName)}Id",
                $"RequestDtos.Update{entityName}RequestDto requestDto"
            });
            var returnType = SyntaxFactory.ParseTypeName("System.Threading.Tasks.Task");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, "UpdateAsync")
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddAttributeLists(attributeListSyntax)
                .AddBodyStatements(body);
            return declaration;
        }

        private MemberDeclarationSyntax GetViewMethodDeclaration(string entityName)
        {
            var entityIdVariableName = $"{OldHelpers.GetVariableName(entityName)}Id";
            const string notFoundResult = "new Microsoft.AspNetCore.Mvc.NotFoundResult()";
            var numberTooLowCheckDeclaration =
                RoslynGenerationHelpers.GetReturnIfLessThanSyntax(entityIdVariableName, 1, notFoundResult);
            var commandLocalDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromMethodOnFieldSyntax("query", "_queryFactory", "GetViewQueryAsync");
            var commandExecutionDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromVariableInvocationSyntax("result", "query");
            var nullQueryResultCheckDeclaration = RoslynGenerationHelpers.GetReturnIfNullSyntax("result", notFoundResult);
            var returnStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("result"));

            // todo: https://github.com/blowdart/AspNetAuthorizationWorkshop/blob/master/src/Step_7_Resource_Based_Requirements/Controllers/DocumentController.cs

            var body = new []
            {
                numberTooLowCheckDeclaration,
                commandLocalDeclaration,
                commandExecutionDeclaration,
                nullQueryResultCheckDeclaration,
                returnStatement
            };

            var attributes = new List<Tuple<string, IList<string>>>
            {
                new Tuple<string, IList<string>>("Microsoft​.AspNetCore​.Mvc.HttpGet", null),
                new Tuple<string, IList<string>>("Microsoft.AspNetCore.Authorization.Authorize", new List<string> { $"Roles=\"API_{entityName}_View\""}),
            };

            var attributeListSyntax = GetAttributeListSyntax(attributes);

            var parameters = GetParams(new[]
            {
                $"int {OldHelpers.GetVariableName(entityName)}Id"
            });

            var returnType = SyntaxFactory.ParseTypeName($"System.Threading.Tasks.Task<ResponseDtos.View{entityName}ResponseDto>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, "ViewAsync")
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddAttributeLists(attributeListSyntax)
                .AddBodyStatements(body);
            return declaration;
        }
    }
}
