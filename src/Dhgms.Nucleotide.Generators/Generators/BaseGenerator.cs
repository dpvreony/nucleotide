// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Immutable;
using System.Text;
using System.Threading;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Dhgms.Nucleotide.Generators.Generators
{
    public abstract class BaseGenerator<TFeatureFlags, TGeneratorProcessor, TGenerationModel> : IIncrementalGenerator
        where TFeatureFlags : class
        where TGeneratorProcessor : BaseGeneratorProcessor<TGenerationModel>, new()
        where TGenerationModel : IClassName
    {
        protected abstract INucleotideGenerationModel<TGenerationModel> NucleotideGenerationModel { get; }

        protected TFeatureFlags FeatureFlags { get; }

        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            var trigger = context.AnalyzerConfigOptionsProvider
                .Combine(context.ParseOptionsProvider)
                .Combine(context.MetadataReferencesProvider.Collect())
                .Combine(context.CompilationProvider)
                .Select((tuple, _) =>
                {
                    (
                        (
                            (
                                AnalyzerConfigOptionsProvider analyzerConfigOptionsProvider,
                                ParseOptions parseOptionsProvider),
                            ImmutableArray<MetadataReference> metadataReferencesProvider),
                        Compilation compilationProvider) = tuple;

                    return (analyzerConfigOptionsProvider, parseOptionsProvider, metadataReferencesProvider, compilationProvider);
                });

            context.RegisterImplementationSourceOutput(
                trigger, (productionContext, tuple) => Execute(
                    productionContext,
                    tuple.analyzerConfigOptionsProvider,
                    tuple.parseOptionsProvider,
                    tuple.metadataReferencesProvider,
                    tuple.compilationProvider));
        }


        public static Diagnostic InfoDiagnostic(string message)
        {
            return Diagnostic.Create(
                "NUCI0001",
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
                "NUCE0001",
                "Nucleotide Generation",
                message,
                DiagnosticSeverity.Error,
                DiagnosticSeverity.Error,
                true,
                0,
                "Model load error");
        }

        private void Execute(
            SourceProductionContext productionContext,
            AnalyzerConfigOptionsProvider analyzerConfigOptionsProvider,
            ParseOptions parseOptionsProvider,
            ImmutableArray<MetadataReference> metadataReferencesProvider,
            Compilation compilationProvider)
        {
            try
            {
                productionContext.ReportDiagnostic(InfoDiagnostic(typeof(TGeneratorProcessor).ToString()));

                // TODO: this is running async code inside non-async
                var memberDeclarationSyntax = Generate(productionContext, CancellationToken.None);

                // TODO: need to review this might be better way than generate, loop, copy.
                // compilationUnit = compilationUnit.AddMembers(memberDeclarationSyntax);

                var nullableSyntaxDirective = SyntaxFactory.NullableDirectiveTrivia(SyntaxFactory.Token(SyntaxKind.EnableKeyword), true);
                var trivia = SyntaxFactory.Trivia(nullableSyntaxDirective);
                var triviaList = SyntaxFactory.TriviaList(trivia);

                var cu = SyntaxFactory.CompilationUnit()
                    .AddMembers(memberDeclarationSyntax)
                    .WithLeadingTrivia(triviaList)
                    .NormalizeWhitespace();

                var feature = typeof(TGeneratorProcessor).ToString();

                var sourceText = SyntaxFactory.SyntaxTree(
                        cu,
                        parseOptionsProvider,
                        encoding: Encoding.UTF8)
                    .GetText();

                var hintName = $"{feature}.g.cs";

                productionContext.AddSource(
                    hintName,
                    sourceText);
            }
            catch (Exception e)
            {
                var diagnostic = ErrorDiagnostic(e.ToString());
                productionContext.ReportDiagnostic(diagnostic);
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
        private MemberDeclarationSyntax Generate(
            SourceProductionContext context,
            CancellationToken cancellationToken)
        {
            var namespaceName = GetNamespace();

            var generationModel = this.NucleotideGenerationModel;

            var rootNamespace = generationModel.RootNamespace;
            var namespaceDeclaration = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.IdentifierName($"{rootNamespace}.{namespaceName}"));

            var generatorProcessor = new TGeneratorProcessor();

            var result = generatorProcessor.GenerateObjects(
                namespaceDeclaration,
                generationModel);

            return result;
        }
    }
}
