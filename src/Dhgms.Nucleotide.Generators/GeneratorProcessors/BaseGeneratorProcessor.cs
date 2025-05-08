// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.Generators.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.GeneratorProcessors
{
    public abstract class BaseGeneratorProcessor<TGenerationModel>
        where TGenerationModel : IClassName
    {
        public abstract NamespaceDeclarationSyntax GenerateObjects(
            NamespaceDeclarationSyntax namespaceDeclaration,
            INucleotideGenerationModel<TGenerationModel> nucleotideGenerationModel);

        protected abstract string[] GetClassPrefixes();

        protected abstract PropertyDeclarationSyntax GetPropertyDeclaration(PropertyInfoBase propertyInfo);

        protected abstract PropertyDeclarationSyntax GetReadOnlyPropertyDeclaration(PropertyInfoBase propertyInfo);

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
