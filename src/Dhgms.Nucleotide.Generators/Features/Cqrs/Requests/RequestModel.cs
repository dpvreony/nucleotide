using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using Microsoft.CodeAnalysis.CSharp;
using Dhgms.Nucleotide.Generators.Features.Core;
using Dhgms.Nucleotide.Generators.Features.Cqrs.Responses;

namespace Dhgms.Nucleotide.Generators.Features.Cqrs.Requests
{
    public sealed record RequestModel(
        string ContainingNamespace,
        string TypeName,
        bool IsSealed,
        NamedTypeParameterModel[] Properties,
        Func<BaseTypeSyntax> BaseTypeSyntaxFunc,
        string[] XmlDocSummary,
        NamedTypeArgumentModel ResponseModel)
        : NamedTypeModel(
            ContainingNamespace,
            TypeName)
    {
        public static RequestModel MediatorRequest(
            string containingNamespace,
            string name,
            bool isSealed,
            NamedTypeParameterModel[] properties,
            NamedTypeArgumentModel responseModel,
            string[] xmlDocSummary)
        {
            return new RequestModel(
                containingNamespace,
                name,
                isSealed,
                properties,
                () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"global::Mediator.IRequest<{responseModel.GetFullyQualifiedTypeArgument()}>")),
                xmlDocSummary,
                responseModel);
        }

        public static RequestModel WhipstaffMediatorQuery(
            string containingNamespace,
            string name,
            bool isSealed,
            NamedTypeParameterModel[] properties,
            NamedTypeArgumentModel responseModel,
            string[] xmlDocSummary)
        {
            return new RequestModel(
                containingNamespace,
                name,
                isSealed,
                properties,
                () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"global::Whipstaff.Mediator.IQuery<{responseModel.GetFullyQualifiedTypeArgument()}>")),
                xmlDocSummary,
                responseModel);
        }

        public static RequestModel WhipstaffMediatorCommand(
            string containingNamespace,
            string name,
            bool isSealed,
            NamedTypeParameterModel[] properties,
            NamedTypeArgumentModel responseModel,
            string[] xmlDocSummary)
        {
            return new RequestModel(
                containingNamespace,
                name,
                isSealed,
                properties,
                () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"global::Whipstaff.Mediator.ICommand<{responseModel.GetFullyQualifiedTypeArgument()}>")),
                xmlDocSummary,
                responseModel);
        }

        public static RequestModel WhipstaffMediatorAuditableQuery(
            string containingNamespace,
            string name,
            bool isSealed,
            NamedTypeArgumentModel rawRequestDto,
            NamedTypeArgumentModel responseModel,
            string[] xmlDocSummary)
        {
            var properties = new[]
            {
                new NamedTypeParameterModel(
                    rawRequestDto.ContainingNamespace,
                    rawRequestDto.TypeName,
                    rawRequestDto.Nullable,
                    "RequestDto"),

                new NamedTypeParameterModel(
                    "System.Security.Claims",
                    "ClaimsPrincipal",
                    false,
                    "ClaimsPrincipal")
            };

            return new RequestModel(
                containingNamespace,
                name,
                isSealed,
                properties,
                () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"global::Whipstaff.Mediator.IAuditableQuery<{rawRequestDto.GetFullyQualifiedTypeArgument()}, {responseModel.GetFullyQualifiedTypeArgument()}>")),
                xmlDocSummary,
                responseModel);
        }
    }
}
