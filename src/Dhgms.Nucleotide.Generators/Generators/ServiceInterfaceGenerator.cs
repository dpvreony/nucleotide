using Dhgms.Nucleotide.Generators.GeneratorProcessors;

namespace Dhgms.Nucleotide.Generators.Generators
{
    /// <summary>
    /// Generator for Service Interface
    /// </summary>
    public abstract class ServiceInterfaceGenerator : BaseInterfaceLevelCodeGenerator<ServiceInterfaceFeatureFlags, ServiceInterfaceGeneratorProcessor>
    {
        protected override string GetNamespace()
        {
            return "Services";
        }
    }
}
