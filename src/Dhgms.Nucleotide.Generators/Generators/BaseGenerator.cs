using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Model;
using Dhgms.Nucleotide.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators
{
    public abstract class BaseGenerator<TFeatureFlags, TGeneratorProcessor> : ISourceGenerator
        where TFeatureFlags : class
        where TGeneratorProcessor : BaseGeneratorProcessor, new()
    {
#if OLDCGR
        protected BaseGenerator(AttributeData attributeData)
        {
            if (attributeData == null)
            {
                throw new ArgumentNullException(nameof(attributeData));
            }

            if (attributeData.ConstructorArguments == null)
            {
                throw new ArgumentException("ConstructorArguments", nameof(attributeData));
            }

            if (attributeData.ConstructorArguments.Length < 1)
            {
                throw new ArgumentException(nameof(attributeData));
            }

            this.NucleotideGenerationModel = attributeData.ConstructorArguments;
        }
#endif

        protected INucleotideGenerationModel NucleotideGenerationModel { get; }

        protected TFeatureFlags FeatureFlags { get; }

        public void Initialize(GeneratorInitializationContext context)
        {
        }

        public void Execute(GeneratorExecutionContext context)
        {
            var compilationUnit = SyntaxFactory.CompilationUnit();
            var parseOptions = context.ParseOptions;

            // TODO: this is running async code inside non-async
            var result = GenerateAsync(context, CancellationToken.None)
                .GetAwaiter()
                .GetResult();

            foreach (var memberDeclarationSyntax in result)
            {
                // TODO: need to review this might be better way than generate, loop, copy.
                compilationUnit = compilationUnit.AddMembers(memberDeclarationSyntax);
            }

            var sourceText = SyntaxFactory.SyntaxTree(
                    compilationUnit,
                    parseOptions,
                    encoding: Encoding.UTF8)
                .GetText();

            // TODO: hint name per generator, or per class?
            context.AddSource(
                "nucleotide.generated.cs",
                sourceText);
        }

        protected abstract string GetNamespace();

        protected async Task<INucleotideGenerationModel> GetModel(INamedTypeSymbol namedTypeSymbols, Compilation compilation)
        {
            var assembly = GetAssembly(namedTypeSymbols.ContainingAssembly, compilation);

            var typeName = $"{namedTypeSymbols.ContainingNamespace}.{namedTypeSymbols.Name}";
            var modelType = assembly.GetType(typeName);
            if (modelType == null)
            {
                throw new InvalidOperationException($"Unable to find model type: {typeName}");
            }

            var instance = Activator.CreateInstance(modelType);
            if (instance == null)
            {
                throw new InvalidOperationException($"Unable to create instance: {typeName}");
            }

            return await Task.FromResult(instance as INucleotideGenerationModel);
        }

        protected Assembly GetAssembly(IAssemblySymbol symbol, Compilation compilation)
        {
            if (symbol == null)
            {
                throw new ArgumentNullException(nameof(symbol));
            }

            if (compilation == null)
            {
                throw new ArgumentNullException(nameof(compilation));
            }

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

        /// <summary>
        /// Create the syntax tree representing the expansion of some member to which this attribute is applied.
        /// </summary>
        /// <param name="context">The transformation context being generated for.</param>
        /// <param name="progress">A way to report diagnostic messages.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The generated member syntax to be added to the project.</returns>
        private async Task<SyntaxList<MemberDeclarationSyntax>> GenerateAsync(
            GeneratorExecutionContext context,
            CancellationToken cancellationToken)
        {
            var namespaceName = GetNamespace();
            return await ReportErrorInNamespace(
                context,
                namespaceName,
                "#error Failed to detect a generation model from attribute indicating the model type.");

            #if OLDCGR
            var castDetails = (System.Collections.Immutable.ImmutableArray<TypedConstant>)this.NucleotideGenerationModel;

            var a = castDetails.First();
            var namedTypeSymbols = a.Value as INamedTypeSymbol;


            if (namedTypeSymbols == null)
            {
                return await ReportErrorInNamespace(context, namespaceName, "#error Failed to detect a generation model from attribute indicating the model type.");
            }

            var compilation = context.Compilation;

            var generationModel = await this.GetModel(namedTypeSymbols, compilation);

            if (generationModel == null)
            {
                return await ReportErrorInNamespace(context, namespaceName, $"#error Failed to find model: {namedTypeSymbols}");
            }
            #endif

            var generationModel = this.NucleotideGenerationModel;

            var rootNamespace = generationModel.RootNamespace;
            var namespaceDeclaration = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.IdentifierName($"{rootNamespace}.{namespaceName}"));

            var generatorProcessor = new TGeneratorProcessor();

            var result = await generatorProcessor.GenerateObjects(namespaceDeclaration, generationModel)
                .ConfigureAwait(false);

            return await GetSyntaxList(result).ConfigureAwait(false);
        }

        private async Task<SyntaxList<MemberDeclarationSyntax>> ReportErrorInNamespace(
            GeneratorExecutionContext progress,
            string namespaceName,
            string comment)
        {
            var errorDiagnostic = Diagnostic.Create(
                "NUC0001",
                "Nucleotide Generation",
                "Problem working out the model to be used for generation",
                DiagnosticSeverity.Error,
                DiagnosticSeverity.Error,
                true,
                0,
                "Model load error");

            progress.ReportDiagnostic(errorDiagnostic);
            var namespaceDeclaration = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.IdentifierName(namespaceName))
                .WithLeadingTrivia(SyntaxFactory.Comment(comment));

            return await GetSyntaxList(namespaceDeclaration);
        }

        private async Task<SyntaxList<MemberDeclarationSyntax>> GetSyntaxList(NamespaceDeclarationSyntax namespaceDeclaration)
        {
            var nodes = new MemberDeclarationSyntax[]
            {
                namespaceDeclaration
            };

            var results = SyntaxFactory.List(nodes);
            return await Task.FromResult(results);
        }
    }
}
