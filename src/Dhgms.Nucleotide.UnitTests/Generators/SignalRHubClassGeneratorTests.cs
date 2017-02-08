using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public static class SignalRHubClassGeneratorTests
    {
        public sealed class ConstructorMethod : BaseConstructorMethod<SignalRHubClassGenerator>
        {
            public ConstructorMethod() : base(
                () => new SignalRHubClassGenerator(new Moq.Mock<AttributeData>().Object),
                () => new SignalRHubClassGenerator(null))
            {
            }
        }
    }
}
