using System;
using System.Collections.Generic;
using System.Linq;
using Dhgms.Nucleotide.Generators.Features.Core;
using Dhgms.Nucleotide.Generators.Features.Core.Roslyn;
using Dhgms.Nucleotide.Generators.Features.Core.XmlDoc;
using Dhgms.Nucleotide.Generators.Features.Cqrs.RequestFactories;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.AspNetCore.MvcControllers
{
    public sealed class MvcControllersMemberDeclarationSyntaxFactory : IMemberDeclarationSyntaxFactory<MvcControllerModel>
    {
        public SyntaxList<MemberDeclarationSyntax> GetMemberDeclarationSyntaxCollection(IReadOnlyCollection<MvcControllerModel> featureModels)
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

        private ClassDeclarationSyntax GetClassDeclaration(MvcControllerModel mvcControllerModel)
        {
            var classDeclaration = SyntaxFactory.ClassDeclaration(mvcControllerModel.Name)
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword)));

            if (mvcControllerModel.IsSealed)
            {
                classDeclaration = classDeclaration.AddModifiers(SyntaxFactory.Token(SyntaxKind.SealedKeyword));
            }

            if (mvcControllerModel.IsPartial)
            {
                classDeclaration = classDeclaration.AddModifiers(SyntaxFactory.Token(SyntaxKind.PartialKeyword));
            }

            if (mvcControllerModel.ConstructorModel != null
                &&
                (mvcControllerModel.ConstructorModel.ArgsForBaseConstructorPassThrough is { Count: >= 1 }
                 || mvcControllerModel.ConstructorModel.ArgsForFieldAssignments is { Count: >= 1 }))
            {
                var constructorDeclaration = ConstructorMemberDeclarationSyntaxFactory.GetConstructorDeclaration(
                    mvcControllerModel.Name,
                    mvcControllerModel.ConstructorModel);
                classDeclaration = classDeclaration.AddMembers(constructorDeclaration);
            }

            var baseType = mvcControllerModel.BaseTypeSyntaxFunc.Invoke();
            classDeclaration = classDeclaration.AddBaseListTypes(baseType);
            var xmlDoc = SyntaxTriviaFactory.GetSummary(mvcControllerModel.XmlDocSummary);
            classDeclaration = classDeclaration.WithLeadingTrivia(xmlDoc);
            return classDeclaration;
        }
    }
}
