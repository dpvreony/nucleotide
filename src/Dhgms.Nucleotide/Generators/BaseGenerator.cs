using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeGeneration.Roslyn;
using Dhgms.Nucleotide.Model;
using Dhgms.Nucleotide.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Validation;

namespace Dhgms.Nucleotide.Generators
{
    public abstract class BaseGenerator : ICodeGenerator
    {
        protected BaseGenerator(AttributeData attributeData)
        {
            Requires.NotNull(attributeData, nameof(attributeData));
            Requires.That(attributeData.ConstructorArguments.Length > 0, nameof(attributeData), "x");

            this.NucleotideGenerationModel = attributeData.ConstructorArguments;
        }

        protected object NucleotideGenerationModel { get; }

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
            var namespaceName = GetNamespace();
            var namespaceDeclaration = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.IdentifierName(namespaceName));

            var castDetails = (System.Collections.Immutable.ImmutableArray<TypedConstant>)this.NucleotideGenerationModel;

            var a = castDetails.First();
            var namedTypeSymbols = a.Value as INamedTypeSymbol;
            var compilation = context.Compilation;
            var generationModel = await this.GetModel(namedTypeSymbols, compilation);

            if (generationModel == null)
            {
                namespaceDeclaration = namespaceDeclaration.WithLeadingTrivia(SyntaxFactory.Comment($"#error Failed to find model: {namedTypeSymbols}"));
            }
            else
            {
                namespaceDeclaration = await this.GenerateObjects(namespaceDeclaration, generationModel.EntityGenerationModel);
            }

            var nodes = new MemberDeclarationSyntax[]
            {
                namespaceDeclaration
            };

            var results = SyntaxFactory.List(nodes);

            return await Task.FromResult(results);
        }

        protected abstract Task<NamespaceDeclarationSyntax> GenerateObjects(NamespaceDeclarationSyntax namespaceDeclaration, EntityGenerationModel[] generationModelEntityGenerationModel);

        protected abstract string GetClassPrefix();

        /// <summary>
        /// Gets the suffix to be applied to a class
        /// </summary>
        /// <returns>Class suffix</returns>
        protected abstract string GetClassSuffix();

        protected abstract string GetNamespace();

        protected static void AddToList<T>(List<MemberDeclarationSyntax> list, IReadOnlyCollection<T> items)
            where T : MemberDeclarationSyntax
        {
            if (items != null && items.Count > 0)
            {
                list.AddRange(items);
            }
        }

        protected static ParameterListSyntax GetParams(string[] argCollection)
        {
            var parameters = SyntaxFactory.SeparatedList<ParameterSyntax>();

            foreach (var s in argCollection)
            {
                var node = SyntaxFactory.Parameter(SyntaxFactory.Identifier(s));
                parameters = parameters.Add(node);
            }

            return SyntaxFactory.ParameterList(parameters);
        }

        protected async Task<INucleotideGenerationModel> GetModel(INamedTypeSymbol namedTypeSymbols, CSharpCompilation compilation)
        {
            var assembly = GetAssembly(namedTypeSymbols.ContainingAssembly, compilation);

            var typeName = $"{namedTypeSymbols.ContainingNamespace}.{namedTypeSymbols.Name}";
            var modelType = assembly.GetType(typeName);
            //var modelType = Type.GetType(typeName);
            if (modelType == null)
            {
                throw new InvalidOperationException($"Unable to find model type: {typeName}");
            }

            var instance = Activator.CreateInstance(modelType);
            if (instance == null)
            {
                throw new InvalidOperationException($"Unable to create instance: {typeName}");
            }

            // namedTypeSymbols.ContainingAssembly
            //namedTypeSymbols.Name
            return await Task.FromResult(instance as INucleotideGenerationModel);
        }

        protected Assembly GetAssembly(IAssemblySymbol symbol, Compilation compilation)
        {
            Requires.NotNull(symbol, "symbol");
            Requires.NotNull(compilation, "compilation");

            var matchingReferences = (from reference in compilation.References.OfType<PortableExecutableReference>()
                where string.Equals(Path.GetFileNameWithoutExtension(reference.FilePath), symbol.Identity.Name, StringComparison.OrdinalIgnoreCase)
                select reference).ToArray();

            if (matchingReferences == null || matchingReferences.Length == 0)
            {
                throw new InvalidOperationException($"Failed to find {symbol.Identity}");
            }

            var assembly = this.GetType().GetTypeInfo().Assembly;
            var loadContext = AssemblyLoadContext.GetLoadContext(assembly);
            return loadContext.LoadFromAssemblyPath(matchingReferences[0].FilePath);
        }

        protected abstract PropertyDeclarationSyntax GetPropertyDeclaration(PropertyInfoBase propertyInfo);

        protected abstract PropertyDeclarationSyntax GetReadOnlyPropertyDeclaration(PropertyInfoBase propertyInfo);

        protected IEnumerable<SyntaxTrivia> GetSummary(string[] summaryLines)
        {
            var result = new List<SyntaxTrivia>
            {
                SyntaxFactory.Comment($"/// <summary>")
            };

            var lines = summaryLines.Select(line => SyntaxFactory.Comment($"/// {line}"));
            result.AddRange(lines);

            result.Add(SyntaxFactory.Comment($"/// </summary>"));

            return result;
        }

        protected abstract PropertyDeclarationSyntax GetPropertyDeclaration(
            PropertyInfoBase propertyInfo,
            AccessorDeclarationSyntax[] accessorList,
            IEnumerable<SyntaxTrivia> summary);
    }
}
