using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dhgms.Nucleotide.Tests
{
    using System.Diagnostics.CodeAnalysis;

    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    public class BaseUnitTests
    {
        public BaseUnitTests(ITestOutputHelper output)
        {
            if (output == null)
            {
                throw new ArgumentNullException("output");
            }

            this.OutputHelper = output;
        }

        protected ITestOutputHelper OutputHelper { get; private set; }
    }
}
