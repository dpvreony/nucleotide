using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Features.Model
{
    [Generator]
    public sealed class KeyedModelInterfaceGenerator : BaseInterfaceLevelCodeGenerator<KeyedModelInterfaceFeatureFlags, KeyedModelInterfaceGeneratorProcessor>
    {
        protected override string GetNamespace()
        {
            return "Models";
        }
    }
}