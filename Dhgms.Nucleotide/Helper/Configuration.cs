// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Configuration.cs" company="DHGMS Solutions">
//   Licensed under GNU General Public License version 2 (GPLv2)
// </copyright>
// <summary>
//   Class for handling configuration class generation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Dhgms.Nucleotide.Model.Helper
{
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class for handling configuration class generation
    /// </summary>
    public class Configuration
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
        /// Properties of the configuration class
        /// </param>
        /// <returns>
        /// C# code
        /// </returns>
        public static string Generate(
            string mainNamespaceName,
            string subNamespace,
            string className,
            string classRemarks,
            IEnumerable<Info.ConfigurationProperty> properties)
        {
            var sb = new StringBuilder();

            foreach (var prop in properties)
            {
                DoConfigurationProperty(sb, prop);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Generates the code for a configuration property
        /// </summary>
        /// <param name="sb">
        /// The string builder to add the code to
        /// </param>
        /// <param name="property">
        /// The property.
        /// </param>
        private static void DoConfigurationProperty(
            StringBuilder sb,
            Info.ConfigurationProperty property)
        {
            sb.AppendLine("		/// <summary>");
            sb.AppendLine("		/// " + property.Description);
            sb.AppendLine("		/// </summary>");
            sb.AppendLine("		[System.Configuration.ConfigurationProperty(\"" + property.Name + "\", IsRequired = " + (property.IsRequired ? "true" : "false") + ")]");
            sb.AppendLine("		public " + property.DataType + " " + property.Name);
            sb.AppendLine("		{");
            sb.AppendLine("			get");
            sb.AppendLine("			{");
            sb.AppendLine("				return (" + property.DataType + ")this[\"" + property.Name + "\"];");
            sb.AppendLine("			}");
            sb.AppendLine("			set");
            sb.AppendLine("			{");
            sb.AppendLine("				this[\"" + property.Name + "\"] = value;");
            sb.AppendLine("			}");
            sb.AppendLine("		}");
        }
    }
}
