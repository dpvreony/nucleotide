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
    /// Generates an Entity Framework DB Set
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    [CodeGenerationAttribute(typeof(EntityFrameworkDbSetGenerator))]
    [Conditional("CodeGeneration")]
    public sealed class GenerateEntityFrameworkDbSetAttribute : BaseCodeGeneratorAttribute
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="nucleotideGenerationModel"></param>
        public GenerateEntityFrameworkDbSetAttribute(Type nucleotideGenerationModel) : base(nucleotideGenerationModel)
        {
        }
    }
}
