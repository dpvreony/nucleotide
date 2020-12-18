using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Dhgms.Nucleotide.Features.Dto;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.ModelTests;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    [ExcludeFromCodeCoverage]
    public static class RequestDtoClassGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<RequestDtoClassGenerator, RequestDtoClassFeatureFlags, RequestDtoClassGeneratorProcessor>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, RequestDtoClassGenerator> GetFactory()
            {
                return data => new TestRequestDtoClassGenerator();
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<RequestDtoClassGenerator, RequestDtoClassFeatureFlags, RequestDtoClassGeneratorProcessor>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, RequestDtoClassGenerator> GetFactory()
            {
                return data => new TestRequestDtoClassGenerator();
            }
        }
    }
}
