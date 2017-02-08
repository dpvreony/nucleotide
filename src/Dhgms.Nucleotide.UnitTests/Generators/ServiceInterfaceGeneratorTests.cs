using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public static class ServiceInterfaceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseConstructorMethod<ServiceInterfaceGenerator>
        {
            public ConstructorMethod() : base(
                () => new ServiceInterfaceGenerator(new Moq.Mock<AttributeData>().Object),
                () => new ServiceInterfaceGenerator(null))
            {
            }
        }
    }
}
