using Dhgms.Nucleotide.Generators.Generators;

namespace Dhgms.Nucleotide.Generators.Features.SignalR
{
    /// <summary>
    /// Generator for SignalR Hub Interface
    /// </summary>
    public abstract class SignalRHubInterfaceGenerator : BaseInterfaceLevelCodeGenerator<SignalRHubInterfaceFeatureFlags, SignalRHubInterfaceGeneratorProcessor>
    {
        protected override string GetNamespace()
        {
            return "Hubs";
        }
    }
}
