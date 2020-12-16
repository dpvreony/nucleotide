using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Dhgms.Nucleotide.Attributes;
using Dhgms.Nucleotide.Features.Model;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    [ExcludeFromCodeCoverage]
    public static class UnkeyedModelInterfaceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<UnkeyedModelInterfaceGenerator, UnkeyedModelInterfaceFeatureFlags, UnkeyedModelInterfaceGeneratorProcessor, GenerateUnkeyedModelInterfaceAttribute>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, UnkeyedModelInterfaceGenerator> GetFactory()
            {
                return attributeData => new UnkeyedModelInterfaceGenerator();
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<UnkeyedModelInterfaceGenerator, UnkeyedModelInterfaceFeatureFlags, UnkeyedModelInterfaceGeneratorProcessor, GenerateUnkeyedModelInterfaceAttribute>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, UnkeyedModelInterfaceGenerator> GetFactory()
            {
                return data => new UnkeyedModelInterfaceGenerator();
            }
        }
    }
}
