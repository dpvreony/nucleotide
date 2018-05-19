using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using CodeGeneration.Roslyn;
using Dhgms.Nucleotide.Features.Model;
using Dhgms.Nucleotide.Generators;

namespace Dhgms.Nucleotide.Attributes
{
    /// <summary>
    /// Generate the models interfaces associate to this class
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    [CodeGenerationAttribute(typeof(KeyedModelInterfaceGenerator))]
    [Conditional("CodeGeneration")]
    public sealed class GenerateKeyedModelInterfaceAttribute : BaseCodeGeneratorAttribute
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="nucleotideGenerationModel"></param>
        public GenerateKeyedModelInterfaceAttribute(Type nucleotideGenerationModel) : base(nucleotideGenerationModel)
        {
        }
    }
}
