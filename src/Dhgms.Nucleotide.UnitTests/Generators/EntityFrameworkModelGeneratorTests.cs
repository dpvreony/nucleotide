using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public static class EntityFrameworkModelGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<EntityFrameworkModelGenerator>
        {
            protected override Func<AttributeData, EntityFrameworkModelGenerator> GetFactory()
            {
                return data => new EntityFrameworkModelGenerator(data);
            }
        }
    }
}
