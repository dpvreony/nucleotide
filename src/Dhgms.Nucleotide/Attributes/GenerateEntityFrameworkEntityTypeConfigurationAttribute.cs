using System;
using System.Diagnostics;
using CodeGeneration.Roslyn;
using Dhgms.Nucleotide.Features.EntityFramework;

namespace Dhgms.Nucleotide.Attributes
{
    [AttributeUsage(AttributeTargets.Assembly)]
    [CodeGenerationAttribute(typeof(EntityFrameworkEntityTypeConfigurationGenerator))]
    [Conditional("CodeGeneration")]
    public class GenerateEntityFrameworkEntityTypeConfigurationAttribute : BaseCodeGeneratorAttribute
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="nucleotideGenerationModel"></param>
        public GenerateEntityFrameworkEntityTypeConfigurationAttribute(Type nucleotideGenerationModel) : base(nucleotideGenerationModel)
        {
        }
    }
}