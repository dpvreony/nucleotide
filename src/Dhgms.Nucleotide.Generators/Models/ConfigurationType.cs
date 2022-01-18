// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace Dhgms.Nucleotide.Generators.Models
{
    /// <summary>
    /// Information about a configuration property
    /// </summary>
    public class ConfigurationProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationProperty"/> class.
        /// </summary>
        /// <param name="name">
        /// Name of the configuration property
        /// </param>
        /// <param name="description">
        /// Description of the property
        /// </param>
        /// <param name="dataType">
        /// The data type.
        /// </param>
        /// <param name="isRequired">
        /// The is required.
        /// </param>
        private ConfigurationProperty(string name, string description, string dataType, bool isRequired)
        {
            this.Name = name;
            this.Description = description;
            this.DataType = dataType;
            this.IsRequired = isRequired;
        }

        /// <summary>
        /// Gets or sets the .NET data type of the property
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// Gets or sets the Description of the property
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the property is required to be configured
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// Gets or sets the Name of the configuration property
        /// </summary>
        public string Name { get; set; }
    }
}