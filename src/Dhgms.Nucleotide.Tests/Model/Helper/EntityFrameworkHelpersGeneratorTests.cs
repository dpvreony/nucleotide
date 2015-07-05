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

    public class EntityFrameworkHelpersGeneratorTests
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
                var instance = new EntityFrameworkHelpers();

                var result = instance.Generate("TestDhgms", null);

                this.OutputHelper.WriteLine(result);

                Assert.True(result.StartsWith("#error"));
                Assert.True(result.Contains("ArgumentNullException"));
            }

            [Fact]
            public void ThrowsArgumentException()
            {
                var instance = new EntityFrameworkHelpers();

                var cgp = new MockClassGenerationParameters(TestInputs.MainNamespaceName, TestInputs.SubNamespace, null, null, TestInputs.PropertiesDefault, null, null, 2010, null, null);
                List<Tuple<IClassGenerationParameters, string>> classes = new List<Tuple<IClassGenerationParameters, string>>
                                                                              {
                                                                                  new Tuple<IClassGenerationParameters, string>(cgp, "SomeClassEf")
                                                                              };

                var result = instance.Generate("TestDhgms", classes);

                this.OutputHelper.WriteLine(result);
                
                Assert.True(result.StartsWith("#error"));
                Assert.True(result.Contains("ArgumentException"));
            }

            [Fact]
            public void ReturnsCode()
            {
                var instance = new EntityFrameworkHelpers();
                List<Tuple<IClassGenerationParameters, string>> classes = new List<Tuple<IClassGenerationParameters, string>>
                                                                              {
                                                                                  new Tuple<IClassGenerationParameters, string>(new InformationInterfaceGeneratorTests.Cgp(), "SomeClassEf")
                                                                              };
                var result = instance.Generate("TestDhgms", classes);

                Assert.NotNull(result);
                this.OutputHelper.WriteLine(result);
            }
        }
    }
}
