namespace Dhgms.Nucleotide.Generators.Models
{
    /// <summary>
    /// Represents the access available to read\write a property.
    /// </summary>
    public enum PropertyAccessorFlags
    {
        /// <summary>
        /// No access flag set, should not be used.
        /// </summary>
        None,

        /// <summary>
        /// Provide a get accessor on a property. useful for readonly data structures.
        /// </summary>
        Get,

        /// <summary>
        /// Provide a get and init accessor on a property useful for readonly data structure where you want to ensure the data can only be set at object instantiation. Requires C# 9 or later.
        /// </summary>
        GetInit,

        /// <summary>
        /// Provides read\write access to a property.
        /// </summary>
        GetSet,
    }
}