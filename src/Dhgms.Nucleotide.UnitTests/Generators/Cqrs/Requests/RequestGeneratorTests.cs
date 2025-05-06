using Dhgms.Nucleotide.Generators.Features.Cqrs;
using Dhgms.Nucleotide.ModelTests;
using Dhgms.Nucleotide.SampleGenerator.Cqrs;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Dhgms.Nucleotide.UnitTests.Generators.Cqrs.Requests
{
    public static class RequestGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<TestableRequestGenerator>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, TestableRequestGenerator> GetFactory()
            {
                return data => new TestableRequestGenerator();
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<TestableRequestGenerator>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, TestableRequestGenerator> GetFactory()
            {
                return data => new TestableRequestGenerator();
            }
        }
    }
}
