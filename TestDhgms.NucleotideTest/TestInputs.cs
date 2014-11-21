using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestDhgms.NucleotideTest
{
    using Dhgms.Nucleotide.Model.Info;
    using Dhgms.Nucleotide.Model.Info.PropertyInfo;

    /// <summary>
    /// The test inputs.
    /// </summary>
    public static class TestInputs
    {
        /// <summary>
        /// Gets the properties default.
        /// </summary>
        public static Base[] PropertiesDefault
        {
            get
            {
                return new Base[]
                {
                    new ClrBoolean(CollectionType.None, "BooleanItem", "A Boolean Item", false, false, null), 
                    new ClrDateTime(CollectionType.None, "DateTimeItem", "A DateTime Item", false, null, null, false, null)
                };
            }
        }
    }
}
