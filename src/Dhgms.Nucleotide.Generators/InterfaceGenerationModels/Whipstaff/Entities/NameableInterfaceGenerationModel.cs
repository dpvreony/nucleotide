using System.Collections.Generic;
using Dhgms.Nucleotide.Generators.Models;

namespace Dhgms.Nucleotide.Generators.InterfaceGenerationModels.Whipstaff.Entities
{
    public sealed record NameableInterfaceGenerationModel() : InterfaceGenerationModel(
        "Whipstaff.Entities.INameable",
        new List<PropertyGenerationModel>
        {
            new ("string", "Name", PropertyAccessorFlags.Get)
        },
        new List<IInterfaceMethodGenerationModel>(),
        new List<InterfaceGenerationModel>());
}
