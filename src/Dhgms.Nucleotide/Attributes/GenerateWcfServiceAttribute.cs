using System;
using CodeGeneration.Roslyn;
using Dhgms.Nucleotide.Generators;

namespace Dhgms.Nucleotide.Attributes
{
    /// <summary>
    /// Generate a WCF service associated with this class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    [CodeGenerationAttribute(typeof(WcfServiceGenerator))]
    public sealed class GenerateWcfServiceAttribute : Attribute
    {
        
    }
}