namespace Dhgms.Nucleotide.Model
{
    /// <summary>
    /// Model that Generator Attributes should be attached to
    /// </summary>
    public interface INucleotideGenerationModel
    {
        /// <summary>
        /// Gets a collection of Class Generation Parameters.
        /// </summary>
        ClassGenerationParameters[] ClassGenerationParameters { get; }
    }
}