// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Collections.Immutable;
using Dhgms.Nucleotide.Generators.Features.AspNetCore;
using Dhgms.Nucleotide.Generators.Features.AspNetCore.MvcControllers;
using Dhgms.Nucleotide.Generators.Features.Cqrs.Requests;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Dhgms.Nucleotide.Generators.Features.Cqrs;
using Dhgms.Nucleotide.Generators.Features.Cqrs.RequestFactories;
using Dhgms.Nucleotide.Generators.Features.Cqrs.Responses;
using Dhgms.Nucleotide.Generators.Features.DataTransferObjects;
using Dhgms.Nucleotide.Generators.Features.Logging;
using Dhgms.Nucleotide.SampleGenerator.DataTransferObjects;

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


        protected abstract NucleotideGenerationModel GetGenerationModel();

        private void DoGeneration(
            NucleotideGenerationModel generationModel,
            SourceProductionContext productionContext,
            ParseOptions parseOptionsProvider)
        {
            RoslynGenerationHelpers.DoFeatureGeneration<DataTransferObjectMemberDeclarationSyntaxFactory, DataTransferObjectModel>(
                generationModel.DataTransferObjects,
                productionContext,
                parseOptionsProvider,
                "DataTransferObjects");

            DoAspNetCoreGeneration(
                generationModel.AspNetCore,
                productionContext,
                parseOptionsProvider);

            DoCqrsGeneration(
                generationModel.Cqrs,
                productionContext,
                parseOptionsProvider);

            DoLoggingGeneration(
                generationModel.Logging,
                productionContext,
                parseOptionsProvider);
        }

        private void DoAspNetCoreGeneration(
            AspNetCoreGenerationModel? generationModelAspNetCore,
            SourceProductionContext productionContext,
            ParseOptions parseOptionsProvider)
        {
            if (generationModelAspNetCore == null)
            {
                return;
            }

            RoslynGenerationHelpers.DoFeatureGeneration<MvcControllersMemberDeclarationSyntaxFactory, MvcControllerModel>(
                generationModelAspNetCore.MvcControllers,
                productionContext,
                parseOptionsProvider,
                "AspNetCore.MvcControllers");
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

            RoslynGenerationHelpers.DoFeatureGeneration<ResponseMemberDeclarationSyntaxFactory, ResponseModel>(
                cqrsGenerationModel.Responses,
                productionContext,
                parseOptionsProvider,
                "Cqrs.Responses");

            RoslynGenerationHelpers.DoFeatureGeneration<RequestMemberDeclarationSyntaxFactory, RequestModel>(
                cqrsGenerationModel.Requests,
                productionContext,
                parseOptionsProvider,
                "Cqrs.Requests");

            RoslynGenerationHelpers.DoFeatureGeneration<RequestFactoryClassMemberDeclarationSyntaxFactory, RequestFactoryModel>(
                cqrsGenerationModel.RequestFactoryClasses,
                productionContext,
                parseOptionsProvider,
                "Cqrs.RequestFactoryClasses");
        }

        private void DoLoggingGeneration(LoggingGenerationModel generationModelLogging, SourceProductionContext productionContext, ParseOptions parseOptionsProvider)
        {
            RoslynGenerationHelpers.DoFeatureGeneration<LogMessageActionModelMemberDeclarationSyntaxFactory, LogMessageActionModel>(
                generationModelLogging.LogMessageActions,
                productionContext,
                parseOptionsProvider,
                "Logging.LogMessageActions");

            /*
            RoslynGenerationHelpers.DoFeatureGeneration<LogMessageActionWrapperModelMemberDeclarationSyntaxFactory, LogMessageActionModel>(
                generationModelLogging.LogMessageActions,
                productionContext,
                parseOptionsProvider,
                "Logging.LogMessageActions");
            */
        }
    }
}
