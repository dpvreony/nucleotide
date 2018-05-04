using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;
using System.Text;
using CodeGeneration.Roslyn;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public class BaseGeneratorTests
    {
        public class MockAttributeData : AttributeData
        {
            public MockAttributeData()
            {

            }

            protected override INamedTypeSymbol CommonAttributeClass { get; }
            protected override IMethodSymbol CommonAttributeConstructor { get; }
            protected override SyntaxReference CommonApplicationSyntaxReference { get; }
            protected override ImmutableArray<TypedConstant> CommonConstructorArguments { get; }
            protected override ImmutableArray<KeyValuePair<string, TypedConstant>> CommonNamedArguments { get; }
        }

        public abstract class BaseConstructorMethod<TGenerator>
            where TGenerator : class, ICodeGenerator
        {
            protected abstract Func<AttributeData, TGenerator> GetFactory();

            [Fact]
            public void ThrowsArgumentNullException()
            {
                var factory = GetFactory();
                var exception = Assert.Throws<ArgumentNullException>(() => factory(null));
                Assert.Equal("attributeData", exception.ParamName);
            }

            [Fact]
            public void ThrowsArgumentException()
            {
                var factory = GetFactory();
                var attributeData = new MockAttributeData();

                var exception = Assert.Throws<ArgumentException>(() => factory(attributeData));
                Assert.Equal("attributeData", exception.ParamName);
            }

            [Fact]
            public void ReturnsInstance()
            {
                var factory = GetFactory();
                var attributeData = new MockAttributeData();
                var instance = factory(attributeData);

                Assert.NotNull(instance);
            }
        }

        public abstract class BaseGenerateAsyncMethod<TGenerator>
            where TGenerator : class, ICodeGenerator
        {
            [Fact]
            public void ThrowsArgumentNullException()
            {
            }

        }
    }
}