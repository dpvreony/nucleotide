// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IClassGenerationParameters.cs" company="DHGMS Solutions">
//   Licensed under GNU General Public License version 2 (GPLv2)
// </copyright>
// <summary>
//   Interface for the class generation parameters
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Dhgms.Nucleotide.Model.Info.Interface
{
    using Dhgms.Nucleotide.Model.Info.PropertyInfo;

    /// <summary>
    /// Interface for the class generation parameters.
    /// </summary>
    public interface IClassGenerationParameters
    {
        /// <summary>
        /// Gets or sets the main namespace
        /// </summary>
        string MainNamespaceName { get; set; }

        /// <summary>
        /// Gets or sets the sub namespace, if any
        /// </summary>
        string SubNamespace { get; set; }

        /// <summary>
        /// Gets or sets name of the information class.
        /// </summary>
        string ClassName { get; set; }

        /// <summary>
        /// Gets or sets collection of properties for the class.
        /// </summary>
        Base[] Properties { get; set; }

        /// <summary>
        /// Gets or sets collection of properties for the inherited base class, if any.
        /// </summary>
        Base[] BaseClassProperties { get; set; }
    }
}
