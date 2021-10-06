using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Models;

namespace Dhgms.Nucleotide.Generators.Generators
{
    /// <summary>
    /// Base class for a code generator that generates code based on the Class Level of Generation Metadata.
    /// </summary>
    public abstract class BaseClassLevelCodeGenerator<TFeatureFlags, TGeneratorProcessor, TGenerationModel> : BaseGenerator<TFeatureFlags, TGeneratorProcessor, TGenerationModel>
        where TFeatureFlags : class
        where TGeneratorProcessor : BaseClassLevelCodeGeneratorProcessor<TGenerationModel>, new()
        where TGenerationModel : IClassName
    {
    }
}
