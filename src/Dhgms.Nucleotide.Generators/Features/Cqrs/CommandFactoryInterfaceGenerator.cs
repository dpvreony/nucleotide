using Dhgms.Nucleotide.Generators.Generators;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Generators.Features.Cqrs
{
    /// <summary>
    /// Generator for Command Factory Interface
    /// </summary>
    public abstract class CommandFactoryInterfaceGenerator : BaseInterfaceLevelCodeGenerator<CommandFactoryInterfaceFeatureFlags, CommandFactoryInterfaceGeneratorProcessor, IEntityGenerationModel>
    {
        protected override string GetNamespace()
        {
            return "CommandFactories";
        }
    }
}
