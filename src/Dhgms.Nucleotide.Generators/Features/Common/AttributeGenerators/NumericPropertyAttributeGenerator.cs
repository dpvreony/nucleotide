﻿// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections.Generic;
using Dhgms.Nucleotide.Generators.PropertyInfo;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.Common.AttributeGenerators
{
    public class NumericPropertyAttributeGenerator<TNumeric> : IAttributeGenerator<NumericPropertyInfo<TNumeric>>
        where TNumeric : struct
    {
        public IList<AttributeSyntax> GetAttributes(NumericPropertyInfo<TNumeric> propertyInfo)
        {
            // TODO: need to review this for const expressions i.e. Double.PositiveInfinity
            var argumentList = RoslynGenerationHelpers.GetAttributeArgumentListSyntax(new List<string>
            {
                propertyInfo.MinimumValue.ToString(),
                propertyInfo.MaximumValue.ToString()
            });

            return new List<AttributeSyntax>
            {
                SyntaxFactory.Attribute(SyntaxFactory.ParseName("Range"), argumentList)
            };
        }
    }
}
