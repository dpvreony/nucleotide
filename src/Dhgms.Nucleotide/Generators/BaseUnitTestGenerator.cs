﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitTestBase.cs" company="DHGMS Solutions">
//   Licensed under GNU General Public License version 2 (GPLv2)
// </copyright>
// <summary>
//   Base class for generating unit tests
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Dhgms.Nucleotide.Generators
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using Dhgms.Nucleotide.Extensions;
    using Dhgms.Nucleotide.PropertyInfo;

    /// <summary>
    /// Base class for generating unit tests
    /// </summary>
    public abstract class UnitTestBase
    {
        /// <summary>
        /// Entry point for generating the code
        /// </summary>
        /// <param name="mainNamespaceName">
        /// The main namespace
        /// </param>
        /// <param name="subNamespace">
        /// The sub namespace, if any
        /// </param>
        /// <param name="className">
        /// The class name
        /// </param>
        /// <param name="classRemarks">
        /// Remarks for the class
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
        /// <returns>
        /// C# code
        /// </returns>
        public string Generate(
            string mainNamespaceName,
            string subNamespace,
            string className,
            string classRemarks,
            PropertyInfoBase[] properties,
            string baseClassName,
            PropertyInfoBase[] baseClassProperties)
        {
            if (string.IsNullOrWhiteSpace(mainNamespaceName))
            {
                throw new ArgumentNullException("mainNamespaceName");
            }

            if (string.IsNullOrWhiteSpace(className))
            {
                throw new ArgumentNullException("className");
            }

            if (string.IsNullOrWhiteSpace(classRemarks))
            {
                throw new ArgumentNullException("classRemarks");
            }

            if (properties == null)
            {
                throw new ArgumentNullException("properties");
            }

            if (properties.Count(p => p.IsKey) > 1)
            {
                throw new ArgumentException("Too many primary keys defined");
            }

            var sb = new StringBuilder();
            var tabCount = 2;

            sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "namespace {0}.Model.{1}{2}", mainNamespaceName, this.ClassTypeName, (!string.IsNullOrEmpty(subNamespace)) ? "." + subNamespace : null));
            sb.AppendLine("{");
            sb.AppendLine("        using System;");
            sb.AppendLine("        using System.ComponentModel.DataAnnotations;");
            sb.AppendLine("        using System.Data.Entity;");
            sb.AppendLine("        using System.Diagnostics;");
            sb.AppendLine("        using System.Diagnostics.CodeAnalysis;");
            sb.AppendLine("        using System.Runtime.Serialization;");
            sb.AppendLine("        using System.Xml;");
            sb.AppendLine("        using System.Xml.Linq;");
            sb.AppendLine(string.Empty);
            sb.AppendLine(string.Empty);
            sb.AppendLine(OldHelpers.GetAutoGeneratedWarning());
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// " + classRemarks);
            sb.AppendLine("        /// </summary>");
            this.DoUnitTestClassAttributes(sb, tabCount);
            sb.AppendLine("        [ExcludeFromCodeCoverage]");
            sb.AppendLine("        public class " + className + this.GetClassSuffix() + "Test");
            sb.AppendLine("        {");

            this.DoConstructorMethod(sb, className, properties, baseClassName, baseClassProperties);
            //this.DoDisposeMethod(sb, properties, baseClassName);
            this.DoPropertiesRegion(sb, properties, baseClassProperties);
            //this.DoIComparableRegion(sb, className, properties, baseClassName, baseClassProperties);

            //sb.Append(OldHelpers.GetIEquatableRegion(className + this.GetClassSuffix(), baseClassName, baseClassProperties));

            //this.DoOurMethodsRegion(sb, mainNamespaceName, subNamespace, className, properties, baseClassName, baseClassProperties);

            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }

        /// <summary>
        /// Generate the unit test code for the property region
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="properties"></param>
        /// <param name="baseClassProperties"></param>
        protected void DoPropertiesRegion(StringBuilder sb, PropertyInfoBase[] properties, PropertyInfoBase[] baseClassProperties)
        {
            var tabCount = 2;
            sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}#region properties", OldHelpers.GetTabs(tabCount)));

            //int i = 1;
            foreach (PropertyInfoBase pi in properties)
            {
                sb.AppendLine("{0}/// <summary>", OldHelpers.GetTabs(tabCount));
                sb.AppendLine("{0}/// Unit tests for property: {1}", OldHelpers.GetTabs(tabCount), pi.Name);
                sb.AppendLine("{0}/// </summary>", OldHelpers.GetTabs(tabCount));
                this.DoUnitTestClassAttributes(sb, tabCount);
                sb.AppendLine("{0}public class {1}Property", OldHelpers.GetTabs(tabCount), pi.Name);
                sb.AppendLine("{0}{", OldHelpers.GetTabs(tabCount));

                tabCount++;
                this.DoUnitTestMethodAttributes(sb, tabCount);
                sb.AppendLine("{0}public void NormalOperation()", OldHelpers.GetTabs(tabCount));
                sb.AppendLine("{0}{{", OldHelpers.GetTabs(tabCount));

                tabCount++;
                sb.AppendLine("{0}var instance = new {1}();", OldHelpers.GetTabs(tabCount), "?");
                sb.AppendLine("{0}var testValue = {2};", OldHelpers.GetTabs(tabCount), pi.Name, "pi.RandomTestValue");
                sb.AppendLine("{0}Assert.AreEqual({1}, instance.{2});", OldHelpers.GetTabs(tabCount), pi.DefaultValue, pi.Name);
                sb.AppendLine("{0}instance.{1} = testValue;", OldHelpers.GetTabs(tabCount), pi.Name);
                sb.AppendLine("{0}Assert.AreEqual(testValue, instance.{1});", OldHelpers.GetTabs(tabCount), pi.Name);
                tabCount--;

                sb.AppendLine("{0}}}", OldHelpers.GetTabs(tabCount));
                tabCount--;

                sb.AppendLine("{0}}}", OldHelpers.GetTabs(tabCount));

                /*
                sb.AppendLine(
                    "        [SuppressMessage(\"StyleCop.CSharp.ReadabilityRules\", \"SA1121:UseBuiltInTypeAlias\", Justification = \"Reviewed. Suppression is OK here.\")]");

                // WCF Data Member Information
                string required = "IsRequired = " + (!pi.Optional).ToString().ToLower();
                string order = ", Order = " + i++;

                string dataMemberAttributes = "(" + required + order + ")";
                sb.AppendLine("        [DataMember" + dataMemberAttributes + "]");

                // Data Annotation Information
                if (!pi.Optional)
                {
                    sb.AppendLine("        [Required]");
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
                    sb.AppendLine("                return this." + OldHelpers.GetVariableName(pi.Name) + ";");
                    sb.AppendLine("            }");
                    sb.AppendLine(string.Empty);
                    this.OnDoPropertyMutator(sb, pi);
                }

                sb.AppendLine("        }");
                sb.AppendLine(string.Empty);
                 * */
            }

            //DoGetHeaderRecordMethod(sb, properties, baseClassProperties);

            //this.OnDoClassSpecificProperties(sb, properties);

            sb.AppendLine("        #endregion");
            sb.AppendLine(string.Empty);
        }

        private void DoUnitTestMethodAttributes(StringBuilder sb, int tabCount)
        {
            sb.AppendLine("{0}[Fact]", OldHelpers.GetTabs(tabCount));
        }

        private void DoUnitTestClassAttributes(StringBuilder sb, int tabCount)
        {
        }

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
            StringBuilder sb,
            string className,
            PropertyInfoBase[] properties,
            string baseClassName,
            PropertyInfoBase[] baseClassProperties)
        {
            // Default Constructor
            sb.AppendLine("            public class DefaultConstructorMethod");
            sb.AppendLine("            {");
            this.DoDummyTest(sb, 4);
            sb.AppendLine("                [Fact]");
            sb.AppendLine("                public void ShouldSucceed()");
            sb.AppendLine("                {");
            sb.AppendLine("                    var instance = new " + baseClassName + "();");
            sb.AppendLine("                    Assert.NotNull(instance);");

            // todo: check default value of each property
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine(string.Empty);

            // Copy Constructor
            sb.AppendLine("            public class CopyConstructorMethod");
            sb.AppendLine("            {");
            this.DoDummyTest(sb, 3);
            sb.AppendLine("                [Fact]");
            sb.AppendLine("                public void ArgumentNull()");
            sb.AppendLine("                {");
            sb.AppendLine("                    Assert.Throws<ArgumentNullException>(new " + baseClassName + "(null));");
            sb.AppendLine("                }");
            sb.AppendLine(string.Empty);
            sb.AppendLine("                [Fact]");
            sb.AppendLine("                public void ShouldSucceed()");
            sb.AppendLine("                {");
            sb.AppendLine("                    var initial = new " + baseClassName + "();");
            sb.AppendLine("                    var instance = new " + baseClassName + "(initial);");
            sb.AppendLine("                    Assert.NotNull(instance);");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine(string.Empty);

            // Constructor with parameters
            this.DoConstructorWithParameters(sb, className, properties, baseClassName, baseClassProperties);
        }

        /// <summary>
        /// Generate the unit test code for the constructor that takes parameters
        /// </summary>
        /// <param name="sb">string build to append the code to</param>
        /// <param name="className">name of the class</param>
        /// <param name="properties">collection of properties</param>
        /// <param name="baseClassName">name of the base class</param>
        /// <param name="baseClassProperties">collection of base class properties</param>
        protected abstract void DoConstructorWithParameters(StringBuilder sb, string className, PropertyInfoBase[] properties, string baseClassName, PropertyInfoBase[] baseClassProperties);

        private void DoDummyTest(StringBuilder sb, int indentCount)
        {
            sb.AppendLine(OldHelpers.GetTabs(indentCount) + "[Fact]");
            sb.AppendLine(OldHelpers.GetTabs(indentCount) + "public void Dummy()");
            sb.AppendLine(OldHelpers.GetTabs(indentCount) + "{");
            sb.AppendLine(OldHelpers.GetTabs(indentCount + 1) + "Assert.True(true);");
            sb.AppendLine(OldHelpers.GetTabs(indentCount) + "}");
        }

        /// <summary>
        ///     Gets the class suffix
        /// </summary>
        /// <returns>
        ///     the class suffix
        /// </returns>
        protected abstract string GetClassSuffix();

        /// <summary>
        /// Gets the type of class being produced (i.e. info, difference, view filter, search filter)
        /// </summary>
        protected string ClassTypeName { get; private set; }
    }
}
