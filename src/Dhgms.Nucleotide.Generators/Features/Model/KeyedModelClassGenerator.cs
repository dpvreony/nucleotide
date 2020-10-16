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
    public class KeyedModelClassGenerator : BaseClassLevelCodeGenerator<KeyedModelClassFeatureFlags, KeyedModelClassGeneratorProcessor>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyedModelClassGenerator"/> class.
        /// </summary>
        public KeyedModelClassGenerator(AttributeData attributeData) : base(attributeData)
        {
        }

        protected override string GetNamespace() => "Models";
    }
}
