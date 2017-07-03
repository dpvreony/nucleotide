﻿namespace Dhgms.Nucleotide.Tests
{
    using Dhgms.Nucleotide.Model;
    using Dhgms.Nucleotide.PropertyInfo;

    /// <summary>
    /// The test inputs.
    /// </summary>
    public static class TestInputs
    {
        /// <summary>
        /// The main namespace name.
        /// </summary>
        public const string MainNamespaceName = "TestDhgms.Nucleotide";

        /// <summary>
        /// The sub namespace.
        /// </summary>
        public const string SubNamespace = "SubNamespace";

        /// <summary>
        /// Gets the properties default.
        /// </summary>
        public static PropertyInfoBase[] PropertiesDefault
        {
            get
            {
                return new PropertyInfoBase[]
                {
                    new ClrBooleanPropertyInfo(CollectionType.None, "BooleanItem", "A Boolean Item", false, false, null), 
                    new ClrDateTimePropertyInfo(CollectionType.None, "DateTimeItem", "A DateTime Item", false, null, null, false, null)
                };
            }
        }
    }
}