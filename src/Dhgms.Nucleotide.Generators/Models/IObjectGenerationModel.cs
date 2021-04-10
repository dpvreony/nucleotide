using Dhgms.Nucleotide.Generators.GeneratorProcessors;

namespace Dhgms.Nucleotide.Generators.Models
{
    public interface IObjectGenerationModel : IClassName
    {
        /// <summary>
        /// Gets the main namespace.
        /// </summary>
        string NamespaceName { get; }

        /// <summary>
        /// Gets the name of the information class.
        /// </summary>
        string ClassName { get; }

    }
}