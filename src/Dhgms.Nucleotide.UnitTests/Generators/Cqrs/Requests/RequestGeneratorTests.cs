using Dhgms.Nucleotide.Generators.Features.Cqrs;
using Dhgms.Nucleotide.ModelTests;
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
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<TestRequestDtoClassGenerator>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, TestRequestDtoClassGenerator> GetFactory()
            {
                return data => new TestRequestDtoClassGenerator();
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<QueryFactoryInterfaceGenerator>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, QueryFactoryInterfaceGenerator> GetFactory()
            {
                return data => new TestQueryFactoryInterfaceGenerator();
            }
        }
    }
}
