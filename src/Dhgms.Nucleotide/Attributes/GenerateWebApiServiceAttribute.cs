using System;
using System.Dynamic;
using CodeGeneration.Roslyn;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Model;

namespace Dhgms.Nucleotide.Attributes
{
    /// <summary>
    /// Generate a Web API service.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    [CodeGenerationAttribute(typeof(WebApiServiceGenerator))]
    public sealed class GenerateWebApiServiceAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nucleotideGenerationModel"></param>
        public GenerateWebApiServiceAttribute(Type nucleotideGenerationModel)
        {
            this.NucleotideGenerationModel = Activator.CreateInstance(nucleotideGenerationModel) as INucleotideGenerationModel;
        }

        /// <summary>
        /// 
        /// </summary>
        public INucleotideGenerationModel NucleotideGenerationModel { get; }
    }
}