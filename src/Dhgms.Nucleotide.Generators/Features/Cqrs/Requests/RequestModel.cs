using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using Microsoft.CodeAnalysis.CSharp;

namespace Dhgms.Nucleotide.Generators.Features.Cqrs.Requests
{
    public sealed record RequestModel(
        string ContainingNamespace,
        string Name,
        bool IsSealed,
        string[] Properties,
        Func<BaseTypeSyntax> BaseTypeSyntaxFunc)
        : NamedTypeModel(
            ContainingNamespace,
            Name)
    {
        public static RequestModel MediatRRequest(
            string containingNamespace,
            string name,
            bool isSealed,
            string[] properties,
            NamedTypeParameterModel responseModel)
        {
            return new RequestModel(
                containingNamespace,
                name,
                isSealed,
                properties,
                () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"MediatR.IRequest<{responseModel.GetFullyQualifiedName()}>")));
        }

        public static RequestModel WhipstaffMediatRQuery(
            string containingNamespace,
            string name,
            bool isSealed,
            string[] properties,
            NamedTypeParameterModel responseModel)
        {
            return new RequestModel(
                containingNamespace,
                name,
                isSealed,
                properties,
                () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"Whipstaff.MediatR.IQuery<{responseModel.GetFullyQualifiedName()}>")));
        }

        public static RequestModel WhipstaffMediatRCommand(
            string containingNamespace,
            string name,
            bool isSealed,
            string[] properties,
            NamedTypeParameterModel responseModel)
        {
            return new RequestModel(
                containingNamespace,
                name,
                isSealed,
                properties,
                () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"Whipstaff.MediatR.ICommand<{responseModel.GetFullyQualifiedName()}>")));
        }


        public static RequestModel WhipstaffMediatRAuditableRequest(
            string containingNamespace,
            string name,
            bool isSealed,
            NamedTypeParameterModel responseModel)
        {
            var properties = new[]
            {
                "RequestDto",
                "ClaimsPrincipal"
            };

            return new RequestModel(
                containingNamespace,
                name,
                isSealed,
                properties,
                () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"Whipstaff.MediatR.IAuditableRequest<{responseModel.GetFullyQualifiedName()}>")));
        }
    }
}
