using System;
using System.Collections.Generic;
using System.Text;

namespace Dhgms.Nucleotide.Generators.Features.Core
{
    public record NamedTypeArgumentModel(string ContainingNamespace, string TypeName, bool Nullable) : NamedTypeModel(ContainingNamespace, TypeName)
    {
        public string GetFullyQualifiedTypeArgument()
        {
            return $"{ContainingNamespace}.{TypeName}{(Nullable ? "?" : string.Empty)}";
        }
    }
}
