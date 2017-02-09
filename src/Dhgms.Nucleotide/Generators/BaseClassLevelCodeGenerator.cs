using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeGeneration.Roslyn;
using Dhgms.Nucleotide.Model;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Validation;

namespace Dhgms.Nucleotide.Generators
{
    /// <summary>
    /// Base class for a code generator that generates code based on the Class Level of Generation Metadata.
    /// </summary>
    public abstract class BaseClassLevelCodeGenerator : ICodeGenerator
    {
        private readonly object nucleotideGenerationModel;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attributeData"></param>
        protected BaseClassLevelCodeGenerator(AttributeData attributeData)
        {
            Requires.NotNull(attributeData, nameof(attributeData));
            Requires.That(attributeData.ConstructorArguments.Length > 0, nameof(attributeData), "x");

            this.nucleotideGenerationModel = attributeData.ConstructorArguments;
            //this.nucleotideGenerationModel = (Type) [0].Value;
        }

        /// <summary>
        /// Create the syntax tree representing the expansion of some member to which this attribute is applied.
        /// </summary>
        /// <param name="applyTo">The syntax node this attribute is found on.</param>
        /// <param name="document">The document with the semantic model in which this attribute was found.</param>
        /// <param name="progress">A way to report diagnostic messages.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The generated member syntax to be added to the project.</returns>
        public async Task<SyntaxList<MemberDeclarationSyntax>> GenerateAsync(MemberDeclarationSyntax applyTo, Document document, IProgress<Diagnostic> progress,
            CancellationToken cancellationToken)
        {
            var namespaceDeclaration = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.IdentifierName("WebApi"));

            var castDetails = (System.Collections.Immutable.ImmutableArray<TypedConstant>)this.nucleotideGenerationModel;

            var a = castDetails.First();

            var t = a.Value.GetType();
            //var typeToCreate = Type.GetType(typ);
            //if (typeToCreate == null)
            //{
                namespaceDeclaration = namespaceDeclaration.WithLeadingTrivia(SyntaxFactory.Comment($"#error Failed to find type: {t}"));
            //}
            //var instance = Activator.CreateInstance(typeToCreate);


            /*
            var generationModelType = this.nucleotideGenerationModel as Type;
            if (generationModelType != typeof(INucleotideGenerationModel))
            {
                namespaceDeclaration = namespaceDeclaration.WithLeadingTrivia(SyntaxFactory.Comment($"#error DROP OUT 1: {generationModelType}"));
            }
            else
            {
                var generationModel = (INucleotideGenerationModel)Activator.CreateInstance(generationModelType);
                namespaceDeclaration = await this.GenerateClasses(namespaceDeclaration, generationModel.ClassGenerationParameters);
            }
            */

            var nodes = new MemberDeclarationSyntax[]
            {
                namespaceDeclaration
            };
            

            var results = SyntaxFactory.List(nodes);

            return await Task.FromResult(results);
        }

        private async Task<NamespaceDeclarationSyntax> GenerateClasses(NamespaceDeclarationSyntax namespaceDeclaration, ClassGenerationParameters[] generationModelClassGenerationParameters)
        {
            if (generationModelClassGenerationParameters == null || generationModelClassGenerationParameters.Length < 1)
            {
                namespaceDeclaration = namespaceDeclaration.WithLeadingTrivia(SyntaxFactory.Comment("#error DROP OUT 2"));
                return namespaceDeclaration;
            }

            var classDeclarations = new List<MemberDeclarationSyntax>();

            foreach (var generationModelClassGenerationParameter in generationModelClassGenerationParameters)
            {
                classDeclarations.Add(await GetClassDeclarationSyntax(generationModelClassGenerationParameter));
            }

            return await Task.FromResult(namespaceDeclaration.AddMembers(classDeclarations.ToArray()));
        }

        private async Task<MemberDeclarationSyntax> GetClassDeclarationSyntax(IClassGenerationParameters classDeclaration)
        {
            var className = classDeclaration.ClassName;
            var declaration = SyntaxFactory.InterfaceDeclaration($"{className}SomeSuffix");
            return await Task.FromResult(declaration);
        }
    }
}
