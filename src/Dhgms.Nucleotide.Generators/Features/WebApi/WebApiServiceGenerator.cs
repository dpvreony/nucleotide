using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Generators.Features.WebApi;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Features.WebApi
{
    /// <summary>
    /// Generates the Web API service
    /// </summary>
    public sealed class WebApiServiceGenerator : BaseClassLevelCodeGenerator<WebApiServiceFeatureFlags, WebApiServiceGeneratorProcessor>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebApiServiceGenerator"/> class.
        /// </summary>
        public WebApiServiceGenerator(AttributeData attributeData) : base(attributeData)
        {
        }

        protected override string GetNamespace()
        {
            return "ApiControllers";
        }
    }
}
