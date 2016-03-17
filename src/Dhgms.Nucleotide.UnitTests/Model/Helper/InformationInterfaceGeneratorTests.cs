namespace Dhgms.Nucleotide.Tests.Model.Helper
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using Dhgms.Nucleotide.Generators;
    using Dhgms.Nucleotide.Model;
    using Dhgms.Nucleotide.PropertyInfo;

    using TestDhgms.NucleotideMocking;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    public class InformationInterfaceGeneratorTests
    {
        public class Cgp : ClassGenerationParameters
        {
            public override string MainNamespaceName
            {
                get
                {
                    return "TestDhgms.NucleotideMocking";
                }
            }

            public override string SubNamespace
            {
                get
                {
                    return null;
                }
            }

            public override string ClassName
            {
                get
                {
                    return "SingleSimple";
                }
            }

            public override PropertyInfoBase[] Properties
            {
                get
                {
                    return new PropertyInfoBase[]
                {
                    new Dhgms.Nucleotide.PropertyInfo.Integer32PropertyInfo(
                        Dhgms.Nucleotide.Model.CollectionType.None,
                        "Id",
                        "Unique Id",
                        false,
                        null,
                        null,
                        true,
                        null
                        ),
                    new Dhgms.Nucleotide.PropertyInfo.ClrStringPropertyInfo(
                        Dhgms.Nucleotide.Model.CollectionType.None,
                        "Name",
                        "Name",
                        false,
                        null,
                        null,
                        false,
                        false,
                        null
                        )
                };
                }
            }

            public override PropertyInfoBase[] BaseClassProperties
            {
                get
                {
                    return null;
                }
            }

            public override string CompanyName
            {
                get
                {
                    return "DHGMS Solutions";
                }
            }

            public override string[] CopyrightBanner
            {
                get
                {
                    return new[] { "bleh" };
                }
            }

            public override int CopyrightStartYear
            {
                get
                {
                    return 2008;
                }
            }

            public override string BaseClassName
            {
                get
                {
                    return null;
                }
            }

            public override string ClassRemarks
            {
                get
                {
                    return "Represents a class containing properties that are simple";
                }
            }
        }

        public class GenerateMethod : BaseUnitTests
        {
            public GenerateMethod(ITestOutputHelper output)
                : base(output)
            {
            }

            [Fact]
            public void ThrowsArgumentNullException()
            {
                var instance = new InformationInterfaceGenerator();

                var result = instance.Generate(null);

                this.OutputHelper.WriteLine(result);

                Assert.True(result.StartsWith("#error"));
                Assert.True(result.Contains("ArgumentNullException"));
            }

            [Fact]
            public void ThrowsArgumentException()
            {
                var instance = new InformationInterfaceGenerator();

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
                var instance = new InformationInterfaceGenerator();
                var classes = new List<IClassGenerationParameters> { new Cgp() };
                var result = instance.Generate(classes);

                Assert.NotNull(result);

                this.OutputHelper.WriteLine(result);
            }
        }
    }
}
