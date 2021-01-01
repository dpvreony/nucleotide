using Dhgms.Nucleotide.Generators.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Generators.Features.Model
{
    [Generator]
    public abstract class UnkeyedModelInterfaceGenerator : BaseInterfaceLevelCodeGenerator<UnkeyedModelInterfaceFeatureFlags, UnkeyedModelInterfaceGeneratorProcessor>
    {
        protected override string GetNamespace()
        {
            return "Models";
        }
    }
}
