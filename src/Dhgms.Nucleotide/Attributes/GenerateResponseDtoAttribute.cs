using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGeneration.Roslyn;
using Dhgms.Nucleotide.Generators;

namespace Dhgms.Nucleotide.Attributes
{
    /// <summary>
    /// Generate a Response Dto class associated with this class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    [CodeGenerationAttribute(typeof(ResponseDtoClassGenerator))]
    [Conditional("CodeGeneration")]
    public sealed class GenerateResponseDtoAttribute : BaseCodeGeneratorAttribute
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="nucleotideGenerationModel"></param>
        public GenerateResponseDtoAttribute(Type nucleotideGenerationModel) : base(nucleotideGenerationModel)
        {
        }
    }
}