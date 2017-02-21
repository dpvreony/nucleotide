﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGeneration.Roslyn;
using Dhgms.Nucleotide.Generators;

namespace Dhgms.Nucleotide.Attributes
{
    /// <summary>
    /// Generate a Query Class associated with this class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    [CodeGenerationAttribute(typeof(QueryClassGenerator))]
    public sealed class GenerateQueryClassAttribute : BaseCodeGeneratorAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nucleotideGenerationModel"></param>
        public GenerateQueryClassAttribute(Type nucleotideGenerationModel) : base(nucleotideGenerationModel)
        {
        }
    }
}