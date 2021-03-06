﻿using System;
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
    public abstract class BaseGenerator<TFeatureFlags, TGeneratorProcessor, TGenerationModel> : ISourceGenerator
        where TFeatureFlags : class
        where TGeneratorProcessor : BaseGeneratorProcessor<TGenerationModel>, new()
        where TGenerationModel : IClassName
    {
        protected abstract INucleotideGenerationModel<TGenerationModel> NucleotideGenerationModel { get; }

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
            context.ReportDiagnostic(InfoDiagnostic(typeof(TGeneratorProcessor).ToString()));

            // TODO: this is running async code inside non-async
            var memberDeclarationSyntax = GenerateAsync(context, CancellationToken.None)
                .GetAwaiter()
                .GetResult();

            var parseOptions = context.ParseOptions;

            // TODO: need to review this might be better way than generate, loop, copy.
            // compilationUnit = compilationUnit.AddMembers(memberDeclarationSyntax);

            var cu = SyntaxFactory.CompilationUnit()
                .AddMembers(memberDeclarationSyntax)
                .NormalizeWhitespace();

            var feature = typeof(TGeneratorProcessor).ToString();
            var guid = Guid.NewGuid();

            var sourceText = SyntaxFactory.SyntaxTree(
                cu,
                parseOptions,
                encoding: Encoding.UTF8)
                .GetText();

            var hintName = $"{feature}.{guid}.g.cs";

            context.AddSource(
                hintName,
                sourceText);
        }

        protected abstract string GetNamespace();

        /// <summary>
        /// Create the syntax tree representing the expansion of some member to which this attribute is applied.
        /// </summary>
        /// <param name="context">The transformation context being generated for.</param>
        /// <param name="progress">A way to report diagnostic messages.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The generated member syntax to be added to the project.</returns>
        private async Task<MemberDeclarationSyntax> GenerateAsync(
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

            return await Task.FromResult(result)
                .ConfigureAwait(false);
        }
    }
}
