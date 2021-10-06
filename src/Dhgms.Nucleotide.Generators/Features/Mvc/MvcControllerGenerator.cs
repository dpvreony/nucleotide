using Dhgms.Nucleotide.Generators.Generators;
using Dhgms.Nucleotide.Generators.Models;

namespace Dhgms.Nucleotide.Generators.Features.Mvc
{
    /// <summary>
    /// Generates the MVC Controllers
    /// </summary>
    public abstract class MvcControllerGenerator : BaseClassLevelCodeGenerator<MvcControllerFeatureFlags, MvcControllerGeneratorProcessor, IEntityGenerationModel>
    {
        protected override string GetNamespace()
        {
            return "MvcControllers";
        }
    }
}
