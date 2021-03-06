﻿//// --------------------------------------------------------------------------------------------------------------------
//// <copyright company="DHGMS Solutions" file="Difference.cs">
////   Licensed under GNU General Public License version 2 (GPLv2)
//// </copyright>
//// 
//// --------------------------------------------------------------------------------------------------------------------

//namespace Dhgms.Nucleotide.Generators
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Text;

//    using Dhgms.Nucleotide.PropertyInfo;

//    /// <summary>
//    /// Helper class for generating a difference class
//    /// </summary>
//    public class DifferenceClassGenerator : BaseClassGenerator
//    {
//        #region Constructors and Destructors

//        /// <summary>
//        /// Initializes a new instance of the <see cref="DifferenceClassGenerator"/> class. 
//        /// Constructor
//        /// </summary>
//        public DifferenceClassGenerator()
//            : base("Dhgms.DataManager.Model.Info.DifferenceBase", "Difference")
//        {
//        }

//        #endregion

//        #region Methods

//        /// <summary>
//        /// Gets the class suffix
//        /// </summary>
//        /// <returns>the class suffix</returns>
//        protected override string GetClassSuffix()
//        {
//            return "Difference";
//        }

//        /// <summary>
//        /// Gets a collection of namespaces used by the code.
//        /// </summary>
//        /// <returns>Collection of namespaces</returns>
//        protected override IEnumerable<string> GetUsingNamespaces()
//        {
//            return new[]
//                       {
//                        "System",
//                        "System.ComponentModel.DataAnnotations",
//                        "System.Diagnostics",
//                        "System.Diagnostics.CodeAnalysis",
//                        "System.Runtime.Serialization",
//                        "System.Xml",
//                        "System.Xml.Linq"
//                       };
//        }

//        /// <summary>
//        /// Produces code for class specific methods
//        /// </summary>
//        /// <param name="sb">
//        /// The String Builder to add the code to
//        /// </param>
//        /// <param name="mainNamespaceName">
//        /// The main namespace
//        /// </param>
//        /// <param name="subNamespace">
//        /// The sub namespace, if any
//        /// </param>
//        /// <param name="className">
//        /// The class name
//        /// </param>
//        /// <param name="properties">
//        /// Properties of the info class
//        /// </param>
//        /// <param name="baseClassName">
//        /// The name of the base class
//        /// </param>
//        /// <param name="baseClassProperties">
//        /// The properties of the base class
//        /// </param>
//        protected override void DoClassSpecificMethods(
//            StringBuilder sb, 
//            string mainNamespaceName, 
//            string subNamespace, 
//            string className, 
//            PropertyInfoBase[] properties, 
//            string baseClassName, 
//            PropertyInfoBase[] baseClassProperties)
//        {
//        }

//        /// <summary>
//        /// Builds the Fields Region
//        /// </summary>
//        /// <param name="sb">
//        /// The String Builder to add the code to
//        /// </param>
//        /// <param name="properties">
//        /// The collection of properties for the class
//        /// </param>
//        protected override void DoFieldsRegion(StringBuilder sb, PropertyInfoBase[] properties)
//        {
//            // no op
//        }

//        /// <summary>
//        /// Builds the Properties Region
//        /// </summary>
//        /// <param name="sb">
//        /// The String Builder to add the code to
//        /// </param>
//        /// <param name="properties">
//        /// The collection of properties for the class
//        /// </param>
//        /// <param name="baseClassProperties">
//        /// The properties of the base class
//        /// </param>
//        protected override void DoPropertiesRegion(StringBuilder sb, PropertyInfoBase[] properties, PropertyInfoBase[] baseClassProperties)
//        {
//            sb.AppendLine("        #region properties");

//            foreach (PropertyInfoBase pi in properties)
//            {
//                sb.AppendLine("        /// <summary>");
//                sb.AppendLine("        /// " + pi.Description);
//                sb.AppendLine("        /// </summary>");

//                sb.AppendLine("        public bool " + pi.Name);
//                sb.AppendLine("        {");
//                sb.AppendLine("            get;");
//                sb.AppendLine("            set;");
//                sb.AppendLine("        }");
//                sb.AppendLine(string.Empty);
//            }

//            this.OnDoClassSpecificProperties(sb, properties);

//            sb.AppendLine("        #endregion");
//            sb.AppendLine(string.Empty);
//        }

//        /// <summary>
//        /// Gets the type to be used for a parameter in the constructor
//        /// </summary>
//        /// <param name="propertyInfo">
//        /// the property
//        /// </param>
//        /// <returns>
//        /// The parameter type used in a constructor
//        /// </returns>
//        protected override string GetConstructorParameterType(PropertyInfoBase propertyInfo)
//        {
//            return "bool";
//        }

//        /// <summary>
//        /// Gets the type for a property
//        /// </summary>
//        /// <param name="pi">
//        /// The property to generate a type for
//        /// </param>
//        /// <returns>
//        /// .NET data type
//        /// </returns>
//        protected override string GetPropertyType(PropertyInfoBase pi)
//        {
//            return "bool";
//        }

//        /// <summary>
//        /// Gets the value of the property when converting to a string array.
//        /// </summary>
//        /// <param name="pi">
//        /// property information
//        /// </param>
//        /// <returns>
//        /// the value of the property when converting to a string array
//        /// </returns>
//        protected override string GetValueForToStringArray(PropertyInfoBase pi)
//        {
//            if (pi == null)
//            {
//                throw new ArgumentNullException("pi");
//            }

//            return pi.Name + " ? \"1\" : \"0\"";
//        }

//        /// <summary>
//        /// Does any class specific properties. For example the count property on the difference class
//        /// </summary>
//        /// <param name="sb">
//        /// The String Builder to add the code to
//        /// </param>
//        /// <param name="properties">
//        /// The collection of properties for the class
//        /// </param>
//        protected override void OnDoClassSpecificProperties(StringBuilder sb, PropertyInfoBase[] properties)
//        {
//            if (sb == null)
//            {
//                throw new ArgumentNullException("sb");
//            }

//            if (properties == null)
//            {
//                throw new ArgumentNullException("properties");
//            }

//            sb.AppendLine("            /// <summary>");
//            sb.AppendLine("            /// Gets the number of properties that are different");
//            sb.AppendLine("            /// </summary>");
//            sb.AppendLine("            /// <return>");
//            sb.AppendLine("            /// the number of properties that are different");
//            sb.AppendLine("            /// </return>");
//            sb.AppendLine("            public override int Count");
//            sb.AppendLine("            {");
//            sb.AppendLine("                get");
//            sb.AppendLine("                {");
//            sb.AppendLine("                    return");

//            sb.AppendLine("                    (" + properties[0].Name + " ? 1 : 0)");
//            for (int i = 1; i < properties.Length; i++)
//            {
//                sb.AppendLine("                    + (" + properties[i].Name + " ? 1 : 0)");
//            }

//            sb.AppendLine("                    ;");
//            sb.AppendLine("                }");
//            sb.AppendLine("            }");
//            sb.AppendLine(string.Empty);
//        }

//        /// <summary>
//        /// Generates the code for comparing properties in the CompareTo method
//        /// </summary>
//        /// <param name="sb">
//        /// StringBuilder to add the code to
//        /// </param>
//        /// <param name="properties">
//        /// The property to generate code for
//        /// </param>
//        /// <param name="baseClassProperties">
//        /// Properties in the base class, if any
//        /// </param>
//        /// <param name="checkResultDeclared">
//        /// Whether the check result variable has been declared yet
//        /// </param>
//        protected override void OnDoCompareToProperties(
//            StringBuilder sb, PropertyInfoBase[] properties, PropertyInfoBase[] baseClassProperties, bool checkResultDeclared)
//        {
//            int returnResultCounter = (baseClassProperties == null) ? 1 : baseClassProperties.Length + 1;

//            foreach (PropertyInfoBase pi in properties)
//            {
//                sb.Append("            ");
//                if (!checkResultDeclared)
//                {
//                    sb.Append("int ");
//                }

//                sb.AppendLine("            checkResult = " + pi.Name + ".CompareTo(other." + pi.Name + ");");
//                sb.AppendLine("            if(checkResult != 0)");
//                sb.AppendLine("            {");
//                sb.AppendLine(
//                    "                return (checkResult > 0) ? " + returnResultCounter + " : -" + returnResultCounter
//                    + ";");
//                sb.AppendLine("            }");
//                sb.AppendLine(string.Empty);

//                if (!checkResultDeclared)
//                {
//                    checkResultDeclared = true;
//                }

//                returnResultCounter++;
//            }
//        }

//        /// <summary>
//        /// Generates the field code for a property member
//        /// </summary>
//        /// <param name="sb">
//        /// The String Builder to add the code to
//        /// </param>
//        /// <param name="pi">
//        /// The property to generate a field for
//        /// </param>
//        protected override void OnDoFieldItem(StringBuilder sb, PropertyInfoBase pi)
//        {
//            if (sb == null)
//            {
//                throw new ArgumentNullException("sb");
//            }

//            if (pi == null)
//            {
//                throw new ArgumentNullException("pi");
//            }

//            sb.AppendLine("            bool _" + OldHelpers.GetVariableName(pi.Name) + ";");
//        }

//        /// <summary>
//        /// Generates the mutator for the property
//        /// </summary>
//        /// <param name="sb">
//        /// The String Builder to add the code to
//        /// </param>
//        /// <param name="pi">
//        /// The property to generate the mutator for
//        /// </param>
//        protected override void OnDoPropertyMutator(StringBuilder sb, PropertyInfoBase pi)
//        {
//            if (sb == null)
//            {
//                throw new ArgumentNullException("sb");
//            }

//            if (pi == null)
//            {
//                throw new ArgumentNullException("pi");
//            }

//            sb.AppendLine("            set");
//            sb.AppendLine("            {");
//            sb.AppendLine("                _" + OldHelpers.GetVariableName(pi.Name) + " = value;");
//            sb.AppendLine("            }");
//        }

//        /// <summary>
//        /// Generates code for the OnDispose event
//        /// </summary>
//        /// <param name="sb">string builder to add the code to</param>
//        /// <param name="properties">list of properties belonging to the class</param>
//        /// <param name="baseClassName">the name of the base class, if different from normal</param>
//        protected override void DoDisposeMethod(StringBuilder sb, IEnumerable<PropertyInfoBase> properties, string baseClassName)
//        {
//            sb.AppendLine("            /// <summary>");
//            sb.AppendLine("            /// The on disposing event");
//            sb.AppendLine("            /// </summary>");
//            sb.AppendLine("            protected override void OnDisposing()");
//            sb.AppendLine("            {");
//            sb.AppendLine("            }");
//        }

//        /// <summary>
//        /// The do get hash code method.
//        /// </summary>
//        /// <param name="sb">
//        /// The String Builder to add the code to
//        /// </param>
//        /// <param name="properties">
//        /// Properties of the info class
//        /// </param>
//        /// <param name="baseClassProperties">
//        /// The properties of the base class
//        /// </param>
//        protected override void DoGetHashCodeMethod(
//            StringBuilder sb, IList<PropertyInfoBase> properties, ICollection<PropertyInfoBase> baseClassProperties)
//        {
//            sb.AppendLine("        /// <summary>");
//            sb.AppendLine("        /// Gets the hash code for the object");
//            sb.AppendLine("        /// </summary>");
//            sb.AppendLine("        /// <returns>hash code</returns>");
//            sb.AppendLine("        public override int GetHashCode()");
//            sb.AppendLine("        {");

//            if ((baseClassProperties != null ? baseClassProperties.Count : 0) + properties.Count > 1)
//            {
//                sb.AppendLine("            return");

//                if (baseClassProperties != null && baseClassProperties.Count > 0)
//                {
//                    sb.AppendLine("                base.GetHashCode() ^");
//                }

//                sb.AppendLine("                this." + properties[0].Name + ".GetHashCode()");

//                int counter = 1;
//                while (counter < properties.Count - 1)
//                {
//                    sb.AppendLine("                ^ this." + properties[counter].Name + ".GetHashCode()");
//                    counter++;
//                }

//                sb.AppendLine("                ^ this." + properties[properties.Count - 1].Name + ".GetHashCode();");
//            }
//            else
//            {
//                sb.AppendLine("            return this." + properties[0].Name + ".GetHashCode();");
//            }

//            sb.AppendLine("        }");
//            sb.AppendLine(string.Empty);
//        }
//        #endregion
//    }
//}