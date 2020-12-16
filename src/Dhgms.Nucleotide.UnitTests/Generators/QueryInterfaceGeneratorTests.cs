using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Dhgms.Nucleotide.Attributes;
using Dhgms.Nucleotide.Features.Cqrs;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    [ExcludeFromCodeCoverage]
    public static class QueryInterfaceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<QueryInterfaceGenerator, QueryInterfaceFeatureFlag, QueryInterfaceGeneratorProcessor, GenerateQueryInterfaceAttribute>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, QueryInterfaceGenerator> GetFactory()
            {
                return data => new QueryInterfaceGenerator();
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<QueryInterfaceGenerator, QueryInterfaceFeatureFlag, QueryInterfaceGeneratorProcessor, GenerateQueryInterfaceAttribute>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, QueryInterfaceGenerator> GetFactory()
            {
                return data => new QueryInterfaceGenerator();
            }
        }
    }
}
