using Dhgms.Nucleotide.Generators.Generators;
using Dhgms.Nucleotide.Generators.Models;

namespace Dhgms.Nucleotide.Generators.Features.Database
{
    public abstract class ForiegnKeyInterfaceGenerator : BaseGenerator<ForiegnKeyInterfaceFeatureFlags, ForiegnKeyInterfaceGeneratorProcessor, IEntityGenerationModel>
    {
        /// <inheritdoc />
        protected override string GetNamespace()
        {
            return "Database";
        }
    }
}