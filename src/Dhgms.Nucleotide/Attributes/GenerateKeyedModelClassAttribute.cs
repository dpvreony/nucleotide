using System;
using System.Diagnostics;
using CodeGeneration.Roslyn;
using Dhgms.Nucleotide.Features.Model;
using Dhgms.Nucleotide.Generators;

namespace Dhgms.Nucleotide.Attributes
{
    /// <summary>
    /// Generate the models associate to this class
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    [CodeGenerationAttribute(typeof(KeyedModelClassGenerator))]
    [Conditional("CodeGeneration")]
    public sealed class GenerateKeyedModelClassAttribute : BaseCodeGeneratorAttribute
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="nucleotideGenerationModel"></param>
        public GenerateKeyedModelClassAttribute(Type nucleotideGenerationModel) : base(nucleotideGenerationModel)
        {
        }
    }
}