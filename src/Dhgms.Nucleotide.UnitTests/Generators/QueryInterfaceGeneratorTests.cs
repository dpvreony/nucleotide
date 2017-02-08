using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public static class QueryInterfaceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseConstructorMethod<QueryInterfaceGenerator>
        {
            public ConstructorMethod() : base(
                () => new QueryInterfaceGenerator(new Moq.Mock<AttributeData>().Object),
                () => new QueryInterfaceGenerator(null))
            {
            }
        }
    }
}
