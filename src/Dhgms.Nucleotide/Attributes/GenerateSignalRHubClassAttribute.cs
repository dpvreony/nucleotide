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
    /// Generate a SignalR Hub Interface associated with this class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    [CodeGenerationAttribute(typeof(SignalRHubClassGenerator))]
    public sealed class GenerateSignalRHubClassAttribute : BaseCodeGeneratorAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nucleotideGenerationModel"></param>
        public GenerateSignalRHubClassAttribute(Type nucleotideGenerationModel) : base(nucleotideGenerationModel)
        {
        }
    }
}