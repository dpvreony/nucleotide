using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dhgms.Nucleotide.Generators.Features.Core.XmlDoc
{
    public static class SyntaxTriviaFactory
    {
        public static IEnumerable<SyntaxTrivia> GetSummary(string[] summaryLines)
        {
            yield return SyntaxFactory.Comment($"/// <summary>");

            foreach (var line in summaryLines)
            {
                yield return SyntaxFactory.Comment($"/// {line}");
            }

            yield return SyntaxFactory.Comment($"/// </summary>");
        }

        public static IEnumerable<SyntaxTrivia> GetExample(string[] code)
        {
            yield return SyntaxFactory.Comment($"/// <example>");
            yield return SyntaxFactory.Comment($"/// <code>");

            foreach (var line in code)
            {
                yield return SyntaxFactory.Comment($"/// {line}");
            }

            yield return SyntaxFactory.Comment($"/// </code>");
            yield return SyntaxFactory.Comment($"/// </example>");
        }

        public static IEnumerable<SyntaxTrivia> GetXmlDocumentation(
            string[] summary,
            string[] code)
        {
            foreach (var line in GetSummary(summary))
            {
                yield return line;
            }

            foreach (var line in GetExample(code))
            {
                yield return line;
            }
        }

        public static IEnumerable<SyntaxTrivia> GenerateConstructorComment(
            string className,
            IEnumerable<(string paramName, string paramText)> parameters)
        {
            return GenerateMethodComment(
                [ $"Initializes a new instance of the <see cref=\"{className}\"/> class." ],
                parameters);
        }

        /// <summary>
        /// Generates a method comment with documents for parameters.
        /// </summary>
        /// <param name="summary">The lines of the summary comment.</param>
        /// <param name="parameters">The key/value text of each parameter.</param>
        /// <returns>The syntax trivia of the comment.</returns>
        public static IEnumerable<SyntaxTrivia> GenerateMethodComment(
            string[] summary,
            IEnumerable<(string paramName, string paramText)> parameters)
        {
            foreach (var line in GetSummary(summary))
            {
                yield return line;
            }

            foreach (var parameter in parameters)
            {
                yield return SyntaxFactory.Comment($"/// <param name=\"{parameter.paramName}\">\n");

                foreach (var line in parameter.paramText.Split(
                             [
                                 "\n",
                                 "\r\n" ],
                             StringSplitOptions.None))
                {
                    yield return SyntaxFactory.Comment($"/// {line}\n");
                }

                yield return SyntaxFactory.Comment($"/// </param>\n");
            }
        }

    }
}
