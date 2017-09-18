using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Features.WebApi;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Helpers;
using Dhgms.Nucleotide.Model;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Features.Mvc
{
    /// <summary>
    /// Generates the MVC Controllers
    /// </summary>
    public sealed class MvcControllerGenerator : BaseClassLevelCodeGenerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MvcControllerGenerator"/> class.
        /// </summary>
        public MvcControllerGenerator(AttributeData attributeData) : base(attributeData)
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
            return "MvcControllers";
        }

        protected override IList<string> GetUsings()
        {
            return new List<string>
            {
                "Microsoft.Extensions.Logging",
                "Microsoft.AspNetCore.Authorization"
            };
        }

        protected override bool GetWhetherClassShouldBePartialClass() => true;

        protected override bool GetWhetherClassShouldBeSealedClass() => true;

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
                new Tuple<Func<string, string>, string, Accessibility>(_ => "Microsoft.AspNetCore.Authorization.IAuthorizationService", "authorizationService", Accessibility.Private),
                new Tuple<Func<string, string>, string, Accessibility>(entityName => $"Microsoft.Extensions.Logging.ILogger<{entityName}Controller>", "logger", Accessibility.Private),
            };

            return result;
        }

        protected override string[] GetClassLevelCommentSummary(string entityName)
        {
            return new[]
            {
                $"MVC Controller for {entityName}"
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
                GetListMethodDeclaration(entityName),
                GetViewMethodDeclaration(entityName),
                GetEventIdMethodDeclaration(entityName, "List"),
                GetEventIdMethodDeclaration(entityName, "View"),
            };


            return result.ToArray();
        }

        private MemberDeclarationSyntax GetListMethodDeclaration(string entityName)
        {
            var userLocalDeclaration =
                RoslynGenerationHelpers
                    .GetVariableAssignmentFromVariablePropertyAccessSyntax("user", "HttpContext", "User");
            var commandLocalDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromMethodOnFieldSyntax("query", "_queryFactory", "GetListQueryAsync", null, true);
            var arguments = new[]
            {
                "requestDto",
                "user"
            };
            var commandExecutionDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromVariableInvocationSyntax("result", "query", "ExecuteAsync", arguments);
            var returnStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("result"));

            var body = new StatementSyntax[]
            {
                userLocalDeclaration,
                commandLocalDeclaration,
                commandExecutionDeclaration,
                returnStatement
            };

            var attributes = new List<Tuple<string, IList<string>>>
            {
                new Tuple<string, IList<string>>("Microsoft​.AspNetCore​.Mvc.HttpGet", null)
            };

            var attributeListSyntax = GetAttributeListSyntax(attributes);

            //var parameters = GetParams(new[] { $"RequestDtos.List{entityName}RequestDto requestDto" });

            var returnType = SyntaxFactory.ParseTypeName("System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, "ListAsync")
                //.WithParameterList(parameters)
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
            var commandLocalDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromMethodOnFieldSyntax("query", "_queryFactory", "GetViewQueryAsync", null, true);

            var arguments = new[]
            {
                "id"
            };
            var commandExecutionDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromVariableInvocationSyntax("result", "query", "Execute", arguments);
            var nullQueryResultCheckDeclaration = RoslynGenerationHelpers.GetReturnIfNullSyntax("result", notFoundResult);
            var returnStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("result"));

            // todo: https://github.com/blowdart/AspNetAuthorizationWorkshop/blob/master/src/Step_7_Resource_Based_Requirements/Controllers/DocumentController.cs

            var body = new[]
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
