using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

using Dhgms.Nucleotide.Model.Info.PropertyInfo;

namespace Dhgms.Nucleotide.Model.Helper
{
    using Dhgms.Nucleotide.Model.Info;

    /// <summary>
    /// String Builder Extensions
    /// </summary>
    public static class StringBuilderExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void AppendLine(this StringBuilder instance, string format, params object[] args)
        {
            var s = string.Format(format, args);
            instance.AppendLine(s);
        }
    }

    /// <summary>
    /// LINQ Extensions for the Enumerable classes
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Take items from a list which suit a predicate
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TSource> Take<TSource>(this IList<TSource> instance, Func<TSource, bool> predicate)
        {
            Contract.Requires<ArgumentNullException>(instance != null);
            Contract.Requires<ArgumentNullException>(predicate != null);

            var result = new List<TSource>();

            var position = 0;
            while (position < instance.Count)
            {
                var item = instance[position];
                if (predicate(item))
                {
                    result.Add(item);
                    instance.Remove(item);
                }
                else
                {
                    position++;
                }
            }

            return result;
        }
    }

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
            try
            {
                return DoGeneration(classes);
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
                DoGeneration(sb, sortedClass);
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
                    DoGenerateClass(sb, cgp);
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

        private static void DoProperties(StringBuilder sb, int tabCount, Base[] properties)
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
