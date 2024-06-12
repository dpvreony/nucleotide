using System.Collections.Generic;

namespace Dhgms.Nucleotide.Generators.Features.ConceptAsString
{
    /// <summary>
    /// Represents the request model for the Concept As String feature.
    /// </summary>
    /// <param name="MappingDictionary">A dictionary of namespaces and classes that are a concept that can be represented as a string.</param>
    public sealed record ConceptAsStringRequestModel(IReadOnlyDictionary<string, IReadOnlyCollection<string>> MappingDictionary);
}
