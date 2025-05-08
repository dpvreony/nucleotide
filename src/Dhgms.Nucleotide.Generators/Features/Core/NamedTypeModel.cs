namespace Dhgms.Nucleotide.Generators.Features.Core
{
    public record NamedTypeModel(string? ContainingNamespace, string TypeName)
    {
        public string GetFullyQualifiedTypeName()
        {
            if (string.IsNullOrWhiteSpace(ContainingNamespace))
            {
                return TypeName;
            }

            return $"global::{ContainingNamespace}.{TypeName}";
        }
    }
}
