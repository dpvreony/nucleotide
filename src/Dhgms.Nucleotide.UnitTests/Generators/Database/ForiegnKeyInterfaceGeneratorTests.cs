using System;
using System.Diagnostics.CodeAnalysis;
using Dhgms.Nucleotide.Generators.Features.Database;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.ModelTests;
using Microsoft.CodeAnalysis;
using Xunit.Abstractions;

namespace Dhgms.Nucleotide.UnitTests.Generators.Database
{
    [ExcludeFromCodeCoverage]
    public static class ForiegnKeyInterfaceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<ForiegnKeyInterfaceGenerator, ForiegnKeyInterfaceFeatureFlags, ForiegnKeyInterfaceGeneratorProcessor, IEntityGenerationModel>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, ForiegnKeyInterfaceGenerator> GetFactory()
            {
                return data => new TestForiegnKeyInterfaceGenerator();
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<ForiegnKeyInterfaceGenerator, ForiegnKeyInterfaceFeatureFlags, ForiegnKeyInterfaceGeneratorProcessor, IEntityGenerationModel>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, ForiegnKeyInterfaceGenerator> GetFactory()
            {
                return data => new TestForiegnKeyInterfaceGenerator();
            }
        }
    }
}
