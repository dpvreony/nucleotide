using Dhgms.Nucleotide.Generators.Generators;
using Dhgms.Nucleotide.Generators.Models;

namespace Dhgms.Nucleotide.Generators.Features.Logging
{
    public abstract class CrudControllerLoggerMessageActionGenerator : BaseClassLevelCodeGenerator<CrudControllerLoggerMessageActionFeatureFlags, CrudControllerLoggerMessageActionGeneratorProcessor, IEntityGenerationModel>
    {
        protected override string GetNamespace()
        {
            return "LogMessageActions";
        }
    }
}
