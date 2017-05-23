using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public static class CommandClassGeneratorTests
    {
        public sealed class ConstructorMethod : BaseConstructorMethod<CommandClassGenerator>
        {
            public ConstructorMethod() : base(
                () => new CommandClassGenerator(new Moq.Mock<AttributeData>().Object),
                () => new CommandClassGenerator(null))
            {
            }
        }
    }
}
