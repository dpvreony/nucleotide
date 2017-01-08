using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public static class EntityFrameworkGeneratorTests
    {
        public sealed class ConstructorMethod
        {
            [Fact]
            public void ReturnsInstance()
            {
                var attributeData = new Mock<AttributeData>();
                var instance = new EntityFrameworkDbSetGenerator(attributeData.Object);
                Assert.NotNull(instance);
            }
        }

        public sealed class GenerateAsyncMethod
        {
            [Fact]
            public async Task ReturnsInstance()
            {
                var attributeData = new Mock<AttributeData>();
                var instance = new EntityFrameworkDbSetGenerator(attributeData.Object);

                var result = await instance.GenerateAsync(null, null, null, CancellationToken.None);
                Assert.NotNull(result);
            }
        }
    }
}
