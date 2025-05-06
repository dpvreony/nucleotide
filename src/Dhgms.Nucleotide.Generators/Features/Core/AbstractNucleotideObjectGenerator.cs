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
            DoFeatureGeneration<ResponseMemberDeclarationSyntaxFactory, ResponseModel>(
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
            DoFeatureGeneration<RequestMemberDeclarationSyntaxFactory, RequestModel>(
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
            DoFeatureGeneration<RequestFactoryInterfaceMemberDeclarationSyntaxFactory, RequestFactoryModel>(
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
            DoFeatureGeneration<RequestFactoryClassMemberDeclarationSyntaxFactory, RequestFactoryModel>(
                requestFactoryClasses,
                productionContext,
                parseOptionsProvider,
                "Cqrs.RequestFactoryClasses");
        }

        private void DoFeatureGeneration<TMemberDeclarationSyntaxFactory, TFeatureModel>(
            IReadOnlyCollection<TFeatureModel>? featureModelCollection,
            SourceProductionContext productionContext,
            ParseOptions parseOptionsProvider,
            string featureName)
            where TMemberDeclarationSyntaxFactory : IMemberDeclarationSyntaxFactory<TFeatureModel>, new()
        {
            if (featureModelCollection == null || featureModelCollection.Count < 1)
            {
                return;
            }

            var nullableSyntaxDirective = SyntaxFactory.NullableDirectiveTrivia(SyntaxFactory.Token(SyntaxKind.EnableKeyword), true);
            var trivia = SyntaxFactory.Trivia(nullableSyntaxDirective);
            var triviaList = SyntaxFactory.TriviaList(trivia);

            var memberDeclarationSyntaxCollection = TryGetMemberDeclarationSyntaxCollection<TMemberDeclarationSyntaxFactory, TFeatureModel>(featureModelCollection);
            var cu = SyntaxFactory.CompilationUnit()
                .WithMembers(memberDeclarationSyntaxCollection)
                .WithLeadingTrivia(triviaList)
                .NormalizeWhitespace();

            var sourceText = SyntaxFactory.SyntaxTree(
                    cu,
                    parseOptionsProvider,
                    encoding: Encoding.UTF8)
                .GetText();

            var hintName = $"Nucelotide.{featureName}.g.cs";

            productionContext.AddSource(
                hintName,
                sourceText);

        }

        private SyntaxList<MemberDeclarationSyntax> TryGetMemberDeclarationSyntaxCollection<TMemberDeclarationSyntaxFactory, TFeatureModel>(IReadOnlyCollection<TFeatureModel> featureModelCollection)
            where TMemberDeclarationSyntaxFactory : IMemberDeclarationSyntaxFactory<TFeatureModel>, new()
        {
            try
            {
                var memberDeclarationSyntaxFactory = new TMemberDeclarationSyntaxFactory();
                return memberDeclarationSyntaxFactory.GetMemberDeclarationSyntaxCollection(featureModelCollection);
            }
            catch (Exception e)
            {
                var errorDirective = SyntaxFactory.Trivia(
                    SyntaxFactory.ErrorDirectiveTrivia(true)
                        .WithErrorKeyword(SyntaxFactory.Token(SyntaxKind.ErrorKeyword))
                        .WithEndOfDirectiveToken(
                            SyntaxFactory.Token(
                                SyntaxFactory.TriviaList(
                                    SyntaxFactory.PreprocessingMessage(e.ToString())
                                    ),
                                    SyntaxKind.EndOfDirectiveToken,
                                    SyntaxFactory.TriviaList()
                            )));

                var emptyStatement = SyntaxFactory.EmptyStatement()
                    .WithLeadingTrivia(errorDirective);

                var global = SyntaxFactory.GlobalStatement(emptyStatement);
                return SyntaxFactory.List<MemberDeclarationSyntax>([global]);
            }
        }

        protected abstract NucleotideGenerationModel GetGenerationModel();
    }
}
