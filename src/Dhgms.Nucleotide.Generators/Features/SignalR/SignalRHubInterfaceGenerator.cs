using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Features.SignalR
{
    /// <summary>
    /// Generator for SignalR Hub Interface
    /// </summary>
    public sealed class SignalRHubInterfaceGenerator : BaseInterfaceLevelCodeGenerator<SignalRHubInterfaceFeatureFlags, SignalRHubInterfaceGeneratorProcessor>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SignalRHubInterfaceGenerator"/> class.
        /// </summary>
        public SignalRHubInterfaceGenerator(AttributeData attributeData) : base(attributeData)
        {
        }
        protected override string GetNamespace()
        {
            return "Hubs";
        }
    }
}
