using System;
using System.Collections.Generic;
using System.Linq;
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
    public class UnkeyedModelClassGenerator : BaseClassLevelCodeGenerator<UnkeyedModelClassFeatureFlags, UnkeyedModelClassGeneratorProcessor>
    {
        protected override string GetNamespace() => "Models";
    }
}
