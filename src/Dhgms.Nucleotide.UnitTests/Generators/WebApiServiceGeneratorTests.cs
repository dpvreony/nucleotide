using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Features.WebApi;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public static class WebApiServiceGeneratorTests
    {
        public sealed class ConstructorMethod
        {
            [Fact]
            public void ThrowsArgumentNullException()
            {

                var exception = Assert.Throws<ArgumentNullException>(() => new WebApiServiceGenerator(null));
                Assert.Equal("attributeData", exception.ParamName);
            }

            [Fact]
            public void ReturnsInstance()
            {
                var attributeData = new Mock<AttributeData>(MockBehavior.Strict);
                var instance = new WebApiServiceGenerator(attributeData.Object);
                Assert.NotNull(instance);
            }
        }
    }
}
