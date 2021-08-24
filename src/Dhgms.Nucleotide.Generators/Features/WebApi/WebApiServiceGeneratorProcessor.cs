using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.Generators.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.WebApi
{
    public class WebApiServiceGeneratorProcessor : BaseClassLevelCodeGeneratorProcessor<IEntityGenerationModel>
    {
        /// <inheritdoc />
        protected override PropertyDeclarationSyntax[] GetPropertyDeclarations(IEntityGenerationModel entityGenerationModel)
        {
            return null;
        }

        protected override string[] GetClassPrefixes() => null;

        protected override string GetClassSuffix()
        {
            return "Controller";
        }

        protected override IList<string> GetUsings()
        {
            return new List<string>
            {
                "System.Threading.Tasks",
                "Microsoft.Extensions.Logging",
                "Microsoft.AspNetCore.Authorization",
                "Microsoft.AspNetCore.Mvc"
            };
        }

        protected override bool GetWhetherClassShouldBePartialClass() => true;

        protected override bool GetWhetherClassShouldBeSealedClass() => true;

        /// <inheritdoc />
        protected override string GetBaseClass(string entityName) =>
            $"Whipstaff.AspNetCore.CrudController<{entityName}Controller, Queries.IList{entityName}Query, RequestDtos.List{entityName}RequestDto, ResponseDtos.List{entityName}ResponseDto, Queries.IView{entityName}Query, ResponseDtos.View{entityName}ResponseDto, Commands.IAdd{entityName}Command, RequestDtos.Add{entityName}RequestDto, ResponseDtos.Add{entityName}ResponseDto, Commands.IDelete{entityName}Command, ResponseDtos.Delete{entityName}ResponseDto, Commands.IUpdate{entityName}Command, RequestDtos.Update{entityName}RequestDto, ResponseDtos.Update{entityName}ResponseDto>";

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
                new Tuple<Func<string, string>, string, Accessibility>(_ => "Microsoft.AspNetCore.Authorization.IAuthorizationService", "authorizationService", Accessibility.Private),
                new Tuple<Func<string, string>, string, Accessibility>(entityName => $"Microsoft.Extensions.Logging.ILogger<{entityName}Controller>", "logger", Accessibility.Private),
                new Tuple<Func<string, string>, string, Accessibility>(entityName => $"MediatR.IMediator", "mediator", Accessibility.Private),
                new Tuple<Func<string, string>, string, Accessibility>(entityName => $"CommandFactories.I{entityName}CommandFactory", "commandFactory", Accessibility.Private),
                new Tuple<Func<string, string>, string, Accessibility>(entityName => $"QueryFactories.I{entityName}QueryFactory", "queryFactory", Accessibility.Private),
            };

            return result;
        }

        protected override IList<string> GetBaseConstructorArguments()
        {
            var result = new List<string>
            {
                "authorizationService",
                "logger",
                "mediator",
                "commandFactory",
                "queryFactory",
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

        protected override IList<Tuple<string, IList<string>>> GetClassAttributes(IEntityGenerationModel entityDeclaration)
        {
            return new List<Tuple<string, IList<string>>>
            {
                new Tuple<string, IList<string>>("Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryToken", null),
                new Tuple<string, IList<string>>("Microsoft.AspNetCore.Authorization.Authorize", null),
                new Tuple<string, IList<string>>("Microsoft.AspNetCore.Mvc.Route", new[]{ $"\"api/{entityDeclaration.ClassName.ToLower()}\"" })
            };
        }

        /// <inheritdoc />
        protected override MethodDeclarationSyntax[] GetMethodDeclarations(IEntityGenerationModel entityGenerationModel)
        {
            var entityName = entityGenerationModel.ClassName;

            var result = new []
            {
                GetAddActionResultAsyncDeclaration(entityName),
                GetDeleteActionResultAsyncDeclaration(entityName),
                GetListActionResultAsyncDeclaration(entityName),
                GetUpdateActionResultAsyncDeclaration(entityName),
                GetViewActionResultAsyncDeclaration(entityName),

                //GetAddMethodDeclaration(entityName),
                //GetDeleteMethodDeclaration(entityName),
                //GetListMethodDeclaration(entityName),
                //GetUpdateMethodDeclaration(entityName),
                //GetViewMethodDeclaration(entityName),

                GetCommandMethodDeclaration(entityName,"Add", $"RequestDtos.Add{entityName}RequestDto"),
                GetCommandMethodDeclaration(entityName,"Delete", "long"),
                GetCommandMethodDeclaration(entityName,"Update", $"RequestDtos.Update{entityName}RequestDto"),

                GetPolicyMethodDeclaration(entityName, "Add"),
                GetPolicyMethodDeclaration(entityName, "Delete"),
                GetPolicyMethodDeclaration(entityName, "List"),
                GetPolicyMethodDeclaration(entityName, "Update"),
                GetPolicyMethodDeclaration(entityName, "View"),

                GetEventIdMethodDeclaration(entityName, "Add"),
                GetEventIdMethodDeclaration(entityName, "Delete"),
                GetEventIdMethodDeclaration(entityName, "List"),
                GetEventIdMethodDeclaration(entityName, "Update"),
                GetEventIdMethodDeclaration(entityName, "View"),

                GetQueryMethodDeclaration(entityName,"List", $"RequestDtos.List{entityName}RequestDto"),
                GetQueryMethodDeclaration(entityName,"View", "long"),
            };


            return result;
        }

        private MethodDeclarationSyntax GetCommandMethodDeclaration(
            string entityName,
            string action,
            string requestType)
        {
            var methodName = $"Get{action}CommandAsync";

            var returnStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.ParseExpression($"await CommandFactory.Get{action}CommandAsync(request, claimsPrincipal, cancellationToken).ConfigureAwait(false)"));

            var body = new StatementSyntax[]
            {
                returnStatement
            };

            var returnType = SyntaxFactory.ParseTypeName($"Task<Commands.I{action}{entityName}Command>");

            var parameters = GetParams(new []
            {
                $"{requestType} request",
                "System.Security.Claims.ClaimsPrincipal claimsPrincipal",
                "System.Threading.CancellationToken cancellationToken",
            });

            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName)
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.ProtectedKeyword), SyntaxFactory.Token(SyntaxKind.OverrideKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddBodyStatements(body);
            return declaration;
        }

        private MethodDeclarationSyntax GetQueryMethodDeclaration(
            string entityName,
            string action,
            string requestType)
        {
            var methodName = $"Get{action}QueryAsync";

            var returnStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.ParseExpression($"await QueryFactory.Get{action}QueryAsync(request, claimsPrincipal, cancellationToken).ConfigureAwait(false)"));

            var body = new StatementSyntax[]
            {
                returnStatement
            };

            var returnType = SyntaxFactory.ParseTypeName($"Task<Queries.I{action}{entityName}Query>");

            var parameters = GetParams(new []
            {
                $"{requestType} request",
                "System.Security.Claims.ClaimsPrincipal claimsPrincipal",
                "System.Threading.CancellationToken cancellationToken",
            });

            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName)
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.ProtectedKeyword), SyntaxFactory.Token(SyntaxKind.OverrideKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddBodyStatements(body);
            return declaration;
        }

        protected override SeparatedSyntaxList<AttributeSyntax> GetAttributesForProperty(PropertyInfoBase propertyInfo)
        {
            return default(SeparatedSyntaxList<AttributeSyntax>);
        }

        private MethodDeclarationSyntax GetPolicyMethodDeclaration(string entityName, string action)
        {
            var methodName = $"Get{action}PolicyAsync";

            var returnStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.ParseExpression($"await Task.FromResult(\"Api.{entityName}.{action}\").ConfigureAwait(false)"));

            var body = new StatementSyntax[]
            {
                returnStatement
            };

            var returnType = SyntaxFactory.ParseTypeName("Task<string>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.ProtectedKeyword), SyntaxFactory.Token(SyntaxKind.OverrideKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddBodyStatements(body);
            return declaration;
        }

        private MethodDeclarationSyntax GetAddActionResultAsyncDeclaration(string entityName)
        {
            return GetOkActionResultDeclaration(entityName, "add");
        }

        private MethodDeclarationSyntax GetDeleteActionResultAsyncDeclaration(string entityName)
        {
            return GetOkActionResultDeclaration(entityName, "delete");
        }

        private MethodDeclarationSyntax GetListActionResultAsyncDeclaration(string entityName)
        {
            return GetOkActionResultDeclaration(entityName, "list");
        }

        private MethodDeclarationSyntax GetUpdateActionResultAsyncDeclaration(string entityName)
        {
            return GetOkActionResultDeclaration(entityName, "update");
        }

        private MethodDeclarationSyntax GetViewActionResultAsyncDeclaration(string entityName)
        {
            return GetOkActionResultDeclaration(entityName, "view");
        }

        private MethodDeclarationSyntax GetOkActionResultDeclaration(string entityName, string action)
        {
            var camelAction = action.Substring(0, 1).ToUpper() + action.Substring(1);
            var lowerAction = action.Substring(0, 1).ToLower() + action.Substring(1);

            var methodName = $"Get{camelAction}ActionResultAsync";

            var baseMethodInvocationSyntax =
                RoslynGenerationHelpers.GetMethodOnClassInvocationSyntax("Ok", new [] {$"{lowerAction}Response"}, false);

            var taskFromResult =
                RoslynGenerationHelpers.GetStaticMethodInvocationSyntax("Task", "FromResult",
                    baseMethodInvocationSyntax, true);
            var returnStatement = SyntaxFactory.ReturnStatement(taskFromResult);

            var body = new StatementSyntax[]
            {
                returnStatement
            };

            var parameters = GetParams(new []{ $"ResponseDtos.{camelAction}{entityName}ResponseDto {lowerAction}Response"});

            var returnType = SyntaxFactory.ParseTypeName("System.Threading.Tasks.Task<IActionResult>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName)
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.ProtectedKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword), SyntaxFactory.Token(SyntaxKind.OverrideKeyword))
                .AddBodyStatements(body);
            return declaration;
        }
    }
}
