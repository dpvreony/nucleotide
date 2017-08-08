using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;
using System.Text;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public class BaseGeneratorTests
    {
<<<<<<< HEAD
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
=======
        public abstract class BaseConstructorMethod<TGenerator>
            where TGenerator : class
        {
            protected abstract Func<AttributeData, TGenerator> GetFactory();

            [Fact]
            public void ThrowsArgumentNullException()
>>>>>>> origin/roslyn
            {
                var factory = GetFactory();
                var exception = Assert.Throws<ArgumentNullException>(() => factory(null));
                Assert.Equal("attributeData", exception.ParamName);
            }

            [Fact]
            public void ThrowsArgumentException()
            {
                var factory = GetFactory();
                var attributeData = new Mock<AttributeData>(MockBehavior.Strict);
                attributeData.SetupProperty(x => x.ConstructorArguments, ImmutableArray<TypedConstant>.Empty);

                var exception = Assert.Throws<ArgumentNullException>(() => factory(null));
                Assert.Equal("attributeData", exception.ParamName);
            }

            [Fact]
            public void ReturnsInstance()
            {
                var factory = GetFactory();
                var attributeData = new Mock<AttributeData>(MockBehavior.Strict);
                var instance = factory(attributeData.Object);
                Assert.NotNull(instance);
            }
        }
    }
}
