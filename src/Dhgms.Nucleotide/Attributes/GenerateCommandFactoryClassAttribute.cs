using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGeneration.Roslyn;
using Dhgms.Nucleotide.Generators;

namespace Dhgms.Nucleotide.Attributes
{
    /// <summary>
    /// Generate a Command Factory Class associated with this class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    [CodeGenerationAttribute(typeof(CommandFactoryClassGenerator))]
    public sealed class GenerateCommandFactoryClassAttribute : BaseCodeGeneratorAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nucleotideGenerationModel"></param>
        public GenerateCommandFactoryClassAttribute(Type nucleotideGenerationModel) : base(nucleotideGenerationModel)
        {
        }
    }
}
