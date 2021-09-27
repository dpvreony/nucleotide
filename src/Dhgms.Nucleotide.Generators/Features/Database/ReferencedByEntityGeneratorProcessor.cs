using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.Database
{
    public sealed class ReferencedByEntityGeneratorProcessor : BaseInterfaceLevelCodeGeneratorProcessor<ReferencedByEntityGenerationModel>
    {
        /// <inheritdoc />
        protected override string[] GetClassPrefixes()
        {
            return null;
        }

        /// <inheritdoc />
        protected override string GetClassSuffix()
        {
            return "ReferencedByEntity";
        }

        /// <inheritdoc />
        protected override string[] GetInterfaceSummary(ReferencedByEntityGenerationModel entityDeclaration)
        {
            return new[]
            {
                "Represents a entity that is referencing this entity as the principal entity (one) in a one to many relationship.",
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

            var summary = GetSummary(new[] { $"Gets or Sets the Foreign Entity for {entityGenerationModel.ClassName}" });

            var type = SyntaxFactory.ParseName(entityGenerationModel.EntityType);
            var identifier = entityGenerationModel.PropertyName;

            var result = SyntaxFactory.PropertyDeclaration(type, identifier)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .WithAccessorList(
                    SyntaxFactory.AccessorList(
                        SyntaxFactory.List(accessorList)
                    ))
                .WithLeadingTrivia(summary);

            return new []
            {
                result,
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
