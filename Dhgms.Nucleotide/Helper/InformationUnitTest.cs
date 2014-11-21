using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dhgms.Nucleotide.Model.Helper
{
    /// <summary>
    /// Generator for the unit tests of the information class
    /// </summary>
    public class InformationUnitTest : BaseClassGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="defaultBaseNamespace">
        /// The default namespace for the base class of the class being generated
        /// </param>
        /// <param name="classTypeName">
        /// The type of class being produced (i.e. info, difference, viewfilter, searchfilter
        /// </param>
        public InformationUnitTest(string defaultBaseNamespace, string classTypeName)
            : base(defaultBaseNamespace, classTypeName)
        {
        }
    }
}
