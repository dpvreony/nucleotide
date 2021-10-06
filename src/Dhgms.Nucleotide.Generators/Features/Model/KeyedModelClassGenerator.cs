using Dhgms.Nucleotide.Generators.Generators;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Generators.Features.Model
{
    /// <summary>
    /// Generates models
    /// </summary>
    public abstract class KeyedModelClassGenerator : BaseClassLevelCodeGenerator<KeyedModelClassFeatureFlags, KeyedModelClassGeneratorProcessor, IEntityGenerationModel>
    {
        protected override string GetNamespace() => "Models";
    }
}
