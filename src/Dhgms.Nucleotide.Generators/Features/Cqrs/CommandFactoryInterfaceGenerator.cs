using Dhgms.Nucleotide.Generators.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Generators.Features.Cqrs
{
    /// <summary>
    /// Generator for Command Factory Interface
    /// </summary>
    [Generator]
    public abstract class CommandFactoryInterfaceGenerator : BaseInterfaceLevelCodeGenerator<CommandFactoryInterfaceFeatureFlags, CommandFactoryInterfaceGeneratorProcessor>
    {
        protected override string GetNamespace()
        {
            return "CommandFactories";
        }
    }
}
