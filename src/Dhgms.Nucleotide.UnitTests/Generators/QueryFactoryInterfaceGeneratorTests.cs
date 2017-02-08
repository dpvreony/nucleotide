using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public static class QueryFactoryInterfaceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseConstructorMethod<QueryFactoryInterfaceGenerator>
        {
            public ConstructorMethod() : base(
                () => new QueryFactoryInterfaceGenerator(new Moq.Mock<AttributeData>().Object),
                () => new QueryFactoryInterfaceGenerator(null))
            {
            }
        }
    }
}
