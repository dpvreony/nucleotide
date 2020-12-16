using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Dhgms.Nucleotide.Attributes;
using Dhgms.Nucleotide.Features.Cqrs;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    [ExcludeFromCodeCoverage]
    public class CommandFactoryInterfaceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<CommandFactoryInterfaceGenerator, CommandFactoryInterfaceFeatureFlags, CommandFactoryInterfaceGeneratorProcessor, GenerateCommandFactoryInterfaceAttribute>
        {
            public ConstructorMethod(ITestOutputHelper output)
                : base(output)
            {
            }

            protected override Func<AttributeData, CommandFactoryInterfaceGenerator> GetFactory()
            {
                return attributeData => new CommandFactoryInterfaceGenerator();
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<CommandFactoryInterfaceGenerator, CommandFactoryInterfaceFeatureFlags, CommandFactoryInterfaceGeneratorProcessor, GenerateCommandFactoryInterfaceAttribute>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, CommandFactoryInterfaceGenerator> GetFactory()
            {
                return data => new CommandFactoryInterfaceGenerator();
            }
        }
    }
}
