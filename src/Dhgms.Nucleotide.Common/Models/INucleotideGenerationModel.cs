namespace Dhgms.Nucleotide.Common.Models
{
    /// <summary>
    /// Model that Generator Attributes should be attached to
    /// </summary>
    public interface INucleotideGenerationModel
    {
        /// <summary>
        /// Gets a collection of Class Generation Parameters.
        /// </summary>
        IEntityGenerationModel[] EntityGenerationModel { get; }

        string RootNamespace { get; }
    }
}