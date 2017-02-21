// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdoNetHelpers.cs" company="DHGMS Solutions">
//   Licensed under GNU General Public License version 2 (GPLv2)
// </copyright>
// <summary>
//   Generator for ADO.NET helpers
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Dhgms.Nucleotide.Generators
{
    using System;
    using System.Linq;
    using System.Text;

    using Dhgms.Nucleotide.Model;
    using Dhgms.Nucleotide.PropertyInfo;

    /// <summary>
    /// Generator for ADO.NET helpers
    /// </summary>
    public class AdoNetGenerator : GeneratorBase
    {
        /// <summary>
        /// Carries out the generation of code for a class
        /// </summary>
        /// <param name="sb">The string builder to append code to.</param>
        /// <param name="classGenerationParameters">The class generation parameters</param>
        protected override void DoGenerationOfClass(StringBuilder sb, IClassGenerationParameters classGenerationParameters)
        {
            if (sb == null)
            {
                throw new ArgumentNullException(nameof(sb));
            }

            if (classGenerationParameters == null)
            {
                throw new ArgumentNullException(nameof(classGenerationParameters));
            }

            var fullyQualifiedClassName = classGenerationParameters.MainNamespaceName + ".Model." + (!string.IsNullOrWhiteSpace(classGenerationParameters.SubNamespace) ? classGenerationParameters.SubNamespace + "." : null) + classGenerationParameters.ClassName;

            sb.AppendLine("    using System;");
            sb.AppendLine(string.Empty);
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// Helper methods for using POCO and low level ADO.NET");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    public class " + classGenerationParameters.ClassName + "AdoNetHelper");
            sb.AppendLine("                : Dhgms.DataManager.Model.Helper.AdoNet.AdoNetBase<" + fullyQualifiedClassName + ">");
            sb.AppendLine("    {");

            sb.AppendLine("        #region our methods");
            sb.AppendLine(string.Empty);

            DoGetDataColumnsMethod(sb, classGenerationParameters);
            this.DoGetStronglyTypedObjectFromDataReaderRowMethod(sb, classGenerationParameters, this.DoInformationClassGetRowData, null);

            sb.AppendLine("        #endregion");

            sb.AppendLine("    }");
            sb.AppendLine(string.Empty);
        }

        /// <summary>
        /// The do get ordinals.
        /// </summary>
        /// <param name="generatedCode">
        /// The String Builder to add the code to
        /// </param>
        /// <param name="properties">
        /// Properties of the info class
        /// </param>
        protected static void DoGetOrdinals(StringBuilder generatedCode, PropertyInfoBase[] properties)
        {
            foreach (PropertyInfoBase pi in properties)
            {
                var name = !string.IsNullOrWhiteSpace(pi.AlternativeDatabaseColumnName)
                               ? pi.AlternativeDatabaseColumnName
                               : pi.Name;
                generatedCode.AppendLine(
                    "            var " + OldHelpers.GetVariableName(pi.Name) + "Ordinal = dataReader.GetOrdinal(\""
                    + name + "\");");
            }
        }

        /// <summary>
        /// The do get data columns method.
        /// </summary>
        /// <param name="generatedCode">
        /// The String Builder to add the code to
        /// </param>
        /// <param name="classInfo">
        /// The class Info.
        /// </param>
        protected static void DoGetDataColumnsMethod(StringBuilder generatedCode, IClassGenerationParameters classInfo)
        {
            if (generatedCode == null)
            {
                throw new ArgumentNullException(nameof(generatedCode));
            }

            if (classInfo == null)
            {
                throw new ArgumentNullException(nameof(generatedCode));
            }

            generatedCode.AppendLine("            /// <summary>");
            generatedCode.AppendLine("            /// Gets a collection of data columns representing the type");
            generatedCode.AppendLine("            /// </summary>");
            generatedCode.AppendLine("            /// <returns>a collection of strings representing the data record</returns>");
            generatedCode.AppendLine("            public override System.Data.DataColumn[] GetDataColumns()");
            generatedCode.AppendLine("            {");
            generatedCode.AppendLine("                System.Collections.Generic.List<System.Data.DataColumn> result =");
            generatedCode.Append("                    new System.Collections.Generic.List<System.Data.DataColumn>");

            var baseClassProperties = classInfo.BaseClassProperties;
            if (baseClassProperties != null && baseClassProperties.Length > 0)
            {
                generatedCode.Append("                (base.GetDataColumns())");
            }

            generatedCode.AppendLine(string.Empty);
            generatedCode.AppendLine("                {");

            var properties = classInfo.Properties;
            for (int i = 0; i < properties.Length; i++)
            {
                generatedCode.AppendLine(
                    "                    new System.Data.DataColumn(\"" + properties[i].Name + "\", typeof("
                    + properties[i].NetDataType + "))" + (i < properties.Length - 1 ? "," : string.Empty));
            }

            generatedCode.AppendLine("                };");
            generatedCode.AppendLine(string.Empty);

            generatedCode.AppendLine("                return result.ToArray();");
            generatedCode.AppendLine("            }");
        }

        /// <summary>
        /// Generates the code that gets the row data for reading a data reader into a strongly typed class
        /// </summary>
        /// <param name="generatedCode">
        /// The String Builder to add the code to
        /// </param>
        /// <param name="properties">
        /// The collection of properties for the class
        /// </param>
        protected static void DoViewFilterGetRowData(StringBuilder generatedCode, PropertyInfoBase[] properties)
        {
            if (generatedCode == null)
            {
                throw new ArgumentNullException(nameof(generatedCode));
            }

            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            foreach (PropertyInfoBase pi in properties.Where(pi => pi.SqlDataReaderType != null))
            {
                generatedCode.AppendLine("            bool " + OldHelpers.GetVariableName(pi.Name) + " =");
                generatedCode.AppendLine(
                    "                (" + OldHelpers.GetVariableName(pi.Name) + "Ordinal > -1) && (dataReader.GetBoolean("
                    + OldHelpers.GetVariableName(pi.Name) + "Ordinal));");
                generatedCode.AppendLine(string.Empty);
            }
        }

        /// <summary>
        /// Generates the code that gets the row data for reading a data reader into a strongly typed class
        /// </summary>
        /// <param name="generatedCode">
        /// The String Builder to add the code to
        /// </param>
        /// <param name="properties">
        /// The collection of properties for the class
        /// </param>
        protected static void DoDifferenceGetRowData(StringBuilder generatedCode, PropertyInfoBase[] properties)
        {
            if (generatedCode == null)
            {
                throw new ArgumentNullException(nameof(generatedCode));
            }

            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            foreach (var pi in properties.Where(pi => pi.SqlDataReaderType != null))
            {
                generatedCode.AppendLine("            bool " + OldHelpers.GetVariableName("row" + pi.Name) + " = false;");
                generatedCode.AppendLine("            if (" + OldHelpers.GetVariableName(pi.Name) + "Ordinal > -1)");
                generatedCode.AppendLine("            {");
                generatedCode.AppendLine(
                    "                " + OldHelpers.GetVariableName("row" + pi.Name) + " = dataReader.GetBoolean("
                    + OldHelpers.GetVariableName(pi.Name) + "Ordinal);");
                generatedCode.AppendLine("            }");
                generatedCode.AppendLine(string.Empty);
            }
        }

        /// <summary>
        /// Generates the code that gets the row data for reading a data reader into a strongly typed class
        /// </summary>
        /// <param name="generatedCode">
        /// The String Builder to add the code to
        /// </param>
        /// <param name="properties">
        /// The collection of properties for the class
        /// </param>
        protected void DoInformationClassGetRowData(StringBuilder generatedCode, PropertyInfoBase[] properties)
        {
            if (generatedCode == null)
            {
                throw new ArgumentNullException(nameof(generatedCode));
            }

            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            foreach (PropertyInfoBase pi in properties)
            {
                if (pi.SqlDataReaderType == null)
                {
                    continue;
                }

                string optional = null;
                if (pi.Optional && !pi.NetDataType.Equals("string", StringComparison.Ordinal))
                {
                    optional = "?";
                }

                generatedCode.AppendLine(
                    "            " + pi.GetCSharpDataTypeDeclaration() + optional + " "
                    + OldHelpers.GetVariableName("row" + pi.Name) + " = " + (pi.Optional ? "null" : pi.DefaultValue) + ";");
                generatedCode.AppendLine("            if (" + OldHelpers.GetVariableName(pi.Name) + "Ordinal > -1)");
                generatedCode.AppendLine("            {");
                if (pi.Optional)
                {
                    generatedCode.AppendLine(
                        "                if (!dataReader.IsDBNull(" + OldHelpers.GetVariableName(pi.Name) + "Ordinal))");
                    generatedCode.AppendLine("                {");

                    generatedCode.AppendLine(
                        "                    " + OldHelpers.GetVariableName("row" + pi.Name) + " = "
                        + (pi.RequiresSqlMapping ? "(" + pi.GetCSharpDataTypeDeclaration() + ")" : null)
                        + "dataReader.Get" + pi.SqlDataReaderType + "(" + OldHelpers.GetVariableName(pi.Name) + "Ordinal);");
                    generatedCode.AppendLine("                }");
                }
                else
                {
                    generatedCode.AppendLine(
                        "                " + OldHelpers.GetVariableName("row" + pi.Name) + " = "
                        + (pi.RequiresSqlMapping ? "(" + pi.GetCSharpDataTypeDeclaration() + ")" : null)
                        + "dataReader.Get" + pi.SqlDataReaderType + "(" + OldHelpers.GetVariableName(pi.Name) + "Ordinal);");
                }

                generatedCode.AppendLine("            }");
                generatedCode.AppendLine(string.Empty);
            }
        }

        /// <summary>
        /// The do get strongly typed object from data reader row method.
        /// </summary>
        /// <param name="generatedCode">
        /// The String Builder to add the code to
        /// </param>
        /// <param name="classInfo">
        /// The class Info.
        /// </param>
        /// <param name="doGetRowDataMethod">
        /// The do Get Row Data Method.
        /// </param>
        /// <param name="classSuffix">
        /// class suffix (used for difference class, etc.)
        /// </param>
        protected virtual void DoGetStronglyTypedObjectFromDataReaderRowMethod(
            StringBuilder generatedCode,
            IClassGenerationParameters classInfo,
            Action<StringBuilder, PropertyInfoBase[]> doGetRowDataMethod,
            string classSuffix)
        {
            if (generatedCode == null)
            {
                throw new ArgumentNullException("generatedCode");
            }

            if (classInfo == null)
            {
                throw new ArgumentNullException("classInfo");
            }

            if (doGetRowDataMethod == null)
            {
                throw new ArgumentNullException("doGetRowDataMethod");
            }

            var fullyQualifiedClassName = classInfo.MainNamespaceName + ".Model." + (!string.IsNullOrWhiteSpace(classInfo.SubNamespace) ? classInfo.SubNamespace + "." : null) + classInfo.ClassName;

            var properties = classInfo.Properties;
            if (properties == null || properties.Length < 1)
            {
                throw new ArgumentException("classInfo.properties");
            }

            var baseClassProperties = classInfo.BaseClassProperties;

            generatedCode.AppendLine("        /// <summary>");
            generatedCode.AppendLine("        /// Get Strongly Typed Object from a data reader");
            generatedCode.AppendLine("        /// </summary>");
            generatedCode.AppendLine("        /// <param name=\"dataReader\">");
            generatedCode.AppendLine("        /// The data Reader.");
            generatedCode.AppendLine("        /// </param>");
            generatedCode.AppendLine("        /// <returns>");
            generatedCode.AppendLine("        /// strongly typed object.");
            generatedCode.AppendLine("        /// </returns>");
            generatedCode.AppendLine(
                "        public override " + fullyQualifiedClassName + classSuffix
                + " GetStronglyTypedObjectFromDataReaderRow(System.Data.IDataReader dataReader)");
            generatedCode.AppendLine("        {");

            if (baseClassProperties != null && baseClassProperties.Length > 0 &&
                baseClassProperties.Any(pi => pi.SqlDataReaderType == null || pi.Collection != CollectionType.None))
            {
                generatedCode.AppendLine("            throw new NotImplementedException();");
                generatedCode.AppendLine("        }");
                return;
            }

            if (properties.Any(pi => pi.SqlDataReaderType == null || pi.Collection != CollectionType.None))
            {
                generatedCode.AppendLine("            throw new NotImplementedException();");
                generatedCode.AppendLine("        }");
                return;
            }

            generatedCode.AppendLine("            if (dataReader == null)");
            generatedCode.AppendLine("            {");
            generatedCode.AppendLine("                throw new ArgumentNullException(\"dataReader\");");
            generatedCode.AppendLine("            }");
            generatedCode.AppendLine(string.Empty);

            generatedCode.AppendLine("            // get ordinals");
            if (baseClassProperties != null && baseClassProperties.Length > 0)
            {
                DoGetOrdinals(generatedCode, baseClassProperties);
            }

            DoGetOrdinals(generatedCode, properties);
            generatedCode.AppendLine(string.Empty);

            generatedCode.AppendLine("            // get row data");
            if (baseClassProperties != null && baseClassProperties.Length > 0)
            {
                doGetRowDataMethod(generatedCode, baseClassProperties);
            }

            doGetRowDataMethod(generatedCode, properties);

            generatedCode.AppendLine("            return new " + fullyQualifiedClassName + classSuffix + "(");
            if (baseClassProperties != null && baseClassProperties.Length > 0)
            {
                generatedCode.AppendLine(
                    "                " + OldHelpers.GetVariableName("row" + baseClassProperties[0].Name)
                    + (baseClassProperties.Length > 1 ? "," : string.Empty));
                for (int i = 1; i < baseClassProperties.Length; i++)
                {
                    generatedCode.AppendLine(
                        "                " + OldHelpers.GetVariableName("row" + baseClassProperties[i].Name) + ",");
                }
            }

            for (int i = 0; i < properties.Length; i++)
            {
                generatedCode.AppendLine(
                    "                " + OldHelpers.GetVariableName("row" + properties[i].Name)
                    + (i < properties.Length - 1 ? "," : ");"));
            }

            generatedCode.AppendLine("        }");
        }
    }
}
