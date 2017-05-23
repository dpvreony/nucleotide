using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public static class QueryFactoryGeneratorTests
    {
        public sealed class ConstructorMethod : BaseConstructorMethod<QueryFactoryGenerator>
        {
            public ConstructorMethod() : base(
                () => new QueryFactoryGenerator(new Moq.Mock<AttributeData>().Object),
                () => new QueryFactoryGenerator(null))
            {
            }
        }
    }
}
