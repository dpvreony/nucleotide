using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public static class WcfServiceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseConstructorMethod<WcfServiceGenerator>
        {
            public ConstructorMethod() : base(
                () => new WcfServiceGenerator(new Moq.Mock<AttributeData>().Object),
                () => new WcfServiceGenerator(null))
            {
            }
        }
    }
}
