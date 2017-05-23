// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IClassGenerationParameters.cs" company="DHGMS Solutions">
//   Licensed under GNU General Public License version 2 (GPLv2)
// </copyright>
// <summary>
//   Interface for the class generation parameters
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Dhgms.Nucleotide.Model
{
    using Dhgms.Nucleotide.PropertyInfo;

    /// <summary>
    /// Interface for the class generation parameters.
    /// </summary>
    public interface IClassGenerationParameters
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

        /// <summary>
        /// Gets the type of key used on the model.
        /// </summary>
        KeyType KeyType { get; }

        /// <summary>
        /// Gets the collection of properties for the class.
        /// </summary>
        PropertyInfoBase[] Properties { get; }

        /// <summary>
        /// Gets the collection of properties for the inherited base class, if any.
        /// </summary>
        PropertyInfoBase[] BaseClassProperties { get; }

        /// <summary>
        /// Gets the company name.
        /// </summary>
        string CompanyName { get; }

        /// <summary>
        /// Gets the copyright banner.
        /// </summary>
        string[] CopyrightBanner { get; }

        /// <summary>
        /// Gets the copyright start year.
        /// </summary>
        int CopyrightStartYear { get; }

        /// <summary>
        /// Gets name of the base information class.
        /// </summary>
        string BaseClassName { get; }

        /// <summary>
        /// Gets the class remarks.
        /// </summary>
        string ClassRemarks { get; }
    }
}
