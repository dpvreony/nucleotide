using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Generators
{
    public abstract class BaseGenerator<TFeatureFlags, TGeneratorProcessor> : ISourceGenerator
        where TFeatureFlags : class
        where TGeneratorProcessor : BaseGeneratorProcessor, new()
    {
        protected abstract INucleotideGenerationModel NucleotideGenerationModel { get; }

        protected TFeatureFlags FeatureFlags { get; }

        public void Initialize(GeneratorInitializationContext context)
        {
        }

        public static Diagnostic InfoDiagnostic(string message)
        {
            return Diagnostic.Create(
                "NUC-I0001",
                "Nucleotide Generation",
                message,
                DiagnosticSeverity.Info,
                DiagnosticSeverity.Info,
                true,
                1,
                "Model Generation");
        }

        public static Diagnostic ErrorDiagnostic(string message)
        {
            return Diagnostic.Create(
                "NUC-E0001",
                "Nucleotide Generation",
                message,
                DiagnosticSeverity.Error,
                DiagnosticSeverity.Error,
                true,
                0,
                "Model load error");
        }

        public void Execute(GeneratorExecutionContext context)
        {
            var compilation = context.Compilation;
            context.ReportDiagnostic(InfoDiagnostic(typeof(TGeneratorProcessor).ToString()));

            // TODO: this is running async code inside non-async
            var result = GenerateAsync(context, CancellationToken.None)
                .GetAwaiter()
                .GetResult();

            var parseOptions = context.ParseOptions;

            foreach (var memberDeclarationSyntax in result)
            {
                // TODO: need to review this might be better way than generate, loop, copy.
                // compilationUnit = compilationUnit.AddMembers(memberDeclarationSyntax);

                var cu = SyntaxFactory.CompilationUnit().AddMembers(memberDeclarationSyntax).NormalizeWhitespace();


                // TODO: hint name per generator, or per class?
                var feature = "feature";
                var guid = Guid.NewGuid();

                var sourceText = SyntaxFactory.SyntaxTree(cu, parseOptions, encoding: Encoding.UTF8).GetText();

                // https://github.com/dotnet/roslyn-sdk/pull/553/files
                var generatedSourceOutputPath = context.TryCreateGeneratedSourceOutputPath();
                context.AddSource(
                    generatedSourceOutputPath,
                    $"nucleotide.{feature}.{guid}.g.cs",
                    sourceText);
            }
        }

        protected abstract string GetNamespace();

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
