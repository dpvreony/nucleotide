using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Features.Cqrs;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public static class QueryFactoryClassGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<QueryFactoryClassGenerator>
        {
            protected override Func<AttributeData, QueryFactoryClassGenerator> GetFactory()
            {
                return data => new QueryFactoryClassGenerator(data);
            }
        }
    }
}
