using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
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
    [CodeGenerationAttribute(typeof(WebApiClientGenerator))]
    [Conditional("CodeGeneration")]
    public sealed class GenerateWebApiClientClassAttribute : Attribute
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="nucleotideGenerationModel"></param>
        public GenerateWebApiClientClassAttribute(Type nucleotideGenerationModel)
        {
            this.NucleotideGenerationModel = Activator.CreateInstance(nucleotideGenerationModel) as INucleotideGenerationModel;
        }

        /// <summary>
        ///
        /// </summary>
        public INucleotideGenerationModel NucleotideGenerationModel { get; }
    }
}
