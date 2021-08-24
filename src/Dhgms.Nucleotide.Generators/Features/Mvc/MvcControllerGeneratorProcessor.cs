using System;
using System.Collections.Generic;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.Generators.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.Mvc
{
    /// <summary>
    /// Generates the MVC Controllers
    /// </summary>
    public sealed class MvcControllerGeneratorProcessor : BaseClassLevelCodeGeneratorProcessor<IEntityGenerationModel>
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
            $"Whipstaff.AspNetCore.QueryOnlyController<{entityName}Controller, Queries.IList{entityName}Query, RequestDtos.List{entityName}RequestDto, ResponseDtos.List{entityName}ResponseDto, Queries.IView{entityName}Query, ResponseDtos.View{entityName}ResponseDto>";

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
                "queryFactory",
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

        protected override IList<Tuple<string, IList<string>>> GetClassAttributes(IEntityGenerationModel entityDeclaration)
        {
            return new List<Tuple<string, IList<string>>>
            {
                new Tuple<string, IList<string>>("Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryToken", null),
                new Tuple<string, IList<string>>("Microsoft.AspNetCore.Authorization.Authorize", null),
                new Tuple<string, IList<string>>("Microsoft.AspNetCore.Mvc.Route", new[]{ $"\"{entityDeclaration.ClassName}\"" })
            };
        }

        /// <inheritdoc />
        protected override MethodDeclarationSyntax[] GetMethodDeclarations(IEntityGenerationModel entityGenerationModel)
        {
            var entityName = entityGenerationModel.ClassName;
            var result = new List<MethodDeclarationSyntax>
            {
                GetMvcViewActionResultDeclaration(entityName, "list"),
                GetMvcViewActionResultDeclaration(entityName, "view"),
                //GetCommandMethodDeclaration(entityName, "Add"),
                //GetAddMethodDeclaration(entityName),
                //GetDeleteMethodDeclaration(entityName),
                //GetListMethodDeclaration(entityName),
                //GetUpdateMethodDeclaration(entityName),
                //GetViewMethodDeclaration(entityName),
                GetPolicyMethodDeclaration(entityName, "List"),
                GetPolicyMethodDeclaration(entityName, "View"),
                GetQueryMethodDeclaration(entityName, "List", $"RequestDtos.List{entityName}RequestDto"),
                GetQueryMethodDeclaration(entityName, "View", "long"),
                GetEventIdMethodDeclaration(entityName, "List"),
                GetEventIdMethodDeclaration(entityName, "View"),
            };


            return result.ToArray();
        }

        private MethodDeclarationSyntax GetCommandMethodDeclaration(string entityName, string action)
        {
            var methodName = $"Get{action}CommandAsync";
            var requestDtoType = $"RequestDtos.{action}{entityName}RequestDto";

            var camelAction = action.Substring(0, 1).ToUpper() + action.Substring(1);
            var returnStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.ParseExpression($"_commandFactory.Get{camelAction}CommandAsync(query, claimsPrincipal, cancellationToken)"));

            var body = new StatementSyntax[]
            {
                returnStatement
            };

            var returnType = SyntaxFactory.ParseTypeName($"Task<Queries.I{camelAction}{entityName}Query>");

            var parameters = GetParams(new []
            {
                $"{requestDtoType} command",
                "System.Security.Claims.ClaimsPrincipal claimsPrincipal",
                "System.Threading.CancellationToken cancellationToken",
            });
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName)
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.ProtectedKeyword), SyntaxFactory.Token(SyntaxKind.OverrideKeyword))
                .AddBodyStatements(body);
            return declaration;
        }

        private MethodDeclarationSyntax GetQueryMethodDeclaration(string entityName, string action, string requestDtoType)
        {
            var methodName = $"Get{action}QueryAsync";

            var camelAction = action.Substring(0, 1).ToUpper() + action.Substring(1);
            var returnStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.ParseExpression($"QueryFactory.Get{camelAction}QueryAsync(query, claimsPrincipal, cancellationToken)"));

            var body = new StatementSyntax[]
            {
                returnStatement
            };

            var returnType = SyntaxFactory.ParseTypeName($"Task<Queries.I{camelAction}{entityName}Query>");

            var parameters = GetParams(new []
            {
                $"{requestDtoType} query",
                "System.Security.Claims.ClaimsPrincipal claimsPrincipal",
                "System.Threading.CancellationToken cancellationToken",
            });
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName)
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.ProtectedKeyword), SyntaxFactory.Token(SyntaxKind.OverrideKeyword))
                .AddBodyStatements(body);
            return declaration;
        }

        private MethodDeclarationSyntax GetPolicyMethodDeclaration(string entityName, string action)
        {
            var methodName = $"Get{action}PolicyAsync";

            var returnStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.ParseExpression($"await Task.FromResult(\"Mvc.{entityName}.{action}\").ConfigureAwait(false)"));

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

        private MethodDeclarationSyntax GetMvcViewActionResultDeclaration(string entityName, string action)
        {
            var camelAction = action.Substring(0, 1).ToUpper() + action.Substring(1);
            var lowerAction = action.Substring(0, 1).ToLower() + action.Substring(1);

            var methodName = $"Get{camelAction}ActionResultAsync";

            var baseMethodInvocationSyntax =
                RoslynGenerationHelpers.GetMethodOnClassInvocationSyntax("View", new [] {$"{lowerAction}Response"}, false);

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

        protected override SeparatedSyntaxList<AttributeSyntax> GetAttributesForProperty(PropertyInfoBase propertyInfo)
        {
            return default(SeparatedSyntaxList<AttributeSyntax>);
        }
    }
}
