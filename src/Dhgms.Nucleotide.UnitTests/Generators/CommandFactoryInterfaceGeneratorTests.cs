using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public static class CommandFactoryInterfaceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseConstructorMethod<CommandFactoryInterfaceGenerator>
        {
            public ConstructorMethod() : base(
                () => new CommandFactoryInterfaceGenerator(new Moq.Mock<AttributeData>().Object),
                () => new CommandFactoryInterfaceGenerator(null))
            {
            }
        }
    }
}
