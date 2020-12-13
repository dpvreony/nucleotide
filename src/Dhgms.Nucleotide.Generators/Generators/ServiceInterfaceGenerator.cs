using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Generators
{
    /// <summary>
    /// Generator for Service Interface
    /// </summary>
    public class ServiceInterfaceGenerator : BaseInterfaceLevelCodeGenerator<ServiceInterfaceFeatureFlags, ServiceInterfaceGeneratorProcessor>
    {
        protected override string GetNamespace()
        {
            return "Services";
        }
    }
}
