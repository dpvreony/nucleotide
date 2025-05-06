// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Dhgms.Nucleotide.Generators.Features.Core.XmlDoc;
using Dhgms.Nucleotide.Generators.Features.Cqrs.Requests;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using Dhgms.Nucleotide.Generators.Features.Cqrs;
using Dhgms.Nucleotide.Generators.Features.Cqrs.RequestFactories;
using Dhgms.Nucleotide.Generators.Features.Cqrs.Responses;

namespace Dhgms.Nucleotide.Generators.Features.Core
{
    public abstract class AbstractNucleotideObjectGenerator : IIncrementalGenerator
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
            NucleotideGenerationModel generationModel,
            SourceProductionContext productionContext,
            ParseOptions parseOptionsProvider)
        {
            DoCqrsGeneration(
                generationModel.CqrsGenerationModel,
                productionContext,
                parseOptionsProvider);
        }

        private void DoCqrsGeneration(
            CqrsGenerationModel? cqrsGenerationModel,
            SourceProductionContext productionContext,
            ParseOptions parseOptionsProvider)
        {
            if (cqrsGenerationModel == null)
            {
                return;
            }

            DoCqrsRequestFactoryClassesGeneration(
                cqrsGenerationModel.RequestFactoryClasses,
                productionContext,
                parseOptionsProvider);

            DoCqrsRequestFactoryInterfacesGeneration(
                cqrsGenerationModel.RequestFactoryInterfaces,
                productionContext,
                parseOptionsProvider);

            DoCqrsRequestsGeneration(
                cqrsGenerationModel.Requests,
                productionContext,
                parseOptionsProvider);

            DoCqrsResponsesGeneration(
                cqrsGenerationModel.Responses,
                productionContext,
                parseOptionsProvider);
        }

        private void DoCqrsResponsesGeneration(
            IReadOnlyCollection<ResponseModel>? responses,
            SourceProductionContext productionContext,
            ParseOptions parseOptionsProvider)
        {
            RoslynGenerationHelpers.DoFeatureGeneration<ResponseMemberDeclarationSyntaxFactory, ResponseModel>(
                responses,
                productionContext,
                parseOptionsProvider,
                "Cqrs.RequestFactoryClasses");
        }

        private void DoCqrsRequestsGeneration(
            IReadOnlyCollection<RequestModel>? requests,
            SourceProductionContext productionContext,
            ParseOptions parseOptionsProvider)
        {
            RoslynGenerationHelpers.DoFeatureGeneration<RequestMemberDeclarationSyntaxFactory, RequestModel>(
                requests,
                productionContext,
                parseOptionsProvider,
                "Cqrs.RequestFactoryClasses");
        }

        private void DoCqrsRequestFactoryInterfacesGeneration(
            IReadOnlyCollection<RequestFactoryModel>? requestFactoryInterfaces,
            SourceProductionContext productionContext,
            ParseOptions parseOptionsProvider)
        {
            RoslynGenerationHelpers.DoFeatureGeneration<RequestFactoryInterfaceMemberDeclarationSyntaxFactory, RequestFactoryModel>(
                requestFactoryInterfaces,
                productionContext,
                parseOptionsProvider,
                "Cqrs.RequestFactoryClasses");
        }

        private void DoCqrsRequestFactoryClassesGeneration(
            IReadOnlyCollection<RequestFactoryModel>? requestFactoryClasses,
            SourceProductionContext productionContext,
            ParseOptions parseOptionsProvider)
        {
            RoslynGenerationHelpers.DoFeatureGeneration<RequestFactoryClassMemberDeclarationSyntaxFactory, RequestFactoryModel>(
                requestFactoryClasses,
                productionContext,
                parseOptionsProvider,
                "Cqrs.RequestFactoryClasses");
        }


        protected abstract NucleotideGenerationModel GetGenerationModel();
    }
}
