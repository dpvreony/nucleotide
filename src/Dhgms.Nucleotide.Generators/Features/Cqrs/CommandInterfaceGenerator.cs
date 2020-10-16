using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Features.Cqrs
{
    public sealed class CommandInterfaceGenerator : BaseInterfaceLevelCodeGenerator<CommandInterfaceFeatureFlags, CommandInterfaceGeneratorProcessor>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryInterfaceGenerator"/> class.
        /// </summary>
        public CommandInterfaceGenerator(AttributeData attributeData) : base(attributeData)
        {
        }

        protected override string GetNamespace() => "Commands";
    }
}
