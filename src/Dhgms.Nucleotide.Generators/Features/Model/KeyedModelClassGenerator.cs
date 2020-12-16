using System;
using System.Collections.Generic;
using Dhgms.Nucleotide.Attributes;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Features.Model
{
    /// <summary>
    /// Generates models
    /// </summary>
    [Generator]
    public class KeyedModelClassGenerator : BaseClassLevelCodeGenerator<KeyedModelClassFeatureFlags, KeyedModelClassGeneratorProcessor, GenerateKeyedModelClassAttribute>
    {
        protected override string GetNamespace() => "Models";
    }
}
