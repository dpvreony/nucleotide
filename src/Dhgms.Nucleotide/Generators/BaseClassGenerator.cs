﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseClassGenerator.cs" company="DHGMS Solutions">
//   Licensed under GNU General Public License version 2 (GPLv2)
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Dhgms.Nucleotide.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using Dhgms.Nucleotide.Model;
    using Dhgms.Nucleotide.PropertyInfo;

    /// <summary>
    ///     Base Class for Code Generated Classes
    /// </summary>
    public abstract class BaseClassGenerator : GeneratorBase
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseClassGenerator"/> class.
        ///     Constructor
        /// </summary>
        /// <param name="defaultBaseNamespace">
        /// The default namespace for the base class of the class being generated
        /// </param>
        /// <param name="classTypeName">
        /// The type of class being produced (i.e. info, difference, viewfilter, searchfilter
        /// </param>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        protected BaseClassGenerator(string defaultBaseNamespace, string classTypeName)
        {
            this.DefaultBaseNamespace = defaultBaseNamespace;
            this.ClassTypeName = classTypeName;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the type of class being produced (i.e. info, difference, view filter, search filter)
        /// </summary>
        protected string ClassTypeName { get; private set; }

        /// <summary>
        ///     Gets the default namespace for the base class of the class being generated
        /// </summary>
        protected string DefaultBaseNamespace { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Carries out the generation of code for a class
        /// </summary>
        /// <param name="sb">The string builder to append code to.</param>
        /// <param name="classGenerationParameters">The class generation parameters</param>
        protected override void DoGenerationOfClass(StringBuilder sb, IClassGenerationParameters classGenerationParameters)
        {
            if (classGenerationParameters == null)
            {
                throw new ArgumentNullException("classGenerationParameters");
            }

            var mainNamespaceName = classGenerationParameters.MainNamespaceName;
            if (string.IsNullOrWhiteSpace(mainNamespaceName))
            {
                throw new ArgumentException("MainNamespaceName", "classGenerationParameters");
            }

            var className = classGenerationParameters.ClassName;
            if (string.IsNullOrWhiteSpace(className))
            {
                throw new ArgumentException("ClassName", "classGenerationParameters");
            }

            var companyName = classGenerationParameters.CompanyName;
            if (string.IsNullOrWhiteSpace(companyName))
            {
                throw new ArgumentException("CompanyName", "classGenerationParameters");
            }

            var copyrightBanner = classGenerationParameters.CopyrightBanner;
            if (copyrightBanner == null || copyrightBanner.Length < 1)
            {
                throw new ArgumentException("copyrightBanner", "classGenerationParameters");
            }

            var copyrightStartYear = classGenerationParameters.CopyrightStartYear;
            if (copyrightStartYear < 1900)
            {
                throw new ArgumentException("CopyrightStartYear", "classGenerationParameters");
            }

            var classRemarks = classGenerationParameters.ClassRemarks;
            if (string.IsNullOrWhiteSpace(classRemarks))
            {
                throw new ArgumentException("ClassRemarks", "classGenerationParameters");
            }

            var properties = classGenerationParameters.Properties;
            if (properties == null)
            {
                throw new ArgumentException("Properties", "classGenerationParameters");
            }

            if (properties.Count(p => p.IsKey) > 1)
            {
                throw new ArgumentException("Too many primary keys defined");
            }

            //var subNamespace = classGenerationParameters.SubNamespace;
            //sb.AppendLine(
            //    "namespace " + mainNamespaceName + ".Model." + this.ClassTypeName
            //    + ((!string.IsNullOrEmpty(subNamespace)) ? "." + subNamespace : null));
            //sb.AppendLine("{");

            //foreach (string ns in this.GetUsingNamespaces())
            //{
            //    var indentation = Helpers.GetTabs(2);
            //    sb.AppendLine(string.Format("{0}using {1};", indentation, ns));
            //}

            sb.AppendLine(string.Empty);
            sb.AppendLine(Helpers.GetAutoGeneratedWarning());
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// " + classRemarks);
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        [System.Runtime.Serialization.DataContract]");
            sb.AppendLine("        public class " + className + this.GetClassSuffix());
            sb.AppendLine("// ReSharper disable RedundantNameQualifier");

            var baseClassName = classGenerationParameters.BaseClassName;
            var baseClassProperties = classGenerationParameters.BaseClassProperties;
            if (string.IsNullOrWhiteSpace(baseClassName) == false && baseClassProperties != null
                && baseClassProperties.Length > 0)
            {
                sb.AppendLine("            : " + baseClassName + this.GetClassSuffix());
            }
            else
            {
                sb.AppendLine(
                    "            : " + this.DefaultBaseNamespace + "<" + className + this.GetClassSuffix() + ">, I" + className + this.GetClassSuffix());
            }

            sb.AppendLine("// ReSharper restore RedundantNameQualifier");
            sb.AppendLine("        {");

            this.DoFieldsRegion(sb, properties);
            this.DoConstructorMethod(sb, className, properties, baseClassName, baseClassProperties);
            this.DoPropertiesRegion(sb, properties, baseClassProperties);
            this.DoIComparableRegion(sb, className, properties, baseClassName, baseClassProperties);

            sb.Append(Helpers.GetIEquatableRegion(className + this.GetClassSuffix(), baseClassName, baseClassProperties));

            this.DoOurMethodsRegion(
                sb, mainNamespaceName, classGenerationParameters.SubNamespace, className, properties, baseClassName, baseClassProperties);

            this.DoDisposeMethod(sb, properties, baseClassName);

            sb.AppendLine("    }");
            //sb.AppendLine("}");
        }

        /// <summary>
        /// Gets a collection of namespaces used by the code.
        /// </summary>
        /// <returns>Collection of namespaces</returns>
        protected abstract IEnumerable<string> GetUsingNamespaces();

        #endregion

        #region Methods

        /// <summary>
        /// Generates the comments for the parameters of the constructor
        /// </summary>
        /// <param name="sb">
        /// The String Builder to add the code to
        /// </param>
        /// <param name="properties">
        /// Properties of the info class
        /// </param>
        protected static void DoConstructorParamComments(StringBuilder sb, PropertyInfoBase[] properties)
        {
            foreach (PropertyInfoBase pi in properties)
            {
                sb.AppendLine(
                    "        /// <param name=\"" + Helpers.GetVariableName(pi.Name) + "\">" + pi.Description + "</param>");
            }
        }

        ///// <summary>
        ///// The do get header record method.
        ///// </summary>
        ///// <param name="sb">
        ///// The String Builder to add the code to
        ///// </param>
        ///// <param name="properties">
        ///// Properties of the info class
        ///// </param>
        ///// <param name="baseClassProperties">
        ///// The properties of the base class
        ///// </param>
        //protected static void DoGetHeaderRecordMethod(
        //    StringBuilder sb, IList<PropertyInfoBase> properties, ICollection<PropertyInfoBase> baseClassProperties)
        //{
        //    sb.AppendLine("            /// <summary>");
        //    sb.AppendLine("            /// Gets a header record for use for something like a CSV file");
        //    sb.AppendLine("            /// </summary>");
        //    sb.AppendLine("            /// <returns>a collection of strings representing the header record</returns>");
        //    sb.AppendLine("            public override System.Collections.Generic.IList<string> HeaderRecord");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                get");
        //    sb.AppendLine("                {");
        //    sb.Append("                    var result = new System.Collections.Generic.List<string>");
        //    if (baseClassProperties != null && baseClassProperties.Count > 0)
        //    {
        //        sb.Append("(base.HeaderRecord)");
        //    }

        //    sb.AppendLine(string.Empty);
        //    sb.AppendLine("                    {");

        //    for (int i = 0; i < properties.Count; i++)
        //    {
        //        sb.AppendLine(
        //            "                        \"" + properties[i].Name + "\""
        //            + (i < properties.Count - 1 ? "," : string.Empty));
        //    }

        //    sb.AppendLine("                    };");
        //    sb.AppendLine(string.Empty);
        //    sb.AppendLine("                    return result;");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("            }");
        //    sb.AppendLine(string.Empty);
        //}

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
        protected abstract void DoClassSpecificMethods(
            StringBuilder sb, 
            string mainNamespaceName, 
            string subNamespace, 
            string className, 
            PropertyInfoBase[] properties, 
            string baseClassName, 
            PropertyInfoBase[] baseClassProperties);

        /// <summary>
        /// The do constructor method.
        /// </summary>
        /// <param name="sb">
        /// The String Builder to add the code to
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
        protected virtual void DoConstructorMethod(
            StringBuilder sb, string className, PropertyInfoBase[] properties, string baseClassName, PropertyInfoBase[] baseClassProperties)
        {
            // Default Constructor
            sb.AppendLine(Helpers.GetAutoGeneratedWarning());
            sb.AppendLine("        /// <summary>");
            sb.AppendLine(
                "        /// Initializes a new instance of the <see cref=\"" + className + this.GetClassSuffix()
                + "\"/> class.");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public " + className + this.GetClassSuffix() + "()");
            sb.AppendLine("        {");
            sb.AppendLine("        }");
            sb.AppendLine(string.Empty);

            // Copy Constructor
            sb.AppendLine("        /// <summary>");
            sb.AppendLine(
                "        /// Initializes a new instance of the <see cref=\"" + className + this.GetClassSuffix()
                + "\"/> class.");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"other\">");
            sb.AppendLine("        /// Object to copy");
            sb.AppendLine("        /// </param>");
            sb.AppendLine(
                "        public " + className + this.GetClassSuffix() + "(" + className + this.GetClassSuffix()
                + " other)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (other == null)");
            sb.AppendLine("            {");
            sb.AppendLine("                throw new System.ArgumentNullException(\"other\");");
            sb.AppendLine("            }");
            sb.AppendLine(string.Empty);

            foreach (PropertyInfoBase pi in properties)
            {
                sb.AppendLine("            this." + pi.Name + " = other." + pi.Name + ";");
            }

            sb.AppendLine("        }");

            // Constructor
            sb.AppendLine(string.Empty);
            sb.AppendLine(Helpers.GetAutoGeneratedWarning());
            sb.AppendLine("        /// <summary>");
            sb.AppendLine(
                "        /// Initializes a new instance of the <see cref=\"" + className + this.GetClassSuffix()
                + "\"/> class.");
            sb.AppendLine("        /// </summary>");

            if (string.IsNullOrWhiteSpace(baseClassName) == false && baseClassProperties != null
                && baseClassProperties.Length > 0)
            {
                DoConstructorParamComments(sb, baseClassProperties);
            }

            DoConstructorParamComments(sb, properties);

            sb.AppendLine("        public " + className + this.GetClassSuffix() + "(");

            this.DoConstructorParameters(sb, properties, baseClassName, baseClassProperties);

            if (string.IsNullOrWhiteSpace(baseClassName) == false && baseClassProperties != null
                && baseClassProperties.Length > 0)
            {
                sb.AppendLine("            : base(");

                int counter = 0;
                while (counter < baseClassProperties.Length)
                {
                    sb.Append("                " + Helpers.GetVariableName(baseClassProperties[counter].Name));
                    counter++;
                    sb.AppendLine(counter < baseClassProperties.Length ? "," : ")");
                }
            }

            sb.AppendLine("            {");

            foreach (PropertyInfoBase pi in properties)
            {
                sb.AppendLine("            this." + pi.Name + " = " + Helpers.GetVariableName(pi.Name) + ";");
            }

            sb.AppendLine("        }");
            sb.AppendLine(string.Empty);
        }

        /// <summary>
        /// Generates the parameters for the constructor
        /// </summary>
        /// <param name="sb">
        /// The String Builder to add the code to
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
        protected void DoConstructorParameters(
            StringBuilder sb, PropertyInfoBase[] properties, string baseClassName, PropertyInfoBase[] baseClassProperties)
        {
            int counter = 0;
            if (string.IsNullOrWhiteSpace(baseClassName) == false && baseClassProperties != null
                && baseClassProperties.Length > 0)
            {
                while (counter < baseClassProperties.Length)
                {
                    sb.Append(
                        "            " + this.GetConstructorParameterType(baseClassProperties[counter]) + " "
                        + Helpers.GetVariableName(baseClassProperties[counter].Name) + ",");
                    counter++;
                }

                counter = 0;
            }

            while (counter < properties.Length)
            {
                sb.Append(
                    "            " + this.GetConstructorParameterType(properties[counter]) + " "
                    + Helpers.GetVariableName(properties[counter].Name));
                counter++;
                sb.AppendLine(counter < properties.Length ? "," : ")");
            }
        }

        /// <summary>
        /// Generates code for the OnDispose event
        /// </summary>
        /// <param name="sb">
        /// string builder to add the code to
        /// </param>
        /// <param name="properties">
        /// list of properties belonging to the class
        /// </param>
        /// <param name="baseClassName">
        /// the name of the base class, if different from normal
        /// </param>
        protected virtual void DoDisposeMethod(StringBuilder sb, IEnumerable<PropertyInfoBase> properties, string baseClassName)
        {
            sb.AppendLine("            /// <summary>");
            sb.AppendLine("            /// The on disposing event");
            sb.AppendLine("            /// </summary>");
            sb.AppendLine("            protected override void OnDisposing()");
            sb.AppendLine("            {");

            if (!string.IsNullOrWhiteSpace(baseClassName))
            {
                sb.AppendLine("                base.OnDisposing();");
            }

            foreach (PropertyInfoBase pi in properties.Where(pi => !pi.GenerateAutoProperty))
            {
                if (pi.Collection != CollectionType.None || pi.Optional || pi.NullableType)
                {
                    sb.AppendLine("            this." + Helpers.GetVariableName(pi.Name) + " = null;");
                }
                else if (pi.DisposableType)
                {
                    sb.AppendLine("            this." + Helpers.GetVariableName(pi.Name) + ".Dispose();");
                }
            }

            sb.AppendLine("            }");
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
        protected virtual void DoFieldsRegion(StringBuilder sb, PropertyInfoBase[] properties)
        {
            sb.AppendLine("        #region fields");

            foreach (PropertyInfoBase pi in properties.Where(pi => !pi.GenerateAutoProperty))
            {
                sb.AppendLine("            /// <summary>");
                sb.AppendLine("            /// " + pi.Description);
                sb.AppendLine("            /// </summary>");
                sb.AppendLine(
                    "            [System.Diagnostics.CodeAnalysis.SuppressMessage(\"StyleCop.CSharp.ReadabilityRules\", \"SA1121:UseBuiltInTypeAlias\", Justification = \"Reviewed. Suppression is OK here.\")]");
                this.OnDoFieldItem(sb, pi);
                sb.AppendLine(string.Empty);
            }

            sb.AppendLine("        #endregion");
            sb.AppendLine(string.Empty);
        }

        /// <summary>
        /// The do get hash code method.
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
        protected virtual void DoGetHashCodeMethod(
            StringBuilder sb, IList<PropertyInfoBase> properties, ICollection<PropertyInfoBase> baseClassProperties)
        {
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// Gets the hash code for the object");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <returns>hash code</returns>");
            sb.AppendLine("        public override int GetHashCode()");
            sb.AppendLine("        {");
            sb.AppendLine("            return");

            if (baseClassProperties != null && baseClassProperties.Count > 0)
            {
                sb.AppendLine("                base.GetHashCode() ^");
            }

            sb.AppendLine("                " + properties[0].GetHashcodeOperation());

            int counter = 1;
            while (counter < properties.Count - 1)
            {
                sb.AppendLine("                ^ " + properties[counter].GetHashcodeOperation());
                counter++;
            }

            sb.AppendLine("                ^ " + properties[properties.Count - 1].GetHashcodeOperation() + ";");
            sb.AppendLine("        }");
            sb.AppendLine(string.Empty);
        }

        /// <summary>
        /// Builds the methods required by the IComparable interface
        /// </summary>
        /// <param name="sb">
        /// StringBuilder to add the code to
        /// </param>
        /// <param name="className">
        /// Name of the class
        /// </param>
        /// <param name="properties">
        /// Collection of properties in the class
        /// </param>
        /// <param name="baseClassName">
        /// Base class name, if not using the default
        /// </param>
        /// <param name="baseClassProperties">
        /// Properties in the base class, if any
        /// </param>
        protected virtual void DoIComparableRegion(
            StringBuilder sb, string className, PropertyInfoBase[] properties, string baseClassName, PropertyInfoBase[] baseClassProperties)
        {
            sb.AppendLine("        #region IComparable methods");
            sb.AppendLine(string.Empty);
            sb.AppendLine(Helpers.GetAutoGeneratedWarning());
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// Compares the current instance with another object of the same type.");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"other\">");
            sb.AppendLine("        /// The instance to compare to");
            sb.AppendLine("        /// </param>");
            sb.AppendLine("        /// <returns>");
            sb.AppendLine("        /// 0 if equal, otherwise non zero");
            sb.AppendLine("        /// </returns>");
            string modifier = (!string.IsNullOrWhiteSpace(baseClassName) && baseClassProperties != null
                               && baseClassProperties.Length > 0)
                                  ? null
                                  : "override ";
            sb.AppendLine(
                "        public " + modifier + "int CompareTo(" + className + this.GetClassSuffix() + " other)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (other == null)");
            sb.AppendLine("            {");
            sb.AppendLine("                throw new System.ArgumentNullException(\"other\");");
            sb.AppendLine("            }");
            sb.AppendLine(string.Empty);

            bool checkResultDeclared = false;

            if (!string.IsNullOrWhiteSpace(baseClassName) && baseClassProperties != null
                && baseClassProperties.Length > 0)
            {
                sb.AppendLine(string.Empty);
                sb.AppendLine("        var checkResult = base.CompareTo(other);");
                sb.AppendLine("        if (checkResult != 0)");
                sb.AppendLine("        {");
                sb.AppendLine("            return checkResult;");
                sb.AppendLine("        }");
                sb.AppendLine(string.Empty);

                checkResultDeclared = true;
            }

            this.OnDoCompareToProperties(sb, properties, baseClassProperties, checkResultDeclared);

            sb.AppendLine("            return 0;");
            sb.AppendLine("        }");
            sb.AppendLine(string.Empty);
            sb.AppendLine("        #endregion");
        }

        /// <summary>
        /// Generates OData method for an information class
        /// </summary>
        /// <remarks>
        /// based upon http://blogs.msdn.com/b/astoriateam/archive/2011/10/13/vocabularies-in-wcf-data-services.aspx
        /// </remarks>
        /// <param name="sb">
        /// String builder to add the code to
        /// </param>
        /// <param name="mainNamespaceName">
        /// The main namespace the class sits in
        /// </param>
        /// <param name="subNamespace">
        /// The sub namespace the class sits in
        /// </param>
        /// <param name="className">
        /// The name of the class
        /// </param>
        /// <param name="properties">
        /// Collection of properties for the class
        /// </param>
        /// <param name="baseClassProperties">
        /// Collection of properties for the base case, if any.
        /// </param>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        protected static void DoOdataVocabulariesMethod(
            StringBuilder sb, 
            string mainNamespaceName, 
            string subNamespace, 
            string className, 
            PropertyInfoBase[] properties, 
            PropertyInfoBase[] baseClassProperties)
        {
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// Gets the CDSL that defines the OData Vocabularies for this class");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine(
                "        public static " + (baseClassProperties != null ? "new " : string.Empty)
                + "System.Xml.XmlReader GetOdataVocabularies()");
            sb.AppendLine("        {");

            string fullNamespace = mainNamespaceName
                                   + (!string.IsNullOrWhiteSpace(subNamespace) ? "." + subNamespace : null);

            foreach (PropertyInfoBase property in properties)
            {
                sb.AppendLine("            // " + property.Name);
                sb.AppendLine(string.Empty);
            }

            sb.AppendLine("        var schema = new XElement(");
            sb.AppendLine("            \"Schema\",");
            sb.AppendLine("            new XAttribute(\"Namespace\", \"" + fullNamespace + "\"),");
            sb.AppendLine("            new XAttribute(\"xmlns\", \"http://schemas.microsoft.com/ado/2009/11/edm\"),");
            sb.AppendLine("            // using directive");
            sb.AppendLine("            new XElement(");
            sb.AppendLine("                \"Using\",");
            sb.AppendLine("                new XAttribute(\"Namespace\", \"Org.OData.Validation.V1\"),");
            sb.AppendLine("                new XAttribute(\"Alias\", \"Validation\"),");

            string fullClassName = fullNamespace + "." + className;
            if (baseClassProperties != null && baseClassProperties.Any())
            {
                for (int position = 0; position < baseClassProperties.Count() - 1; position++)
                {
                    sb.AppendLine("                new XElement(\"Annotations\",");
                    sb.AppendLine(
                        "                    new XAttribute(\"Target\", \"" + fullClassName + "/"
                        + baseClassProperties[position].Name + "\")),");
                }

                sb.AppendLine("                new XElement(");
                sb.AppendLine("                    \"Annotations\",");
                sb.AppendLine(
                    "                    new XAttribute(\"Target\", \"" + fullClassName + "/"
                    + baseClassProperties[baseClassProperties.Count() - 1].Name + "\")),");
            }

            for (int position = 0; position < properties.Count() - 1; position++)
            {
                sb.AppendLine("                new XElement(");
                sb.AppendLine("                    \"Annotations\",");
                sb.AppendLine(
                    "                    new XAttribute(\"Target\", \"" + fullClassName + "/"
                    + properties[position].Name + "\")),");
            }

            sb.AppendLine("                new XElement(");
            sb.AppendLine("                    \"Annotations\",");
            sb.AppendLine(
                "                    new XAttribute(\"Target\", \"" + fullClassName + "/"
                + properties[properties.Count() - 1].Name + "\"))));");
            sb.AppendLine(string.Empty);
            sb.AppendLine("        Debug.Assert(schema.Document != null, \"schema.Document != null\");");
            sb.AppendLine("        return schema.Document.CreateReader();");

            /*
            <Schema Namespace="VocabSample" Alias="VocabSample" xmlns="http://schemas.microsoft.com/ado/2009/11/edm">

  <Using Namespace="Org.OData.Validation.V1" Alias="Validation"/>

  <Annotations Target="VocabSample.Person/Age">

    <TypeAnnotation Term="Validation.Range">

      <PropertyValue Property="Min" Decimal="16" />

      <PropertyValue Property="Max" Decimal="90" />

    </TypeAnnotation>

  </Annotations>

</Schema>


            XElement contacts =
    new XElement("Contacts",
        new XElement("Contact",
            new XElement("Name", "Patrick Hines"),
            new XElement("Phone", "206-555-0144",
                new XAttribute("Type", "Home")),
            new XElement("phone", "425-555-0145",
                new XAttribute("Type", "Work")),
            new XElement("Address",
                new XElement("Street1", "123 Main St"),
                new XElement("City", "Mercer Island"),
                new XElement("State", "WA"),
                new XElement("Postal", "68042")
            )
        )
    );
             * */
            sb.AppendLine("        }");
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
        protected virtual void DoPropertiesRegion(StringBuilder sb, PropertyInfoBase[] properties, PropertyInfoBase[] baseClassProperties)
        {
            sb.AppendLine("        #region properties");

            int i = 1;
            foreach (PropertyInfoBase pi in properties)
            {
                sb.AppendLine("        /// <summary>");
                sb.AppendLine("        /// Gets or sets " + pi.Description);
                sb.AppendLine("        /// </summary>");

                sb.AppendLine(
                    "        [System.Diagnostics.CodeAnalysis.SuppressMessage(\"StyleCop.CSharp.ReadabilityRules\", \"SA1121:UseBuiltInTypeAlias\", Justification = \"Reviewed. Suppression is OK here.\")]");

                // WCF Data Member Information
                string required = "IsRequired = " + (!pi.Optional).ToString().ToLower(CultureInfo.InvariantCulture);
                string order = ", Order = " + i++;

                string dataMemberAttributes = "(" + required + order + ")";
                sb.AppendLine("        [System.Runtime.Serialization.DataMember" + dataMemberAttributes + "]");

                // Data Annotation Information
                if (!pi.Optional)
                {
                    sb.AppendLine("        [System.ComponentModel.DataAnnotations.Required]");
                }

                var propertySpecificAnnotations = pi.GetDataAnnotations();
                if (!string.IsNullOrWhiteSpace(propertySpecificAnnotations))
                {
                    sb.AppendLine(propertySpecificAnnotations);
                }

                sb.AppendLine("        public " + this.GetPropertyType(pi) + " " + pi.Name);
                sb.AppendLine("        {");
                if (pi.GenerateAutoProperty)
                {
                    sb.AppendLine("            get;");
                    sb.AppendLine("            set;");
                }
                else
                {
                    sb.AppendLine("            get");
                    sb.AppendLine("            {");
                    sb.AppendLine("                return this." + Helpers.GetVariableName(pi.Name) + ";");
                    sb.AppendLine("            }");
                    sb.AppendLine(string.Empty);
                    this.OnDoPropertyMutator(sb, pi);
                }

                sb.AppendLine("        }");
                sb.AppendLine(string.Empty);
            }

            this.OnDoClassSpecificProperties(sb, properties);

            sb.AppendLine("        #endregion");
            sb.AppendLine(string.Empty);
        }

        //protected virtual void DoToStringArrayMethod(StringBuilder sb, PropertyInfoBase[] properties, PropertyInfoBase[] baseClassProperties)
        //{
        //    bool skipMethod = false;
        //    if (baseClassProperties != null && baseClassProperties.Length > 0)
        //    {
        //        if (baseClassProperties.Count(baseClassProperty => baseClassProperty.Collection != CollectionType.None)
        //            > 0)
        //        {
        //            skipMethod = true;
        //        }
        //    }

        //    if (!skipMethod)
        //    {
        //        if (properties.Count(property => property.Collection != CollectionType.None) > 0)
        //        {
        //            skipMethod = true;
        //        }
        //    }

        //    sb.AppendLine("            /// <summary>");
        //    sb.AppendLine("            /// Gets a collection of string data for use for something like a CSV file");
        //    sb.AppendLine("            /// </summary>");
        //    sb.AppendLine("            /// <returns>a collection of strings representing the data record</returns>");
        //    sb.AppendLine("            public override System.Collections.Generic.IList<string> ToStringArray()");
        //    sb.AppendLine("            {");
        //    if (skipMethod)
        //    {
        //        sb.AppendLine("            throw new System.NotImplementedException();");
        //    }
        //    else
        //    {
        //        sb.Append("                var result = new System.Collections.Generic.List<string>");
        //        if (baseClassProperties != null && baseClassProperties.Length > 0)
        //        {
        //            sb.AppendLine("(base.ToStringArray())");
        //        }

        //        sb.AppendLine(string.Empty);
        //        sb.AppendLine("                {");

        //        for (int i = 0; i < properties.Length; i++)
        //        {
        //            sb.AppendLine(
        //                "                    this." + this.GetValueForToStringArray(properties[i])
        //                + (i < properties.Length - 1 ? "," : string.Empty));
        //        }

        //        sb.AppendLine("                };");
        //        sb.AppendLine(string.Empty);
        //        sb.AppendLine("                return result;");
        //    }

        //    sb.AppendLine("            }");
        //}

        /// <summary>
        ///     Gets the class suffix
        /// </summary>
        /// <returns>
        ///     the class suffix
        /// </returns>
        protected abstract string GetClassSuffix();

        /// <summary>
        /// Gets the type to be used for a parameter in the constructor
        /// </summary>
        /// <param name="propertyInfo">
        /// the property
        /// </param>
        /// <returns>
        /// the constructor parameter type
        /// </returns>
        protected abstract string GetConstructorParameterType(PropertyInfoBase propertyInfo);

        /// <summary>
        /// Gets the type for a property
        /// </summary>
        /// <param name="pi">
        /// The property to generate a type for
        /// </param>
        /// <returns>
        /// .NET data type
        /// </returns>
        protected abstract string GetPropertyType(PropertyInfoBase pi);

        /// <summary>
        /// Gets the value of the property when converting to a string array.
        /// </summary>
        /// <param name="pi">
        /// property information
        /// </param>
        /// <returns>
        /// the value of the property when converting to a string array
        /// </returns>
        protected abstract string GetValueForToStringArray(PropertyInfoBase pi);

        /// <summary>
        /// Does any class specific properties. For example the count property on the difference class
        /// </summary>
        /// <param name="sb">
        /// The String Builder to add the code to
        /// </param>
        /// <param name="properties">
        /// The collection of properties for the class
        /// </param>
        protected abstract void OnDoClassSpecificProperties(StringBuilder sb, PropertyInfoBase[] properties);

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
        protected abstract void OnDoCompareToProperties(
            StringBuilder sb, PropertyInfoBase[] properties, PropertyInfoBase[] baseClassProperties, bool checkResultDeclared);

        /// <summary>
        /// Generates the field code for a property member
        /// </summary>
        /// <param name="sb">
        /// The String Builder to add the code to
        /// </param>
        /// <param name="pi">
        /// The property to generate a field for
        /// </param>
        protected abstract void OnDoFieldItem(StringBuilder sb, PropertyInfoBase pi);

        /// <summary>
        /// Generates the setter for the property
        /// </summary>
        /// <param name="sb">
        /// The String Builder to add the code to
        /// </param>
        /// <param name="pi">
        /// The property to generate the setter for
        /// </param>
        protected abstract void OnDoPropertyMutator(StringBuilder sb, PropertyInfoBase pi);

        //private static void DoTableValidation(
        //    StringBuilder sb,
        //    IEnumerable<PropertyInfoBase> properties,
        //    ICollection<PropertyInfoBase> baseClassProperties)
        //{
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// Checks a table to ensure it meets the required schema");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        public override void DoTableValidation()");
        //    sb.AppendLine("        {");

        //    /*
        //    if (baseClassProperties != null && baseClassProperties.Count > 0)
        //    {
        //        sb.AppendLine("        base.DoTableValidation();");
        //        sb.AppendLine(string.Empty);
        //    }

        //    foreach (Base property in properties)
        //    {
        //        sb.AppendLine("            // " + property.Name);
        //        sb.AppendLine(string.Empty);
        //    }
        //     */
        //    sb.AppendLine("        }");
        //}

        /// <summary>
        /// Generates the code for the our methods region
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
        /// <param name="baseClassName">
        /// The name of the base class
        /// </param>
        /// <param name="baseClassProperties">
        /// The properties of the base class
        /// </param>
        private void DoOurMethodsRegion(
            StringBuilder sb, 
            string mainNamespaceName, 
            string subNamespace, 
            string className, 
            PropertyInfoBase[] properties, 
            string baseClassName, 
            PropertyInfoBase[] baseClassProperties)
        {
            sb.AppendLine("    #region our methods");
            sb.AppendLine(string.Empty);

            this.DoGetHashCodeMethod(sb, properties, baseClassProperties);

            sb.AppendLine(string.Empty);

            sb.AppendLine(string.Empty);

            sb.AppendLine(string.Empty);

            this.DoClassSpecificMethods(
                sb, mainNamespaceName, subNamespace, className, properties, baseClassName, baseClassProperties);

            //DoOdataVocabulariesMethod(sb, mainNamespaceName, subNamespace, className, properties, baseClassProperties);

            sb.AppendLine("        #endregion");
        }

        #endregion
    }
}