// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections.Generic;
using Dhgms.Nucleotide.Generators.PropertyInfo;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.Common.AttributeGenerators
{
    public interface IAttributeGenerator<in TPropertyInfo>
        where TPropertyInfo : PropertyInfoBase
    {
        IList<AttributeSyntax> GetAttributes(TPropertyInfo propertyInfo);
    }
}