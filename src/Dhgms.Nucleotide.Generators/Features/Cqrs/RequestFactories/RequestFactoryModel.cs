using System;
using Dhgms.Nucleotide.Generators.Features.Core;
using Dhgms.Nucleotide.Generators.Features.Cqrs.Requests;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.Cqrs.RequestFactories
{
    public sealed record RequestFactoryModel(
        string ContainingNamespace,
        string Name,
        bool IsSealed,
        Func<BaseTypeSyntax> BaseTypeSyntaxFunc,
        string[] XmlDocSummary,
        MethodDeclarationSyntax[] Methods)
        : NamedTypeModel(
            ContainingNamespace,
            Name)
    {
        public static RequestFactoryModel AuditableQueryFactoryWithStraightPassThrough(
            string containingNamespace,
            string name,
            bool isSealed,
            RequestModel listRequestModel,
            NamedTypeModel listRequestDto,
            RequestModel viewRequestModel,
            string[] xmlDocSummary)
        {
            var listQueryTypeName = listRequestModel.GetFullyQualifiedTypeName();
            var listRequestDtoName = listRequestDto.GetFullyQualifiedTypeName();
            var listResponseTypeName = listRequestModel.ResponseModel.GetFullyQualifiedTypeName();
            var viewQueryName = viewRequestModel.GetFullyQualifiedTypeName();
            var viewResponseName = viewRequestModel.ResponseModel.GetFullyQualifiedTypeArgument();

            var listRequestModelMethodDeclarationSyntax = GetListRequestMethodDeclarationSyntax(listQueryTypeName, listRequestDtoName);

            var viewRequestModelMethodDeclarationSyntax = GetViewRequestMethodDeclarationSyntax(viewQueryName);

            var methods = new[]
            {
                listRequestModelMethodDeclarationSyntax,
                viewRequestModelMethodDeclarationSyntax
            };

            return new RequestFactoryModel(
                containingNamespace,
                name,
                isSealed,
                    () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"global::Whipstaff.Mediator.IAuditableQueryFactory<{listQueryTypeName}, {listRequestDtoName}, {listResponseTypeName}, {viewQueryName}, {viewResponseName}>")),
                xmlDocSummary,
                methods);
        }

        private static MethodDeclarationSyntax GetViewRequestMethodDeclarationSyntax(string viewQueryName)
        {
            var viewMethodBody = new StatementSyntax[]
            {
                SyntaxFactory.ReturnStatement(SyntaxFactory.ParseExpression($"global::System.Threading.Tasks.Task.FromResult(new {viewQueryName}(id, claimsPrincipal))"))
            };

            ParameterSyntax[] parameters =
            [
                SyntaxFactory.Parameter(SyntaxFactory.Identifier("id"))
                    .WithType(SyntaxFactory.ParseTypeName("long")),

                SyntaxFactory.Parameter(SyntaxFactory.Identifier("claimsPrincipal"))
                    .WithType(SyntaxFactory.ParseTypeName($"global::System.Security.Claims.ClaimsPrincipal")),

                SyntaxFactory.Parameter(SyntaxFactory.Identifier("cancellationToken"))
                    .WithType(SyntaxFactory.ParseTypeName($"global::System.Threading.CancellationToken"))
            ];

            var viewRequestModelMethodDeclarationSyntax = SyntaxFactory.MethodDeclaration(
                    SyntaxFactory.ParseTypeName($"global::System.Threading.Tasks.Task<{viewQueryName}>"),
                    "GetViewQueryAsync")
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddParameterListParameters(parameters)
                .AddBodyStatements(viewMethodBody);
            return viewRequestModelMethodDeclarationSyntax;
        }

        private static MethodDeclarationSyntax GetListRequestMethodDeclarationSyntax(
            string listQueryTypeName,
            string listRequestDtoName)
        {
            var listMethodBody = new StatementSyntax[]
            {
                SyntaxFactory.ReturnStatement(SyntaxFactory.ParseExpression($"global::System.Threading.Tasks.Task.FromResult(new {listQueryTypeName}(requestDto, claimsPrincipal))"))
            };

            var parameters = new ParameterSyntax[]
            {
                SyntaxFactory.Parameter(SyntaxFactory.Identifier("requestDto"))
                    .WithType(SyntaxFactory.ParseTypeName(listRequestDtoName)),

                SyntaxFactory.Parameter(SyntaxFactory.Identifier("claimsPrincipal"))
                    .WithType(SyntaxFactory.ParseTypeName($"global::System.Security.Claims.ClaimsPrincipal")),

                SyntaxFactory.Parameter(SyntaxFactory.Identifier("cancellationToken"))
                    .WithType(SyntaxFactory.ParseTypeName($"global::System.Threading.CancellationToken"))
            };

            var listRequestModelMethodDeclarationSyntax = SyntaxFactory.MethodDeclaration(
                    SyntaxFactory.ParseTypeName($"global::System.Threading.Tasks.Task<{listQueryTypeName}>"),
                    "GetListQueryAsync")
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddParameterListParameters(parameters)
                .AddBodyStatements(listMethodBody);
            return listRequestModelMethodDeclarationSyntax;
        }

        public static RequestFactoryModel CommandFactory(
            string containingNamespace,
            string name,
            bool isSealed,
            RequestModel createInputModel,
            RequestModel createRequestModel,
            RequestModel deleteInputModel,
            RequestModel deleteRequestModel,
            RequestModel updateRequestModel,
            string[] xmlDocSummary)
        {
            var createInputModelName = createInputModel.GetFullyQualifiedTypeName();
            var createRequestModelCommandTypeName = createRequestModel.GetFullyQualifiedTypeName();
            var createResponseTypeName = createRequestModel.ResponseModel.GetFullyQualifiedTypeName();

            var deleteInputModelName = deleteInputModel.GetFullyQualifiedTypeName();
            var deleteRequestModelCommandTypeName = deleteRequestModel.GetFullyQualifiedTypeName();
            var deleteResponseTypeName = deleteRequestModel.ResponseModel.GetFullyQualifiedTypeName();

            var updateRequestModelCommandTypeName = updateRequestModel.GetFullyQualifiedTypeName();
            var updateResponseTypeName = updateRequestModel.ResponseModel.GetFullyQualifiedTypeName();
            
            return new RequestFactoryModel(
                containingNamespace,
                name,
                isSealed,
                () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"global::Whipstaff.Mediator.IAuditableCommandFactory<{createInputModelName}, {createRequestModelCommandTypeName}, {createResponseTypeName},{deleteInputModelName}, {deleteRequestModelCommandTypeName}, {deleteResponseTypeName}, {updateRequestModelCommandTypeName}, {updateResponseTypeName}>")),
                xmlDocSummary,
                []);
        }
    }
}
