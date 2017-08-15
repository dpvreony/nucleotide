using System;
using System.Collections.Generic;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Helpers;
using Dhgms.Nucleotide.Model;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Features.WebApi
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
        protected override MemberDeclarationSyntax[] GetPropertyDeclarations(IEntityGenerationModel entityGenerationModel)
        {
            return null;
        }

        protected override string GetClassPrefix()
        {
            return null;
        }

        protected override string GetClassSuffix()
        {
            return "Controller";
        }

        protected override string GetNamespace()
        {
            return "Controllers";
        }

        protected override IList<string> GetUsings()
        {
            return new List<string>
            {
                "Microsoft.Extensions.Logging"
            };
        }

        /// <inheritdoc />
        protected override string GetBaseClass(string entityName)
        {
            return "Microsoft.AspNetCore.Mvc.Controller";
        }

        protected override IList<string> GetImplementedInterfaces(string entityName)
        {
            return null;

            /*
            return new List<string>
            {
                $"Services.I{entityName}Service"
            };
            */
        }

        /// <inheritdoc />
        protected override IList<Tuple<Func<string, string>, string, Accessibility>> GetConstructorArguments()
        {
            var result = new List<Tuple<Func<string, string>, string, Accessibility>>
            {
                new Tuple<Func<string, string>, string, Accessibility>(entityName => $"Hubs.I{entityName}Hub", "signalRHub", Accessibility.Private),
                new Tuple<Func<string, string>, string, Accessibility>(entityName => $"CommandFactories.I{entityName}CommandFactory", "commandFactory", Accessibility.Private),
                new Tuple<Func<string, string>, string, Accessibility>(entityName => $"QueryFactories.I{entityName}QueryFactory", "queryFactory", Accessibility.Private),
                new Tuple<Func<string, string>, string, Accessibility>(_ => $"Microsoft.AspNetCore.Authorization.IAuthorizationService", "authorizationService", Accessibility.Private),
                new Tuple<Func<string, string>, string, Accessibility>(entityName => $"Microsoft.Extensions.Logging.ILogger<{entityName}Controller>", "logger", Accessibility.Private),
            };

            return result;
        }

        protected override string[] GetClassLevelCommentSummary(string entityName)
        {
            return new[]
            {
                $"Web API Service for {entityName}"
            };
        }

        protected override string[] GetClassLevelCommentRemarks(string entityName)
        {
            return null;
        }

        protected override List<Tuple<string, IList<string>>> GetClassAttributes()
        {
            return new List<Tuple<string, IList<string>>>
            {
                new Tuple<string, IList<string>>("Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryToken", null),
                new Tuple<string, IList<string>>("Microsoft.AspNetCore.Authorization.Authorize", null)
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

            var userLocalDeclaration =
                RoslynGenerationHelpers
                    .GetVariableAssignmentFromVariablePropertyAccessSyntax("user", "HttpContext", "User");

            var commandLocalDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromMethodOnFieldSyntax(
                "command",
                "_commandFactory",
                "GetAddCommandAsync");

            var arguments = new[]
            {
                "requestDto",
                "user"
            };

            var commandExecutionDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromVariableInvocationSyntax(
                "result",
                "command",
                "ExecuteAsync", arguments);

            var signalRNotificationExecution = RoslynGenerationHelpers.GetMethodOnFieldInvocationSyntax("_signalRHub", "OnAddAsync", new [] { "result" }, true);

            var catchDeclaration = SyntaxFactory.CatchDeclaration(SyntaxFactory.IdentifierName("Exception"),
                    SyntaxFactory.Identifier("ex"));

            var loggerExceptionArgs = new[]
            {
                $"EventId.{entityName}ControllerOnAddNotifySignalR",
                "ex",
                $"\"Exception in {methodName} for SignalR OnAdd\"",
            };
            var exceptionLoggingInvocation = RoslynGenerationHelpers.GetMethodOnFieldInvocationSyntax(
                "_logger",
                "LogWarning",
                loggerExceptionArgs,
                false);
            var catchBlockStatements = new [] {exceptionLoggingInvocation};

            var catchBlock = SyntaxFactory.Block(catchBlockStatements);
            var catchClause = SyntaxFactory.CatchClause(catchDeclaration, null, catchBlock);

            var trySignalRNotification = SyntaxFactory.TryStatement(SyntaxFactory.Block(signalRNotificationExecution), new SyntaxList<CatchClauseSyntax>().Add(catchClause), null);

            var returnStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("result.Id"));

            var body = new []
            {
                userLocalDeclaration,
                commandLocalDeclaration,
                commandExecutionDeclaration,
                trySignalRNotification,
                returnStatement
            };

            var attributes = new List<Tuple<string, IList<string>>>
            {
                new Tuple<string, IList<string>>("Microsoft​.AspNetCore​.Mvc.HttpPost", null),
                new Tuple<string, IList<string>>("Microsoft​.AspNetCore​.Mvc.Produces", new List<string>{ "typeof(int)"}),
                new Tuple<string, IList<string>>("Swashbuckle.AspNetCore.SwaggerGen.SwaggerResponse", new List<string>{ "200", "Type = typeof(int)"}),
                //new Tuple<string, IList<string>>("Microsoft.AspNetCore.Authorization.Authorize", new List<string> { $"Roles=\"API_{entityName}_Add\""}),
            };

            var attributeListSyntax = GetAttributeListSyntax(attributes);

            var parameters = GetParams(new []{ $"Models.Unkeyed{entityName}Model requestDto"});

            var returnType = SyntaxFactory.ParseTypeName("System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult>");
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
            var arguments = new[]
            {
                "id"
            };
            var commandExecutionDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromVariableInvocationSyntax("result", "command", "ExecuteAsync", arguments);
            var returnStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("result"));

            var body = new StatementSyntax[] { commandLocalDeclaration, commandExecutionDeclaration, returnStatement };

            var attributes = new List<Tuple<string, IList<string>>>
            {
                new Tuple<string, IList<string>>("Microsoft​.AspNetCore​.Mvc.HttpDelete", null),
                new Tuple<string, IList<string>>("Microsoft.AspNetCore.Authorization.Authorize", new List<string> { $"Roles=\"API_{entityName}_Delete\""}),
            };

            var attributeListSyntax = GetAttributeListSyntax(attributes);

            var parameters = GetParams(new[] { $"int id" });

            var returnType = SyntaxFactory.ParseTypeName("System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult>");
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
                new Tuple<string, IList<string>>("Microsoft​.AspNetCore​.Mvc.Produces", new List<string>{ $"typeof({entityName}[])"}),
                new Tuple<string, IList<string>>("Swashbuckle.AspNetCore.SwaggerGen.SwaggerResponse", new List<string>{ "200", $"Type = typeof({entityName}[])"}),
            };

            var attributeListSyntax = GetAttributeListSyntax(attributes);

            var parameters = GetParams(new[] { $"RequestDtos.List{entityName}RequestDto requestDto" });

            var returnType = SyntaxFactory.ParseTypeName("System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult>");
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
            var arguments = new[]
            {
                "requestDto"
            };
            var commandExecutionDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromVariableInvocationSyntax("result", "command", "ExecuteAsync", arguments);
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
                $"RequestDtos.Update{entityName}RequestDto requestDto"
            });
            var returnType = SyntaxFactory.ParseTypeName("System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, "UpdateAsync")
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddAttributeLists(attributeListSyntax)
                .AddBodyStatements(body);
            return declaration;
        }

        private MemberDeclarationSyntax GetViewMethodDeclaration(string entityName)
        {
            var entityIdVariableName = "id";
            const string notFoundResult = "new Microsoft.AspNetCore.Mvc.NotFoundResult()";
            var numberTooLowCheckDeclaration =
                RoslynGenerationHelpers.GetReturnIfLessThanSyntax(entityIdVariableName, 1, notFoundResult);
            var commandLocalDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromMethodOnFieldSyntax("query", "_queryFactory", "GetViewQueryAsync");

            var arguments = new[]
            {
                "id"
            };
            var commandExecutionDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromVariableInvocationSyntax("result", "query", "Execute", arguments);
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
                new Tuple<string, IList<string>>("Microsoft​.AspNetCore​.Mvc.Produces", new List<string>{ $"typeof({entityName}Model)"}),
                new Tuple<string, IList<string>>("Swashbuckle.AspNetCore.SwaggerGen.SwaggerResponse", new List<string>{ "200", $"Type = typeof({entityName}Model)" }),
            };

            var attributeListSyntax = GetAttributeListSyntax(attributes);

            var parameters = GetParams(new[]
            {
                "int id"
            });

            var returnType = SyntaxFactory.ParseTypeName("System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, "ViewAsync")
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddAttributeLists(attributeListSyntax)
                .AddBodyStatements(body);
            return declaration;
        }
    }
}
