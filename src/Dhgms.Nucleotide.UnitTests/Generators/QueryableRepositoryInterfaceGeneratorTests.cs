using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public static class QueryableRepositoryInterfaceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<QueryableRepositoryInterfaceGenerator>
        {
            protected override Func<AttributeData, QueryableRepositoryInterfaceGenerator> GetFactory()
            {
                return data => new QueryableRepositoryInterfaceGenerator(data);
            }
        }
    }
}
