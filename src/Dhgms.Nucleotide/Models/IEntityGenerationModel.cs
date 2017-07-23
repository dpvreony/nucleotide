// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntityGenerationModel.cs" company="DHGMS Solutions">
//   Licensed under GNU General Public License version 2 (GPLv2)
// </copyright>
// <summary>
//   Interface for the class generation parameters
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Dhgms.Nucleotide.Models;

namespace Dhgms.Nucleotide.Model
{
    using Dhgms.Nucleotide.PropertyInfo;

    /// <summary>
    /// Interface for the class generation parameters.
    /// </summary>
    public interface IEntityGenerationModel : IObjectGenerationModel
    {
        /// <summary>
        /// Gets the type of key used on the model.
        /// </summary>
        KeyType KeyType { get; }

        /// <summary>
        /// Gets the collection of properties for the class.
        /// </summary>
        PropertyInfoBase[] Properties { get; }

        IEntityGenerationModel BaseTypeEntityGenerationModel { get; }

        IInterfaceGenerationModel[] InterfaceGenerationModels { get; }


        /// <summary>
        /// Gets the company name.
        /// </summary>
        //string CompanyName { get; }

        /// <summary>
        /// Gets the copyright banner.
        /// </summary>
        //string[] CopyrightBanner { get; }

        /// <summary>
        /// Gets the copyright start year.
        /// </summary>
        //int CopyrightStartYear { get; }

        /// <summary>
        /// Gets name of the base information class.
        /// </summary>
        //string BaseClassName { get; }

        /// <summary>
        /// Gets the class remarks.
        /// </summary>
        string ClassRemarks { get; }
    }
}
