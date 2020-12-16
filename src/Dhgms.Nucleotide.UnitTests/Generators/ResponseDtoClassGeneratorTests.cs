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
    public static class ResponseDtoClassGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<ResponseDtoClassGenerator, ResponseDtoClassFeatureFlags, ResponseDtoClassGeneratorProcessor, GenerateResponseDtoAttribute>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, ResponseDtoClassGenerator> GetFactory()
            {
                return data => new ResponseDtoClassGenerator();
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<ResponseDtoClassGenerator, ResponseDtoClassFeatureFlags, ResponseDtoClassGeneratorProcessor, GenerateResponseDtoAttribute>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, ResponseDtoClassGenerator> GetFactory()
            {
                return data => new ResponseDtoClassGenerator();
            }
        }
    }
}
