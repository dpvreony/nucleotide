using Dhgms.Nucleotide.Generators.Generators;
using Dhgms.Nucleotide.Generators.Models;

namespace Dhgms.Nucleotide.Generators.Features.SignalR
{
    /// <summary>
    /// Generator for SignalR Hub Interface
    /// </summary>
    public abstract class SignalRHubInterfaceGenerator : BaseInterfaceLevelCodeGenerator<SignalRHubInterfaceFeatureFlags, SignalRHubInterfaceGeneratorProcessor, IEntityGenerationModel>
    {
        protected override string GetNamespace()
        {
            return "Hubs";
        }
    }
}
