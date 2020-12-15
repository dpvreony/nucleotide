using Dhgms.Nucleotide.Common.Models;

namespace Dhgms.Nucleotide.Common.PropertyInfo
{
    public sealed class ClrSinglePropertyInfo
        : NumericPropertyInfo<float>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ClrSinglePropertyInfo"/> class. 
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
        public ClrSinglePropertyInfo(
            CollectionType collection,
            string name,
            string description,
            bool optional,
            float minimumValue,
            float maximumValue,
            bool isKey,
            string alternativeDatabaseColumnName)
            : base(
                collection,
                name,
                description,
                optional,
                "float",
                "Single",
                false,
                "0",
                false,
                isKey,
                true,
                typeof(float),
                alternativeDatabaseColumnName,
                minimumValue,
                maximumValue)
        {
        }
    }
}
