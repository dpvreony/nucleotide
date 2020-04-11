using System;
using System.Diagnostics;
using System.Dynamic;
using CodeGeneration.Roslyn;
using Dhgms.Nucleotide.Features.WebApi;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Model;

namespace Dhgms.Nucleotide.Attributes
{
    /// <summary>
    /// Generate a Web API service.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    [CodeGenerationAttribute(typeof(WebApiServiceGenerator))]
    [Conditional("CodeGeneration")]
    public sealed class GenerateWebApiServiceClassAttribute : Attribute
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="nucleotideGenerationModel"></param>
        public GenerateWebApiServiceClassAttribute(Type nucleotideGenerationModel)
        {
            this.NucleotideGenerationModel = Activator.CreateInstance(nucleotideGenerationModel) as INucleotideGenerationModel;
        }

        /// <summary>
        ///
        /// </summary>
        public INucleotideGenerationModel NucleotideGenerationModel { get; }
    }
}