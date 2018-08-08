using System.Collections.Generic;
using Dhgms.Nucleotide.PropertyInfo;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Features.AttributeGenerators
{
    public interface IAttributeGenerator<in TPropertyInfo>
        where TPropertyInfo : PropertyInfoBase
    {
        IList<AttributeSyntax> GetAttributes(TPropertyInfo propertyInfo);
    }
}