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
    public static class UnkeyedModelInterfaceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<UnkeyedModelInterfaceGenerator>
        {
            protected override Func<AttributeData, UnkeyedModelInterfaceGenerator> GetFactory()
            {
                return attributeData => new UnkeyedModelInterfaceGenerator(attributeData);
            }
        }
    }
}
