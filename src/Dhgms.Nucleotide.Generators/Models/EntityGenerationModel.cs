// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using Dhgms.Nucleotide.Generators.PropertyInfo;

namespace Dhgms.Nucleotide.Generators.Models
{
    /// <summary>
    /// Represents the parameters for generating an data manager classes
    /// </summary>
    public class EntityGenerationModel : IEntityGenerationModel
    {
        /// <summary>
        /// Gets the name of the information class.
        /// </summary>
        public string ClassName { get; init; }

        public KeyType KeyType { get; init; }

        public BaseEntityTypeGenerationModel BaseTypeEntityGenerationModel { get; init; }

        public InterfaceGenerationModel[] InterfaceGenerationModels { get; init; }

        /// <summary>
        /// Gets the name of the information class.
        /// </summary>
        public string ClassRemarks { get; init; }

        /// <summary>
        /// Gets the collection of properties for the class.
        /// </summary>
        public PropertyInfoBase[] Properties { get; init; }
    }
}
