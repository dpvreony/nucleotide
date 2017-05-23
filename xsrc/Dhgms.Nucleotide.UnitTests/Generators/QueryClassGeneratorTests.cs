using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public static class QueryClassGeneratorTests
    {
        public sealed class ConstructorMethod : BaseConstructorMethod<QueryClassGenerator>
        {
            public ConstructorMethod() : base(
                () => new QueryClassGenerator(new Moq.Mock<AttributeData>().Object),
                () => new QueryClassGenerator(null))
            {
            }
        }
    }
}
