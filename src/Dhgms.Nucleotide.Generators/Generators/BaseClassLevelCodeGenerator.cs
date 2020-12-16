using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Attributes;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Helpers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators
{
    /// <summary>
    /// Base class for a code generator that generates code based on the Class Level of Generation Metadata.
    /// </summary>
    public abstract class BaseClassLevelCodeGenerator<TFeatureFlags, TGeneratorProcessor, TAttribute> : BaseGenerator<TFeatureFlags, TGeneratorProcessor, TAttribute>
        where TFeatureFlags : class
        where TGeneratorProcessor : BaseClassLevelCodeGeneratorProcessor, new()
        where TAttribute : BaseCodeGeneratorAttribute
    {
    }
}
