using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
