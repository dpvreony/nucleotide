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
    public static class ReferencedByEntityGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<ReferencedByEntityGenerator, ReferencedByEntityFeatureFlags, ReferencedByEntityGeneratorProcessor, ReferencedByEntityGenerationModel>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, ReferencedByEntityGenerator> GetFactory()
            {
                return data => new TestReferencedByEntityGenerator();
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<ReferencedByEntityGenerator, ReferencedByEntityFeatureFlags, ReferencedByEntityGeneratorProcessor, ReferencedByEntityGenerationModel>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, ReferencedByEntityGenerator> GetFactory()
            {
                return data => new TestReferencedByEntityGenerator();
            }
        }
    }
}
