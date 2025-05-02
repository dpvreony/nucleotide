using System;
using System.Collections.Generic;
using System.Text;

namespace Dhgms.Nucleotide.Generators.Features.Cqrs.Requests
{
    public record NamedTypeParameterModel(
        string ContainingNamespace,
        string Name,
        bool Nullable) : NamedTypeModel(ContainingNamespace, Name)
    {
        public string GetFullyQualifiedName()
        {
            return $"{ContainingNamespace}.{Name}{(Nullable ? "?" : string.Empty)}";
        }
    }
}
