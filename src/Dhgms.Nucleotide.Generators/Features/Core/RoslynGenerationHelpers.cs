using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dhgms.Nucleotide.Generators.Features.AspNetCore.MvcControllers;
using Dhgms.Nucleotide.Generators.Features.Cqrs.Responses;

namespace Dhgms.Nucleotide.Generators.Features.Core
{
    public static class RoslynGenerationHelpers
    {
        public static void DoFeatureGeneration<TMemberDeclarationSyntaxFactory, TFeatureModel>(
            IList<TFeatureModel> featureModelCollection,
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

            var cu = SyntaxFactory.CompilationUnit();
            try
            {
                var memberDeclarationSyntaxFactory = new TMemberDeclarationSyntaxFactory();
                var memberDeclarationSyntaxCollection = memberDeclarationSyntaxFactory.GetMemberDeclarationSyntaxCollection(featureModelCollection);
                cu = cu
                    .WithMembers(memberDeclarationSyntaxCollection)
                    .WithLeadingTrivia(triviaList)
                    .NormalizeWhitespace();
            }
            catch (Exception e)
            {
                var errorDirective = SyntaxFactory.Trivia(
                    SyntaxFactory.ErrorDirectiveTrivia(true)
                        .WithErrorKeyword(SyntaxFactory.Token(SyntaxKind.ErrorKeyword))
                        .WithEndOfDirectiveToken(
                            SyntaxFactory.Token(
                                SyntaxFactory.TriviaList(
                                    SyntaxFactory.PreprocessingMessage($"Failed to generate code in: {typeof(TMemberDeclarationSyntaxFactory)}")
                                ),
                                SyntaxKind.EndOfDirectiveToken,
                                SyntaxFactory.TriviaList()
                            )));

                var splitString = new[] { "\r\n", "\n" };
                var text = e.ToString()
                    .Split(splitString, StringSplitOptions.None)
                    .Select(line => line.Trim())
                    .Aggregate(string.Empty, (current, line) => current + $"/// {line}\r\n");
                var errorCommentTrivia = SyntaxFactory.Comment(text);

                cu = cu
                    .WithLeadingTrivia(trivia, errorCommentTrivia, errorDirective)
                    .NormalizeWhitespace();
            }


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
    }
}
