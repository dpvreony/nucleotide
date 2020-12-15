using Dhgms.Nucleotide.Common.Models;

namespace Dhgms.Nucleotide.Common.PropertyInfo
{
    public class UnsignedInteger8PropertyInfo
        : NumericPropertyInfo<byte>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ClrDecimalPropertyInfo"/> class. 
        /// </summary>
        /// <param name="collection">Whether the field is a collection</param>
        /// <param name="name">Name of the field</param>
        /// <param name="description">Description for the field, used for commenting</param>
        /// <param name="optional">Whether the field is optional \ capable of being null</param>
        /// <param name="minimumValue">The minimum acceptable value for this property</param>
        /// <param name="maximumValue">The maximum acceptable value for this property</param>
        /// <param name="isKey">
        /// Whether the property is the primary key
        /// </param>
        /// <param name="alternativeDatabaseColumnName">
        /// Name of the database column name, if it's different from the .NET property name.
        /// </param>
        public UnsignedInteger8PropertyInfo(
            CollectionType collection,
            string name,
            string description,
            bool optional,
            byte minimumValue,
            byte maximumValue,
            bool isKey,
            string alternativeDatabaseColumnName)
            : base(
                collection,
                name,
                description,
                optional,
                "byte",
                "UInt8",
                false,
                "0",
                false,
                isKey,
                true,
                typeof(byte),
                alternativeDatabaseColumnName,
                minimumValue,
                maximumValue)
        {
        }
    }
}
