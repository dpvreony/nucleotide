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
    /// Generate a Service Interface associated with this class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    [CodeGenerationAttribute(typeof(ServiceInterfaceGenerator))]
    [Conditional("CodeGeneration")]
    public sealed class GenerateServiceInterfaceAttribute : BaseCodeGeneratorAttribute
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="nucleotideGenerationModel"></param>
        public GenerateServiceInterfaceAttribute(Type nucleotideGenerationModel) : base(nucleotideGenerationModel)
        {
        }
    }
}
