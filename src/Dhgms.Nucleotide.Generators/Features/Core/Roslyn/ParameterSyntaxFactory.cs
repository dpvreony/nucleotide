using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.Core.Roslyn
{
    public static class ParameterSyntaxFactory
    {
        public static ParameterSyntax GetParameterSyntax(NamedTypeParameterModel namedTypeParameterModel)
        {
            return SyntaxFactory.Parameter(
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.TokenList(),
                SyntaxFactory.ParseTypeName(namedTypeParameterModel.ContainingNamespace),
                SyntaxFactory.Identifier(namedTypeParameterModel.ParameterName),
                null);
        }

        public static void PopulateParameterSyntaxList<TModel>(
            IList<ParameterSyntax> list,
            IReadOnlyCollection<TModel> models)
            where TModel : NamedTypeParameterModel
        {
            foreach (var model in models)
            {
                list.Add(GetParameterSyntax(model));
            }
        }
    }
}
