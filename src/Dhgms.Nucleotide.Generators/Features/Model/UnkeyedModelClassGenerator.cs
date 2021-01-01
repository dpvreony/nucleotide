using Dhgms.Nucleotide.Generators.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Generators.Features.Model
{
    /// <summary>
    /// Generates models
    /// </summary>
    [Generator]
    public abstract class UnkeyedModelClassGenerator : BaseClassLevelCodeGenerator<UnkeyedModelClassFeatureFlags, UnkeyedModelClassGeneratorProcessor>
    {
        protected override string GetNamespace() => "Models";
    }
}
