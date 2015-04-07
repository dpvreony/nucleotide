using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dhgms.Nucleotide
{
    /// <summary>
    /// The generation flags.
    /// </summary>
    [Flags]
    public enum GenerationFlags
    {
        /// <summary>
        /// No code should be generated
        /// </summary>
        None = 0,

        /// <summary>
        /// The information interface should be generated.
        /// </summary>
        InformationInterface,

        /// <summary>
        /// The information class should be generated.
        /// </summary>
        InformationClass,

        /// <summary>
        /// The difference interface should be generated.
        /// </summary>
        DifferenceInterface,

        /// <summary>
        /// The difference class should be generated.
        /// </summary>
        DifferenceClass,

        /// <summary>
        /// The delta interface should be generated.
        /// </summary>
        DeltaInterface,

        /// <summary>
        /// The delta class should be generated.
        /// </summary>
        DeltaClass,

        /// <summary>
        /// The search filter interface should be generated.
        /// </summary>
        SearchFilterInterface,

        /// <summary>
        /// The search filter class should be generated.
        /// </summary>
        SearchFilterClass,

        /// <summary>
        /// The ADO.NET class should be generated.
        /// </summary>
        AdoNetClass
    }
}
