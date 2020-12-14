using System;
using System.Collections.Generic;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Model;
using Dhgms.Nucleotide.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Features.Model
{
    /// <summary>
    /// Generates models
    /// </summary>
    [Generator]
    public class KeyedModelClassGenerator : BaseClassLevelCodeGenerator<KeyedModelClassFeatureFlags, KeyedModelClassGeneratorProcessor>
    {
        protected override string GetNamespace() => "Models";
    }
}
