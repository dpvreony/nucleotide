// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using Dhgms.Nucleotide.Generators.PropertyInfo;

namespace Dhgms.Nucleotide.Generators.Models
{
    /// <summary>
    /// Represents the parameters for generating an data manager classes
    /// </summary>
    public abstract class EntityGenerationModel : IEntityGenerationModel
    {
        /// <summary>
        /// Gets the name of the information class.
        /// </summary>
        public abstract string ClassName { get; }

        public abstract KeyType KeyType { get; }

        public abstract IEntityGenerationModel BaseTypeEntityGenerationModel { get; }

        public abstract InterfaceGenerationModel[] InterfaceGenerationModels { get; }

        /// <summary>
        /// Gets the name of the information class.
        /// </summary>
        public abstract string ClassRemarks { get; }

        /// <summary>
        /// Gets the collection of properties for the class.
        /// </summary>
        public abstract PropertyInfoBase[] Properties { get; }
    }
}
