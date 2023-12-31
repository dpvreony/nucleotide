using System.Collections.Generic;
using Dhgms.Nucleotide.Generators.Models;

namespace Dhgms.Nucleotide.SampleGenerator.InterfaceGenerationModels.Whipstaff.Entities
{
    public sealed record NameableInterfaceGenerationModel() : InterfaceGenerationModel(
        "Whipstaff.Core.Entities.INameable",
        new List<PropertyGenerationModel>
        {
            new ("string", "Name", PropertyAccessorFlags.Get)
        },
        new List<IInterfaceMethodGenerationModel>(),
        new List<InterfaceGenerationModel>());
}
