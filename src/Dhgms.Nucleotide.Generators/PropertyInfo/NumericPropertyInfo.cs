// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using Dhgms.Nucleotide.Generators.Models;

namespace Dhgms.Nucleotide.Generators.PropertyInfo
{
    public class NumericPropertyInfo<TNumeric>
        : PropertyInfoBase, IPropertyWithRange<TNumeric?>
        where TNumeric : struct
    {
        public NumericPropertyInfo(
            CollectionType collection,
            string name,
            string description,
            bool optional,
            string netDataType,
            string sqlDataReaderType,
            bool requiresSqlMapping,
            string defaultValue,
            bool nullableType,
            bool isKey,
            bool xmlIsCdataElement,
            Type dataType,
            string alternativeDatabaseColumnName,
            TNumeric? minimumValue,
            TNumeric? maximumValue)
            : base(collection, name, description, optional, netDataType, sqlDataReaderType, requiresSqlMapping, defaultValue, nullableType, isKey, xmlIsCdataElement, dataType, alternativeDatabaseColumnName)
        {
            MinimumValue = minimumValue;
            MaximumValue = maximumValue;
        }

        /// <summary>
        /// The minimum allowed value, if any
        /// </summary>
        public TNumeric? MinimumValue { get; }

        /// <summary>
        /// The maximum allowed value, if any
        /// </summary>
        public TNumeric? MaximumValue { get; }

        public string? MinimumValueAsString => MinimumValue?.ToString();

        public string? MaximumValueAsString => MaximumValue?.ToString();
    }
}
