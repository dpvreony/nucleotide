﻿namespace Dhgms.Nucleotide.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using Dhgms.Nucleotide.Extensions;
    using Dhgms.Nucleotide.Model;

    /// <summary>
    /// Base class for the generators
    /// </summary>
    public abstract class GeneratorBase : IGenerator
    {
        /// <summary>
        /// Entry point for generating the code
        /// </summary>
        /// <param name="classes">
        /// Collection of classes to generate an interface for
        /// </param>
        /// <param name="doCopyrightHeader">
        /// Flag indicating whether to add the copyright header to the top of the output. Can be used to suppress output when placing all generated code in a single file.
        /// </param>
        /// <param name="suppressExceptionsAsCode">
        /// If an exception occurs instead of throwing the exception, they are output as code content. This is typically more useful in a transform environment so you can see the error in the affected file.
        /// </param>
        /// <returns>
        /// C# code
        /// </returns>
        public string Generate(
            IList<IClassGenerationParameters> classes,
            bool doCopyrightHeader = true,
            bool suppressExceptionsAsCode = true)
        {
            try
            {
                return this.DoGeneration(classes, doCopyrightHeader);
            }
            catch (Exception e)
            {
                if (suppressExceptionsAsCode)
                {

                    return "#error " + e.ToString().Replace(System.Environment.NewLine, string.Empty);
                }

                throw;
            }
        }

        /// <summary>
        /// Carries out the generation of code for a class
        /// </summary>
        /// <param name="sb">The string builder to append code to.</param>
        /// <param name="classGenerationParameters">The class generation parameters</param>
        protected abstract void DoGenerationOfClass(StringBuilder sb, IClassGenerationParameters classGenerationParameters);

        private void DoCopyrightHeader(StringBuilder sb, string companyName, IEnumerable<string> copyrightBanner, int copyrightStartYear, string className, string classRemarks)
        {
            sb.AppendLine("// --------------------------------------------------------------------------------------------------------------------");

            sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "// <copyright file=\"{0}.cs\" company=\"{1}\">", className, companyName));
            var thisYear = DateTime.Now.Year;
            var yearDetails = copyrightStartYear < thisYear ? string.Format(CultureInfo.InvariantCulture, "{0}-{1}", copyrightStartYear, thisYear) : copyrightStartYear.ToString(CultureInfo.InvariantCulture);
            sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "//   Copyright {0} {1}", yearDetails, companyName));
            sb.AppendLine("//   ");

            foreach (var line in copyrightBanner)
            {
                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "//   {0}", line));
            }

            sb.AppendLine("// </copyright>");

            sb.AppendLine("// <summary>");
            sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "//   {0}", classRemarks));
            sb.AppendLine("// </summary>");
            sb.AppendLine("// --------------------------------------------------------------------------------------------------------------------");
            sb.AppendLine(string.Empty);
        }

        private string DoGeneration(IList<IClassGenerationParameters> classes, bool doCopyrightHeader)
        {
            if (classes == null)
            {
                throw new ArgumentNullException("classes");
            }

            if (classes.Count < 1)
            {
                throw new ArgumentException("classes must contain at least one item", "classes");
            }

            // we clone because we do a grouping and sort between namespaces
            var classesClone = new List<IClassGenerationParameters>(classes);

            var sb = new StringBuilder();

            if (doCopyrightHeader)
            {
                var item = classes.First();
                this.DoCopyrightHeader(
                    sb,
                    item.CompanyName,
                    item.CopyrightBanner,
                    item.CopyrightStartYear,
                    "NucleotideGenerated",
                    "Code Generated by Nucleotide.");
            }


            var sortedClasses = SortMainNameSpaces(classesClone);

            foreach (var sortedClass in sortedClasses)
            {
                this.DoGenerationOfMainNameSpace(sb, sortedClass);
            }

            return sb.ToString();
        }

        private void DoGenerationOfMainNameSpace(StringBuilder sb, KeyValuePair<string, IDictionary<string, IList<IClassGenerationParameters>>> sortedMainNamespace)
        {
            var mainNamespaceName = sortedMainNamespace.Key;

            foreach (var sortedSubNamspaces in sortedMainNamespace.Value)
            {
                var subNamespace = !string.IsNullOrWhiteSpace(sortedSubNamspaces.Key) ? "." + sortedSubNamspaces.Key : null;
                var cgps = sortedSubNamspaces.Value;

                sb.AppendLine("namespace " + mainNamespaceName + ".Model" + subNamespace);
                sb.AppendLine("{");

                foreach (var cgp in cgps)
                {
                    this.DoGenerationOfClass(sb, cgp);
                }

                sb.AppendLine("}");
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

                var classesInSubNamespace = ns == null
                                                ? classes.Take(
                                                    x =>
                                                    x.SubNamespace == null).ToList()
                                                : classes.Take(
                                                    x =>
                                                    x.SubNamespace.Equals(ns, StringComparison.Ordinal)).ToList();

                mappings.Add(subNamespace ?? string.Empty, classesInSubNamespace);
            }

            return mappings;
        }
    }
}
