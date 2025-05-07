using Dhgms.Nucleotide.Generators.Features.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dhgms.Nucleotide.Generators.Features.AspNetCore.MvcControllers
{
    public sealed record ConstructorModel(
        IReadOnlyCollection<NamedTypeParameterModel>? ArgsForFieldAssignments,
        IReadOnlyCollection<NamedTypeParameterModel>? ArgsForBaseConstructorPassThrough)
    {
    }
}
