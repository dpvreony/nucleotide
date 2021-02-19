using Dhgms.Nucleotide.Generators.Generators;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Generators.Features.Cqrs
{
    public abstract class CommandInterfaceGenerator : BaseInterfaceLevelCodeGenerator<CommandInterfaceFeatureFlags, CommandInterfaceGeneratorProcessor, IEntityGenerationModel>
    {
        protected override string GetNamespace() => "Commands";
    }
}
