namespace Dhgms.Nucleotide.Generators.Models
{
    public interface IPropertyGenerationModel : INameable
    {
        string Type { get; }

        PropertyAccessorFlags PropertyAccessorFlags { get; }
    }
}
