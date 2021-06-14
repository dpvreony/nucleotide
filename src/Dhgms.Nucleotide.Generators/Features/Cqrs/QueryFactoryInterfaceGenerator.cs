using Dhgms.Nucleotide.Generators.Generators;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Generators.Features.Cqrs
{
    /// <summary>
    /// Generator for Query Factory Interface
    /// </summary>
    public abstract class QueryFactoryInterfaceGenerator : BaseInterfaceLevelCodeGenerator<QueryFactoryInterfaceFeatureFlags, QueryFactoryInterfaceGeneratorProcessor, IEntityGenerationModel>
    {
        protected override string GetNamespace()
        {
            return "QueryFactories";
        }
    }
}
