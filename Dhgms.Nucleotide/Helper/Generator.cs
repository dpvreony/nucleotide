using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dhgms.Nucleotide.Helper
{
    using Dhgms.Nucleotide.Model;

    /// <summary>
    /// Generator class
    /// </summary>
    public class Generator
    {
        /// <summary>
        /// Generates the code for the template.
        /// </summary>
        /// <param name="classes"></param>
        /// <returns></returns>
        public string Generate(IList<IClassGenerationParameters> classes)
        {
            if (classes == null)
            {
                throw new ArgumentNullException("classes");
            }

            if (classes.Count < 1)
            {
                throw new ArgumentException("classes");
            }

            var output = new StringBuilder();

            output.Append(new InformationInterfaceGenerator().Generate(classes));

            output.Append(new DifferenceInterfaceGenerator().Generate(classes));

            output.Append(new Information().Generate(classes));

            output.Append(new Difference().Generate(classes));

            return output.ToString();
        }
    }
}
