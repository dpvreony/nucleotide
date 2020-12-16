using Dhgms.Nucleotide.Attributes;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Features.Cqrs
{
    /// <summary>
    /// Generator for Command Factory Interface
    /// </summary>
    [Generator]
    public sealed class CommandFactoryInterfaceGenerator : BaseInterfaceLevelCodeGenerator<CommandFactoryInterfaceFeatureFlags, CommandFactoryInterfaceGeneratorProcessor, GenerateCommandFactoryInterfaceAttribute>
    {
        protected override string GetNamespace()
        {
            return "CommandFactories";
        }
    }
}
