namespace Dhgms.Nucleotide.Tests.Model.Helper
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using Dhgms.Nucleotide.Helper;
    using Dhgms.Nucleotide.Model;
    using Dhgms.Nucleotide.PropertyInfo;

    using TestDhgms.NucleotideMocking;

    using Xunit;

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
        
        public class GenerateMethod
        {
            [Fact]
            public void ThrowsArgumentNullException()
            {
                var instance = new InformationInterfaceGenerator();
                var ex = Assert.Throws<ArgumentNullException>(() => instance.Generate(null));

                Assert.Equal("classes", ex.ParamName);
            }

            [Fact]
            public void ThrowsArgumentException()
            {
                var instance = new InformationInterfaceGenerator();
                var ex = Assert.Throws<ArgumentException>(() => instance.Generate(null));

                Assert.Equal("classes", ex.ParamName);
            }

            [Fact]
            public void ReturnsInterfaceCode()
            {
                var instance = new InformationInterfaceGenerator();
                var classes = new List<IClassGenerationParameters> { new Cgp() };
                var result = instance.Generate(classes);

                Assert.NotNull(result);

                Console.WriteLine(result);
            }
        }
    }
}
