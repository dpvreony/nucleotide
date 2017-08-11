using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CodeGeneration.Roslyn;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Validation;

namespace Dhgms.Nucleotide.Features.EntityFramework
{
    /// <summary>
    /// Code Generator for Entity Framework DB Sets
    /// </summary>
    public sealed class EntityFrameworkDbSetGenerator : ICodeGenerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityFrameworkDbSetGenerator"/> class.
        /// </summary>
        public EntityFrameworkDbSetGenerator(AttributeData attributeData)
        {
            Requires.NotNull(attributeData, nameof(attributeData));
        }

        /// <summary>
        /// Create the syntax tree representing the expansion of some member to which this attribute is applied.
        /// </summary>
        /// <param name="context">The transformation context being generated for.</param>
        /// <param name="progress">A way to report diagnostic messages.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The generated member syntax to be added to the project.</returns>
        public async Task<SyntaxList<MemberDeclarationSyntax>> GenerateAsync(
            TransformationContext context,
            IProgress<Diagnostic> progress,
            CancellationToken cancellationToken)
        {
            var nodes = new MemberDeclarationSyntax[]
            {
                SyntaxFactory.NamespaceDeclaration(SyntaxFactory.IdentifierName("EntityFramework"))
                    .AddMembers(GetMembers())
            };

            var results = SyntaxFactory.List(nodes);

            return await Task.FromResult(results);
        }

        private MemberDeclarationSyntax[] GetMembers()
        {
            var members = GetModelClasses()
                .Concat(GetDbContextClass())
                .ToArray();

            return members;
        }

        private MemberDeclarationSyntax[] GetModelClasses()
        {
            var name = "Test";

            var leadingTrivia = new[]
            {
                SyntaxFactory.Comment($"/// <summary>Represents the Entity Framework DbSet.</summary>"),
            };

            var baseTypes = new BaseTypeSyntax[]
            {
                SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName("Microsoft.EntityFrameworkCore.DbContext"))
            };

            return new MemberDeclarationSyntax[]
            {
                SyntaxFactory.ClassDeclaration($"{name}DbSet")
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.SealedKeyword))
                .AddBaseListTypes(baseTypes)
                .WithLeadingTrivia(leadingTrivia)
            };
        }

        private MemberDeclarationSyntax[] GetDbContextClass()
        {
            return new MemberDeclarationSyntax[]
            {
            };
        }
    }
}
