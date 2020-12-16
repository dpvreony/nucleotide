using System;
using System.Collections.Generic;
using System.Linq;
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
    public class UnkeyedModelClassGenerator : BaseClassLevelCodeGenerator<UnkeyedModelClassFeatureFlags, UnkeyedModelClassGeneratorProcessor, GenerateUnkeyedModelClassAttribute>
    {
        protected override string GetNamespace() => "Models";
    }
}
