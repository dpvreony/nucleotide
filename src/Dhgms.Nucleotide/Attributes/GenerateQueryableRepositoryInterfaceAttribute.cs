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
    /// Generates a Repository Interface that supports searching and results based on IQueryable logic
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    [CodeGenerationAttribute(typeof(QueryableRepositoryIntefaceGenerator))]
    public sealed class GenerateQueryableRepositoryInterfaceAttribute : Attribute
    {
    }
}
