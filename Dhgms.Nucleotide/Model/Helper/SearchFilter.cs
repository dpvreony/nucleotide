// --------------------------------------------------------------------------------------------------------------------
// <copyright company="DHGMS Solutions" file="SearchFilter.cs">
//   Licensed under GNU General Public License version 2 (GPLv2)
// </copyright>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace Dhgms.Nucleotide.Model.Helper
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    using Dhgms.Nucleotide.Model.Info.PropertyInfo;

    /// <summary>
    /// Helper class for generating a search filter
    /// </summary>
    public class SearchFilter : BaseClassGenerator
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchFilter"/> class. 
        /// Constructor
        /// </summary>
        public SearchFilter()
            : base("Dhgms.DataManager.Model.Info.SearchFilter.Base", "SearchFilter")
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the class suffix
        /// </summary>
        /// <returns>the class suffix</returns>
        protected override string GetClassSuffix()
        {
            return "SearchFilter";
        }

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
                        "System.Data.Entity",
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
            Base[] properties, 
            string baseClassName, 
            Base[] baseClassProperties)
        {
        }

        /// <summary>
        /// Builds the Fields Region
        /// </summary>
        /// <param name="sb">
        /// The String Builder to add the code to
        /// </param>
        /// <param name="properties">
        /// The collection of properties for the class
        /// </param>
        protected override void DoFieldsRegion(StringBuilder sb, Base[] properties)
        {
        }

        /// <summary>
        /// Builds the Properties Region
        /// </summary>
        /// <param name="sb">
        /// The String Builder to add the code to
        /// </param>
        /// <param name="properties">
        /// The collection of properties for the class
        /// </param>
        /// <param name="baseClassProperties">
        /// The properties of the base class
        /// </param>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        protected override void DoPropertiesRegion(StringBuilder sb, Base[] properties, Base[] baseClassProperties)
        {
            sb.AppendLine("        #region properties");

            foreach (Base pi in properties)
            {
                sb.AppendLine("        /// <summary>");
                sb.AppendLine("        /// " + pi.Description);
                sb.AppendLine("        /// </summary>");

                sb.AppendLine("        public Dhgms.DataManager.Model.SearchFilterComparison.Base " + pi.Name);
                sb.AppendLine("        {");
                sb.AppendLine("            get;");
                sb.AppendLine("            set;");
                sb.AppendLine("        }");
                sb.AppendLine(string.Empty);
            }

            DoGetHeaderRecordMethod(sb, properties, baseClassProperties);

            this.OnDoClassSpecificProperties(sb, properties);

            sb.AppendLine("        #endregion");
            sb.AppendLine(string.Empty);
        }

        /// <summary>
        /// The do to string array method.
        /// </summary>
        /// <param name="sb">
        /// The String Builder to add the code to
        /// </param>
        /// <param name="properties">
        /// Properties of the info class
        /// </param>
        /// <param name="baseClassProperties">
        /// The properties of the base class
        /// </param>
        protected override void DoToStringArrayMethod(StringBuilder sb, Base[] properties, Base[] baseClassProperties)
        {
            sb.AppendLine("            /// <summary>");
            sb.AppendLine("            /// Gets a collection of string data for use for something like a CSV file");
            sb.AppendLine("            /// </summary>");
            sb.AppendLine("            /// <returns>a collection of strings representing the data record</returns>");
            sb.AppendLine("            public override System.Collections.Generic.IList<System.String> ToStringArray()");
            sb.AppendLine("            {");
            sb.AppendLine("                throw new System.NotImplementedException();");
            sb.AppendLine("            }");
        }

        /// <summary>
        /// Generates the DoXmlElement method.
        /// </summary>
        /// <param name="sb">
        /// The String Builder to add the code to
        /// </param>
        /// <param name="properties">
        /// Properties of the info class
        /// </param>
        /// <param name="baseClassProperties">
        /// The properties of the base class
        /// </param>
        protected override void DoDoXmlElementMethod(StringBuilder sb, Base[] properties, Base[] baseClassProperties)
        {
            sb.AppendLine("            /// <summary>");
            sb.AppendLine("            /// Adds an XML Element to an XML Writer");
            sb.AppendLine("            /// </summary>");
            sb.AppendLine("            public override void DoXmlElement(");
            sb.AppendLine("                    System.Xml.XmlWriter writer,");
            sb.AppendLine("                    string parentElementName)");
            sb.AppendLine("            {");
            sb.AppendLine("                throw new System.NotImplementedException();");
            sb.AppendLine("            }");
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
        protected override string GetConstructorParameterType(Base propertyInfo)
        {
            return "Dhgms.DataManager.Model.SearchFilterComparison.Base";
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
        protected override string GetPropertyType(Base pi)
        {
            return "Dhgms.DataManager.Model.SearchFilterComparison.Base";
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
        protected override string GetValueForToStringArray(Base pi)
        {
            if (pi == null)
            {
                throw new ArgumentNullException("pi");
            }

            return pi.Name + "? \"1\" : \"0\"";
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
        protected override void OnDoClassSpecificProperties(StringBuilder sb, Base[] properties)
        {
        }

        /// <summary>
        /// Generates the code for comparing properties in the CompareTo method
        /// </summary>
        /// <param name="sb">
        /// StringBuilder to add the code to
        /// </param>
        /// <param name="properties">
        /// The properties to generate code for
        /// </param>
        /// <param name="baseClassProperties">
        /// Properties in the base class, if any
        /// </param>
        /// <param name="checkResultDeclared">
        /// Whether the check result variable has been declared yet
        /// </param>
        protected override void OnDoCompareToProperties(
            StringBuilder sb, Base[] properties, Base[] baseClassProperties, bool checkResultDeclared)
        {
            int returnResultCounter = (baseClassProperties == null) ? 1 : baseClassProperties.Length + 1;

            foreach (Base pi in properties)
            {
                sb.Append("            ");
                if (!checkResultDeclared)
                {
                    sb.Append("int ");
                }

                sb.AppendLine("            checkResult = " + pi.Name + ".CompareTo(other." + pi.Name + ");");
                sb.AppendLine("            if(checkResult != 0)");
                sb.AppendLine("            {");
                sb.AppendLine(
                    "                return (checkResult > 0) ? " + returnResultCounter + " : -" + returnResultCounter + ";");
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
        protected override void OnDoFieldItem(StringBuilder sb, Base pi)
        {
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
        protected override void OnDoPropertyMutator(StringBuilder sb, Base pi)
        {
            if (sb == null)
            {
                throw new ArgumentNullException("sb");
            }

            if (pi == null)
            {
                throw new ArgumentNullException("pi");
            }

            sb.AppendLine("            set");
            sb.AppendLine("            {");
            sb.AppendLine("                _" + pi.Name + " = value;");
            sb.AppendLine("            }");
        }

        #endregion
    }
}