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
        string[] XmlDocSummary)
        : NamedTypeModel(
            ContainingNamespace,
            Name)
    {
        public static RequestFactoryModel QueryFactory(
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
            var viewResponseName = viewRequestModel.ResponseModel.GetFullyQualifiedTypeName();
            return new RequestFactoryModel(
                containingNamespace,
                name,
                isSealed,
                    () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"global::Whipstaff.MediatR.IAuditableQueryFactory<{listQueryTypeName}, {listRequestDtoName}, {listResponseTypeName}, {viewQueryName}, {viewResponseName}>")),
                xmlDocSummary);
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
                () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"global::Whipstaff.MediatR.IAuditableCommandFactory<{createInputModelName}, {createRequestModelCommandTypeName}, {createResponseTypeName},{deleteInputModelName}, {deleteRequestModelCommandTypeName}, {deleteResponseTypeName}, {updateRequestModelCommandTypeName}, {updateResponseTypeName}>")),
                xmlDocSummary);
        }
    }
}
