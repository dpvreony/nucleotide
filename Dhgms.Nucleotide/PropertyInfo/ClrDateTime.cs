// -----------------------------------------------------------------------
// <copyright file="ClrDateTime.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Dhgms.Nucleotide.Model.Info.PropertyInfo
{
    using System.Text;

    /// <summary>
    /// Property Information for ClrDateTime
    /// </summary>
    public class ClrDateTime
        : Base
    {
        #region fields
        /// <summary>
        /// The minimum value, if any
        /// </summary>
        private readonly System.DateTime? minimumValue;

        /// <summary>
        /// The maximum value, if any
        /// </summary>
        private readonly System.DateTime? maximumValue;
        #endregion

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
        public ClrDateTime(
            CollectionType collection,
            System.String name,
            System.String description,
            bool optional,
            System.DateTime? minimumValue,
            System.DateTime? maximumValue,
            bool isKey,
            string alternativeDatabaseColumnName)
            : base(
                collection,
                name,
                description,
                optional,
                "DateTime",
                "Dhgms.DataManager.Model.SearchFilter.DateTime",
                "DateTime",
                false,
                "System.DateTime.MinValue",
                false,
                isKey,
                true,
                typeof(System.DateTime),
                alternativeDatabaseColumnName)
        {
            this.minimumValue = minimumValue;
            this.maximumValue = maximumValue;
        }

        /// <summary>
        /// Gets the mutator code for a poperty
        /// </summary>
        /// <returns>C# code</returns>
        public override string GetMutator()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("            set");
            sb.AppendLine("        {");

            if (this.minimumValue != null)
            {
                sb.Append("            if (");
                if (Optional)
                {
                    sb.Append("value != null && ");
                }

                sb.AppendLine("value < " + this.minimumValue + ")");
                sb.AppendLine("            {");
                sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
                sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooLowClrDateTimeException(" + this.minimumValue + ", value" + (Optional ? ".Value" : "") + ");");
                sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
                sb.AppendLine("            }");
                sb.AppendLine(string.Empty);
            }

            if (this.maximumValue != null)
            {
                sb.Append("            if (");
                if (Optional)
                {
                    sb.Append("value != null && ");
                }

                sb.AppendLine("value > " + this.maximumValue + ")");
                sb.AppendLine("            {");
                sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
                sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooHighClrDateTimeException(" + this.maximumValue + ", value" + (Optional ? ".Value" : "") + ");");
                sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
                sb.AppendLine("            }");
                sb.AppendLine(string.Empty);
            }

            sb.AppendLine("            this." + Helper.Common.GetVariableName(Name) + " = value;");

            sb.AppendLine("        }");
            return sb.ToString();
        }

        /// <summary>
        /// Produces the data annotations specific to the property
        /// </summary>
        /// <returns></returns>
        public override string GetDataAnnotations()
        {
            return "[Range(typeof(System.DateTime), \"" + this.minimumValue + "\", \"" + this.maximumValue + "\")]";
        }

        /// <summary>
        /// Whether to generate an auto property, or a property that uses a field
        /// </summary>
        public override bool GenerateAutoProperty
        {
            get
            {
                return this.maximumValue == null && this.minimumValue == null;
            }
        }

        /// <summary>
        /// Gets the code used for outputting a value as part of a string array
        /// </summary>
        public override string ToStringArrayCode
        {
            get
            {
                return "ToString(\"yyyy-MM-dd HH:mm:ss\")";
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

        /// <summary>
        /// Gets a random value for use in a unit test.
        /// </summary>
        public override string RandomUnitTestValue
        {
            get
            {
                var minValue = this.minimumValue.HasValue && this.minimumValue.Value > System.DateTime.MinValue ? this.minimumValue.Value : System.DateTime.MinValue;
                var max32BitDate = new System.DateTime(int.MaxValue);
                var maxValue = this.maximumValue.HasValue && this.maximumValue.Value < max32BitDate ? this.maximumValue.Value : max32BitDate;
                var randomTicks = new System.DateTime(new System.Random().Next((int)minValue.Ticks, (int)maxValue.Ticks));
                return string.Format("new System.DateTime({0})", randomTicks);
            }
        }
    }
}
