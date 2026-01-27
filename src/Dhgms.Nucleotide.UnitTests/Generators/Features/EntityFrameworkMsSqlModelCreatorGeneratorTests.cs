using Dhgms.Nucleotide.SampleGenerator;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators.Features
{
    [ExcludeFromCodeCoverage]
    public static class EntityFrameworkMsSqlModelCreatorGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<TestEntityFrameworkMsSqlModelCreatorGenerator>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<TestEntityFrameworkMsSqlModelCreatorGenerator>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }
        }
    }
}
