// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using Dhgms.Nucleotide.Generators.Models;

namespace Dhgms.Nucleotide.Generators.PropertyInfo
{
    public class Integer32PropertyInfo
        : NumericPropertyInfo<int>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Integer32PropertyInfo"/> class. 
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
        public Integer32PropertyInfo(
            CollectionType collection,
            string name,
            string description,
            bool optional,
            int? minimumValue,
            int? maximumValue,
            bool isKey,
            string? alternativeDatabaseColumnName)
            : base(
                collection,
                name,
                description,
                optional,
                "int",
                "Int32",
                false,
                "0",
                false,
                isKey,
                true,
                typeof(int),
                alternativeDatabaseColumnName,
                minimumValue,
                maximumValue)
        {
        }

        /// <summary>
        /// Gets a random value for use in a unit test.
        /// </summary>
        //public override string RandomUnitTestValue
        //{
        //    get
        //    {
        //        var minValue = this.minimumValue.HasValue && this.minimumValue.Value > int.MinValue ? this.minimumValue.Value : int.MinValue;
        //        var maxValue = this.maximumValue.HasValue && this.maximumValue.Value < int.MaxValue ? this.maximumValue.Value : int.MaxValue;
        //        return new System.Random((int)System.DateTime.Now.Ticks).Next((int)minValue, (int)maxValue).ToString(System.Globalization.CultureInfo.InvariantCulture);
        //    }
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
        ///// Gets the code used for outputting a value as part of a string array
        ///// </summary>
        //public override string ToStringArrayCode
        //{
        //    get
        //    {
        //        return "ToString(System.Globalization.CultureInfo.InvariantCulture)";
        //    }
        //}

        ///// <summary>
        ///// Produces the data annotations specific to the property
        ///// </summary>
        ///// <returns>The data annotation, if any.</returns>
        //public override string GetDataAnnotations()
        //{
        //    return "[System.ComponentModel.DataAnnotations.Range(typeof(int), \"" + this.minimumValue + "\", \"" + this.maximumValue + "\")]";
        //}

        ///// <summary>
        ///// Gets the mutation code for a property
        ///// </summary>
        ///// <returns>C# code</returns>
        //public override string GetMutator()
        //{
        //    System.Text.StringBuilder sb = new System.Text.StringBuilder();

        //    sb.AppendLine("            set");
        //    sb.AppendLine("        {");

        //    if (this.minimumValue != null)
        //    {
        //        sb.Append("            if(");
        //        if (this.Optional)
        //        {
        //            sb.Append("value != null && ");
        //        }

        //        sb.AppendLine("value < " + this.minimumValue + ")");
        //        sb.AppendLine("            {");
        //        sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
        //        sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooLowInteger32Exception(\"" + this.Name + "\"," + this.minimumValue + ", value" + (this.Optional ? ".Value" : string.Empty) + ");");
        //        sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
        //        sb.AppendLine("            }");
        //    }

        //    if (this.maximumValue != null)
        //    {
        //        sb.AppendLine("            if(value > " + this.maximumValue + ")");
        //        sb.AppendLine("            {");
        //        sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
        //        sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooHighInteger32Exception(\"" + this.Name + "\", " + this.maximumValue + ", value" + (this.Optional ? ".Value" : string.Empty) + ");");
        //        sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
        //        sb.AppendLine("            }");
        //    }

        //    sb.AppendLine("            this." + OldHelpers.GetVariableName(this.Name) + " = value;");

        //    sb.AppendLine("        }");
        //    return sb.ToString();
        //}
    }
}
