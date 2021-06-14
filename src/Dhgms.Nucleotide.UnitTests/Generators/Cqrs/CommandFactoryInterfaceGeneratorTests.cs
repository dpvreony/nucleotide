using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Generators.Features.Cqrs;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.ModelTests;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    [ExcludeFromCodeCoverage]
    public class CommandFactoryInterfaceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<CommandFactoryInterfaceGenerator, CommandFactoryInterfaceFeatureFlags, CommandFactoryInterfaceGeneratorProcessor, IEntityGenerationModel>
        {
            public ConstructorMethod(ITestOutputHelper output)
                : base(output)
            {
            }

            protected override Func<AttributeData, CommandFactoryInterfaceGenerator> GetFactory()
            {
                return attributeData => new TestCommandFactoryInterfaceGenerator();
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<CommandFactoryInterfaceGenerator, CommandFactoryInterfaceFeatureFlags, CommandFactoryInterfaceGeneratorProcessor, IEntityGenerationModel>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, CommandFactoryInterfaceGenerator> GetFactory()
            {
                return data => new TestCommandFactoryInterfaceGenerator();
            }
        }
    }
}
