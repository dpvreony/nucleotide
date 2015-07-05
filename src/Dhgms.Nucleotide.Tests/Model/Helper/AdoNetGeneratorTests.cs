using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dhgms.Nucleotide.Tests.Model.Helper
{
    using Dhgms.Nucleotide.Generators;
    using Dhgms.Nucleotide.Model;

    using TestDhgms.NucleotideMocking;

    using Xunit;
    using Xunit.Abstractions;

    public class AdoNetGeneratorTests
    {
        public class GenerateMethod : BaseUnitTests
        {
            public GenerateMethod(ITestOutputHelper output)
                : base(output)
            {
            }

            [Fact]
            public void ThrowsArgumentNullException()
            {
                var instance = new AdoNetGenerator();

                var result = instance.Generate(null);

                this.OutputHelper.WriteLine(result);

                Assert.True(result.StartsWith("#error"));
                Assert.True(result.Contains("ArgumentNullException"));
            }

            [Fact]
            public void ThrowsArgumentException()
            {
                var instance = new AdoNetGenerator();

                var cgp = new MockClassGenerationParameters(TestInputs.MainNamespaceName, TestInputs.SubNamespace, null, null, TestInputs.PropertiesDefault, null, null, 2010, null, null);
                var classes = new List<IClassGenerationParameters> { cgp };

                var result = instance.Generate(classes);

                this.OutputHelper.WriteLine(result);

                Assert.True(result.StartsWith("#error"));
                Assert.True(result.Contains("ArgumentException"));
            }

            [Fact]
            public void ReturnsInterfaceCode()
            {
                var instance = new AdoNetGenerator();
                var classes = new List<IClassGenerationParameters> { new InformationInterfaceGeneratorTests.Cgp() };
                var result = instance.Generate(classes);

                Assert.NotNull(result);

                this.OutputHelper.WriteLine(result);
            }
        }
    }
}
