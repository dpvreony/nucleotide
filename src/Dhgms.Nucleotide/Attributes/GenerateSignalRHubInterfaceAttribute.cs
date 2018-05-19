using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGeneration.Roslyn;
using Dhgms.Nucleotide.Features.SignalR;
using Dhgms.Nucleotide.Generators;

namespace Dhgms.Nucleotide.Attributes
{
    /// <summary>
    /// Generate a SignalR Hub Interface associated with this class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    [CodeGenerationAttribute(typeof(SignalRHubInterfaceGenerator))]
    [Conditional("CodeGeneration")]
    public sealed class GenerateSignalRHubInterfaceAttribute : BaseCodeGeneratorAttribute
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="nucleotideGenerationModel"></param>
        public GenerateSignalRHubInterfaceAttribute(Type nucleotideGenerationModel) : base(nucleotideGenerationModel)
        {
        }
    }
}
