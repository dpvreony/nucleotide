namespace Dhgms.Nucleotide.Generators
{
    using System.Text;

    using Dhgms.Nucleotide.Extensions;
    using Dhgms.Nucleotide.PropertyInfo;

    /// <summary>
    /// The generator for a Difference Interface.
    /// </summary>
    public sealed class DifferenceInterfaceGenerator : BaseInterfaceGenerator
    {
        /// <summary>
        /// Gets the suffix for the class type
        /// </summary>
        /// <returns>The suffix for the class type.</returns>
        protected override string GetClassSuffix()
        {
            return "Difference";
        }

        /// <summary>
        /// Generates code for the properties.
        /// </summary>
        /// <param name="sb">The string builder to append code to</param>
        /// <param name="tabCount">The depth count of the tabs</param>
        /// <param name="properties">collection of properties to generate code for</param>
        /// <param name="isBaseInterface">Whether this is the base interface</param>
        protected override void DoProperties(StringBuilder sb, int tabCount, PropertyInfoBase[] properties, bool isBaseInterface)
        {
            //if (isBaseInterface)
            //{
            //    sb.AppendLine("{0}/// <summary>", Helpers.GetTabs(tabCount));
            //    sb.AppendLine("{0}/// Gets the number of properties that are different", Helpers.GetTabs(tabCount));
            //    sb.AppendLine("{0}/// </summary>", Helpers.GetTabs(tabCount));
            //    sb.AppendLine("{0}/// <return>", Helpers.GetTabs(tabCount));
            //    sb.AppendLine("{0}/// the number of properties that are different", Helpers.GetTabs(tabCount));
            //    sb.AppendLine("{0}/// </return>", Helpers.GetTabs(tabCount));
            //    sb.AppendLine("{0}int Count {{ get; }}", Helpers.GetTabs(tabCount));
            //    sb.AppendLine(string.Empty);
            //}

            var position = 0;
            while (position < properties.Length)
            {
                var property = properties[position];

                sb.AppendLine("{0}/// <summary>Gets a value indicating whether there is a difference for {1}</summary>", Helpers.GetTabs(tabCount), property.Description);
                sb.AppendLine("{0}bool {1} {{ get; }}", Helpers.GetTabs(tabCount), property.Name);

                if (position <= properties.Length)
                {
                    sb.AppendLine(string.Empty);
                }

                position++;
            }
        }
    }
}
