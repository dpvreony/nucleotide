using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Features.Cqrs
{
    /// <summary>
    /// Generator for Query Factory Interface
    /// </summary>
    [Generator]
    public abstract class QueryFactoryInterfaceGenerator : BaseInterfaceLevelCodeGenerator<QueryFactoryInterfaceFeatureFlags, QueryFactoryInterfaceGeneratorProcessor>
    {
        protected override string GetNamespace()
        {
            return "QueryFactories";
        }
    }
}
