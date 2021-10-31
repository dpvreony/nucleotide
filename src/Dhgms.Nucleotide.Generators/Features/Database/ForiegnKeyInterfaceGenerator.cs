using Dhgms.Nucleotide.Generators.Generators;

namespace Dhgms.Nucleotide.Generators.Features.Database
{
    public abstract class ForiegnKeyInterfaceGenerator : BaseGenerator<ForiegnKeyInterfaceFeatureFlags, ForiegnKeyInterfaceGeneratorProcessor, ReferencedByEntityGenerationModel>
    {
        /// <inheritdoc />
        protected override string GetNamespace()
        {
            return "Database";
        }
    }
}