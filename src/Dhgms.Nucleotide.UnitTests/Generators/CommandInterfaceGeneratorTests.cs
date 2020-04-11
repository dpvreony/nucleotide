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
    public static class CommandInterfaceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<CommandInterfaceGenerator>
        {
            protected override Func<AttributeData, CommandInterfaceGenerator> GetFactory()
            {
                return attributeData => new CommandInterfaceGenerator(attributeData);
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<CommandInterfaceGenerator>
        {
            protected override Func<AttributeData, CommandInterfaceGenerator> GetFactory()
            {
                return data => new CommandInterfaceGenerator(data);
            }
        }
    }
}
