using System;
using System.Collections.Generic;
using System.Text;

namespace Dhgms.Nucleotide.Generators.Features.Cqrs.Requests
{
    public record NamedTypeModel(string ContainingNamespace, string Name, bool Nullable)
    {
        public string GetFullyQualifiedTypeName()
        {
            return $"{ContainingNamespace}.{Name}{(Nullable ? "?" : string.Empty)}";
        }
    }
}
