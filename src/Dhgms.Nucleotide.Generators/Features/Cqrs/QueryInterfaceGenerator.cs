using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Features.Cqrs
{
    /// <summary>
    /// Generator for Query Interface
    /// </summary>
    [Generator]
    public sealed class QueryInterfaceGenerator : BaseInterfaceLevelCodeGenerator<QueryInterfaceFeatureFlag, QueryInterfaceGeneratorProcessor>
    {
        protected override string GetNamespace() => "Queries";
    }
}
