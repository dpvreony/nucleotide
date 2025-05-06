using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dhgms.Nucleotide.Generators.Features.Core
{
    public static class RoslynGenerationHelpers
    {
        public static void DoFeatureGeneration<TMemberDeclarationSyntaxFactory, TFeatureModel>(
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

        public static SyntaxList<MemberDeclarationSyntax> TryGetMemberDeclarationSyntaxCollection<TMemberDeclarationSyntaxFactory, TFeatureModel>(IReadOnlyCollection<TFeatureModel> featureModelCollection)
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
    }
}
