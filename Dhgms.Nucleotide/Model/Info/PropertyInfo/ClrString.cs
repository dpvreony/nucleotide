// --------------------------------------------------------------------------------------------------------------------
// <copyright company="DHGMS Solutions" file="ClrString.cs">
//   Licensed under GNU General Public License version 2 (GPLv2)
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Dhgms.Nucleotide.Model.Info.PropertyInfo
{
    using System.Text;

    using Dhgms.Nucleotide.Model.Helper;

    /// <summary>
    /// Property Information for a String
    /// </summary>
    public class ClrString : Base
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ClrString"/> class. 
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
        public ClrString(
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
                "Dhgms.DataManager.Model.SearchFilter.String", 
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
        public override bool GenerateAutoProperty
        {
            get
            {
                return this.MaximumLength == null && this.MinimumLength == null;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the maximum length of a string
        /// </summary>
        private int? MaximumLength { get; set; }

        /// <summary>
        /// Gets or sets the maximum length of a string
        /// </summary>
        private int? MinimumLength { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets the C# for carrying out a compare.
        /// </summary>
        /// <param name="checkResultDeclared">
        /// The check Result Declared.
        /// </param>
        /// <returns>
        /// C# for carrying out a compare
        /// </returns>
        public override string GetCSharpCompareCode(bool checkResultDeclared)
        {
            var sb = new StringBuilder();

            sb.Append("            ");
            if (!checkResultDeclared)
            {
                sb.Append("var ");
            }

            sb.AppendLine("checkResult = string.CompareOrdinal(this." + this.Name + ", other." + this.Name + ");");

            return sb.ToString();
        }

        /// <summary>
        /// Gets the mutator code for a poperty
        /// </summary>
        /// <returns>
        /// C# code
        /// </returns>
        public override string GetMutator()
        {
            var sb = new StringBuilder();

            sb.AppendLine("            set");
            sb.AppendLine("        {");

            if (this.MinimumLength != null)
            {
                sb.Append("            if(value ");
                sb.Append(!this.Optional ? " != null && " : " == null || ");

                sb.AppendLine("value.Length < " + this.MinimumLength + ")");
                sb.AppendLine("            {");
                sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
                sb.AppendLine(
                    "                throw new Dhgms.DataManager.Model.Exception.StringTooShortException(" + this.MinimumLength
                    + ", value.Length);");
                sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
                sb.AppendLine("            }");
            }

            if (this.MaximumLength != null)
            {
                sb.AppendLine("            if(value != null && value.Length > " + this.MaximumLength + ")");
                sb.AppendLine("            {");
                sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
                sb.AppendLine(
                    "                throw new Dhgms.DataManager.Model.Exception.StringTooLongException(" + this.MaximumLength
                    + ", value.Length);");
                sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
                sb.AppendLine("            }");
            }

            sb.AppendLine("            this." + Common.GetVariableName(this.Name) + " = value;");

            sb.AppendLine("        }");
            return sb.ToString();
        }

        /// <summary>
        /// Produces the data annotations specific to the property
        /// </summary>
        /// <returns></returns>
        public override string GetDataAnnotations()
        {
            if (this.MinimumLength == null && this.MaximumLength == null)
            {
                return null;
            }

            if (this.MinimumLength != null && this.MaximumLength == null)
            {
                return "[MinLength(" + this.MinimumLength + ", ErrorMessage=\"Must be at least " + this.MinimumLength + " characters in length\")]";
            }

            if (this.MinimumLength == null && this.MaximumLength != null)
            {
                return "[MaxLength(" + this.MaximumLength + ", ErrorMessage=\"Must be " + this.MaximumLength + " or less characters in length\")]";
            }

            return "[MinLength(" + this.MinimumLength + ", ErrorMessage=\"Must be between " + this.MinimumLength + " and" + this.MaximumLength + " characters in length\"), MaxLength(" + this.MaximumLength + ", ErrorMessage=\"Must be between " + this.MinimumLength + " and" + this.MaximumLength + " characters in length\")]";
        }

        /// <summary>
        /// Gets the code used for outputting a value as part of a string array
        /// </summary>
        public override string ToStringArrayCode
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Whether the type is disposable
        /// </summary>
        public override bool DisposableType
        {
            get
            {
                return false;
            }
        }

        #endregion
    }
}