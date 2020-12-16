using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Dhgms.Nucleotide.Attributes;
using Dhgms.Nucleotide.Features.EntityFramework;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    [ExcludeFromCodeCoverage]
    public static class EntityFrameworkModelGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<EntityFrameworkModelGenerator, EntityFrameworkModelFeatureFlags, EntityFrameworkModelGeneratorProcessor, GenerateEntityFrameworkModelClassAttribute>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, EntityFrameworkModelGenerator> GetFactory()
            {
                return data => new EntityFrameworkModelGenerator();
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<EntityFrameworkModelGenerator, EntityFrameworkModelFeatureFlags, EntityFrameworkModelGeneratorProcessor, GenerateEntityFrameworkModelClassAttribute>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, EntityFrameworkModelGenerator> GetFactory()
            {
                return data => new EntityFrameworkModelGenerator();
            }
        }
    }
}
