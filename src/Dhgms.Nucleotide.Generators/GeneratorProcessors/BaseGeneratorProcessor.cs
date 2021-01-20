using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.Generators.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.GeneratorProcessors
{
    public abstract class BaseGeneratorProcessor
    {
        public abstract Task<NamespaceDeclarationSyntax> GenerateObjects(
            NamespaceDeclarationSyntax namespaceDeclaration,
            INucleotideGenerationModel nucleotideGenerationModel);

        protected abstract string[] GetClassPrefixes();

        protected abstract PropertyDeclarationSyntax GetPropertyDeclaration(PropertyInfoBase propertyInfo);

        protected abstract PropertyDeclarationSyntax GetReadOnlyPropertyDeclaration(PropertyInfoBase propertyInfo);

        protected IEnumerable<SyntaxTrivia> GetSummary(string[] summaryLines)
        {
            var result = new List<SyntaxTrivia>
            {
                SyntaxFactory.Comment($"/// <summary>")
            };

            var lines = summaryLines.Select(line => SyntaxFactory.Comment($"/// {line}"));
            result.AddRange(lines);

            result.Add(SyntaxFactory.Comment($"/// </summary>"));

            return result;
        }

        protected abstract PropertyDeclarationSyntax GetPropertyDeclaration(
            PropertyInfoBase propertyInfo,
            AccessorDeclarationSyntax[] accessorList,
            IEnumerable<SyntaxTrivia> summary);

        protected static void AddToList<T>(List<MemberDeclarationSyntax> list, IReadOnlyCollection<T> items)
            where T : MemberDeclarationSyntax
        {
            if (items != null && items.Count > 0)
            {
                list.AddRange(items);
            }
        }

        protected static ParameterListSyntax GetParams(string[] argCollection)
        {
            var parameters = SyntaxFactory.SeparatedList<ParameterSyntax>();

            foreach (var s in argCollection)
            {
                var node = SyntaxFactory.Parameter(SyntaxFactory.Identifier(s));
                parameters = parameters.Add(node);
            }

            return SyntaxFactory.ParameterList(parameters);
        }
    }
}
