using Dhgms.Nucleotide.Generators.Generators;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Generators.Features.WebApi
{
    public abstract class WebApiClientGenerator : BaseClassLevelCodeGenerator<WebApiClientFeatureFlags, WebApiClientGeneratorProcessor, IEntityGenerationModel>
    {
        protected override string GetNamespace()
        {
            return "ApiClients";
        }
    }
}
