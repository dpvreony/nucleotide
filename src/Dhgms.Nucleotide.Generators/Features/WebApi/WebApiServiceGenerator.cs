using Dhgms.Nucleotide.Generators.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Generators.Features.WebApi
{
    /// <summary>
    /// Generates the Web API service
    /// </summary>
    public abstract class WebApiServiceGenerator : BaseClassLevelCodeGenerator<WebApiServiceFeatureFlags, WebApiServiceGeneratorProcessor>
    {
        protected override string GetNamespace()
        {
            return "ApiControllers";
        }
    }
}
