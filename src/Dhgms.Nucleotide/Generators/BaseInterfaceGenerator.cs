namespace Dhgms.Nucleotide.Generators
{
    using System;
    using System.Linq;
    using System.Text;

    using Dhgms.Nucleotide.Extensions;
    using Dhgms.Nucleotide.Model;
    using Dhgms.Nucleotide.PropertyInfo;

    /// <summary>
    /// Base Class for interface generation
    /// </summary>
    public abstract class BaseInterfaceGenerator : GeneratorBase
    {
        /// <summary>
        /// Carries out the generation of code for a class
        /// </summary>
        /// <param name="sb">The string builder to append code to.</param>
        /// <param name="classGenerationParameters">The class generation parameters</param>
        protected override void DoGenerationOfClass(StringBuilder sb, IClassGenerationParameters classGenerationParameters)
        {
            if (sb == null)
            {
                throw new ArgumentNullException("sb");
            }

            if (classGenerationParameters == null)
            {
                throw new ArgumentNullException("classGenerationParameters");
            }

            var tabCount = 2;

            var classSuffix = this.GetClassSuffix();

            // generate the main interface
            sb.AppendLine("{0}/// <summary>", Helpers.GetTabs(tabCount));
            sb.AppendLine("{0}/// {1}", Helpers.GetTabs(tabCount), classGenerationParameters.ClassRemarks);
            sb.AppendLine("{0}/// </summary>", Helpers.GetTabs(tabCount));
            sb.AppendLine("{0}public interface I{1}{2} : IUnkeyed{1}{2}", Helpers.GetTabs(tabCount), classGenerationParameters.ClassName, classSuffix);
            sb.AppendLine("{0}{{", Helpers.GetTabs(tabCount));

            tabCount++;

            this.DoProperties(sb, tabCount, classGenerationParameters.Properties.Where(x => x.IsKey).ToArray(), false);

            tabCount--;

            sb.AppendLine("{0}}}", Helpers.GetTabs(tabCount));
            sb.AppendLine(string.Empty);

            // generate the unkeyed interface
            sb.AppendLine("{0}/// <summary>", Helpers.GetTabs(tabCount));
            sb.AppendLine("{0}/// Un-keyed interface for {1}{2}", Helpers.GetTabs(tabCount), classGenerationParameters.ClassRemarks, classSuffix);
            sb.AppendLine("{0}/// </summary>", Helpers.GetTabs(tabCount));
            sb.AppendLine("{0}/// <remarks>", Helpers.GetTabs(tabCount));
            sb.AppendLine("{0}/// Un-keyed interfaces are used in services that allow creation of new objects.", Helpers.GetTabs(tabCount));
            sb.AppendLine("{0}/// </remarks>", Helpers.GetTabs(tabCount));
            sb.AppendLine("{0}public interface IUnkeyed{1}{2}", Helpers.GetTabs(tabCount), classGenerationParameters.ClassName, classSuffix);
            sb.AppendLine("{0}{{", Helpers.GetTabs(tabCount));

            tabCount++;

            this.DoProperties(sb, tabCount, classGenerationParameters.Properties.Where(x => !x.IsKey).ToArray(), true);

            tabCount--;

            sb.AppendLine("{0}}}", Helpers.GetTabs(tabCount));
        }

        /// <summary>
        /// Gets the suffix for the class type
        /// </summary>
        /// <returns>The suffix for the class type.</returns>
        protected abstract string GetClassSuffix();

        /// <summary>
        /// Generates code for the properties.
        /// </summary>
        /// <param name="sb">The string builder to append code to</param>
        /// <param name="tabCount">The depth count of the tabs</param>
        /// <param name="properties">collection of properties to generate code for</param>
        /// <param name="isBaseInterface">Whether this is the base interface</param>
        protected abstract void DoProperties(StringBuilder sb, int tabCount, PropertyInfoBase[] properties, bool isBaseInterface);
    }
}
