using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Generators.Features.EntityFramework;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.ModelTests;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    [ExcludeFromCodeCoverage]
    public static class EntityFrameworkDbContextGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<EntityFrameworkDbContextGenerator, EntityFrameworkDbContextFeatureFlags, EntityFrameworkDbContextGeneratorProcessor, IEntityGenerationModel>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, EntityFrameworkDbContextGenerator> GetFactory()
            {
                return data => new TestEntityFrameworkDbContextGenerator();
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<EntityFrameworkDbContextGenerator, EntityFrameworkDbContextFeatureFlags, EntityFrameworkDbContextGeneratorProcessor, IEntityGenerationModel>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, EntityFrameworkDbContextGenerator> GetFactory()
            {
                return data => new TestEntityFrameworkDbContextGenerator();
            }
        }
    }
}
