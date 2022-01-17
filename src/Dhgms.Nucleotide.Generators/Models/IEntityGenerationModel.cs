// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

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
