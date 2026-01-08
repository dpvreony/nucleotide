using Dhgms.Nucleotide.Generators.Features.AspNetCore.MvcControllers;
using Dhgms.Nucleotide.Generators.Features.Core.Roslyn;
using Dhgms.Nucleotide.Generators.Features.Core;
using Dhgms.Nucleotide.Generators.Features.Cqrs.RequestFactories;
using Dhgms.Nucleotide.Generators.Features.Cqrs.Requests;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dhgms.Nucleotide.Generators.Features.AspNetCore.WebApiControllers
{
    public sealed record WebApiControllerModel(
        string ContainingNamespace,
        string Name,
        bool IsSealed,
        bool IsPartial,
        Func<BaseTypeSyntax> BaseTypeSyntaxFunc,
        string[] XmlDocSummary,
        ConstructorModel? ConstructorModel,
        MethodDeclarationSyntax[]? MethodDeclarations)
        : NamedTypeModel(
            ContainingNamespace,
            Name)
    {
        public static WebApiControllerModel VanillaController(
            string containingNamespace,
            string name,
            bool isSealed,
            bool isPartial,
            string[] summary)
        {
            var baseTypeSyntaxFunc = () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"global::Microsoft.AspNetCore.Mvc.ControllerBase"));

            return new WebApiControllerModel(
                containingNamespace,
                name,
                isSealed,
                isPartial,
                baseTypeSyntaxFunc,
                summary,
                null,
                null);
        }

#if TBC
        public static MvcControllerModel WhipstaffFullCrudController(
            string containingNamespace,
            string name,
            bool isSealed,
            string entityDescription)
        {
            return new MvcControllerModel(
                containingNamespace,
                name,
                isSealed,
                baseTypeSyntaxFunc,
                [ $"MVC controller for querying {entityDescription}."]);
        }
#endif

        public static WebApiControllerModel WhipstaffQueryOnlyController(
            string containingNamespace,
            string name,
            bool isSealed,
            bool isPartial,
            string entityDescription,
            RequestFactoryModel queryFactoryModel,
            RequestModel listRequestModel,
            NamedTypeModel listRequestDtoModel,
            RequestModel viewRequestModel,
            NamedTypeModel loggerMessageActionsModel)
        {
            var listQueryClassName = listRequestModel.GetFullyQualifiedTypeName();
            var listRequestDtoClassName = listRequestDtoModel.GetFullyQualifiedTypeName();
            var listResponseDtoClassName = listRequestModel.ResponseModel.GetFullyQualifiedTypeName();

            var viewQueryClassName = viewRequestModel.GetFullyQualifiedTypeName();
            var viewResponseDtoClassName = viewRequestModel.ResponseModel.GetFullyQualifiedTypeName();

            var logMessageActionsWrapperClassName = loggerMessageActionsModel.GetFullyQualifiedTypeName();

            var baseTypeSyntaxFunc = () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"global::Whipstaff.AspNetCore.AbstractQueryOnlyApiController<{listQueryClassName}, {listRequestDtoClassName}, {listResponseDtoClassName}, {viewQueryClassName}, {viewResponseDtoClassName}, {logMessageActionsWrapperClassName}>"));

            var controllerFullName = $"global::{containingNamespace}.{name}";

            var constructorBaseArgs = new List<NamedTypeParameterModel>
            {
                new ("Microsoft.AspNetCore.Authorization","IAuthorizationService", false, "authorizationService"),
                new ("Mediator", "IMediator", false, "mediator"),
                new (queryFactoryModel.ContainingNamespace, queryFactoryModel.Name, false, "queryFactory"),
                new (loggerMessageActionsModel.ContainingNamespace, loggerMessageActionsModel.TypeName, false, "logMessageActions"),
                new ("Microsoft.Extensions.Logging", $"ILogger<{controllerFullName}>", false, "logger"),
            };

            var constructorModel = new ConstructorModel(
                null,
                constructorBaseArgs);

            var viewDtoModel = new NamedTypeModel(string.Empty, "long");

            MethodDeclarationSyntax[] methodDeclarations = [
                GetApiViewActionResultDeclaration(listRequestModel.ResponseModel, "list"),
                GetApiViewActionResultDeclaration(viewRequestModel.ResponseModel, "view"),
                GetPolicyMethodDeclaration(name, "List"),
                GetPolicyMethodDeclaration(name, "View"),
                GetQueryMethodDeclaration(name, "List", listQueryClassName, listRequestDtoModel),
                GetQueryMethodDeclaration(name, "View", viewQueryClassName, viewDtoModel),
            ];

            return new WebApiControllerModel(
                containingNamespace,
                name,
                isSealed,
                false,
                baseTypeSyntaxFunc,
                [$"API controller for querying {entityDescription}."],
                constructorModel,
                methodDeclarations);
        }

        private static MethodDeclarationSyntax GetQueryMethodDeclaration(string entityName, string action, string queryType, NamedTypeModel requestDto)
        {
            var methodName = $"Get{action}QueryAsync";

            var camelAction = action.Substring(0, 1).ToUpper() + action.Substring(1);
            var returnStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.ParseExpression($"QueryFactory.Get{camelAction}QueryAsync(request, claimsPrincipal, cancellationToken)"));

            var body = new StatementSyntax[]
            {
                returnStatement
            };

            var returnType = SyntaxFactory.ParseTypeName($"global::System.Threading.Tasks.Task<{queryType}>");

            var requestDtoParameter = ParameterSyntaxFactory.GetParameterSyntax(new NamedTypeParameterModel(requestDto.ContainingNamespace, requestDto.TypeName, false, "request"));
            var claimsPrincipalParameter = ParameterSyntaxFactory.GetParameterSyntax(new NamedTypeParameterModel("System.Security.Claims", "ClaimsPrincipal", false, "claimsPrincipal"));
            var cancellationTokenParameter = ParameterSyntaxFactory.GetParameterSyntax(new NamedTypeParameterModel("System.Threading", "CancellationToken", false, "cancellationToken"));
            var parameters = SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList([
                requestDtoParameter,
                claimsPrincipalParameter,
                cancellationTokenParameter
            ]));

            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName)
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.ProtectedKeyword), SyntaxFactory.Token(SyntaxKind.OverrideKeyword))
                .AddBodyStatements(body);
            return declaration;
        }

        private static MethodDeclarationSyntax GetPolicyMethodDeclaration(string entityName, string action)
        {
            var methodName = $"Get{action}PolicyAsync";

            var returnStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.ParseExpression($"global::System.Threading.Tasks.Task.FromResult(\"WebApi.{entityName}.{action}\")"));

            var body = new StatementSyntax[]
            {
                returnStatement
            };

            var returnType = SyntaxFactory.ParseTypeName("global::System.Threading.Tasks.Task<string>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.ProtectedKeyword), SyntaxFactory.Token(SyntaxKind.OverrideKeyword))
                .AddBodyStatements(body);
            return declaration;
        }

        private static MethodDeclarationSyntax GetApiViewActionResultDeclaration(NamedTypeModel responseClassName, string action)
        {
            var camelAction = action.Substring(0, 1).ToUpper() + action.Substring(1);
            var lowerAction = action.Substring(0, 1).ToLower() + action.Substring(1);

            var methodName = $"Get{camelAction}ActionResultAsync";

            var baseMethodInvocationSyntax =
                RoslynGenerationHelpers.GetMethodOnClassInvocationSyntax("Ok", new[] { $"{lowerAction}Response" }, false);

            var taskFromResult =
                RoslynGenerationHelpers.GetStaticMethodInvocationSyntax("global::System.Threading.Tasks.Task", "FromResult",
                    baseMethodInvocationSyntax, true);
            var returnStatement = SyntaxFactory.ReturnStatement(taskFromResult);

            var body = new StatementSyntax[]
            {
                returnStatement
            };

            var parameter = ParameterSyntaxFactory.GetParameterSyntax(new NamedTypeParameterModel(responseClassName.ContainingNamespace, responseClassName.TypeName, false, $"{lowerAction}Response"));
            var parameters = SyntaxFactory.ParameterList(SyntaxFactory.SingletonSeparatedList(parameter));

            var returnType = SyntaxFactory.ParseTypeName($"System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<{responseClassName.GetFullyQualifiedTypeName()}>>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName)
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.ProtectedKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword), SyntaxFactory.Token(SyntaxKind.OverrideKeyword))
                .AddBodyStatements(body);
            return declaration;
        }
    }
}
