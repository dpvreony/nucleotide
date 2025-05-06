using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Dhgms.Nucleotide.Generators.Features.Core;
using Dhgms.Nucleotide.Generators.Features.Cqrs.Requests;
using Dhgms.Nucleotide.Generators.Features.Cqrs.Responses;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Dhgms.Nucleotide.SampleGenerator
{
    public abstract class AbstractTestGenerator<TMemberDeclarationSyntaxFactory, TFeatureModel> : IIncrementalGenerator
        where TMemberDeclarationSyntaxFactory : IMemberDeclarationSyntaxFactory<TFeatureModel>, new()
    {
        /// <inheritdoc/>
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


        protected abstract IReadOnlyCollection<TFeatureModel> GetGenerationModel();

        private void Execute(
            SourceProductionContext productionContext,
            AnalyzerConfigOptionsProvider analyzerConfigOptionsProvider,
            ParseOptions parseOptionsProvider,
            ImmutableArray<MetadataReference> metadataReferencesProvider,
            Compilation compilationProvider)
        {
            var generationModel = GetGenerationModel();

            DoGeneration(
                generationModel,
                productionContext,
                parseOptionsProvider);
        }

        private void DoGeneration(
            IReadOnlyCollection<TFeatureModel> generationModel,
            SourceProductionContext productionContext,
            ParseOptions parseOptionsProvider)
        {
            RoslynGenerationHelpers.DoFeatureGeneration<TMemberDeclarationSyntaxFactory, TFeatureModel>(
                generationModel,
                productionContext,
                parseOptionsProvider,
                "Cqrs.RequestFactoryClasses");
        }
    }
}
