﻿using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Features.SignalR
{
    /// <summary>
    /// Generator for SignalR Hub Interface
    /// </summary>
    public sealed class SignalRHubInterfaceGenerator : BaseInterfaceLevelCodeGenerator<SignalRHubInterfaceFeatureFlags, SignalRHubInterfaceGeneratorProcessor>
    {
        protected override string GetNamespace()
        {
            return "Hubs";
        }
    }
}
