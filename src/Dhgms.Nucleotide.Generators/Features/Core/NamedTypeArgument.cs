using System;
using System.Collections.Generic;
using System.Text;

namespace Dhgms.Nucleotide.Generators.Features.Core
{
    public record NamedTypeArgumentModel(string ContainingNamespace, string Name, bool Nullable) : NamedTypeModel(ContainingNamespace, Name)
    {
        public string GetFullyQualifiedTypeArgument()
        {
            return $"{ContainingNamespace}.{Name}{(Nullable ? "?" : string.Empty)}";
        }
    }
}
