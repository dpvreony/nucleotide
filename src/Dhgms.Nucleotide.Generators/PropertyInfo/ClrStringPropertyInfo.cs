// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using Dhgms.Nucleotide.Generators.Models;

namespace Dhgms.Nucleotide.Generators.PropertyInfo
{
    /// <summary>
    /// Property Information for a String
    /// </summary>
    public class ClrStringPropertyInfo : PropertyInfoBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClrStringPropertyInfo"/> class.
        /// Constructor
        /// </summary>
        /// <param name="collection">
        /// Wether the field is a collection
        /// </param>
        /// <param name="name">
        /// Name of the field
        /// </param>
        /// <param name="description">
        /// Description for the field, used for commenting
        /// </param>
        /// <param name="optional">
        /// Whether the field is optionable \ nullable
        /// </param>
        /// <param name="minimumLength">
        /// The minimum acceptable length for a string
        /// </param>
        /// <param name="maximumLength">
        /// The maximum acceptable length for a string
        /// </param>
        /// <param name="isKey">
        /// Whether the property is the primary key
        /// </param>
        /// <param name="xmlIsCdataElement">
        /// The xml element produced is a CDATA Element.
        /// </param>
        /// <param name="alternativeDatabaseColumnName">
        /// Name of the database column name, if it's different from the .NET property name.
        /// </param>
        public ClrStringPropertyInfo(
            CollectionType collection,
            string name,
            string description,
            bool optional,
            int? minimumLength,
            int? maximumLength,
            bool isKey,
            bool xmlIsCdataElement,
            string? alternativeDatabaseColumnName)
            : base(
                collection,
                name,
                description,
                optional,
                "string",
                "String",
                false,
                "null",
                false,
                isKey,
                xmlIsCdataElement,
                typeof(string),
                alternativeDatabaseColumnName)
        {
            this.MinimumLength = minimumLength;
            this.MaximumLength = maximumLength;
        }

        /// <summary>
        /// Gets or sets the maximum length of a string
        /// </summary>
        public int? MaximumLength { get; }

        /// <summary>
        /// Gets or sets the maximum length of a string
        /// </summary>
        public int? MinimumLength { get; }
    }
}