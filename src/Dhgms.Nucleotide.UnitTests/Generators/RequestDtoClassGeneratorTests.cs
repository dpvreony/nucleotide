using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Dhgms.Nucleotide.Attributes;
using Dhgms.Nucleotide.Features.Dto;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    [ExcludeFromCodeCoverage]
    public static class RequestDtoClassGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<RequestDtoClassGenerator, RequestDtoClassFeatureFlags, RequestDtoClassGeneratorProcessor, GenerateRequestDtoAttribute>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, RequestDtoClassGenerator> GetFactory()
            {
                return data => new RequestDtoClassGenerator();
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<RequestDtoClassGenerator, RequestDtoClassFeatureFlags, RequestDtoClassGeneratorProcessor, GenerateRequestDtoAttribute>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, RequestDtoClassGenerator> GetFactory()
            {
                return data => new RequestDtoClassGenerator();
            }
        }
    }
}
