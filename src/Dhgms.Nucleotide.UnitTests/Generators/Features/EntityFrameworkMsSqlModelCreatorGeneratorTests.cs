using Dhgms.Nucleotide.Generators.Features.EntityFramework;
using Dhgms.Nucleotide.ModelTests;
using Dhgms.Nucleotide.SampleGenerator;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Dhgms.Nucleotide.UnitTests.Generators.Features
{
    [ExcludeFromCodeCoverage]
    public static class EntityFrameworkMsSqlModelCreatorGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<EntityFrameworkMsSqlModelCreatorGenerator, EntityFrameworkDbContextFeatureFlags, EntityFrameworkMsSqlModelCreatorGeneratorProcessor, EntityFrameworkDbContextGenerationModel>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, EntityFrameworkMsSqlModelCreatorGenerator> GetFactory()
            {
                return data => new TestEntityFrameworkMsSqlModelCreatorGenerator();
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<EntityFrameworkMsSqlModelCreatorGenerator, EntityFrameworkDbContextFeatureFlags, EntityFrameworkMsSqlModelCreatorGeneratorProcessor, EntityFrameworkDbContextGenerationModel>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, EntityFrameworkMsSqlModelCreatorGenerator> GetFactory()
            {
                return data => new TestEntityFrameworkMsSqlModelCreatorGenerator();
            }
        }
    }
}
