using Dhgms.Nucleotide.Generators.GeneratorProcessors;

namespace Dhgms.Nucleotide.Generators.Generators
{
    /// <summary>
    /// Base class for a code generator that generates code based on the Interface Level of Generation Metadata.
    /// </summary>
    public abstract class BaseInterfaceLevelCodeGenerator<TFeatureFlags, TGeneratorProcessor> : BaseGenerator<TFeatureFlags, TGeneratorProcessor>
        where TFeatureFlags : class
        where TGeneratorProcessor : BaseInterfaceLevelCodeGeneratorProcessor, new()
    {
    }
}
