using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Features.EntityFramework;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public static class EntityFrameworkDbSetGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<EntityFrameworkDbSetGenerator>
        {
            protected override Func<AttributeData, EntityFrameworkDbSetGenerator> GetFactory()
            {
                return data => new EntityFrameworkDbSetGenerator(data);
            }
        }
    }
}
