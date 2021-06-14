using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Models;

namespace Dhgms.Nucleotide.Generators.Generators
{
    /// <summary>
    /// Generator for Service Interface
    /// </summary>
    public abstract class ServiceInterfaceGenerator : BaseInterfaceLevelCodeGenerator<ServiceInterfaceFeatureFlags, ServiceInterfaceGeneratorProcessor, IEntityGenerationModel>
    {
        protected override string GetNamespace()
        {
            return "Services";
        }
    }
}
