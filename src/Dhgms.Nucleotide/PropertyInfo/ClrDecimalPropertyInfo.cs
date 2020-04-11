﻿using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Model;

namespace Dhgms.Nucleotide.PropertyInfo
{
    public class ClrDecimalPropertyInfo
        : NumericPropertyInfo<decimal>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ClrDecimalPropertyInfo"/> class. 
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
        public ClrDecimalPropertyInfo(
            CollectionType collection,
            string name,
            string description,
            bool optional,
            decimal minimumValue,
            decimal maximumValue,
            bool isKey,
            string alternativeDatabaseColumnName)
            : base(
                collection,
                name,
                description,
                optional,
                "decimal",
                "Decimal",
                false,
                "0",
                false,
                isKey,
                true,
                typeof(decimal),
                alternativeDatabaseColumnName,
                minimumValue,
                maximumValue)
        {
        }
    }
}
