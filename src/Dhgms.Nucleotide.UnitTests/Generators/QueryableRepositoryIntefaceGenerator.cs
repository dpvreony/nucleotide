using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public static class QueryableRepositoryIntefaceGenerator
    {
        public sealed class ConstructorMethod
        {
            [Fact]
            public void ThrowsArgumentNullException()
            {
                var ex = Assert.Throws<ArgumentNullException>(() => new Nucleotide.Generators.QueryableRepositoryIntefaceGenerator(null));
                Assert.Equal("attributeData", ex.ParamName);
            }
        }
    }
}
