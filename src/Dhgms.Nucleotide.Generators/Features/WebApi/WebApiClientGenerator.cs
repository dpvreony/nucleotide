﻿using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Features.WebApi
{
    public sealed class WebApiClientGenerator : BaseClassLevelCodeGenerator<WebApiClientFeatureFlags, WebApiClientGeneratorProcessor>
    {
        protected override string GetNamespace()
        {
            return "ApiClients";
        }
    }
}
