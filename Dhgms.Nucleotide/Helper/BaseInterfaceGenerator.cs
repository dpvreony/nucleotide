namespace Dhgms.Nucleotide.Helper
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;

    using Dhgms.Nucleotide.Extensions;
    using Dhgms.Nucleotide.Model;
    using Dhgms.Nucleotide.PropertyInfo;

    /// <summary>
    /// Base Class for interface generation
    /// </summary>
    public class BaseInterfaceGenerator
    {
        /// <summary>
        /// Entry point for generating the code
        /// </summary>
        /// <param name="classes">
        /// Collection of classes to generate an interface for
        /// </param>
        /// <returns>
        /// C# code
        /// </returns>
        public string Generate(
            IList<IClassGenerationParameters> classes)
        {
            if (Splat.ModeDetector.InUnitTestRunner())
            {
                return this.DoGeneration(classes);
            }

            try
            {
                return this.DoGeneration(classes);
            }
            catch (Exception e)
            {
                return "/*" + e + "*/";
            }
        }

        private string DoGeneration(IList<IClassGenerationParameters> classes)
        {
            Contract.Requires<ArgumentNullException>(classes != null);

            var sb = new StringBuilder();
            //sb.AppendLine("    using System;");
            //sb.AppendLine("    using System.ComponentModel.DataAnnotations;");
            //sb.AppendLine("    using System.Data.Entity;");
            //sb.AppendLine("    using System.Diagnostics;");
            //sb.AppendLine("    using System.Diagnostics.CodeAnalysis;");
            //sb.AppendLine("    using System.Runtime.Serialization;");
            //sb.AppendLine("    using System.Xml;");
            //sb.AppendLine("    using System.Xml.Linq;");
            //sb.AppendLine(string.Empty);

            var sortedClasses = SortMainNameSpaces(classes);

            foreach (var sortedClass in sortedClasses)
            {
                this.DoGeneration(sb, sortedClass);
            }

            return sb.ToString();
        }

        private void DoGeneration(StringBuilder sb, KeyValuePair<string, IDictionary<string, IList<IClassGenerationParameters>>> sortedMainNamespace)
        {
            var mainNamespaceName = sortedMainNamespace.Key;

            foreach (var sortedSubNamspaces in sortedMainNamespace.Value)
            {
                var subNamespace = !string.IsNullOrWhiteSpace(sortedSubNamspaces.Key) ? "." + sortedSubNamspaces.Key : null;
                var cgps = sortedSubNamspaces.Value;

                sb.AppendLine("namespace " + mainNamespaceName + ".Model.Helper.AdoNet" + subNamespace);
                sb.AppendLine("{");

                foreach (var cgp in cgps)
                {
                    this.DoGenerateClass(sb, cgp);
                }

                sb.AppendLine("}");
            }
        }

        private void DoGenerateClass(StringBuilder sb, IClassGenerationParameters cgp)
        {
            var tabCount = 2;
            sb.AppendLine("{0}public interface {1}", Common.GetTabs(tabCount), cgp.ClassName);
            sb.AppendLine("{0}{", Common.GetTabs(tabCount));

            tabCount++;

            DoProperties(sb, tabCount, cgp.Properties);

            tabCount--;

            sb.AppendLine("{0}}", Common.GetTabs(tabCount));
        }

        private static void DoProperties(StringBuilder sb, int tabCount, PropertyInfoBase[] properties)
        {
            var position = 0;
            while (position < properties.Length)
            {
                var property = properties[position];

                sb.AppendLine("{0}///<summary>Gets {1}</summary>", Common.GetTabs(tabCount), property.Description);
                sb.AppendLine("{0}{1} {2} { get; }", Common.GetTabs(tabCount), property.NetDataType, property.Name);
                
                if (position < properties.Length)
                {
                    sb.AppendLine(string.Empty);
                }

                position++;
            }
        }

        private static IEnumerable<KeyValuePair<string, IDictionary<string, IList<IClassGenerationParameters>>>> SortMainNameSpaces(IList<IClassGenerationParameters> classes)
        {
            var mainNamespaces = classes.Select(x => x.MainNamespaceName).Distinct().OrderBy(x => x).ToList();

            var mappings = new Dictionary<string, IDictionary<string, IList<IClassGenerationParameters>>>(mainNamespaces.Count);

            foreach (var mainNamespace in mainNamespaces)
            {
                var ns = mainNamespace;
                var classesInNamespace = classes.Take(x => x.MainNamespaceName.Equals(ns, StringComparison.Ordinal)).ToList();
                var sortedSubNamespaces = SortSubNamespaces(classesInNamespace);

                mappings.Add(mainNamespace, sortedSubNamespaces);
            }

            return mappings;
        }

        private static IDictionary<string, IList<IClassGenerationParameters>> SortSubNamespaces(IList<IClassGenerationParameters> classes)
        {
            var subNamespaces = classes.Select(x => x.SubNamespace).Distinct().OrderBy(x => x).ToList();

            var mappings = new Dictionary<string, IList<IClassGenerationParameters>>(subNamespaces.Count);

            foreach (var subNamespace in subNamespaces)
            {
                var ns = subNamespace;
                var classesInSubNamespace = classes.Take(x => x.MainNamespaceName.Equals(ns, StringComparison.Ordinal)).ToList();

                mappings.Add(subNamespace, classesInSubNamespace);
            }

            return mappings;
        }
    }
}
