using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Generators.Features.Model;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.ModelTests;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    [ExcludeFromCodeCoverage]
    public static class UnkeyedModelInterfaceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<UnkeyedModelInterfaceGenerator, UnkeyedModelInterfaceFeatureFlags, UnkeyedModelInterfaceGeneratorProcessor, IEntityGenerationModel>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, UnkeyedModelInterfaceGenerator> GetFactory()
            {
                return attributeData => new TestUnkeyedModelInterfaceGenerator();
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<UnkeyedModelInterfaceGenerator, UnkeyedModelInterfaceFeatureFlags, UnkeyedModelInterfaceGeneratorProcessor, IEntityGenerationModel>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, UnkeyedModelInterfaceGenerator> GetFactory()
            {
                return data => new TestUnkeyedModelInterfaceGenerator();
            }
        }
    }
}
