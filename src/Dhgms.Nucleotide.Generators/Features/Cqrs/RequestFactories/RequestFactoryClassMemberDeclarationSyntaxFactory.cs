using Dhgms.Nucleotide.Generators.Features.Core;
using Dhgms.Nucleotide.Generators.Features.Core.Roslyn;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dhgms.Nucleotide.Generators.Features.Core.XmlDoc;
using Microsoft.CodeAnalysis.CSharp;

namespace Dhgms.Nucleotide.Generators.Features.Cqrs.RequestFactories
{
    public sealed class RequestFactoryClassMemberDeclarationSyntaxFactory : IMemberDeclarationSyntaxFactory<RequestFactoryModel>
    {
        public SyntaxList<MemberDeclarationSyntax> GetMemberDeclarationSyntaxCollection(IList<RequestFactoryModel> featureModels)
        {
            var groupedModels = featureModels.GroupBy(rm => rm.ContainingNamespace);

            var namespaceDeclarations = new List<MemberDeclarationSyntax>();
            foreach (var group in groupedModels)
            {
                namespaceDeclarations.Add(NamespaceDeclarationFactory.GetNamespaceDeclaration(
                    group,
                    model => GetClassDeclaration(model)));
            }

            return new SyntaxList<MemberDeclarationSyntax>(namespaceDeclarations);
        }

        private ClassDeclarationSyntax GetClassDeclaration(RequestFactoryModel requestFactoryModel)
        {
            var classDeclaration = SyntaxFactory.ClassDeclaration(requestFactoryModel.Name)
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword)));

            if (requestFactoryModel.IsSealed)
            {
                classDeclaration = classDeclaration.AddModifiers(SyntaxFactory.Token(SyntaxKind.SealedKeyword));
            }

            var baseType = requestFactoryModel.BaseTypeSyntaxFunc.Invoke();
            classDeclaration = classDeclaration.AddBaseListTypes(baseType);
            var xmlDoc = SyntaxTriviaFactory.GetSummary(requestFactoryModel.XmlDocSummary);
            classDeclaration = classDeclaration.WithLeadingTrivia(xmlDoc);
            return classDeclaration;
        }
    }
}
