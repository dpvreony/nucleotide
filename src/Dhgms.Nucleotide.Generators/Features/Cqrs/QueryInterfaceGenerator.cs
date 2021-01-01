using Dhgms.Nucleotide.Generators.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Generators.Features.Cqrs
{
    /// <summary>
    /// Generator for Query Interface
    /// </summary>
    [Generator]
    public abstract class QueryInterfaceGenerator : BaseInterfaceLevelCodeGenerator<QueryInterfaceFeatureFlag, QueryInterfaceGeneratorProcessor>
    {
        protected override string GetNamespace() => "Queries";
    }
}
