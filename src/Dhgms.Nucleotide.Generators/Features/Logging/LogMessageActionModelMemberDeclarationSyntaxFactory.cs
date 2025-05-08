using Dhgms.Nucleotide.Generators.Features.Core.Roslyn;
using Dhgms.Nucleotide.Generators.Features.Core.XmlDoc;
using Dhgms.Nucleotide.Generators.Features.Core;
using Dhgms.Nucleotide.SampleGenerator.DataTransferObjects;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dhgms.Nucleotide.Generators.Features.Logging
{
    public sealed class LogMessageActionModelMemberDeclarationSyntaxFactory : IMemberDeclarationSyntaxFactory<LogMessageActionModel>
    {
        public SyntaxList<MemberDeclarationSyntax> GetMemberDeclarationSyntaxCollection(IList<LogMessageActionModel> featureModels)
        {
            var requestModels = featureModels.GroupBy(rm => rm.ContainingNamespace);

            var namespaceDeclarations = new List<MemberDeclarationSyntax>();
            foreach (var groupedRequestModel in requestModels)
            {
                namespaceDeclarations.Add(NamespaceDeclarationFactory.GetNamespaceDeclaration(
                    groupedRequestModel,
                    model => GetClassDeclaration(model)));
            }

            return new SyntaxList<MemberDeclarationSyntax>(namespaceDeclarations);
        }

        private ClassDeclarationSyntax GetClassDeclaration(LogMessageActionModel requestModel)
        {
            var classDeclaration = SyntaxFactory.ClassDeclaration(requestModel.TypeName)
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword)));

            if (requestModel.Sealed)
            {
                classDeclaration = classDeclaration.AddModifiers(SyntaxFactory.Token(SyntaxKind.SealedKeyword));
            }

            var leadingTrivia = SyntaxTriviaFactory.GetSummary(["Represents log message actions."]);

            if (requestModel.BaseTypeSyntaxFunc != null)
            {
                classDeclaration = classDeclaration.WithBaseList(SyntaxFactory.BaseList(SyntaxFactory.SingletonSeparatedList(requestModel.BaseTypeSyntaxFunc())));
            }

            if (requestModel.PropertyDeclarations.Length > 0)
            {
                classDeclaration = classDeclaration.AddMembers(requestModel.PropertyDeclarations.Cast<MemberDeclarationSyntax>()
                    .ToArray());

            }

            return classDeclaration;
        }
    }
}
