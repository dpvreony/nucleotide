using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Generators.Features.WebApi;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Features.WebApi
{
    /// <summary>
    /// Generates the Web API service
    /// </summary>
    [Generator]
    public sealed class WebApiServiceGenerator : BaseClassLevelCodeGenerator<WebApiServiceFeatureFlags, WebApiServiceGeneratorProcessor>
    {
        protected override string GetNamespace()
        {
            return "ApiControllers";
        }
    }
}
