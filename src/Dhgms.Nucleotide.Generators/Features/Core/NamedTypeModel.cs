namespace Dhgms.Nucleotide.Generators.Features.Core
{
    public record NamedTypeModel(string ContainingNamespace, string TypeName)
    {
        public string GetFullyQualifiedTypeName()
        {
            return $"global::{ContainingNamespace}.{TypeName}";
        }
    }
}
