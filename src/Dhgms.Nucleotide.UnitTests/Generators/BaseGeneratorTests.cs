using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeGeneration.Roslyn;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.ModelTests;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators
{

    [ExcludeFromCodeCoverage]
    public class BaseGeneratorTests
    {
        public class MockAttributeData : AttributeData
        {
            public MockAttributeData()
            {
            }

            public MockAttributeData(TypedConstant constructorArg)
            {
                this.CommonConstructorArguments = ImmutableArray.Create(constructorArg);
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
                var attributeData = new MockAttributeData(new TypedConstant());
                var instance = factory(attributeData);

                Assert.NotNull(instance);
            }
        }

        public abstract class BaseGenerateAsyncMethod<TGenerator>
            where TGenerator : class, ICodeGenerator
        {
            protected abstract Func<AttributeData, TGenerator> GetFactory();

            //[Theory]
            public async Task ThrowsArgumentNullException(
                TransformationContext context,
                IProgress<Diagnostic> progress,
                string paramNameThatThrowsException)
            {
                var factory = GetFactory();
                var attributeData = new MockAttributeData(new TypedConstant());
                var instance = factory(attributeData);
                var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => instance.GenerateAsync(context, progress, CancellationToken.None));
                Assert.NotNull(ex);
                Assert.Equal(paramNameThatThrowsException, ex.ParamName);
            }

        }
    }
}