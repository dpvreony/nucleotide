using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeGeneration.Roslyn;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Validation;

namespace Dhgms.Nucleotide.Generators
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
        /// <param name="applyTo">The syntax node this attribute is found on.</param>
        /// <param name="compilation">The overall compilation being generated for.</param>
        /// <param name="progress">A way to report diagnostic messages.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The generated member syntax to be added to the project.</returns>
        public async Task<SyntaxList<MemberDeclarationSyntax>> GenerateAsync(
            MemberDeclarationSyntax applyTo,
            CSharpCompilation compilation,
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
                SyntaxFactory.Comment($"/// <summary>Represents the Entity Framework Table for the {name} model.</summary>"),
            };

            var baseTypes = new BaseTypeSyntax[]
            {
                SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"Models.{name}Model"))
            };


            var tableAttributeArguments = new AttributeArgumentSyntax[]
            {
                SyntaxFactory.AttributeArgument(SyntaxFactory.ParseName($"\"{name}\"")),
            };

            var attributes = new []
            {
                SyntaxFactory.Attribute(SyntaxFactory.ParseName("System.ComponentModel.DataAnnotations.Schema.Table")).AddArgumentListArguments(tableAttributeArguments),
            };

            var sep = SyntaxFactory.SeparatedList(attributes);

            var attributeListSyntax = SyntaxFactory.AttributeList(sep);

            return new MemberDeclarationSyntax[]
            {
                SyntaxFactory.ClassDeclaration($"{name}ModelEf")
                .AddAttributeLists(attributeListSyntax)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
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
