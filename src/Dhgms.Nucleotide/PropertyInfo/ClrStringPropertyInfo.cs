// --------------------------------------------------------------------------------------------------------------------
// <copyright company="DHGMS Solutions" file="ClrString.cs">
//   Licensed under GNU General Public License version 2 (GPLv2)
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Dhgms.Nucleotide.PropertyInfo
{
    using System;
    using System.Globalization;
    using System.Text;

    using Dhgms.Nucleotide.Model;

    /// <summary>
    /// Property Information for a String
    /// </summary>
    public class ClrStringPropertyInfo : PropertyInfoBase
    {
        #region Constructors and Destructors

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
            string alternativeDatabaseColumnName)
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

        #endregion

        #region Public Properties

        /// <summary>
        /// Whether to generate an auto property, or a property that uses a field
        /// </summary>
        //public override bool GenerateAutoProperty
        //{
        //    get
        //    {
        //        return this.MaximumLength == null && this.MinimumLength == null;
        //    }
        //}

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the maximum length of a string
        /// </summary>
        public int? MaximumLength { get; }

        /// <summary>
        /// Gets or sets the maximum length of a string
        /// </summary>
        public int? MinimumLength { get; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets a random value for use in a unit test.
        /// </summary>
        //public override string RandomUnitTestValue
        //{
        //    get
        //    {
        //        var minLength = this.MinimumLength.HasValue ? this.MinimumLength.Value : 1;
        //        var maxLength = this.MaximumLength.HasValue ? this.MaximumLength.Value : 2048;
        //        var length = new Random((int)DateTime.Now.Ticks).Next(minLength, maxLength);
        //        return OldHelpers.GetRandomString(length);
        //    }
        //}

        /// <summary>
        /// Gets the C# for carrying out a compare.
        /// </summary>
        /// <param name="checkResultDeclared">
        /// The check Result Declared.
        /// </param>
        /// <returns>
        /// C# for carrying out a compare
        /// </returns>
        //public override string GetCSharpCompareCode(bool checkResultDeclared)
        //{
        //    var sb = new StringBuilder();

        //    sb.Append("            ");
        //    if (!checkResultDeclared)
        //    {
        //        sb.Append("var ");
        //    }

        //    sb.AppendLine("checkResult = string.CompareOrdinal(this." + this.Name + ", other." + this.Name + ");");

        //    return sb.ToString();
        //}

        /// <summary>
        /// Gets the mutator code for a poperty
        /// </summary>
        /// <returns>
        /// C# code
        /// </returns>
//        public override string GetMutator()
//        {
//            var sb = new StringBuilder();

//            var tabCount = 3;
//            sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}set", OldHelpers.GetTabs(tabCount)));
//            sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}{{", OldHelpers.GetTabs(tabCount)));
//            tabCount++;

//            if (!this.Optional)
//            {
//#if CODECONTRACTS
//                sb.AppendLine("            Contract.Requires<ArgumentNullException>(string.IsNullOrWhitespace(value), \"value\")");
//#else
//                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}if (string.IsNullOrWhiteSpace(value))", OldHelpers.GetTabs(tabCount)));
//                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}{{", OldHelpers.GetTabs(tabCount)));

//                tabCount++;
//                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}throw new System.ArgumentNullException(\"value\");", OldHelpers.GetTabs(tabCount)));
//                tabCount--;

//                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}}}", OldHelpers.GetTabs(tabCount)));
//#endif
//            }
//            else if (this.MinimumLength != null || this.MaximumLength != null)
//            {
//                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}if (value != null)", OldHelpers.GetTabs(tabCount)));
//                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}{{", OldHelpers.GetTabs(tabCount)));
//                tabCount++;
//            }

//            if (this.MinimumLength != null || this.MaximumLength != null)
//            {
//                sb.AppendLine();
//            }

//            if (this.MinimumLength.HasValue)
//            {
//                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}if (value.Length < {1})", OldHelpers.GetTabs(tabCount), this.MinimumLength));
//                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}{{", OldHelpers.GetTabs(tabCount)));

//                tabCount++;
//                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}// ReSharper disable RedundantNameQualifier", OldHelpers.GetTabs(tabCount)));
//                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}throw new Dhgms.DataManager.Model.Exception.StringTooShortException({1}, value.Length);", OldHelpers.GetTabs(tabCount), this.MinimumLength.Value));
//                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}// ReSharper restore RedundantNameQualifier", OldHelpers.GetTabs(tabCount)));
//                tabCount--;

//                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}}}", OldHelpers.GetTabs(tabCount)));
//            }

//            if (this.MinimumLength != null && this.MaximumLength != null)
//            {
//                sb.AppendLine();
//            }

//            if (this.MaximumLength.HasValue)
//            {
//                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}if (value.Length > {1})", OldHelpers.GetTabs(tabCount), this.MaximumLength));
//                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}{{", OldHelpers.GetTabs(tabCount)));

//                tabCount++;
//                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}// ReSharper disable RedundantNameQualifier", OldHelpers.GetTabs(tabCount)));
//                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}throw new Dhgms.DataManager.Model.Exception.StringTooLongException({1}, value.Length);", OldHelpers.GetTabs(tabCount), this.MaximumLength.Value));
//                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}// ReSharper restore RedundantNameQualifier", OldHelpers.GetTabs(tabCount)));
//                tabCount--;

//                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}}}", OldHelpers.GetTabs(tabCount)));
//            }

//            if (this.Optional && (this.MinimumLength != null || this.MaximumLength != null))
//            {
//                tabCount--;
//                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}}}", OldHelpers.GetTabs(tabCount)));
//            }

//            sb.AppendLine();
//            sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}this.{1} = value;", OldHelpers.GetTabs(tabCount), OldHelpers.GetVariableName(this.Name)));

//            tabCount--;
//            sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}}}", OldHelpers.GetTabs(tabCount)));
//            return sb.ToString();
//        }

//        /// <summary>
//        /// Produces the data annotations specific to the property
//        /// </summary>
//        /// <returns></returns>
//        public override string GetDataAnnotations()
//        {
//            if (this.MinimumLength == null && this.MaximumLength == null)
//            {
//                return null;
//            }

//            if (this.MinimumLength != null && this.MaximumLength == null)
//            {
//                return string.Format(CultureInfo.InvariantCulture, "{0}[System.ComponentModel.DataAnnotations.MinLength({1}, ErrorMessage = \"Must be at least {1} characters in length\")]", OldHelpers.GetTabs(2), this.MinimumLength);
//            }

//            if (this.MinimumLength == null && this.MaximumLength != null)
//            {
//                return string.Format(CultureInfo.InvariantCulture, "{0}[System.ComponentModel.DataAnnotations.MaxLength({1}, ErrorMessage = \"Must be {1} or less characters in length\")]", OldHelpers.GetTabs(2), this.MaximumLength);
//            }

//            return string.Format(CultureInfo.InvariantCulture, "{0}[System.ComponentModel.DataAnnotations.MinLength({1}, ErrorMessage = \"Must be between {1} and {2} characters in length\"), MaxLength({2}, ErrorMessage = \"Must be between {1} and {2}  characters in length\")]", OldHelpers.GetTabs(2), this.MinimumLength, this.MaximumLength);
//        }

        /// <summary>
        /// Gets the code used for outputting a value as part of a string array
        /// </summary>
        //public override string ToStringArrayCode
        //{
        //    get
        //    {
        //        return string.Empty;
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

        #endregion
    }
}