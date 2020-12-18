using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Dhgms.Nucleotide.Features.Model;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    [ExcludeFromCodeCoverage]
    public static class UnkeyedModelClassGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<UnkeyedModelClassGenerator, UnkeyedModelClassFeatureFlags, UnkeyedModelClassGeneratorProcessor>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, UnkeyedModelClassGenerator> GetFactory()
            {
                return data => new UnkeyedModelClassGenerator();
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<UnkeyedModelClassGenerator, UnkeyedModelClassFeatureFlags, UnkeyedModelClassGeneratorProcessor>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, UnkeyedModelClassGenerator> GetFactory()
            {
                return data => new UnkeyedModelClassGenerator();
            }
        }
    }
}
