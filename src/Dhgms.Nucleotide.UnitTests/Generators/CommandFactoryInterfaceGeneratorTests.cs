using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public class CommandFactoryInterfaceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<CommandFactoryInterfaceGenerator>
        {
            protected override Func<AttributeData, CommandFactoryInterfaceGenerator> GetFactory()
            {
                return attributeData => new CommandFactoryInterfaceGenerator(attributeData);
            }
        }
    }
}
