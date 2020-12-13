using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Features.Cqrs
{
    public sealed class CommandInterfaceGenerator : BaseInterfaceLevelCodeGenerator<CommandInterfaceFeatureFlags, CommandInterfaceGeneratorProcessor>
    {
        protected override string GetNamespace() => "Commands";
    }
}
