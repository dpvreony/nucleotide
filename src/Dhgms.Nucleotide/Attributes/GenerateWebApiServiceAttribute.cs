using System;
using CodeGeneration.Roslyn;
using Dhgms.Nucleotide.Generators;

namespace Dhgms.Nucleotide.Attributes
{
    /// <summary>
    /// Generate a Web API service.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    [CodeGenerationAttribute(typeof(WebApiServiceGenerator))]
    public sealed class GenerateWebApiServiceAttribute : Attribute
    {
        
    }
}