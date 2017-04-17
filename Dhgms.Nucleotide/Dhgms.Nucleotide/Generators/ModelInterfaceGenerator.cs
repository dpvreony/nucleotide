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
    public sealed class ModelInterfaceGenerator : ICodeGenerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelClassGenerator"/> class. 
        /// </summary>
        public ModelInterfaceGenerator(AttributeData attributeData)
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
                SyntaxFactory.NamespaceDeclaration(SyntaxFactory.IdentifierName("Models"))
                    .AddMembers(GetMembers())
            };

            var results = SyntaxFactory.List(nodes);

            return await Task.FromResult(results);
        }

        private MemberDeclarationSyntax[] GetMembers()
        {
            var members = GetUnkeyedInterfaces()
                .Concat(GetKeyedInterfaces())
                    .ToArray();

            return members;
        }

        private MemberDeclarationSyntax[] GetUnkeyedInterfaces()
        {
            var name = "Test";

            var leadingTrivia = new[]
            {
                SyntaxFactory.Comment($"/// <summary>Interface for the Unkeyed {name} model. Typically used for adding a new record.</summary>"),
            };

            return new MemberDeclarationSyntax[]
            {
                SyntaxFactory.InterfaceDeclaration($"IUnkeyed{name}Model")
                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                    .WithLeadingTrivia(leadingTrivia)
            };
        }

        private MemberDeclarationSyntax[] GetKeyedInterfaces()
        {
            var name = "Test";

            var leadingTrivia = new[]
            {
                SyntaxFactory.Comment($"/// <summary>Interface for the {name} model.</summary>"),
            };

            var baseTypes = new BaseTypeSyntax[]
            {
                SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"IUnkeyed{name}Model"))
            };

            var accessor = new[]
            {
                SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                //SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                //.WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
                //.AddModifiers(SyntaxFactory.Token(SyntaxKind.ProtectedKeyword))
            };

            var members = new MemberDeclarationSyntax[]
            {
                SyntaxFactory.PropertyDeclaration(SyntaxFactory.ParseTypeName("long"), "Id").AddAccessorListAccessors(accessor)
            };

            return new MemberDeclarationSyntax[]
            {

                SyntaxFactory.InterfaceDeclaration($"I{name}Model")
                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                    .AddBaseListTypes(baseTypes)
                    .AddMembers(members)
                    .WithLeadingTrivia(leadingTrivia)
            };
        }
    }
}
