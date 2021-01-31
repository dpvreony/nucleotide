using Dhgms.Nucleotide.Generators.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Generators.Features.Model
{
    /// <summary>
    /// Generates models
    /// </summary>
    public abstract class KeyedModelClassGenerator : BaseClassLevelCodeGenerator<KeyedModelClassFeatureFlags, KeyedModelClassGeneratorProcessor>
    {
        protected override string GetNamespace() => "Models";
    }
}
