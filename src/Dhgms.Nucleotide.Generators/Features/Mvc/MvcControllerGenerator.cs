using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Attributes;
using Dhgms.Nucleotide.Features.WebApi;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Helpers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Features.Mvc
{
    /// <summary>
    /// Generates the MVC Controllers
    /// </summary>
    public sealed class MvcControllerGenerator : BaseClassLevelCodeGenerator<MvcControllerFeatureFlags, MvcControllerGeneratorProcessor, GenerateMvcControllerClassAttribute>
    {
        protected override string GetNamespace()
        {
            return "MvcControllers";
        }
    }
}
