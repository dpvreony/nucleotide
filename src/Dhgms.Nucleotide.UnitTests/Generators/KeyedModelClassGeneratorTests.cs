using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Features.Model;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public static class KeyedModelClassGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<KeyedModelClassGenerator>
        {
            protected override Func<AttributeData, KeyedModelClassGenerator> GetFactory()
            {
                return data => new KeyedModelClassGenerator(data);
            }
        }
    }
}
