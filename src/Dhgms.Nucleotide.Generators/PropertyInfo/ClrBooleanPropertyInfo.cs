﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright company="DHGMS Solutions" file="ClrBoolean.cs">
//   Licensed under GNU General Public License version 2 (GPLv2)
// </copyright>
// 
// --------------------------------------------------------------------------------------------------------------------

using Dhgms.Nucleotide.Generators.Models;

namespace Dhgms.Nucleotide.Generators.PropertyInfo
{
    /// <summary>
    /// Property Information for the Boolean Data Type
    /// </summary>
    public class ClrBooleanPropertyInfo : PropertyInfoBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClrBooleanPropertyInfo"/> class. 
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
        /// <param name="isKey">
        /// Whether the property is the primary key
        /// </param>
        /// <param name="alternativeDatabaseColumnName">
        /// Name of the database column name, if it's different from the .NET property name.
        /// </param>
        public ClrBooleanPropertyInfo(
            CollectionType collection,
            string name,
            string description,
            bool optional,
            bool isKey,
            string alternativeDatabaseColumnName)
            : base(
                collection, 
                name, 
                description, 
                optional, 
                "bool", 
                "Boolean", 
                false, 
                "false", 
                false,
                isKey,
                true,
                typeof(bool),
                alternativeDatabaseColumnName)
        {
        }

        /// <summary>
        /// Whether to generate an auto property, or a property that uses a field
        /// </summary>
        //public override bool GenerateAutoProperty
        //{
        //    get
        //    {
        //        return true;
        //    }
        //}

        ///// <summary>
        ///// Gets the code used for outputting a value as part of a string array
        ///// </summary>
        //public override string ToStringArrayCode
        //{
        //    get
        //    {
        //        return "ToString(System.Globalization.CultureInfo.InvariantCulture).ToLower()";
        //    }
        //}

        ///// <summary>
        ///// Whether the type is disposable
        ///// </summary>
        //public override bool DisposableType
        //{
        //    get
        //    {
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// Produces the data annotations specific to the property
        ///// </summary>
        ///// <returns></returns>
        //public override string GetDataAnnotations()
        //{
        //    return null;
        //}

        ///// <summary>
        ///// Gets a random value for use in a unit test.
        ///// </summary>
        //public override string RandomUnitTestValue
        //{
        //    get
        //    {
        //        return new System.Random().Next(1) == 1 ? "true" : "false";
        //    }
        //}
    }
}