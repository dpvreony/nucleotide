using Dhgms.Nucleotide.Generators.Features.AspNetCore.MvcControllers;
using Dhgms.Nucleotide.Generators.Features.Core.Roslyn;
using Dhgms.Nucleotide.Generators.Features.Core.XmlDoc;
using Dhgms.Nucleotide.Generators.Features.Core;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dhgms.Nucleotide.Generators.Features.AspNetCore.WebApiControllers
{
    public sealed class WebApiControllersMemberDeclarationSyntaxFactory : IMemberDeclarationSyntaxFactory<WebApiControllerModel>
    {
        public SyntaxList<MemberDeclarationSyntax> GetMemberDeclarationSyntaxCollection(IList<WebApiControllerModel> featureModels)
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

        private ClassDeclarationSyntax GetClassDeclaration(WebApiControllerModel mvcControllerModel)
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

            if (mvcControllerModel.MethodDeclarations is { Length: > 0 })
            {
                classDeclaration = classDeclaration.AddMembers(mvcControllerModel.MethodDeclarations.Cast<MemberDeclarationSyntax>().ToArray());
            }

            var baseType = mvcControllerModel.BaseTypeSyntaxFunc.Invoke();
            classDeclaration = classDeclaration.AddBaseListTypes(baseType);
            var xmlDoc = SyntaxTriviaFactory.GetSummary(mvcControllerModel.XmlDocSummary);
            classDeclaration = classDeclaration.WithLeadingTrivia(xmlDoc);
            return classDeclaration;
        }
    }
}
