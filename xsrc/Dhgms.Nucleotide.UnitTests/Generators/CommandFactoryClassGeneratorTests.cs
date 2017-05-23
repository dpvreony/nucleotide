using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public static class CommandFactoryClassGeneratorTests
    {
        public sealed class ConstructorMethod : BaseConstructorMethod<CommandFactoryClassGenerator>
        {
            public ConstructorMethod() : base(
                () => new CommandFactoryClassGenerator(new Moq.Mock<AttributeData>().Object),
                () => new CommandFactoryClassGenerator(null))
            {
            }
        }
    }
}
