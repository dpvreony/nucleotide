using Dhgms.Nucleotide.Generators.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Generators.Features.WebApi
{
    public abstract class WebApiClientGenerator : BaseClassLevelCodeGenerator<WebApiClientFeatureFlags, WebApiClientGeneratorProcessor>
    {
        protected override string GetNamespace()
        {
            return "ApiClients";
        }
    }
}
