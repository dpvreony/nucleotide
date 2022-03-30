using Dhgms.Nucleotide.Generators.Generators;
using Dhgms.Nucleotide.Generators.Models;

namespace Dhgms.Nucleotide.Generators.Features.EventId
{
    public abstract class EventIdGenerator: BaseClassLevelCodeGenerator<EventIdFeatureFlags, EventIdGeneratorProcessor, IEntityGenerationModel>
    {
        /// <inheritdoc />
        protected override string GetNamespace()
        {
            return "LoggerMessageActions";
        }
    }
}
