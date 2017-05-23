using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public class BaseConstructorMethod<TType>
        where TType : class
    {
        private readonly Func<TType> _successFactory;
        private readonly Func<TType> _failureFactory;

        public BaseConstructorMethod(Func<TType> successFactory,
            Func<TType> failureFactory)
        {
            this._successFactory = successFactory;
            this._failureFactory = failureFactory;
        }

        [Fact]
        public void ReturnsInstance()
        {
            var instance = this._successFactory();
            Assert.NotNull(instance);
        }

        [Fact]
        public void ThrowsArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => this._failureFactory());
            Assert.Equal("attributeData", exception.ParamName);
        }
    }

    public static class WebApiServiceClassGeneratorTests
    {
        public sealed class ConstructorMethod : BaseConstructorMethod<WebApiServiceGenerator>
        {
            public ConstructorMethod() : base(
                () => new WebApiServiceGenerator(new Moq.Mock<AttributeData>().Object),
                () => new WebApiServiceGenerator(null))
            {
            }
        }
    }
}
