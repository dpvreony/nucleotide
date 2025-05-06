namespace Dhgms.Nucleotide.Generators.Features.Core
{
    public record NamedTypeModel(string ContainingNamespace, string Name)
    {
        public string GetFullyQualifiedTypeName()
        {
            return $"{ContainingNamespace}.{Name}";
        }
    }
}
