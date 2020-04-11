﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Dhgms.Nucleotide.Features.Cqrs;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    [ExcludeFromCodeCoverage]
    public class CommandFactoryInterfaceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<CommandFactoryInterfaceGenerator>
        {
            protected override Func<AttributeData, CommandFactoryInterfaceGenerator> GetFactory()
            {
                return attributeData => new CommandFactoryInterfaceGenerator(attributeData);
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<CommandFactoryInterfaceGenerator>
        {
            protected override Func<AttributeData, CommandFactoryInterfaceGenerator> GetFactory()
            {
                return data => new CommandFactoryInterfaceGenerator(data);
            }
        }
    }
}
