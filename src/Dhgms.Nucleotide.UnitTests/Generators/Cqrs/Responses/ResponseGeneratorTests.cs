using Dhgms.Nucleotide.SampleGenerator.Cqrs;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators.Cqrs.Requests
{
    public static class ResponseGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<TestableResponseGenerator>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<TestableResponseGenerator>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }
        }
    }
}
