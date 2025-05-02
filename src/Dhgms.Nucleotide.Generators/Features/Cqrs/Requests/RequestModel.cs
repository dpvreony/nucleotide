using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using Microsoft.CodeAnalysis.CSharp;

namespace Dhgms.Nucleotide.Generators.Features.Cqrs.Requests
{
    public sealed record RequestModel(
        string ContainingNamespace,
        string Name,
        string[] Properties,
        Func<BaseTypeSyntax> BaseTypeSyntaxFunc)
        : NamedTypeModel(
            ContainingNamespace,
            Name)
    {
        public static RequestModel WhipstaffQuery(
            string ContainingNamespace,
            string Name,
            string[] Properties,
            NamedTypeParameterModel responseModel)
        {
            return new RequestModel(
                ContainingNamespace,
                Name,
                Properties,
                () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"Whipstaff.MediatR.IQuery<{responseModel.GetFullyQualifiedName()}>")));
        }

        public static RequestModel WhipstaffCommand(
            string containingNamespace,
            string name,
            string[] properties,
            NamedTypeParameterModel responseModel)
        {
            return new RequestModel(
                containingNamespace,
                name,
                properties,
                () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"Whipstaff.MediatR.ICommand<{responseModel.GetFullyQualifiedName()}>")));
        }


        public static RequestModel WhipstaffAuditableRequest(
            string containingNamespace,
            string name,
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
                properties,
                () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"Whipstaff.MediatR.IAuditableRequest<{responseModel.GetFullyQualifiedName()}>")));
        }
    }
}
