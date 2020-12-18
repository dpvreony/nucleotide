using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Features.Cqrs
{
    [Generator]
    public abstract class CommandInterfaceGenerator : BaseInterfaceLevelCodeGenerator<CommandInterfaceFeatureFlags, CommandInterfaceGeneratorProcessor>
    {
        protected override string GetNamespace() => "Commands";
    }
}
