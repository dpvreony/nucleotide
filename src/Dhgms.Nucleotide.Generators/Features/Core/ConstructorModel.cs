using System;
using System.Collections.Generic;
using System.Text;

namespace Dhgms.Nucleotide.Generators.Features.Core
{
    public sealed record ConstructorModel(
        IReadOnlyCollection<NamedTypeParameterModel>? ArgsForFieldAssignments,
        IReadOnlyCollection<NamedTypeParameterModel>? ArgsForBaseConstructorPassThrough)
    {
    }
}
