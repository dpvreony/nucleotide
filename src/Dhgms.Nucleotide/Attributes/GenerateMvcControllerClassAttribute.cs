﻿using System;
using System.Diagnostics;
using CodeGeneration.Roslyn;
using Dhgms.Nucleotide.Features.Mvc;
using Dhgms.Nucleotide.Model;

namespace Dhgms.Nucleotide.Attributes
{
    /// <summary>
    /// Generate a Web API service.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    [CodeGenerationAttribute(typeof(MvcControllerGenerator))]
    [Conditional("CodeGeneration")]
    public sealed class GenerateMvcControllerClassAttribute : Attribute
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="nucleotideGenerationModel"></param>
        public GenerateMvcControllerClassAttribute(Type nucleotideGenerationModel)
        {
            this.NucleotideGenerationModel = Activator.CreateInstance(nucleotideGenerationModel) as INucleotideGenerationModel;
        }

        /// <summary>
        ///
        /// </summary>
        public INucleotideGenerationModel NucleotideGenerationModel { get; }
    }
}