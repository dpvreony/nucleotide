using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public static class QueryFactoryInterfaceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<QueryFactoryInterfaceGenerator>
        {
            protected override Func<AttributeData, QueryFactoryInterfaceGenerator> GetFactory()
            {
                return data => new QueryFactoryInterfaceGenerator(data);
            }
        }
    }
}