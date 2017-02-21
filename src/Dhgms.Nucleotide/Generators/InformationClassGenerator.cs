﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright company="DHGMS Solutions" file="Information.cs">
//   Licensed under GNU General Public License version 2 (GPLv2)
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Dhgms.Nucleotide.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Dhgms.Nucleotide.Model;
    using Dhgms.Nucleotide.PropertyInfo;

    /// <summary>
    /// Helper for generating an information class
    /// </summary>
    public class InformationClassGenerator : BaseClassGenerator
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InformationClassGenerator"/> class. 
        /// </summary>
        public InformationClassGenerator()
            : base("Dhgms.DataManager.Model.Info.InfoBase", "Info")
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a collection of namespaces used by the code.
        /// </summary>
        /// <returns>Collection of namespaces</returns>
        protected override IEnumerable<string> GetUsingNamespaces()
        {
            return new[]
                       {
                        "System",
                        "System.ComponentModel.DataAnnotations",
                        "System.Diagnostics",
                        "System.Diagnostics.CodeAnalysis",
                        "System.Runtime.Serialization",
                        "System.Xml",
                        "System.Xml.Linq"
                       };
        }

        /// <summary>
        /// Produces code for class specific methods
        /// </summary>
        /// <param name="sb">
        /// The String Builder to add the code to
        /// </param>
        /// <param name="mainNamespaceName">
        /// The main namespace
        /// </param>
        /// <param name="subNamespace">
        /// The sub namespace, if any
        /// </param>
        /// <param name="className">
        /// The class name
        /// </param>
        /// <param name="properties">
        /// Properties of the info class
        /// </param>
        /// <param name="baseClassName">
        /// The name of the base class
        /// </param>
        /// <param name="baseClassProperties">
        /// The properties of the base class
        /// </param>
        protected override void DoClassSpecificMethods(
            StringBuilder sb, 
            string mainNamespaceName, 
            string subNamespace, 
            string className, 
            PropertyInfoBase[] properties, 
            string baseClassName, 
            PropertyInfoBase[] baseClassProperties)
        {
            DoGetDifferencesMethod(sb, mainNamespaceName, subNamespace, className, properties, baseClassProperties);
        }

        /// <summary>
        /// Gets the class suffix
        /// </summary>
        /// <returns>
        /// the class suffix
        /// </returns>
        protected override string GetClassSuffix()
        {
            return string.Empty;
        }

        /// <summary>
        /// Gets the type to be used for a parameter in the constructor
        /// </summary>
        /// <param name="propertyInfo">
        /// the property
        /// </param>
        /// <returns>
        /// the constructor parameter type
        /// </returns>
        protected override string GetConstructorParameterType(PropertyInfoBase propertyInfo)
        {
            if (propertyInfo == null)
            {
                throw new ArgumentNullException("propertyInfo");
            }

            return propertyInfo.GetCSharpDataTypeDeclaration()
                   +
                   ((propertyInfo.Optional && !propertyInfo.NetDataType.Equals("string", StringComparison.Ordinal))
                        ? "?"
                        : string.Empty);
        }

        /// <summary>
        /// Gets the type for a property
        /// </summary>
        /// <param name="pi">
        /// The property to generate a type for
        /// </param>
        /// <returns>
        /// .NET data type
        /// </returns>
        protected override string GetPropertyType(PropertyInfoBase pi)
        {
            if (pi == null)
            {
                throw new ArgumentNullException("pi");
            }

            string optional = (pi.Optional && !pi.NetDataType.Equals("string", StringComparison.Ordinal))
                                  ? "?"
                                  : string.Empty;
            return pi.GetCSharpDataTypeDeclaration() + optional;
        }

        /// <summary>
        /// Gets the value of the property when converting to a string array.
        /// </summary>
        /// <param name="pi">
        /// property information
        /// </param>
        /// <returns>
        /// the value of the property when converting to a string array
        /// </returns>
        protected override string GetValueForToStringArray(PropertyInfoBase pi)
        {
            if (pi == null)
            {
                throw new ArgumentNullException("pi");
            }

            if (!pi.NetDataType.Equals("string", StringComparison.Ordinal))
            {
                string stringArrayCode = pi.ToStringArrayCode;

                if (pi.Optional)
                {
                    return pi.Name + ".HasValue ? " + pi.Name + ".Value"
                           + (stringArrayCode.Length > 0 ? "." : string.Empty) + stringArrayCode + " : null";
                }

                return pi.Name + (stringArrayCode.Length > 0 ? "." : string.Empty) + stringArrayCode;
            }

            return pi.Name;
        }

        /// <summary>
        /// Does any class specific properties. For example the count property on the difference class
        /// </summary>
        /// <param name="sb">
        /// The String Builder to add the code to
        /// </param>
        /// <param name="properties">
        /// The collection of properties for the class
        /// </param>
        protected override void OnDoClassSpecificProperties(StringBuilder sb, PropertyInfoBase[] properties)
        {
        }

        /// <summary>
        /// Generates the code for comparing properties in the CompareTo method
        /// </summary>
        /// <param name="sb">
        /// StringBuilder to add the code to
        /// </param>
        /// <param name="properties">
        /// The property to generate code for
        /// </param>
        /// <param name="baseClassProperties">
        /// Properties in the base class, if any
        /// </param>
        /// <param name="checkResultDeclared">
        /// Whether the check result variable has been declared yet
        /// </param>
        protected override void OnDoCompareToProperties(
            StringBuilder sb, PropertyInfoBase[] properties, PropertyInfoBase[] baseClassProperties, bool checkResultDeclared)
        {
            int returnResultCounter = (baseClassProperties == null) ? 1 : baseClassProperties.Length + 1;
            foreach (PropertyInfoBase pi in properties)
            {
                sb.AppendLine("            // " + pi.Name);
                if (pi.Collection != CollectionType.None)
                {
                    sb.Append("            ");
                    if (!checkResultDeclared)
                    {
                        sb.Append("var ");
                    }

                    sb.AppendLine("checkResult = CompareCollection(" + pi.Name + ", other." + pi.Name + ");");
                }
                else
                {
                    sb.AppendLine(pi.GetCSharpCompareCode(checkResultDeclared));
                }

                sb.AppendLine("            if (checkResult != 0)");
                sb.AppendLine("            {");
                sb.AppendLine(
                    "                return (checkResult > 0) ? " + returnResultCounter + " : -" + returnResultCounter
                    + ";");
                sb.AppendLine("            }");
                sb.AppendLine(string.Empty);

                if (!checkResultDeclared)
                {
                    checkResultDeclared = true;
                }

                returnResultCounter++;
            }
        }

        /// <summary>
        /// Generates the field code for a property member
        /// </summary>
        /// <param name="sb">
        /// The String Builder to add the code to
        /// </param>
        /// <param name="pi">
        /// The property to generate a field for
        /// </param>
        protected override void OnDoFieldItem(StringBuilder sb, PropertyInfoBase pi)
        {
            if (sb == null)
            {
                throw new ArgumentNullException("sb");
            }

            if (pi == null)
            {
                throw new ArgumentNullException("pi");
            }

            string optional = (pi.Optional && !pi.NetDataType.Equals("string", StringComparison.Ordinal))
                                  ? "?"
                                  : string.Empty;
            sb.AppendLine(
                "            private " + pi.GetCSharpDataTypeDeclaration() + optional + " "
                + OldHelpers.GetVariableName(pi.Name) + ";");
        }

        /// <summary>
        /// Generates the setter for the property
        /// </summary>
        /// <param name="sb">
        /// The String Builder to add the code to
        /// </param>
        /// <param name="pi">
        /// The property to generate the setter for
        /// </param>
        protected override void OnDoPropertyMutator(StringBuilder sb, PropertyInfoBase pi)
        {
            if (sb == null)
            {
                throw new ArgumentNullException("sb");
            }

            if (pi == null)
            {
                throw new ArgumentNullException("pi");
            }

            sb.Append(pi.GetMutator());
        }

        /// <summary>
        /// Generates the GetDifferences method
        /// </summary>
        /// <param name="sb">
        /// StringBuilder to add the code to
        /// </param>
        /// <param name="mainNamespaceName">
        /// The main namespace
        /// </param>
        /// <param name="subNamespace">
        /// The sub namespace, if any
        /// </param>
        /// <param name="className">
        /// The class name
        /// </param>
        /// <param name="properties">
        /// Properties of the info class
        /// </param>
        /// <param name="baseClassProperties">
        /// The properties of the base class
        /// </param>
        private static void DoGetDifferencesMethod(
            StringBuilder sb, 
            string mainNamespaceName, 
            string subNamespace, 
            string className, 
            IList<PropertyInfoBase> properties, 
            IList<PropertyInfoBase> baseClassProperties)
        {
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// Checks this instance against another to see where there are differences");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"other\">other instance to compare</param>");
            sb.AppendLine("        /// <returns>summary of where there are differences</returns>");
            sb.AppendLine("// ReSharper disable RedundantNameQualifier");
            sb.AppendLine(
                "        public " + mainNamespaceName + ".Model"
                + ((!string.IsNullOrEmpty(subNamespace)) ? "." + subNamespace : null) + "." + className + "Difference"
                + " GetDifferences(" + className + " other)");
            sb.AppendLine("// ReSharper restore RedundantNameQualifier");
            sb.AppendLine("        {");
            sb.AppendLine("            if (other == null)");
            sb.AppendLine("            {");
            sb.AppendLine("                throw new System.ArgumentNullException(\"other\");");
            sb.AppendLine("            }");
            sb.AppendLine(string.Empty);

            bool checkResultDeclared = false;

            if (baseClassProperties != null && baseClassProperties.Count > 0)
            {
                foreach (PropertyInfoBase pi in baseClassProperties)
                {
                    sb.AppendLine("            // " + pi.Name);
                    if (pi.Collection != CollectionType.None)
                    {
                        sb.Append("            ");

                        if (!checkResultDeclared)
                        {
                            sb.Append("var ");
                        }

                        sb.AppendLine("checkResult = CompareCollection(" + pi.Name + ", other." + pi.Name + ");");
                    }
                    else
                    {
                        sb.AppendLine(pi.GetCSharpCompareCode(checkResultDeclared));
                    }

                    sb.AppendLine("            var " + OldHelpers.GetVariableName(pi.Name) + "Different = checkResult != 0;");
                    sb.AppendLine(string.Empty);

                    if (!checkResultDeclared)
                    {
                        checkResultDeclared = true;
                    }
                }
            }

            foreach (PropertyInfoBase pi in properties)
            {
                sb.AppendLine("            // " + pi.Name);
                if (pi.Collection != CollectionType.None)
                {
                    sb.Append("            ");

                    if (!checkResultDeclared)
                    {
                        sb.Append("var ");
                    }

                    sb.AppendLine("checkResult = CompareCollection(" + pi.Name + ", other." + pi.Name + ");");
                }
                else
                {
                    sb.AppendLine(pi.GetCSharpCompareCode(checkResultDeclared));
                }

                sb.AppendLine("            var " + OldHelpers.GetVariableName(pi.Name) + "Different = checkResult != 0;");
                sb.AppendLine(string.Empty);

                if (!checkResultDeclared)
                {
                    checkResultDeclared = true;
                }
            }

            sb.AppendLine("// ReSharper disable RedundantNameQualifier");
            sb.AppendLine(
                "            return new " + mainNamespaceName + ".Model"
                + ((!string.IsNullOrEmpty(subNamespace)) ? "." + subNamespace : null) + "." + className + "Difference(");
            sb.AppendLine("// ReSharper restore RedundantNameQualifier");

            var counter = 0;
            if (baseClassProperties != null && baseClassProperties.Count > 0)
            {
                while (counter < baseClassProperties.Count)
                {
                    sb.Append("                " + OldHelpers.GetVariableName(baseClassProperties[counter].Name + "Different"));

                    if (properties.Count > 0)
                    {
                        sb.AppendLine(",");
                    }
                    else
                    {
                        sb.AppendLine(counter < baseClassProperties.Count - 1 ? "," : ");");
                    }

                    counter++;
                }
            }

            counter = 0;

            while (counter < properties.Count)
            {
                sb.Append("                " + OldHelpers.GetVariableName(properties[counter].Name + "Different"));
                sb.AppendLine(counter < properties.Count - 1 ? "," : ");");
                counter++;
            }
            sb.AppendLine("        }");
            sb.AppendLine(string.Empty);
        }

        #endregion
    }
}