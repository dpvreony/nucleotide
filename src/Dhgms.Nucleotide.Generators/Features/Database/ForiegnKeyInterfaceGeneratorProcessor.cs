using System;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.Database
{
    public sealed class ForiegnKeyInterfaceGeneratorProcessor : BaseInterfaceLevelCodeGeneratorProcessor<ReferencedByEntityGenerationModel>
    {
        /// <inheritdoc />
        protected override string[] GetClassPrefixes()
        {
            return null;
        }

        /// <inheritdoc />
        protected override string GetClassSuffix()
        {
            return "ForeignKey";
        }

        /// <inheritdoc />
        protected override string[] GetInterfaceSummary(ReferencedByEntityGenerationModel entityDeclaration)
        {
            return new[]
            {
                $"Represents a foreign key relationship to the {entityDeclaration.ClassName} entity."
            };
        }

        /// <inheritdoc />
        protected override PropertyDeclarationSyntax[] GetPropertyDeclarations(ReferencedByEntityGenerationModel entityGenerationModel, string prefix)
        {
            var accessorList = new[]
            {
                SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
            };

            var pocoSummary = GetSummary(new[] { $"Gets or Sets the Foreign Entity for {entityGenerationModel.ClassName}" });

            var pocoType = SyntaxFactory.ParseTypeName(entityGenerationModel.EntityType);
            var pocoIdentifier = entityGenerationModel.PropertyName;

            var pocoObject = SyntaxFactory.PropertyDeclaration(pocoType, pocoIdentifier)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .WithAccessorList(
                    SyntaxFactory.AccessorList(
                        SyntaxFactory.List(accessorList)
                    ))
                .WithLeadingTrivia(pocoSummary);

            var foreignKeySummary = GetSummary(new[] { $"Gets or Sets the Foreign Key for {entityGenerationModel.ClassName}" });
            var foreignKeyType = SyntaxFactory.ParseTypeName(entityGenerationModel.KeyType);
            var foreignKeyIdentifier = $"{entityGenerationModel.PropertyName}Id";
            var foreignKey = SyntaxFactory.PropertyDeclaration(foreignKeyType, foreignKeyIdentifier)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .WithAccessorList(
                    SyntaxFactory.AccessorList(
                        SyntaxFactory.List(accessorList)
                    ))
                .WithLeadingTrivia(foreignKeySummary);

            return new []
            {
                foreignKey,
                pocoObject,
            };
        }

        /// <inheritdoc />
        protected override MethodDeclarationSyntax[] GetMethodDeclarations(string className, string prefix)
        {
            return null;
        }

        /// <inheritdoc />
        protected override string[] GetBaseInterfaces(ReferencedByEntityGenerationModel entityGenerationModel, string prefix)
        {
            return null;
        }
    }
}
