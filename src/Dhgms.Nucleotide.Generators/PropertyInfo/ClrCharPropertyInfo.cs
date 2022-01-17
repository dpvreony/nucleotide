﻿// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using Dhgms.Nucleotide.Generators.Models;

namespace Dhgms.Nucleotide.Generators.PropertyInfo
{
    public class ClrCharPropertyInfo
        : NumericPropertyInfo<char>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClrCharPropertyInfo"/> class. 
        /// </summary>
        /// <param name="collection">Whether the field is a collection</param>
        /// <param name="name">Name of the field</param>
        /// <param name="description">Description for the field, used for commenting</param>
        /// <param name="optional">Whether the field is optional \ capable of being null</param>
        /// <param name="minimumValue">The minimum acceptable value for this property</param>
        /// <param name="maximumValue">The maximum acceptable value for this property</param>
        /// <param name="isKey">
        /// Whether the property is the primary key
        /// </param>
        /// <param name="alternativeDatabaseColumnName">
        /// Name of the database column name, if it's different from the .NET property name.
        /// </param>
        public ClrCharPropertyInfo(
            CollectionType collection,
            string name,
            string description,
            bool optional,
            char minimumValue,
            char maximumValue,
            bool isKey,
            string alternativeDatabaseColumnName)
            : base(
                collection,
                name,
                description,
                optional,
                "char",
                "Char",
                false,
                "0",
                false,
                isKey,
                true,
                typeof(char),
                alternativeDatabaseColumnName,
                minimumValue,
                maximumValue)
        {
        }
    }
}
