using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public static class SignalRHubInterfaceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseConstructorMethod<SignalRHubInterfaceGenerator>
        {
            public ConstructorMethod() : base(
                () => new SignalRHubInterfaceGenerator(new Moq.Mock<AttributeData>().Object),
                () => new SignalRHubInterfaceGenerator(null))
            {
            }
        }
    }
}
