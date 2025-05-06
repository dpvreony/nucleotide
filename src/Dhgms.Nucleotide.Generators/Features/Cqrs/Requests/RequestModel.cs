using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using Microsoft.CodeAnalysis.CSharp;

namespace Dhgms.Nucleotide.Generators.Features.Cqrs.Requests
{
    public sealed record RequestModel(
        string ContainingNamespace,
        string Name,
        bool IsSealed,
        NamedTypeParameterModel[] Properties,
        Func<BaseTypeSyntax> BaseTypeSyntaxFunc,
        string[] xmlDocSummary)
        : NamedTypeModel(
            ContainingNamespace,
            Name,
            false)
    {
        public static RequestModel MediatRRequest(
            string containingNamespace,
            string name,
            bool isSealed,
            NamedTypeParameterModel[] properties,
            NamedTypeModel responseModel,
            string[] xmlDocSummary)
        {
            return new RequestModel(
                containingNamespace,
                name,
                isSealed,
                properties,
                () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"MediatR.IRequest<{responseModel.GetFullyQualifiedTypeName()}>")),
                xmlDocSummary);
        }

        public static RequestModel WhipstaffMediatRQuery(
            string containingNamespace,
            string name,
            bool isSealed,
            NamedTypeParameterModel[] properties,
            NamedTypeModel responseModel,
            string[] xmlDocSummary)
        {
            return new RequestModel(
                containingNamespace,
                name,
                isSealed,
                properties,
                () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"Whipstaff.MediatR.IQuery<{responseModel.GetFullyQualifiedTypeName()}>")),
                xmlDocSummary);
        }

        public static RequestModel WhipstaffMediatRCommand(
            string containingNamespace,
            string name,
            bool isSealed,
            NamedTypeParameterModel[] properties,
            NamedTypeModel responseModel,
            string[] xmlDocSummary)
        {
            return new RequestModel(
                containingNamespace,
                name,
                isSealed,
                properties,
                () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"Whipstaff.MediatR.ICommand<{responseModel.GetFullyQualifiedTypeName()}>")),
                xmlDocSummary);
        }


        public static RequestModel WhipstaffMediatRAuditableRequest(
            string containingNamespace,
            string name,
            bool isSealed,
            NamedTypeModel rawRequestDto,
            NamedTypeModel responseModel,
            string[] xmlDocSummary)
        {
            var properties = new[]
            {
                new NamedTypeParameterModel(
                    rawRequestDto.ContainingNamespace,
                    rawRequestDto.Name,
                    rawRequestDto.Nullable,
                    "rawRequestDto"),

                new NamedTypeParameterModel(
                    "global::System.Security.Claims",
                    "ClaimsPrincipal",
                    false,
                    "claimsPrincipal")
                
            };

            return new RequestModel(
                containingNamespace,
                name,
                isSealed,
                properties,
                () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"Whipstaff.MediatR.IAuditableRequest<{responseModel.GetFullyQualifiedTypeName()}>")),
                xmlDocSummary);
        }
    }
}
