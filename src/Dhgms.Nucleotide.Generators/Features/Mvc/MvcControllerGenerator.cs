using Dhgms.Nucleotide.Generators;

namespace Dhgms.Nucleotide.Features.Mvc
{
    /// <summary>
    /// Generates the MVC Controllers
    /// </summary>
    public sealed class MvcControllerGenerator : BaseClassLevelCodeGenerator<MvcControllerFeatureFlags, MvcControllerGeneratorProcessor>
    {
        protected override string GetNamespace()
        {
            return "MvcControllers";
        }
    }
}
