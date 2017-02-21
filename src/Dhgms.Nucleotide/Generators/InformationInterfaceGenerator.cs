namespace Dhgms.Nucleotide.Generators
{
    using System;
    using System.Text;

    using Dhgms.Nucleotide.Extensions;
    using Dhgms.Nucleotide.PropertyInfo;

    /// <summary>
    /// Code Generation for an Information Interface.
    /// </summary>
    public sealed class InformationInterfaceGenerator : BaseInterfaceGenerator
    {
        /// <summary>
        /// Gets the suffix for the class type
        /// </summary>
        /// <returns>The suffix for the class type.</returns>
        protected override string GetClassSuffix()
        {
            return null;
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
            var position = 0;
            while (position < properties.Length)
            {
                var property = properties[position];

                sb.AppendLine("{0}/// <summary>Gets {1}</summary>", OldHelpers.GetTabs(tabCount), property.Description);
                sb.AppendLine("{0}{1} {2} {{ get; }}", OldHelpers.GetTabs(tabCount), this.GetPropertyType(property), property.Name);

                if (position <= properties.Length)
                {
                    sb.AppendLine(string.Empty);
                }

                position++;
            }
        }

        /// <summary>
        /// Gets the type for a property
        /// </summary>
        /// <param name="pi">
        /// The property to generate a type for
        /// </param>
        /// <returns>
        /// .NET data type
        /// </returns>
        private string GetPropertyType(PropertyInfoBase pi)
        {
            if (pi == null)
            {
                throw new ArgumentNullException("pi");
            }

            string optional = (pi.Optional && !pi.NetDataType.Equals("string", StringComparison.Ordinal))
                                  ? "?"
                                  : string.Empty;
            return pi.GetCSharpDataTypeDeclaration() + optional;
        }
    }
}
