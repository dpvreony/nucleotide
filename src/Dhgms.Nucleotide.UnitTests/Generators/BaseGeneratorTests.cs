using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Xunit;
using System.Diagnostics.CodeAnalysis;
using CodeGeneration.Roslyn;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    //[ExcludeFromCodeCoverage]
    public static class GeneratorTests
    {
        public delegate ICodeGenerator CodeGeneratorFactory(AttributeData attributeData);

        public sealed class ConstructorMethod
        {
            public static IEnumerable<object[]> TestData = new[]
            {
                new object[]
                {
                    CommandClassGeneratorFactory
                },
            };

            private static readonly CodeGeneratorFactory CommandClassGeneratorFactory =
                attributeData => new CommandClassGenerator(attributeData);

            private static readonly object[] CommandClassGeneratorTestData = new object[]
            {
                CommandClassGeneratorFactory
            };

            [Theory]
            [MemberData(nameof(TestData))]
            public void ThrowsArgumentNullException(CodeGeneratorFactory factory)
            {
                var exception = Assert.Throws<ArgumentNullException>(() => factory(null));
                Assert.Equal("attributeData", exception.ParamName);
            }

            [Theory]
            [MemberData(nameof(TestData))]
            public void ReturnsInstance(CodeGeneratorFactory factory)
            {
                // just done so code compiles.
                AttributeData attributeData = default(AttributeData);
                var instance = factory(attributeData);
                Assert.NotNull(instance);
            }
        }
    }
}
