﻿using Dhgms.Nucleotide.Generators.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Generators.Features.Model
{
    public abstract class KeyedModelInterfaceGenerator : BaseInterfaceLevelCodeGenerator<KeyedModelInterfaceFeatureFlags, KeyedModelInterfaceGeneratorProcessor>
    {
        protected override string GetNamespace()
        {
            return "Models";
        }
    }
}