namespace Dhgms.Nucleotide.Generators
{
    using System.Collections.Generic;

    using Dhgms.Nucleotide.Model;

    /// <summary>
    /// Generator Interface
    /// </summary>
    public interface IGenerator
    {
        /// <summary>
        /// Entry point for generating the code
        /// </summary>
        /// <param name="classes">
        /// Collection of classes to generate an interface for
        /// </param>
        /// <param name="doCopyrightHeader">
        /// Flag indicating whether to add the copyright header to the top of the output. Can be used to suppress output when placing all generated code in a single file.
        /// </param>
        /// <param name="suppressExceptionsAsCode">
        /// If an exception occurs instead of throwing the exception, they are output as code content. This is typically more useful in a transform environment so you can see the error in the affected file.
        /// </param>
        /// <returns>
        /// C# code
        /// </returns>
        string Generate(
            IList<IClassGenerationParameters> classes,
            bool doCopyrightHeader = true,
            bool suppressExceptionsAsCode = true);
    }
}
