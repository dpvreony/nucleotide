//namespace Dhgms.Nucleotide.Generators
//{
//    using System.Text;

//    using Dhgms.Nucleotide.Extensions;
//    using Dhgms.Nucleotide.PropertyInfo;

//    /// <summary>
//    /// The generator for a Difference Interface.
//    /// </summary>
//    public sealed class DifferenceInterfaceGenerator : BaseInterfaceGenerator
//    {
//        /// <summary>
//        /// Gets the suffix for the class type
//        /// </summary>
//        /// <returns>The suffix for the class type.</returns>
//        protected override string GetClassSuffix()
//        {
//            return "Difference";
//        }

//        /// <summary>
//        /// Generates code for the properties.
//        /// </summary>
//        /// <param name="sb">The string builder to append code to</param>
//        /// <param name="tabCount">The depth count of the tabs</param>
//        /// <param name="properties">collection of properties to generate code for</param>
//        /// <param name="isBaseInterface">Whether this is the base interface</param>
//        protected override void DoProperties(StringBuilder sb, int tabCount, PropertyInfoBase[] properties, bool isBaseInterface)
//        {
//            var position = 0;
//            while (position < properties.Length)
//            {
//                var property = properties[position];

//                sb.AppendLine("{0}/// <summary>Gets a value indicating whether there is a difference for {1}</summary>", OldHelpers.GetTabs(tabCount), property.Description);
//                sb.AppendLine("{0}bool {1} {{ get; }}", OldHelpers.GetTabs(tabCount), property.Name);

//                if (position <= properties.Length)
//                {
//                    sb.AppendLine(string.Empty);
//                }

//                position++;
//            }
//        }
//    }
//}
