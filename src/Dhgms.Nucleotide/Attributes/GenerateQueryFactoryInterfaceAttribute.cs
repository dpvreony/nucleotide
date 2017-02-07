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
    /// Generate a Query Factory Interface associated with this class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    [CodeGenerationAttribute(typeof(QueryFactoryInterfaceGenerator))]
    public sealed class GenerateQueryFactoryInterfaceAttribute : Attribute
    {
    }
}
