using Dhgms.Nucleotide.Attributes;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Features.Cqrs
{
    [Generator]
    public sealed class CommandInterfaceGenerator : BaseInterfaceLevelCodeGenerator<CommandInterfaceFeatureFlags, CommandInterfaceGeneratorProcessor, GenerateCommandInterfaceAttribute>
    {
        protected override string GetNamespace() => "Commands";
    }
}
