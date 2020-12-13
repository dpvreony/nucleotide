using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Helpers;
using Dhgms.Nucleotide.Model;
using Dhgms.Nucleotide.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Features.EntityFramework
{
    /// <summary>
    /// Code Generator for Entity Framework DB Context
    /// </summary>
    public sealed class EntityFrameworkDbContextGenerator : BaseGenerator<EntityFrameworkDbContextFeatureFlags, EntityFrameworkDbContextGeneratorProcessor>
    {
        protected override string GetNamespace()
        {
            return "EfModels";
        }
    }
}
