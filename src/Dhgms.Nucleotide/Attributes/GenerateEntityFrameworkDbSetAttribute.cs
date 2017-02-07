﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGeneration.Roslyn;
using Dhgms.Nucleotide.Generators;

namespace Dhgms.Nucleotide.Attributes
{
    /// <summary>
    /// Generates an Entity Framework DB Set
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    [CodeGenerationAttribute(typeof(EntityFrameworkDbSetGenerator))]
    public sealed class GenerateEntityFrameworkDbSetAttribute : Attribute
    {
        //public GenerateEntityFrameworkDbSetAttribute()
        //{
            
        //}
    }
}
