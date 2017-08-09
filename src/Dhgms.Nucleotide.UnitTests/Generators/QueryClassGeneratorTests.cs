using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public static class QueryClassGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<QueryClassGenerator>
        {
            protected override Func<AttributeData, QueryClassGenerator> GetFactory()
            {
                return data => new QueryClassGenerator(data);
            }
        }
    }
}
