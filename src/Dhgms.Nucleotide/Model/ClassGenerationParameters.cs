// -----------------------------------------------------------------------
// <copyright file="ClassGenerationParameters.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Dhgms.Nucleotide.Model
{
    using Dhgms.Nucleotide.PropertyInfo;

    /// <summary>
    /// Represents the parameters for generating an data manager classes
    /// </summary>
    public abstract class ClassGenerationParameters : IClassGenerationParameters
    {
        /// <summary>
        /// Gets the main namespace.
        /// </summary>
        public abstract string MainNamespaceName { get; }

        /// <summary>
        /// Gets the sub namespace, if any
        /// </summary>
        public abstract string SubNamespace { get; }

        /// <summary>
        /// Gets the name of the information class.
        /// </summary>
        public abstract string ClassName { get; }

        /// <summary>
        /// Gets the name of the information class.
        /// </summary>
        public abstract string ClassRemarks { get; }

        /// <summary>
        /// Gets the collection of properties for the class.
        /// </summary>
        public abstract PropertyInfoBase[] Properties { get; }

        /// <summary>
        /// Gets the collection of properties for the inherited base class, if any.
        /// </summary>
        public abstract PropertyInfoBase[] BaseClassProperties { get; }

        /// <summary>
        /// Gets the company name.
        /// </summary>
        public abstract string CompanyName { get; }

        /// <summary>
        /// Gets the copyright banner.
        /// </summary>
        public abstract string[] CopyrightBanner { get; }

        /// <summary>
        /// Gets the copyright start year.
        /// </summary>
        public abstract int CopyrightStartYear { get; }

        /// <summary>
        /// Gets the name of the base information class.
        /// </summary>
        public abstract string BaseClassName { get; }
    }
}
