// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections.Generic;
using Dhgms.Nucleotide.Generators.PropertyInfo;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.Common.AttributeGenerators
{
    public sealed class StringPropertyAttributeGenerator : IAttributeGenerator<ClrStringPropertyInfo>
    {
        public IList<AttributeSyntax> GetAttributes(ClrStringPropertyInfo propertyInfo)
        {
            var nodes = new List<AttributeSyntax>();

            if (propertyInfo.MaximumLength.HasValue)
            {
                var argumentList = RoslynGenerationHelpers.GetAttributeArgumentListSyntax(new List<string>
                {
                    propertyInfo.MaximumLength.Value.ToString()
                });

                nodes.Add(SyntaxFactory.Attribute(SyntaxFactory.ParseName("MaxLength"), argumentList));
            }

            if (propertyInfo.MinimumLength.HasValue)
            {
                var argumentList = RoslynGenerationHelpers.GetAttributeArgumentListSyntax(new List<string>
                {
                    propertyInfo.MinimumLength.Value.ToString()
                });

                nodes.Add(SyntaxFactory.Attribute(SyntaxFactory.ParseName("MinLength"), argumentList));
            }

            return nodes;
        }
    }
}
