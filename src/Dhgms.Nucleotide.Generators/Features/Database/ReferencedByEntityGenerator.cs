using Dhgms.Nucleotide.Generators.Generators;
using Dhgms.Nucleotide.Generators.Models;

namespace Dhgms.Nucleotide.Generators.Features.Database
{
    public abstract class ReferencedByEntityGenerator : BaseGenerator<ReferencedByEntityFeatureFlags, ReferencedByEntityGeneratorProcessor, IEntityGenerationModel>
    {
        /// <inheritdoc />
        protected override string GetNamespace()
        {
            return "Database";
        }
    }
}
