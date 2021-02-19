using Dhgms.Nucleotide.Generators.GeneratorProcessors;

namespace Dhgms.Nucleotide.Generators.Models
{
    public interface IObjectGenerationModel : IClassName
    {
        /// <summary>
        /// Gets the main namespace.
        /// </summary>
        string MainNamespaceName { get; }

        /// <summary>
        /// Gets the sub namespace, if any.
        /// </summary>
        string SubNamespace { get; }

        /// <summary>
        /// Gets the name of the information class.
        /// </summary>
        string ClassName { get; }

    }
}