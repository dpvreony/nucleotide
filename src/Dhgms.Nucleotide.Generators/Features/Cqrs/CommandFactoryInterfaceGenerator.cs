using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Features.Cqrs
{
    /// <summary>
    /// Generator for Command Factory Interface
    /// </summary>
    public sealed class CommandFactoryInterfaceGenerator : BaseInterfaceLevelCodeGenerator<CommandFactoryInterfaceFeatureFlags, CommandFactoryInterfaceGeneratorProcessor>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandFactoryInterfaceGenerator"/> class.
        /// </summary>
        public CommandFactoryInterfaceGenerator(AttributeData attributeData) : base(attributeData)
        {
        }

        protected override string GetNamespace()
        {
            return "CommandFactories";
        }
    }
}
