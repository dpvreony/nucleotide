using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using Microsoft.CodeAnalysis.CSharp;
using Dhgms.Nucleotide.Generators.Features.Core;

namespace Dhgms.Nucleotide.Generators.Features.Cqrs.Requests
{
    public sealed record RequestModel(
        string ContainingNamespace,
        string TypeName,
        bool IsSealed,
        NamedTypeParameterModel[] Properties,
        Func<BaseTypeSyntax> BaseTypeSyntaxFunc,
        string[] XmlDocSummary,
        NamedTypeModel ResponseModel)
        : NamedTypeModel(
            ContainingNamespace,
            TypeName)
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
                () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"global::MediatR.IRequest<{responseModel.GetFullyQualifiedTypeName()}>")),
                xmlDocSummary,
                responseModel);
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
                () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"global::Whipstaff.MediatR.IQuery<{responseModel.GetFullyQualifiedTypeName()}>")),
                xmlDocSummary,
                responseModel);
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
                () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"global::Whipstaff.MediatR.ICommand<{responseModel.GetFullyQualifiedTypeName()}>")),
                xmlDocSummary,
                responseModel);
        }


        public static RequestModel WhipstaffMediatRAuditableRequest(
            string containingNamespace,
            string name,
            bool isSealed,
            NamedTypeArgumentModel rawRequestDto,
            NamedTypeModel responseModel,
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
                () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"global::Whipstaff.MediatR.IAuditableRequest<{rawRequestDto.GetFullyQualifiedTypeArgument()}, {responseModel.GetFullyQualifiedTypeName()}>")),
                xmlDocSummary,
                responseModel);
        }
    }
}
