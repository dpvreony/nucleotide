using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dhgms.Nucleotide.Generators.Features.Cqrs.XmlDoc
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
    }
}
