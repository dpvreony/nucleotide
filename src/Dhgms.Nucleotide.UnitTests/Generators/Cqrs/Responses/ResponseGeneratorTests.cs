using System;
using Dhgms.Nucleotide.SampleGenerator.Cqrs;
using Microsoft.CodeAnalysis;
using Xunit.Abstractions;

namespace Dhgms.Nucleotide.UnitTests.Generators.Cqrs.Requests
{
    public static class ResponseGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<TestableResponseGenerator>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, TestableResponseGenerator> GetFactory()
            {
                return data => new TestableResponseGenerator();
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<TestableResponseGenerator>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, TestableResponseGenerator> GetFactory()
            {
                return data => new TestableResponseGenerator();
            }
        }
    }
}
