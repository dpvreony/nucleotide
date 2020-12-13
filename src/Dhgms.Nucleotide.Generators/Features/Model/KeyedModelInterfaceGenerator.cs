using System;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Model;
using Dhgms.Nucleotide.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Features.Model
{
    public sealed class KeyedModelInterfaceGenerator : BaseInterfaceLevelCodeGenerator<KeyedModelInterfaceFeatureFlags, KeyedModelInterfaceGeneratorProcessor>
    {
        protected override string GetNamespace()
        {
            return "Models";
        }
    }
}