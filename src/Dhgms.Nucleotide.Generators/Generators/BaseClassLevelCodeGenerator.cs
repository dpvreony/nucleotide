using Dhgms.Nucleotide.Generators.GeneratorProcessors;

namespace Dhgms.Nucleotide.Generators
{
    /// <summary>
    /// Base class for a code generator that generates code based on the Class Level of Generation Metadata.
    /// </summary>
    public abstract class BaseClassLevelCodeGenerator<TFeatureFlags, TGeneratorProcessor> : BaseGenerator<TFeatureFlags, TGeneratorProcessor>
        where TFeatureFlags : class
        where TGeneratorProcessor : BaseClassLevelCodeGeneratorProcessor, new()
    {
    }
}
