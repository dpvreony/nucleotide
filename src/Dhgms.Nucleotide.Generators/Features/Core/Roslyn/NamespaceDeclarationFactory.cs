using System;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;

namespace Dhgms.Nucleotide.Generators.Features.Core.Roslyn
{
    public static class NamespaceDeclarationFactory
    {
        public static NamespaceDeclarationSyntax GetNamespaceDeclaration<TModel, TResponse>(
            IGrouping<string, TModel> groupedResponseModel,
            Func<TModel, TResponse> getMemberDeclarationFunc)
            where TResponse : MemberDeclarationSyntax
        {
            var namespaceDeclaration = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(groupedResponseModel.Key));

            foreach (var responseModel in groupedResponseModel)
            {
                var recordDeclaration = getMemberDeclarationFunc(responseModel);
                namespaceDeclaration = namespaceDeclaration.AddMembers(recordDeclaration);
            }

            return namespaceDeclaration;
        }

    }
}
