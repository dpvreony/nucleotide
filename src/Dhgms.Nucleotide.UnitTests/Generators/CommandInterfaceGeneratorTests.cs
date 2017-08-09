using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public static class CommandInterfaceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<CommandInterfaceGenerator>
        {
            protected override Func<AttributeData, CommandInterfaceGenerator> GetFactory()
            {
                return attributeData => new CommandInterfaceGenerator(attributeData);
            }
        }
    }
}
