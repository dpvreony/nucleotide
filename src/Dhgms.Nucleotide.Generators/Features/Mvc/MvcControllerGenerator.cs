using Dhgms.Nucleotide.Generators.Generators;

namespace Dhgms.Nucleotide.Generators.Features.Mvc
{
    /// <summary>
    /// Generates the MVC Controllers
    /// </summary>
    public abstract class MvcControllerGenerator : BaseClassLevelCodeGenerator<MvcControllerFeatureFlags, MvcControllerGeneratorProcessor>
    {
        protected override string GetNamespace()
        {
            return "MvcControllers";
        }
    }
}
