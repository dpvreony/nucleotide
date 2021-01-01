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