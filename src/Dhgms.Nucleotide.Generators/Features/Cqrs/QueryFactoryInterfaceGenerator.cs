using Dhgms.Nucleotide.Generators.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Generators.Features.Cqrs
{
    /// <summary>
    /// Generator for Query Factory Interface
    /// </summary>
    public abstract class QueryFactoryInterfaceGenerator : BaseInterfaceLevelCodeGenerator<QueryFactoryInterfaceFeatureFlags, QueryFactoryInterfaceGeneratorProcessor>
    {
        protected override string GetNamespace()
        {
            return "QueryFactories";
        }
    }
}
