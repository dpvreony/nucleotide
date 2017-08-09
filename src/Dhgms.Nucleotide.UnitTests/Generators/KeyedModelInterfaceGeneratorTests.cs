using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public static class KeyedModelInterfaceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<KeyedModelInterfaceGenerator>
        {
            protected override Func<AttributeData, KeyedModelInterfaceGenerator> GetFactory()
            {
                return data => new KeyedModelInterfaceGenerator(data);
            }
        }
    }
}
