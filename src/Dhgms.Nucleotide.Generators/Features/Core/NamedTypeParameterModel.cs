using System;
using System.Collections.Generic;
using System.Text;

namespace Dhgms.Nucleotide.Generators.Features.Core
{
    public record NamedTypeParameterModel(
        string? ContainingNamespace,
        string TypeName,
        bool Nullable,
        string ParameterName) : NamedTypeArgumentModel(ContainingNamespace, TypeName, Nullable)
    {
    }
}
