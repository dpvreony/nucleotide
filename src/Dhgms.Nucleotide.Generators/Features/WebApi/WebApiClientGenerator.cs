using Dhgms.Nucleotide.Attributes;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Features.WebApi
{
    [Generator]
    public sealed class WebApiClientGenerator : BaseClassLevelCodeGenerator<WebApiClientFeatureFlags, WebApiClientGeneratorProcessor, GenerateWebApiClientClassAttribute>
    {
        protected override string GetNamespace()
        {
            return "ApiClients";
        }
    }
}
