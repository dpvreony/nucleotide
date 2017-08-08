using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public sealed class CommandClassGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<CommandClassGenerator>
        {
            protected override Func<AttributeData, CommandClassGenerator> GetFactory()
            {
                return attributeData => new CommandClassGenerator(attributeData);
            }
        }
    }
}
