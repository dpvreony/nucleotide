using System;
using System.Collections.Generic;
using System.Text;

namespace Dhgms.Nucleotide.Generators.Features.Cqrs.Requests
{
    public record NamedTypeParameterModel(
        string ContainingNamespace,
        string TypeName,
        bool Nullable,
        string ParameterName) : NamedTypeModel(ContainingNamespace, TypeName, Nullable)
    {
    }
}
