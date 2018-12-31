using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Dhgms.Nucleotide.Features.Model;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    [ExcludeFromCodeCoverage]
    public static class UnkeyedModelInterfaceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<UnkeyedModelInterfaceGenerator>
        {
            protected override Func<AttributeData, UnkeyedModelInterfaceGenerator> GetFactory()
            {
                return attributeData => new UnkeyedModelInterfaceGenerator(attributeData);
            }
        }
 
        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<UnkeyedModelInterfaceGenerator>
        {
            protected override Func<AttributeData, UnkeyedModelInterfaceGenerator> GetFactory()
            {
                return data => new UnkeyedModelInterfaceGenerator(data);
            }
        }
    }
}
