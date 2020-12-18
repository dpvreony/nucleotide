using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Dhgms.Nucleotide.Features.Cqrs;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.ModelTests;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    [ExcludeFromCodeCoverage]
    public static class QueryFactoryInterfaceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<QueryFactoryInterfaceGenerator, QueryFactoryInterfaceFeatureFlags, QueryFactoryInterfaceGeneratorProcessor>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, QueryFactoryInterfaceGenerator> GetFactory()
            {
                return data => new TestQueryFactoryInterfaceGenerator();
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<QueryFactoryInterfaceGenerator, QueryFactoryInterfaceFeatureFlags, QueryFactoryInterfaceGeneratorProcessor>
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