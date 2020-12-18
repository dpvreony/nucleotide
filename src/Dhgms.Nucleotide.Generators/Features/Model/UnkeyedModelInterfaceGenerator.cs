using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Features.Model
{
    [Generator]
    public sealed class UnkeyedModelInterfaceGenerator : BaseInterfaceLevelCodeGenerator<UnkeyedModelInterfaceFeatureFlags, UnkeyedModelInterfaceGeneratorProcessor>
    {
        protected override string GetNamespace()
        {
            return "Models";
        }
    }
}
