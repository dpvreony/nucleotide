namespace Dhgms.Nucleotide.Generators.Models
{
    /// <summary>
    /// Model that Generator Attributes should be attached to
    /// </summary>
    public interface INucleotideGenerationModel<out TGenerationModel>
    {
        /// <summary>
        /// Gets a collection of Class Generation Parameters.
        /// </summary>
        TGenerationModel[] EntityGenerationModel { get; }

        string RootNamespace { get; }
    }
}