using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Generators
{
    /// <summary>
    /// Generator for Service Interface
    /// </summary>
    public class ServiceInterfaceGenerator : BaseInterfaceLevelCodeGenerator<ServiceInterfaceFeatureFlags, ServiceInterfaceGeneratorProcessor>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceInterfaceGenerator"/> class.
        /// </summary>
        public ServiceInterfaceGenerator(AttributeData attributeData) : base(attributeData)
        {
        }

        protected override string GetNamespace()
        {
            return "Services";
        }
    }
}
