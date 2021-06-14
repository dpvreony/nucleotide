using Dhgms.Nucleotide.Generators.Generators;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Generators.Features.Model
{
    public abstract class KeyedModelInterfaceGenerator : BaseInterfaceLevelCodeGenerator<KeyedModelInterfaceFeatureFlags, KeyedModelInterfaceGeneratorProcessor, IEntityGenerationModel>
    {
        protected override string GetNamespace()
        {
            return "Models";
        }
    }
}