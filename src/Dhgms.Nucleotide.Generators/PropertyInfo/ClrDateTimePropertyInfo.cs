// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using Dhgms.Nucleotide.Generators.Models;

namespace Dhgms.Nucleotide.Generators.PropertyInfo
{
    /// <summary>
    /// Property Information for ClrDateTime
    /// </summary>
    public class ClrDateTimePropertyInfo
        : PropertyInfoBase, IPropertyWithRange<System.DateTime?>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collection">Wether the field is a collection</param>
        /// <param name="name">Name of the field</param>
        /// <param name="description">Description for the field, used for commenting</param>
        /// <param name="optional">Whether the field is optionable \ nullable</param>
        /// <param name="minimumValue">The minimum acceptable value for this property</param>
        /// <param name="maximumValue">The maximum acceptable value for this property</param>
        /// <param name="isKey">
        /// Whether the property is the primary key
        /// </param>
        /// <param name="alternativeDatabaseColumnName">
        /// Name of the database column name, if it's different from the .NET property name.
        /// </param>
        public ClrDateTimePropertyInfo(
            CollectionType collection,
            System.String name,
            System.String description,
            bool optional,
            System.DateTime? minimumValue,
            System.DateTime? maximumValue,
            bool isKey,
            string? alternativeDatabaseColumnName)
            : base(
                collection,
                name,
                description,
                optional,
                "System.DateTime",
                "DateTime",
                false,
                "System.DateTime.MinValue",
                false,
                isKey,
                true,
                typeof(System.DateTime),
                alternativeDatabaseColumnName)
        {
            this.MinimumValue = minimumValue;
            this.MaximumValue = maximumValue;
        }

        ///// <summary>
        ///// Gets the mutator code for a poperty
        ///// </summary>
        ///// <returns>C# code</returns>
        //public override string GetMutator()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    sb.AppendLine("            set");
        //    sb.AppendLine("        {");

        //    if (this.minimumValue != null)
        //    {
        //        sb.Append("            if (");
        //        if (this.Optional)
        //        {
        //            sb.Append("value != null && ");
        //        }

        //        sb.AppendLine("value < " + this.minimumValue + ")");
        //        sb.AppendLine("            {");
        //        sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
        //        sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooLowClrDateTimeException(" + this.minimumValue + ", value" + (this.Optional ? ".Value" : "") + ");");
        //        sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
        //        sb.AppendLine("            }");
        //        sb.AppendLine(string.Empty);
        //    }

        //    if (this.maximumValue != null)
        //    {
        //        sb.Append("            if (");
        //        if (this.Optional)
        //        {
        //            sb.Append("value != null && ");
        //        }

        //        sb.AppendLine("value > " + this.maximumValue + ")");
        //        sb.AppendLine("            {");
        //        sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
        //        sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooHighClrDateTimeException(" + this.maximumValue + ", value" + (this.Optional ? ".Value" : "") + ");");
        //        sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
        //        sb.AppendLine("            }");
        //        sb.AppendLine(string.Empty);
        //    }

        //    sb.AppendLine("            this." + OldHelpers.GetVariableName(this.Name) + " = value;");

        //    sb.AppendLine("        }");
        //    return sb.ToString();
        //}

        ///// <summary>
        ///// Produces the data annotations specific to the property
        ///// </summary>
        ///// <returns></returns>
        //public override string GetDataAnnotations()
        //{
        //    return "[System.ComponentModel.DataAnnotations.Range(typeof(System.DateTime), \"" + this.minimumValue + "\", \"" + this.maximumValue + "\")]";
        //}

        ///// <summary>
        ///// Whether to generate an auto property, or a property that uses a field
        ///// </summary>
        //public override bool GenerateAutoProperty
        //{
        //    get
        //    {
        //        return this.maximumValue == null && this.minimumValue == null;
        //    }
        //}

        ///// <summary>
        ///// Gets the code used for outputting a value as part of a string array
        ///// </summary>
        //public override string ToStringArrayCode
        //{
        //    get
        //    {
        //        return "ToString(\"yyyy-MM-dd HH:mm:ss\")";
        //    }
        //}

        /// <summary>
        /// Whether the type is disposable
        /// </summary>
        //public override bool DisposableType
        //{
        //    get
        //    {
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// Gets a random value for use in a unit test.
        ///// </summary>
        //public override string RandomUnitTestValue
        //{
        //    get
        //    {
        //        var minValue = this.minimumValue.HasValue && this.minimumValue.Value > System.DateTime.MinValue ? this.minimumValue.Value : System.DateTime.MinValue;
        //        var max32BitDate = new System.DateTime(int.MaxValue);
        //        var maxValue = this.maximumValue.HasValue && this.maximumValue.Value < max32BitDate ? this.maximumValue.Value : max32BitDate;
        //        var randomTicks = new System.DateTime(new System.Random().Next((int)minValue.Ticks, (int)maxValue.Ticks));
        //        return string.Format(CultureInfo.InvariantCulture, "new System.DateTime({0})", randomTicks);
        //    }
        //}
        public DateTime? MaximumValue { get; }
        public DateTime? MinimumValue { get; }

        public string? MinimumValueAsString => MinimumValue?.ToString();

        public string? MaximumValueAsString => MaximumValue?.ToString();
    }
}
