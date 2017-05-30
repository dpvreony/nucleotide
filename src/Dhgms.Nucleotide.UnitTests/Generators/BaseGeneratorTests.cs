using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Xunit;
using System.Diagnostics.CodeAnalysis;
using CodeGeneration.Roslyn;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    //[ExcludeFromCodeCoverage]
    public static class GeneratorTests
    {
        private static IEnumerable<object[]> TestData = new[]
        {
            CommandClassGeneratorTestData
        };

        private static CodeGeneratorFactory CommandClassGeneratorFactory =
            attributeData => new CommandClassGenerator(attributeData);

        private static object[] CommandClassGeneratorTestData = new object[]
        {
            CommandClassGeneratorFactory
        };

        public delegate ICodeGenerator CodeGeneratorFactory(AttributeData attributeData);

        public sealed class ConstructorMethod
        {
            [Theory]
            [MemberData(nameof(TestData))]
            public void ThrowsArgumentNullException(CodeGeneratorFactory factory)
            {
            }

        }
    }
}
