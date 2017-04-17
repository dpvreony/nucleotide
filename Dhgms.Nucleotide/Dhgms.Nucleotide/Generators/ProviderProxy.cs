// --------------------------------------------------------------------------------------------------------------------
// <copyright company="DHGMS Solutions" file="ProviderProxy.cs">
//   Licensed under GNU General Public License version 2 (GPLv2)
// </copyright>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace Dhgms.Nucleotide.Generators
{
    using System;
    using System.Text;

    /// <summary>
    /// Helper for generating provider proxy classes
    /// </summary>
    public static class ProviderProxy
    {
        #region Public Methods and Operators

        /// <summary>
        /// Entry point that generates the code
        /// </summary>
        /// <param name="projectName">
        /// The project this provider proxy belongs to. This is used as the root namespace
        /// </param>
        /// <param name="objectNames">
        /// collection of provider proxies
        /// </param>
        /// <returns>
        /// The C# code
        /// </returns>
        public static string Generate(string projectName, Model.ProviderProxy[] objectNames)
        {
            if (projectName == null || string.IsNullOrWhiteSpace(projectName))
            {
                throw new ArgumentNullException("projectName");
            }

            if (objectNames == null)
            {
                throw new ArgumentNullException("objectNames");
            }

            if (objectNames.Length < 1)
            {
                throw new ArgumentException("should contain at least 1 item", "objectNames");
            }

            var sb = new StringBuilder();

            int tabs = 0;

            sb.AppendLine("namespace Dhgms.Wcds.Model.ProviderBase");
            sb.AppendLine("{");

            tabs++;
            sb.AppendLine(OldHelpers.GetTabs(tabs) + "public abstract class " + projectName);
            sb.AppendLine(OldHelpers.GetTabs(tabs + 1) + ": System.Configuration.Provider.ProviderBase");
            sb.AppendLine(OldHelpers.GetTabs(tabs) + "{");
            sb.AppendLine("#region our methods");
            sb.AppendLine(OldHelpers.GetTabs(tabs) + "protected " + projectName + "(){}");

            foreach (Model.ProviderProxy objectName in objectNames)
            {
                sb.AppendLine(
                    OldHelpers.GetTabs(tabs)
                    + "public abstract System.Collections.ObjectModel.Collection<Dhgms.Wcds.Model.Info." + projectName
                    + "." + objectName.InfoClass + "> Get" + objectName.Name + "List(");
                sb.AppendLine(
                    OldHelpers.GetTabs(tabs + 1) + "Dhgms.Wcds.Model.SearchFilter." + projectName + "." + objectName.Name
                    + " searchParams,");
                sb.AppendLine(
                    OldHelpers.GetTabs(tabs + 1) + "Dhgms.Wcds.Model.ViewFilter." + projectName + "." + objectName.InfoClass
                    + " viewParams");
                sb.AppendLine(OldHelpers.GetTabs(tabs + 1) + ");");
                sb.AppendLine(string.Empty);
                sb.AppendLine(
                    OldHelpers.GetTabs(tabs) + "public abstract Dhgms.Wcds.Model.Info." + projectName + "."
                    + objectName.InfoClass + " Get" + objectName.Name + "(");
                sb.AppendLine(OldHelpers.GetTabs(tabs + 1) + "int id,");
                sb.AppendLine(
                    OldHelpers.GetTabs(tabs + 1) + "Dhgms.Wcds.Model.ViewFilter." + projectName + "." + objectName.InfoClass
                    + " viewParams");
                sb.AppendLine(OldHelpers.GetTabs(tabs + 1) + ");");
                sb.AppendLine(string.Empty);
            }

            sb.AppendLine("#endregion");
            sb.AppendLine(OldHelpers.GetTabs(tabs) + "}");
            tabs--;

            // providerbase
            sb.AppendLine(OldHelpers.GetTabs(tabs) + "}");

            sb.AppendLine(OldHelpers.GetTabs(tabs) + "namespace Dhgms.Wcds.Model.ProviderCollection");
            sb.AppendLine(OldHelpers.GetTabs(tabs) + "{");

            tabs++;
            sb.AppendLine(OldHelpers.GetTabs(tabs) + "public class " + projectName);
            sb.AppendLine(
                OldHelpers.GetTabs(tabs + 1)
                + ": Dhgms.DataManager.Model.ProviderCollection.BaseCollection<Dhgms.Wcds.Model.ProviderBase."
                + projectName + ">");
            sb.AppendLine(OldHelpers.GetTabs(tabs) + "{");
            sb.AppendLine(OldHelpers.GetTabs(tabs) + "}");
            tabs--;

            // providercollection
            sb.AppendLine(OldHelpers.GetTabs(tabs) + "}");

            sb.AppendLine(OldHelpers.GetTabs(tabs) + "namespace Dhgms.Wcds.Model.ProviderProxy");
            sb.AppendLine(OldHelpers.GetTabs(tabs) + "{");

            tabs++;
            sb.AppendLine(OldHelpers.GetTabs(tabs) + "public sealed class " + projectName);
            sb.AppendLine(OldHelpers.GetTabs(tabs + 1) + ": Dhgms.DataManager.Model.ProviderProxy.Base<");
            sb.AppendLine(OldHelpers.GetTabs(tabs + 2) + projectName + ",");
            sb.AppendLine(OldHelpers.GetTabs(tabs + 2) + "Dhgms.Wcds.Model.ProviderBase." + projectName + ",");
            sb.AppendLine(OldHelpers.GetTabs(tabs + 2) + "Dhgms.Wcds.Model.ProviderCollection." + projectName + ",");

            sb.AppendLine(OldHelpers.GetTabs(tabs + 2) + "Dhgms.DataManager.Model.ConfigurationSection.ProviderSection");
            sb.AppendLine(OldHelpers.GetTabs(tabs + 2) + ">");
            sb.AppendLine(OldHelpers.GetTabs(tabs) + "{");
            tabs++;
            sb.AppendLine(string.Empty);
            sb.AppendLine("#region our methods");
            sb.AppendLine(string.Empty);
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// Constructor");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public " + projectName + "()");
            sb.AppendLine("            : base(\"wcds" + projectName + "\")");
            sb.AppendLine("        {");
            sb.AppendLine("        }");
            sb.AppendLine(string.Empty);

            foreach (Model.ProviderProxy objectName in objectNames)
            {
                sb.AppendLine(
                    OldHelpers.GetTabs(tabs)
                    + "public static System.Collections.ObjectModel.Collection<Dhgms.Wcds.Model.Info." + projectName
                    + "." + objectName.InfoClass + "> Get" + objectName.Name + "List(");
                sb.AppendLine(
                    OldHelpers.GetTabs(tabs + 1) + "Dhgms.Wcds.Model.SearchFilter." + projectName + "." + objectName.Name
                    + " searchParams,");
                sb.AppendLine(
                    OldHelpers.GetTabs(tabs + 1) + "Dhgms.Wcds.Model.ViewFilter." + projectName + "." + objectName.InfoClass
                    + " viewParams");
                sb.AppendLine(OldHelpers.GetTabs(tabs + 1) + ")");
                sb.AppendLine(OldHelpers.GetTabs(tabs) + "{");
                sb.AppendLine(OldHelpers.GetTabs(tabs) + projectName + " instance = new " + projectName + "();");
                sb.AppendLine(OldHelpers.GetTabs(tabs) + "instance.LoadProviders();");
                sb.AppendLine(OldHelpers.GetTabs(tabs) + "if (Provider == null)");
                sb.AppendLine(OldHelpers.GetTabs(tabs) + "{");
                sb.AppendLine(
                    OldHelpers.GetTabs(tabs)
                    + "    throw new System.Configuration.ConfigurationErrorsException(\"No providers\");");
                sb.AppendLine(OldHelpers.GetTabs(tabs) + "}");
                sb.AppendLine(
                    OldHelpers.GetTabs(tabs) + "return Provider.Get" + objectName.Name + "List(searchParams, viewParams);");
                sb.AppendLine(OldHelpers.GetTabs(tabs) + "}");
                sb.AppendLine(string.Empty);

                sb.AppendLine(
                    OldHelpers.GetTabs(tabs) + "public static Dhgms.Wcds.Model.Info." + projectName + "."
                    + objectName.InfoClass + " Get" + objectName.Name + "(");
                sb.AppendLine(OldHelpers.GetTabs(tabs) + "int id,");
                sb.AppendLine(
                    OldHelpers.GetTabs(tabs) + "Dhgms.Wcds.Model.ViewFilter." + projectName + "." + objectName.InfoClass
                    + " viewParams");
                sb.AppendLine(OldHelpers.GetTabs(tabs) + ")");
                sb.AppendLine(OldHelpers.GetTabs(tabs) + "{");
                sb.AppendLine(OldHelpers.GetTabs(tabs) + projectName + " instance = new " + projectName + "();");
                sb.AppendLine(OldHelpers.GetTabs(tabs) + "instance.LoadProviders();");
                sb.AppendLine(OldHelpers.GetTabs(tabs) + "if (Provider == null)");
                sb.AppendLine(OldHelpers.GetTabs(tabs) + "{");
                sb.AppendLine(
                    OldHelpers.GetTabs(tabs)
                    + "    throw new System.Configuration.ConfigurationErrorsException(\"No providers\");");
                sb.AppendLine(OldHelpers.GetTabs(tabs) + "}");
                sb.AppendLine(OldHelpers.GetTabs(tabs) + "return Provider.Get" + objectName.Name + "(id, viewParams);");
                sb.AppendLine(OldHelpers.GetTabs(tabs) + "}");
                sb.AppendLine(string.Empty);
            }

            sb.AppendLine(OldHelpers.GetTabs(tabs) + "#endregion");

            // project name
            tabs--;
            sb.AppendLine(OldHelpers.GetTabs(tabs) + "}");
            tabs--;

            // providerproxy
            sb.AppendLine(OldHelpers.GetTabs(tabs) + "}");
            tabs--;

            sb.AppendLine(OldHelpers.GetTabs(tabs) + "namespace Dhgms.Wcds.Model.Provider." + projectName);
            sb.AppendLine(OldHelpers.GetTabs(tabs) + "{");

            tabs++;
            sb.AppendLine(OldHelpers.GetTabs(tabs) + "public abstract class Base");
            sb.AppendLine(OldHelpers.GetTabs(tabs) + ": Dhgms.DataManager.Model.Provider.Base");
            sb.AppendLine(OldHelpers.GetTabs(tabs) + "{");
            sb.AppendLine("#region our methods");

            foreach (Model.ProviderProxy objectName in objectNames)
            {
                sb.AppendLine(
                    OldHelpers.GetTabs(tabs)
                    + "public abstract System.Collections.ObjectModel.Collection<Dhgms.Wcds.Model.Info." + projectName
                    + "." + objectName.InfoClass + "> Get" + objectName.Name + "List(");
                sb.AppendLine(
                    OldHelpers.GetTabs(tabs + 1) + "Dhgms.Wcds.Model.SearchFilter." + projectName + "." + objectName.Name
                    + " searchParams,");
                sb.AppendLine(
                    OldHelpers.GetTabs(tabs + 1) + "Dhgms.Wcds.Model.ViewFilter." + projectName + "." + objectName.InfoClass
                    + " viewParams");
                sb.AppendLine(OldHelpers.GetTabs(tabs + 1) + ");");
                sb.AppendLine(string.Empty);
                sb.AppendLine(
                    OldHelpers.GetTabs(tabs) + "public abstract Dhgms.Wcds.Model.Info." + projectName + "."
                    + objectName.InfoClass + " Get" + objectName.Name + "(");
                sb.AppendLine(OldHelpers.GetTabs(tabs + 1) + "int id,");
                sb.AppendLine(
                    OldHelpers.GetTabs(tabs + 1) + "Dhgms.Wcds.Model.ViewFilter." + projectName + "." + objectName.InfoClass
                    + " viewParams");
                sb.AppendLine(OldHelpers.GetTabs(tabs + 1) + ");");
                sb.AppendLine(string.Empty);
            }

            sb.AppendLine("#endregion");
            sb.AppendLine(OldHelpers.GetTabs(tabs) + "}");

            // dhgms
            sb.AppendLine("}");

            return sb.ToString();
        }

        #endregion
    }
}