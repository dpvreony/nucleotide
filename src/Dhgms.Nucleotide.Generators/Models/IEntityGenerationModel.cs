﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntityGenerationModel.cs" company="DHGMS Solutions">
//   Licensed under GNU General Public License version 2 (GPLv2)
// </copyright>
// <summary>
//   Interface for the class generation parameters
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Dhgms.Nucleotide.Generators.PropertyInfo;

namespace Dhgms.Nucleotide.Generators.Models
{
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
        /// Gets the class remarks.
        /// </summary>
        string ClassRemarks { get; }
    }
}
