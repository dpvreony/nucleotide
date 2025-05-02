using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using Microsoft.CodeAnalysis.CSharp;

namespace Dhgms.Nucleotide.Generators.Features.Cqrs.Requests
{
    public sealed record RequestModel(
        string ContainingNamespace,
        string Name,
        string[] Properties,
        Func<BaseTypeSyntax> BaseTypeSyntaxFunc) : NamedTypeModel(ContainingNamespace, Name)
    {
        public static RequestModel WhipstaffQuery(
            string ContainingNamespace,
            string Name,
            string[] Properties,
            NamedTypeModel responseModel)
        {
            return new RequestModel(
                ContainingNamespace,
                Name,
                Properties,
                () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"global::{responseModel.ContainingNamespace}.{responseModel.Name}")));
        }

        public static RequestModel WhipstaffCommand(
            string containingNamespace,
            string name,
            string[] properties,
            NamedTypeModel responseModel)
        {
            return new RequestModel(
                containingNamespace,
                name,
                properties,
                () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"Whipstaff.MediatR.ICommand<global::{responseModel.ContainingNamespace}.{responseModel.Name}>")));
        }


        public static RequestModel WhipstaffAuditableRequest(
            string containingNamespace,
            string name,
            NamedTypeModel responseModel)
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
                () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"Whipstaff.MediatR.IAuditableRequest<global::{responseModel.ContainingNamespace}.{responseModel.Name}>")));
        }
    }
}
