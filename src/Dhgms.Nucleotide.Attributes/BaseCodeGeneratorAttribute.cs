using System;
using System.Diagnostics;

namespace Dhgms.Nucleotide.Attributes
{
    /// <summary>
    /// Base class for a code generation
    /// </summary>
    [Conditional("CodeGeneration")]
    public class BaseCodeGeneratorAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nucleotideGenerationModel"></param>
        public BaseCodeGeneratorAttribute(Type nucleotideGenerationModel)
        {
            this.NucleotideGenerationModel = nucleotideGenerationModel;
        }

        /// <summary>
        /// 
        /// </summary>
        public Type NucleotideGenerationModel { get; }
    }
}
