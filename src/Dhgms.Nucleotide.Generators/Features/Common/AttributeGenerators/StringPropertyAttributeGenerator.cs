using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Common.PropertyInfo;
using Dhgms.Nucleotide.Helpers;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Features.AttributeGenerators
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
