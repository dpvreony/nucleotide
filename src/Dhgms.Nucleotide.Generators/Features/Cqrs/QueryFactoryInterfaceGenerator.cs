using System;
using System.Collections.Generic;
using Dhgms.Nucleotide.Attributes;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Features.Cqrs
{
    /// <summary>
    /// Generator for Query Factory Interface
    /// </summary>
    [Generator]
    public sealed class QueryFactoryInterfaceGenerator : BaseInterfaceLevelCodeGenerator<QueryFactoryInterfaceFeatureFlags, QueryFactoryInterfaceGeneratorProcessor, GenerateQueryFactoryInterfaceAttribute>
    {
        protected override string GetNamespace()
        {
            return "QueryFactories";
        }
    }
}
