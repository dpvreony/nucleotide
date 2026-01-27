using Dhgms.Nucleotide.SampleGenerator;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public static class NucleotideObjectGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<TestableNucleotideObjectGenerator>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<TestableNucleotideObjectGenerator>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }
        }
    }
}
