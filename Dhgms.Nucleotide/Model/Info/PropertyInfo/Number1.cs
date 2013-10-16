// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Number1.cs" company="DHGMS Solutions">
//   Licensed under GNU General Public License version 2 (GPLv2)
// </copyright>
// <summary>
//   Property Information classes
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Dhgms.Nucleotide.Model.Info.PropertyInfo
{
    /// <summary>
    /// Property Information for ClrByte
    /// </summary>
    public class ClrByte
        : Base
    {
        #region fields
        /// <summary>
        /// The minimum allowed value, if any
        /// </summary>
        private readonly byte? minimumValue;

        /// <summary>
        /// The maximum allowed value, if any
        /// </summary>
        private readonly byte? maximumValue;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ClrByte"/> class. 
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
        public ClrByte(
            CollectionType collection,
            string name,
            string description,
            bool optional,
            byte? minimumValue,
            byte? maximumValue,
            bool isKey,
            string alternativeDatabaseColumnName)
            : base(
                collection,
                name,
                description,
                optional,
                "byte",
                "Dhgms.DataManager.Model.SearchFilter.Byte",
                "Byte",
                false,
                "0",
                false,
                isKey,
                true,
                typeof(byte),
                alternativeDatabaseColumnName)
        {
            this.minimumValue = minimumValue;
            this.maximumValue = maximumValue;
        }

        /// <summary>
        /// Produces the data annotations specific to the property
        /// </summary>
        /// <returns></returns>
        public override string GetDataAnnotations()
        {
            return "[Range(typeof(byte), \"" + this.minimumValue + "\", \"" + this.maximumValue + "\")]";
        }

        /// <summary>
        /// Gets a random value for use in a unit test.
        /// </summary>
        public override string RandomUnitTestValue
        {
            get
            {
                var minValue = this.minimumValue.HasValue && this.minimumValue.Value > byte.MinValue ? this.minimumValue.Value : byte.MinValue;
                var maxValue = this.maximumValue.HasValue && this.maximumValue.Value < byte.MaxValue ? this.maximumValue.Value : byte.MaxValue;
                return new System.Random((int)System.DateTime.Now.Ticks).Next((int)minValue, (int)maxValue).ToString(System.Globalization.CultureInfo.InvariantCulture);
            }
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
        /// Gets the code used for outputting a value as part of a string array
        /// </summary>
        public override string ToStringArrayCode
        {
            get
            {
                return "ToString(System.Globalization.CultureInfo.InvariantCulture)";
            }
        }

        /// <summary>
        /// Gets the mutator code for a poperty
        /// </summary>
        /// <returns>C# code</returns>
        public override string GetMutator()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine("            set");
            sb.AppendLine("        {");

            if (this.minimumValue != null)
            {
                sb.Append("            if(");
                if (Optional)
                {
                    sb.Append("value != null && ");
                }

                sb.AppendLine("value < " + this.minimumValue + ")");
                sb.AppendLine("            {");
                sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
                sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooLowClrByteException(\"" + this.Name + "\"," + this.minimumValue + ", value" + (Optional ? ".Value" : string.Empty) + ");");
                sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
                sb.AppendLine("            }");
            }

            if (this.maximumValue != null)
            {
                sb.AppendLine("            if(value > " + this.maximumValue + ")");
                sb.AppendLine("            {");
                sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
                sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooHighClrByteException(\"" + this.Name + "\", " + this.maximumValue + ", value" + (Optional ? ".Value" : string.Empty) + ");");
                sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
                sb.AppendLine("            }");
            }

            sb.AppendLine("            this." + Helper.Common.GetVariableName(Name) + " = value;");

            sb.AppendLine("        }");
            return sb.ToString();
        }
    }

    /// <summary>
    /// Property Information for ClrChar
    /// </summary>
    public class ClrChar
        : Base
    {
        #region fields
        /// <summary>
        /// The minimum allowed value, if any
        /// </summary>
        private readonly char? minimumValue;

        /// <summary>
        /// The maximum allowed value, if any
        /// </summary>
        private readonly char? maximumValue;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ClrChar"/> class. 
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
        public ClrChar(
            CollectionType collection,
            string name,
            string description,
            bool optional,
            char? minimumValue,
            char? maximumValue,
            bool isKey,
            string alternativeDatabaseColumnName)
            : base(
                collection,
                name,
                description,
                optional,
                "char",
                "Dhgms.DataManager.Model.SearchFilter.Char",
                "Char",
                false,
                "0",
                false,
                isKey,
                true,
                typeof(char),
                alternativeDatabaseColumnName)
        {
            this.minimumValue = minimumValue;
            this.maximumValue = maximumValue;
        }

        /// <summary>
        /// Produces the data annotations specific to the property
        /// </summary>
        /// <returns></returns>
        public override string GetDataAnnotations()
        {
            return "[Range(typeof(char), \"" + this.minimumValue + "\", \"" + this.maximumValue + "\")]";
        }

        /// <summary>
        /// Gets a random value for use in a unit test.
        /// </summary>
        public override string RandomUnitTestValue
        {
            get
            {
                var minValue = this.minimumValue.HasValue && this.minimumValue.Value > char.MinValue ? this.minimumValue.Value : char.MinValue;
                var maxValue = this.maximumValue.HasValue && this.maximumValue.Value < char.MaxValue ? this.maximumValue.Value : char.MaxValue;
                return new System.Random((int)System.DateTime.Now.Ticks).Next((int)minValue, (int)maxValue).ToString(System.Globalization.CultureInfo.InvariantCulture);
            }
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
        /// Gets the code used for outputting a value as part of a string array
        /// </summary>
        public override string ToStringArrayCode
        {
            get
            {
                return "ToString(System.Globalization.CultureInfo.InvariantCulture)";
            }
        }

        /// <summary>
        /// Gets the mutator code for a poperty
        /// </summary>
        /// <returns>C# code</returns>
        public override string GetMutator()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine("            set");
            sb.AppendLine("        {");

            if (this.minimumValue != null)
            {
                sb.Append("            if(");
                if (Optional)
                {
                    sb.Append("value != null && ");
                }

                sb.AppendLine("value < " + this.minimumValue + ")");
                sb.AppendLine("            {");
                sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
                sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooLowClrCharException(\"" + this.Name + "\"," + this.minimumValue + ", value" + (Optional ? ".Value" : string.Empty) + ");");
                sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
                sb.AppendLine("            }");
            }

            if (this.maximumValue != null)
            {
                sb.AppendLine("            if(value > " + this.maximumValue + ")");
                sb.AppendLine("            {");
                sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
                sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooHighClrCharException(\"" + this.Name + "\", " + this.maximumValue + ", value" + (Optional ? ".Value" : string.Empty) + ");");
                sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
                sb.AppendLine("            }");
            }

            sb.AppendLine("            this." + Helper.Common.GetVariableName(Name) + " = value;");

            sb.AppendLine("        }");
            return sb.ToString();
        }
    }

    /// <summary>
    /// Property Information for ClrDecimal
    /// </summary>
    public class ClrDecimal
        : Base
    {
        #region fields
        /// <summary>
        /// The minimum allowed value, if any
        /// </summary>
        private readonly decimal? minimumValue;

        /// <summary>
        /// The maximum allowed value, if any
        /// </summary>
        private readonly decimal? maximumValue;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ClrDecimal"/> class. 
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
        public ClrDecimal(
            CollectionType collection,
            string name,
            string description,
            bool optional,
            decimal? minimumValue,
            decimal? maximumValue,
            bool isKey,
            string alternativeDatabaseColumnName)
            : base(
                collection,
                name,
                description,
                optional,
                "decimal",
                "Dhgms.DataManager.Model.SearchFilter.Decimal",
                "Decimal",
                false,
                "0",
                false,
                isKey,
                true,
                typeof(decimal),
                alternativeDatabaseColumnName)
        {
            this.minimumValue = minimumValue;
            this.maximumValue = maximumValue;
        }

        /// <summary>
        /// Produces the data annotations specific to the property
        /// </summary>
        /// <returns></returns>
        public override string GetDataAnnotations()
        {
            return "[Range(typeof(decimal), \"" + this.minimumValue + "\", \"" + this.maximumValue + "\")]";
        }

        /// <summary>
        /// Gets a random value for use in a unit test.
        /// </summary>
        public override string RandomUnitTestValue
        {
            get
            {
                var minValue = this.minimumValue.HasValue && this.minimumValue.Value > decimal.MinValue ? this.minimumValue.Value : decimal.MinValue;
                var maxValue = this.maximumValue.HasValue && this.maximumValue.Value < decimal.MaxValue ? this.maximumValue.Value : decimal.MaxValue;
                return new System.Random((int)System.DateTime.Now.Ticks).Next((int)minValue, (int)maxValue).ToString(System.Globalization.CultureInfo.InvariantCulture);
            }
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
        /// Gets the code used for outputting a value as part of a string array
        /// </summary>
        public override string ToStringArrayCode
        {
            get
            {
                return "ToString(System.Globalization.CultureInfo.InvariantCulture)";
            }
        }

        /// <summary>
        /// Gets the mutator code for a poperty
        /// </summary>
        /// <returns>C# code</returns>
        public override string GetMutator()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine("            set");
            sb.AppendLine("        {");

            if (this.minimumValue != null)
            {
                sb.Append("            if(");
                if (Optional)
                {
                    sb.Append("value != null && ");
                }

                sb.AppendLine("value < " + this.minimumValue + ")");
                sb.AppendLine("            {");
                sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
                sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooLowClrDecimalException(\"" + this.Name + "\"," + this.minimumValue + ", value" + (Optional ? ".Value" : string.Empty) + ");");
                sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
                sb.AppendLine("            }");
            }

            if (this.maximumValue != null)
            {
                sb.AppendLine("            if(value > " + this.maximumValue + ")");
                sb.AppendLine("            {");
                sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
                sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooHighClrDecimalException(\"" + this.Name + "\", " + this.maximumValue + ", value" + (Optional ? ".Value" : string.Empty) + ");");
                sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
                sb.AppendLine("            }");
            }

            sb.AppendLine("            this." + Helper.Common.GetVariableName(Name) + " = value;");

            sb.AppendLine("        }");
            return sb.ToString();
        }
    }

    /// <summary>
    /// Property Information for ClrDouble
    /// </summary>
    public class ClrDouble
        : Base
    {
        #region fields
        /// <summary>
        /// The minimum allowed value, if any
        /// </summary>
        private readonly double? minimumValue;

        /// <summary>
        /// The maximum allowed value, if any
        /// </summary>
        private readonly double? maximumValue;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ClrDouble"/> class. 
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
        public ClrDouble(
            CollectionType collection,
            string name,
            string description,
            bool optional,
            double? minimumValue,
            double? maximumValue,
            bool isKey,
            string alternativeDatabaseColumnName)
            : base(
                collection,
                name,
                description,
                optional,
                "double",
                "Dhgms.DataManager.Model.SearchFilter.Double",
                "Double",
                false,
                "0",
                false,
                isKey,
                true,
                typeof(double),
                alternativeDatabaseColumnName)
        {
            this.minimumValue = minimumValue;
            this.maximumValue = maximumValue;
        }

        /// <summary>
        /// Produces the data annotations specific to the property
        /// </summary>
        /// <returns></returns>
        public override string GetDataAnnotations()
        {
            return "[Range(typeof(double), \"" + this.minimumValue + "\", \"" + this.maximumValue + "\")]";
        }

        /// <summary>
        /// Gets a random value for use in a unit test.
        /// </summary>
        public override string RandomUnitTestValue
        {
            get
            {
                var minValue = this.minimumValue.HasValue && this.minimumValue.Value > double.MinValue ? this.minimumValue.Value : double.MinValue;
                var maxValue = this.maximumValue.HasValue && this.maximumValue.Value < double.MaxValue ? this.maximumValue.Value : double.MaxValue;
                return new System.Random((int)System.DateTime.Now.Ticks).Next((int)minValue, (int)maxValue).ToString(System.Globalization.CultureInfo.InvariantCulture);
            }
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
        /// Gets the code used for outputting a value as part of a string array
        /// </summary>
        public override string ToStringArrayCode
        {
            get
            {
                return "ToString(System.Globalization.CultureInfo.InvariantCulture)";
            }
        }

        /// <summary>
        /// Gets the mutator code for a poperty
        /// </summary>
        /// <returns>C# code</returns>
        public override string GetMutator()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine("            set");
            sb.AppendLine("        {");

            if (this.minimumValue != null)
            {
                sb.Append("            if(");
                if (Optional)
                {
                    sb.Append("value != null && ");
                }

                sb.AppendLine("value < " + this.minimumValue + ")");
                sb.AppendLine("            {");
                sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
                sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooLowClrDoubleException(\"" + this.Name + "\"," + this.minimumValue + ", value" + (Optional ? ".Value" : string.Empty) + ");");
                sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
                sb.AppendLine("            }");
            }

            if (this.maximumValue != null)
            {
                sb.AppendLine("            if(value > " + this.maximumValue + ")");
                sb.AppendLine("            {");
                sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
                sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooHighClrDoubleException(\"" + this.Name + "\", " + this.maximumValue + ", value" + (Optional ? ".Value" : string.Empty) + ");");
                sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
                sb.AppendLine("            }");
            }

            sb.AppendLine("            this." + Helper.Common.GetVariableName(Name) + " = value;");

            sb.AppendLine("        }");
            return sb.ToString();
        }
    }

    /// <summary>
    /// Property Information for ClrSingle
    /// </summary>
    public class ClrSingle
        : Base
    {
        #region fields
        /// <summary>
        /// The minimum allowed value, if any
        /// </summary>
        private readonly float? minimumValue;

        /// <summary>
        /// The maximum allowed value, if any
        /// </summary>
        private readonly float? maximumValue;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ClrSingle"/> class. 
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
        public ClrSingle(
            CollectionType collection,
            string name,
            string description,
            bool optional,
            float? minimumValue,
            float? maximumValue,
            bool isKey,
            string alternativeDatabaseColumnName)
            : base(
                collection,
                name,
                description,
                optional,
                "float",
                "Dhgms.DataManager.Model.SearchFilter.Single",
                "Float",
                false,
                "0",
                false,
                isKey,
                true,
                typeof(float),
                alternativeDatabaseColumnName)
        {
            this.minimumValue = minimumValue;
            this.maximumValue = maximumValue;
        }

        /// <summary>
        /// Produces the data annotations specific to the property
        /// </summary>
        /// <returns></returns>
        public override string GetDataAnnotations()
        {
            return "[Range(typeof(float), \"" + this.minimumValue + "\", \"" + this.maximumValue + "\")]";
        }

        /// <summary>
        /// Gets a random value for use in a unit test.
        /// </summary>
        public override string RandomUnitTestValue
        {
            get
            {
                var minValue = this.minimumValue.HasValue && this.minimumValue.Value > float.MinValue ? this.minimumValue.Value : float.MinValue;
                var maxValue = this.maximumValue.HasValue && this.maximumValue.Value < float.MaxValue ? this.maximumValue.Value : float.MaxValue;
                return new System.Random((int)System.DateTime.Now.Ticks).Next((int)minValue, (int)maxValue).ToString(System.Globalization.CultureInfo.InvariantCulture);
            }
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
        /// Gets the code used for outputting a value as part of a string array
        /// </summary>
        public override string ToStringArrayCode
        {
            get
            {
                return "ToString(System.Globalization.CultureInfo.InvariantCulture)";
            }
        }

        /// <summary>
        /// Gets the mutator code for a poperty
        /// </summary>
        /// <returns>C# code</returns>
        public override string GetMutator()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine("            set");
            sb.AppendLine("        {");

            if (this.minimumValue != null)
            {
                sb.Append("            if(");
                if (Optional)
                {
                    sb.Append("value != null && ");
                }

                sb.AppendLine("value < " + this.minimumValue + ")");
                sb.AppendLine("            {");
                sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
                sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooLowClrSingleException(\"" + this.Name + "\"," + this.minimumValue + ", value" + (Optional ? ".Value" : string.Empty) + ");");
                sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
                sb.AppendLine("            }");
            }

            if (this.maximumValue != null)
            {
                sb.AppendLine("            if(value > " + this.maximumValue + ")");
                sb.AppendLine("            {");
                sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
                sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooHighClrSingleException(\"" + this.Name + "\", " + this.maximumValue + ", value" + (Optional ? ".Value" : string.Empty) + ");");
                sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
                sb.AppendLine("            }");
            }

            sb.AppendLine("            this." + Helper.Common.GetVariableName(Name) + " = value;");

            sb.AppendLine("        }");
            return sb.ToString();
        }
    }

    /// <summary>
    /// Property Information for Integer16
    /// </summary>
    public class Integer16
        : Base
    {
        #region fields
        /// <summary>
        /// The minimum allowed value, if any
        /// </summary>
        private readonly short? minimumValue;

        /// <summary>
        /// The maximum allowed value, if any
        /// </summary>
        private readonly short? maximumValue;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Integer16"/> class. 
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
        public Integer16(
            CollectionType collection,
            string name,
            string description,
            bool optional,
            short? minimumValue,
            short? maximumValue,
            bool isKey,
            string alternativeDatabaseColumnName)
            : base(
                collection,
                name,
                description,
                optional,
                "short",
                "Dhgms.DataManager.Model.SearchFilter.Integer16",
                "Int16",
                false,
                "0",
                false,
                isKey,
                true,
                typeof(short),
                alternativeDatabaseColumnName)
        {
            this.minimumValue = minimumValue;
            this.maximumValue = maximumValue;
        }

        /// <summary>
        /// Produces the data annotations specific to the property
        /// </summary>
        /// <returns></returns>
        public override string GetDataAnnotations()
        {
            return "[Range(typeof(short), \"" + this.minimumValue + "\", \"" + this.maximumValue + "\")]";
        }

        /// <summary>
        /// Gets a random value for use in a unit test.
        /// </summary>
        public override string RandomUnitTestValue
        {
            get
            {
                var minValue = this.minimumValue.HasValue && this.minimumValue.Value > short.MinValue ? this.minimumValue.Value : short.MinValue;
                var maxValue = this.maximumValue.HasValue && this.maximumValue.Value < short.MaxValue ? this.maximumValue.Value : short.MaxValue;
                return new System.Random((int)System.DateTime.Now.Ticks).Next((int)minValue, (int)maxValue).ToString(System.Globalization.CultureInfo.InvariantCulture);
            }
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
        /// Gets the code used for outputting a value as part of a string array
        /// </summary>
        public override string ToStringArrayCode
        {
            get
            {
                return "ToString(System.Globalization.CultureInfo.InvariantCulture)";
            }
        }

        /// <summary>
        /// Gets the mutator code for a poperty
        /// </summary>
        /// <returns>C# code</returns>
        public override string GetMutator()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine("            set");
            sb.AppendLine("        {");

            if (this.minimumValue != null)
            {
                sb.Append("            if(");
                if (Optional)
                {
                    sb.Append("value != null && ");
                }

                sb.AppendLine("value < " + this.minimumValue + ")");
                sb.AppendLine("            {");
                sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
                sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooLowInteger16Exception(\"" + this.Name + "\"," + this.minimumValue + ", value" + (Optional ? ".Value" : string.Empty) + ");");
                sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
                sb.AppendLine("            }");
            }

            if (this.maximumValue != null)
            {
                sb.AppendLine("            if(value > " + this.maximumValue + ")");
                sb.AppendLine("            {");
                sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
                sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooHighInteger16Exception(\"" + this.Name + "\", " + this.maximumValue + ", value" + (Optional ? ".Value" : string.Empty) + ");");
                sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
                sb.AppendLine("            }");
            }

            sb.AppendLine("            this." + Helper.Common.GetVariableName(Name) + " = value;");

            sb.AppendLine("        }");
            return sb.ToString();
        }
    }

    /// <summary>
    /// Property Information for Integer32
    /// </summary>
    public class Integer32
        : Base
    {
        #region fields
        /// <summary>
        /// The minimum allowed value, if any
        /// </summary>
        private readonly int? minimumValue;

        /// <summary>
        /// The maximum allowed value, if any
        /// </summary>
        private readonly int? maximumValue;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Integer32"/> class. 
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
        public Integer32(
            CollectionType collection,
            string name,
            string description,
            bool optional,
            int? minimumValue,
            int? maximumValue,
            bool isKey,
            string alternativeDatabaseColumnName)
            : base(
                collection,
                name,
                description,
                optional,
                "int",
                "Dhgms.DataManager.Model.SearchFilter.Integer32",
                "Int32",
                false,
                "0",
                false,
                isKey,
                true,
                typeof(int),
                alternativeDatabaseColumnName)
        {
            this.minimumValue = minimumValue;
            this.maximumValue = maximumValue;
        }

        /// <summary>
        /// Produces the data annotations specific to the property
        /// </summary>
        /// <returns></returns>
        public override string GetDataAnnotations()
        {
            return "[Range(typeof(int), \"" + this.minimumValue + "\", \"" + this.maximumValue + "\")]";
        }

        /// <summary>
        /// Gets a random value for use in a unit test.
        /// </summary>
        public override string RandomUnitTestValue
        {
            get
            {
                var minValue = this.minimumValue.HasValue && this.minimumValue.Value > int.MinValue ? this.minimumValue.Value : int.MinValue;
                var maxValue = this.maximumValue.HasValue && this.maximumValue.Value < int.MaxValue ? this.maximumValue.Value : int.MaxValue;
                return new System.Random((int)System.DateTime.Now.Ticks).Next((int)minValue, (int)maxValue).ToString(System.Globalization.CultureInfo.InvariantCulture);
            }
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
        /// Gets the code used for outputting a value as part of a string array
        /// </summary>
        public override string ToStringArrayCode
        {
            get
            {
                return "ToString(System.Globalization.CultureInfo.InvariantCulture)";
            }
        }

        /// <summary>
        /// Gets the mutator code for a poperty
        /// </summary>
        /// <returns>C# code</returns>
        public override string GetMutator()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine("            set");
            sb.AppendLine("        {");

            if (this.minimumValue != null)
            {
                sb.Append("            if(");
                if (Optional)
                {
                    sb.Append("value != null && ");
                }

                sb.AppendLine("value < " + this.minimumValue + ")");
                sb.AppendLine("            {");
                sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
                sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooLowInteger32Exception(\"" + this.Name + "\"," + this.minimumValue + ", value" + (Optional ? ".Value" : string.Empty) + ");");
                sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
                sb.AppendLine("            }");
            }

            if (this.maximumValue != null)
            {
                sb.AppendLine("            if(value > " + this.maximumValue + ")");
                sb.AppendLine("            {");
                sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
                sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooHighInteger32Exception(\"" + this.Name + "\", " + this.maximumValue + ", value" + (Optional ? ".Value" : string.Empty) + ");");
                sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
                sb.AppendLine("            }");
            }

            sb.AppendLine("            this." + Helper.Common.GetVariableName(Name) + " = value;");

            sb.AppendLine("        }");
            return sb.ToString();
        }
    }

    /// <summary>
    /// Property Information for Integer64
    /// </summary>
    public class Integer64
        : Base
    {
        #region fields
        /// <summary>
        /// The minimum allowed value, if any
        /// </summary>
        private readonly long? minimumValue;

        /// <summary>
        /// The maximum allowed value, if any
        /// </summary>
        private readonly long? maximumValue;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Integer64"/> class. 
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
        public Integer64(
            CollectionType collection,
            string name,
            string description,
            bool optional,
            long? minimumValue,
            long? maximumValue,
            bool isKey,
            string alternativeDatabaseColumnName)
            : base(
                collection,
                name,
                description,
                optional,
                "long",
                "Dhgms.DataManager.Model.SearchFilter.Integer64",
                "Int64",
                false,
                "0",
                false,
                isKey,
                true,
                typeof(long),
                alternativeDatabaseColumnName)
        {
            this.minimumValue = minimumValue;
            this.maximumValue = maximumValue;
        }

        /// <summary>
        /// Produces the data annotations specific to the property
        /// </summary>
        /// <returns></returns>
        public override string GetDataAnnotations()
        {
            return "[Range(typeof(long), \"" + this.minimumValue + "\", \"" + this.maximumValue + "\")]";
        }

        /// <summary>
        /// Gets a random value for use in a unit test.
        /// </summary>
        public override string RandomUnitTestValue
        {
            get
            {
                var minValue = this.minimumValue.HasValue && this.minimumValue.Value > long.MinValue ? this.minimumValue.Value : long.MinValue;
                var maxValue = this.maximumValue.HasValue && this.maximumValue.Value < long.MaxValue ? this.maximumValue.Value : long.MaxValue;
                return new System.Random((int)System.DateTime.Now.Ticks).Next((int)minValue, (int)maxValue).ToString(System.Globalization.CultureInfo.InvariantCulture);
            }
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
        /// Gets the code used for outputting a value as part of a string array
        /// </summary>
        public override string ToStringArrayCode
        {
            get
            {
                return "ToString(System.Globalization.CultureInfo.InvariantCulture)";
            }
        }

        /// <summary>
        /// Gets the mutator code for a poperty
        /// </summary>
        /// <returns>C# code</returns>
        public override string GetMutator()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine("            set");
            sb.AppendLine("        {");

            if (this.minimumValue != null)
            {
                sb.Append("            if(");
                if (Optional)
                {
                    sb.Append("value != null && ");
                }

                sb.AppendLine("value < " + this.minimumValue + ")");
                sb.AppendLine("            {");
                sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
                sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooLowInteger64Exception(\"" + this.Name + "\"," + this.minimumValue + ", value" + (Optional ? ".Value" : string.Empty) + ");");
                sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
                sb.AppendLine("            }");
            }

            if (this.maximumValue != null)
            {
                sb.AppendLine("            if(value > " + this.maximumValue + ")");
                sb.AppendLine("            {");
                sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
                sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooHighInteger64Exception(\"" + this.Name + "\", " + this.maximumValue + ", value" + (Optional ? ".Value" : string.Empty) + ");");
                sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
                sb.AppendLine("            }");
            }

            sb.AppendLine("            this." + Helper.Common.GetVariableName(Name) + " = value;");

            sb.AppendLine("        }");
            return sb.ToString();
        }
    }

    /// <summary>
    /// Property Information for UnsignedInteger8
    /// </summary>
    public class UnsignedInteger8
        : Base
    {
        #region fields
        /// <summary>
        /// The minimum allowed value, if any
        /// </summary>
        private readonly byte? minimumValue;

        /// <summary>
        /// The maximum allowed value, if any
        /// </summary>
        private readonly byte? maximumValue;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="UnsignedInteger8"/> class. 
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
        public UnsignedInteger8(
            CollectionType collection,
            string name,
            string description,
            bool optional,
            byte? minimumValue,
            byte? maximumValue,
            bool isKey,
            string alternativeDatabaseColumnName)
            : base(
                collection,
                name,
                description,
                optional,
                "byte",
                "Dhgms.DataManager.Model.SearchFilter.UnsignedInteger8",
                "UInt8",
                false,
                "0",
                false,
                isKey,
                true,
                typeof(byte),
                alternativeDatabaseColumnName)
        {
            this.minimumValue = minimumValue;
            this.maximumValue = maximumValue;
        }

        /// <summary>
        /// Produces the data annotations specific to the property
        /// </summary>
        /// <returns></returns>
        public override string GetDataAnnotations()
        {
            return "[Range(typeof(byte), \"" + this.minimumValue + "\", \"" + this.maximumValue + "\")]";
        }

        /// <summary>
        /// Gets a random value for use in a unit test.
        /// </summary>
        public override string RandomUnitTestValue
        {
            get
            {
                var minValue = this.minimumValue.HasValue && this.minimumValue.Value > byte.MinValue ? this.minimumValue.Value : byte.MinValue;
                var maxValue = this.maximumValue.HasValue && this.maximumValue.Value < byte.MaxValue ? this.maximumValue.Value : byte.MaxValue;
                return new System.Random((int)System.DateTime.Now.Ticks).Next((int)minValue, (int)maxValue).ToString(System.Globalization.CultureInfo.InvariantCulture);
            }
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
        /// Gets the code used for outputting a value as part of a string array
        /// </summary>
        public override string ToStringArrayCode
        {
            get
            {
                return "ToString(System.Globalization.CultureInfo.InvariantCulture)";
            }
        }

        /// <summary>
        /// Gets the mutator code for a poperty
        /// </summary>
        /// <returns>C# code</returns>
        public override string GetMutator()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine("            set");
            sb.AppendLine("        {");

            if (this.minimumValue != null)
            {
                sb.Append("            if(");
                if (Optional)
                {
                    sb.Append("value != null && ");
                }

                sb.AppendLine("value < " + this.minimumValue + ")");
                sb.AppendLine("            {");
                sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
                sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooLowUnsignedInteger8Exception(\"" + this.Name + "\"," + this.minimumValue + ", value" + (Optional ? ".Value" : string.Empty) + ");");
                sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
                sb.AppendLine("            }");
            }

            if (this.maximumValue != null)
            {
                sb.AppendLine("            if(value > " + this.maximumValue + ")");
                sb.AppendLine("            {");
                sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
                sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooHighUnsignedInteger8Exception(\"" + this.Name + "\", " + this.maximumValue + ", value" + (Optional ? ".Value" : string.Empty) + ");");
                sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
                sb.AppendLine("            }");
            }

            sb.AppendLine("            this." + Helper.Common.GetVariableName(Name) + " = value;");

            sb.AppendLine("        }");
            return sb.ToString();
        }
    }

    /// <summary>
    /// Property Information for UnsignedInteger16
    /// </summary>
    public class UnsignedInteger16
        : Base
    {
        #region fields
        /// <summary>
        /// The minimum allowed value, if any
        /// </summary>
        private readonly ushort? minimumValue;

        /// <summary>
        /// The maximum allowed value, if any
        /// </summary>
        private readonly ushort? maximumValue;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="UnsignedInteger16"/> class. 
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
        public UnsignedInteger16(
            CollectionType collection,
            string name,
            string description,
            bool optional,
            ushort? minimumValue,
            ushort? maximumValue,
            bool isKey,
            string alternativeDatabaseColumnName)
            : base(
                collection,
                name,
                description,
                optional,
                "ushort",
                "Dhgms.DataManager.Model.SearchFilter.UnsignedInteger16",
                "UInt16",
                false,
                "0",
                false,
                isKey,
                true,
                typeof(ushort),
                alternativeDatabaseColumnName)
        {
            this.minimumValue = minimumValue;
            this.maximumValue = maximumValue;
        }

        /// <summary>
        /// Produces the data annotations specific to the property
        /// </summary>
        /// <returns></returns>
        public override string GetDataAnnotations()
        {
            return "[Range(typeof(ushort), \"" + this.minimumValue + "\", \"" + this.maximumValue + "\")]";
        }

        /// <summary>
        /// Gets a random value for use in a unit test.
        /// </summary>
        public override string RandomUnitTestValue
        {
            get
            {
                var minValue = this.minimumValue.HasValue && this.minimumValue.Value > ushort.MinValue ? this.minimumValue.Value : ushort.MinValue;
                var maxValue = this.maximumValue.HasValue && this.maximumValue.Value < ushort.MaxValue ? this.maximumValue.Value : ushort.MaxValue;
                return new System.Random((int)System.DateTime.Now.Ticks).Next((int)minValue, (int)maxValue).ToString(System.Globalization.CultureInfo.InvariantCulture);
            }
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
        /// Gets the code used for outputting a value as part of a string array
        /// </summary>
        public override string ToStringArrayCode
        {
            get
            {
                return "ToString(System.Globalization.CultureInfo.InvariantCulture)";
            }
        }

        /// <summary>
        /// Gets the mutator code for a poperty
        /// </summary>
        /// <returns>C# code</returns>
        public override string GetMutator()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine("            set");
            sb.AppendLine("        {");

            if (this.minimumValue != null)
            {
                sb.Append("            if(");
                if (Optional)
                {
                    sb.Append("value != null && ");
                }

                sb.AppendLine("value < " + this.minimumValue + ")");
                sb.AppendLine("            {");
                sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
                sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooLowUnsignedInteger16Exception(\"" + this.Name + "\"," + this.minimumValue + ", value" + (Optional ? ".Value" : string.Empty) + ");");
                sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
                sb.AppendLine("            }");
            }

            if (this.maximumValue != null)
            {
                sb.AppendLine("            if(value > " + this.maximumValue + ")");
                sb.AppendLine("            {");
                sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
                sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooHighUnsignedInteger16Exception(\"" + this.Name + "\", " + this.maximumValue + ", value" + (Optional ? ".Value" : string.Empty) + ");");
                sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
                sb.AppendLine("            }");
            }

            sb.AppendLine("            this." + Helper.Common.GetVariableName(Name) + " = value;");

            sb.AppendLine("        }");
            return sb.ToString();
        }
    }

    /// <summary>
    /// Property Information for UnsignedInteger32
    /// </summary>
    public class UnsignedInteger32
        : Base
    {
        #region fields
        /// <summary>
        /// The minimum allowed value, if any
        /// </summary>
        private readonly uint? minimumValue;

        /// <summary>
        /// The maximum allowed value, if any
        /// </summary>
        private readonly uint? maximumValue;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="UnsignedInteger32"/> class. 
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
        public UnsignedInteger32(
            CollectionType collection,
            string name,
            string description,
            bool optional,
            uint? minimumValue,
            uint? maximumValue,
            bool isKey,
            string alternativeDatabaseColumnName)
            : base(
                collection,
                name,
                description,
                optional,
                "uint",
                "Dhgms.DataManager.Model.SearchFilter.UnsignedInteger32",
                "UInt32",
                false,
                "0",
                false,
                isKey,
                true,
                typeof(uint),
                alternativeDatabaseColumnName)
        {
            this.minimumValue = minimumValue;
            this.maximumValue = maximumValue;
        }

        /// <summary>
        /// Produces the data annotations specific to the property
        /// </summary>
        /// <returns></returns>
        public override string GetDataAnnotations()
        {
            return "[Range(typeof(uint), \"" + this.minimumValue + "\", \"" + this.maximumValue + "\")]";
        }

        /// <summary>
        /// Gets a random value for use in a unit test.
        /// </summary>
        public override string RandomUnitTestValue
        {
            get
            {
                var minValue = this.minimumValue.HasValue && this.minimumValue.Value > uint.MinValue ? this.minimumValue.Value : uint.MinValue;
                var maxValue = this.maximumValue.HasValue && this.maximumValue.Value < uint.MaxValue ? this.maximumValue.Value : uint.MaxValue;
                return new System.Random((int)System.DateTime.Now.Ticks).Next((int)minValue, (int)maxValue).ToString(System.Globalization.CultureInfo.InvariantCulture);
            }
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
        /// Gets the code used for outputting a value as part of a string array
        /// </summary>
        public override string ToStringArrayCode
        {
            get
            {
                return "ToString(System.Globalization.CultureInfo.InvariantCulture)";
            }
        }

        /// <summary>
        /// Gets the mutator code for a poperty
        /// </summary>
        /// <returns>C# code</returns>
        public override string GetMutator()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine("            set");
            sb.AppendLine("        {");

            if (this.minimumValue != null)
            {
                sb.Append("            if(");
                if (Optional)
                {
                    sb.Append("value != null && ");
                }

                sb.AppendLine("value < " + this.minimumValue + ")");
                sb.AppendLine("            {");
                sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
                sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooLowUnsignedInteger32Exception(\"" + this.Name + "\"," + this.minimumValue + ", value" + (Optional ? ".Value" : string.Empty) + ");");
                sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
                sb.AppendLine("            }");
            }

            if (this.maximumValue != null)
            {
                sb.AppendLine("            if(value > " + this.maximumValue + ")");
                sb.AppendLine("            {");
                sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
                sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooHighUnsignedInteger32Exception(\"" + this.Name + "\", " + this.maximumValue + ", value" + (Optional ? ".Value" : string.Empty) + ");");
                sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
                sb.AppendLine("            }");
            }

            sb.AppendLine("            this." + Helper.Common.GetVariableName(Name) + " = value;");

            sb.AppendLine("        }");
            return sb.ToString();
        }
    }

    /// <summary>
    /// Property Information for UnsignedInteger64
    /// </summary>
    public class UnsignedInteger64
        : Base
    {
        #region fields
        /// <summary>
        /// The minimum allowed value, if any
        /// </summary>
        private readonly ulong? minimumValue;

        /// <summary>
        /// The maximum allowed value, if any
        /// </summary>
        private readonly ulong? maximumValue;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="UnsignedInteger64"/> class. 
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
        public UnsignedInteger64(
            CollectionType collection,
            string name,
            string description,
            bool optional,
            ulong? minimumValue,
            ulong? maximumValue,
            bool isKey,
            string alternativeDatabaseColumnName)
            : base(
                collection,
                name,
                description,
                optional,
                "ulong",
                "Dhgms.DataManager.Model.SearchFilter.UnsignedInteger64",
                "UInt64",
                false,
                "0",
                false,
                isKey,
                true,
                typeof(ulong),
                alternativeDatabaseColumnName)
        {
            this.minimumValue = minimumValue;
            this.maximumValue = maximumValue;
        }

        /// <summary>
        /// Produces the data annotations specific to the property
        /// </summary>
        /// <returns></returns>
        public override string GetDataAnnotations()
        {
            return "[Range(typeof(ulong), \"" + this.minimumValue + "\", \"" + this.maximumValue + "\")]";
        }

        /// <summary>
        /// Gets a random value for use in a unit test.
        /// </summary>
        public override string RandomUnitTestValue
        {
            get
            {
                var minValue = this.minimumValue.HasValue && this.minimumValue.Value > ulong.MinValue ? this.minimumValue.Value : ulong.MinValue;
                var maxValue = this.maximumValue.HasValue && this.maximumValue.Value < ulong.MaxValue ? this.maximumValue.Value : ulong.MaxValue;
                return new System.Random((int)System.DateTime.Now.Ticks).Next((int)minValue, (int)maxValue).ToString(System.Globalization.CultureInfo.InvariantCulture);
            }
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
        /// Gets the code used for outputting a value as part of a string array
        /// </summary>
        public override string ToStringArrayCode
        {
            get
            {
                return "ToString(System.Globalization.CultureInfo.InvariantCulture)";
            }
        }

        /// <summary>
        /// Gets the mutator code for a poperty
        /// </summary>
        /// <returns>C# code</returns>
        public override string GetMutator()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine("            set");
            sb.AppendLine("        {");

            if (this.minimumValue != null)
            {
                sb.Append("            if(");
                if (Optional)
                {
                    sb.Append("value != null && ");
                }

                sb.AppendLine("value < " + this.minimumValue + ")");
                sb.AppendLine("            {");
                sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
                sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooLowUnsignedInteger64Exception(\"" + this.Name + "\"," + this.minimumValue + ", value" + (Optional ? ".Value" : string.Empty) + ");");
                sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
                sb.AppendLine("            }");
            }

            if (this.maximumValue != null)
            {
                sb.AppendLine("            if(value > " + this.maximumValue + ")");
                sb.AppendLine("            {");
                sb.AppendLine("                // ReSharper disable RedundantNameQualifier");
                sb.AppendLine("                throw new Dhgms.DataManager.Model.Exception.NumberTooHighUnsignedInteger64Exception(\"" + this.Name + "\", " + this.maximumValue + ", value" + (Optional ? ".Value" : string.Empty) + ");");
                sb.AppendLine("                // ReSharper restore RedundantNameQualifier");
                sb.AppendLine("            }");
            }

            sb.AppendLine("            this." + Helper.Common.GetVariableName(Name) + " = value;");

            sb.AppendLine("        }");
            return sb.ToString();
        }
    }
}
