using System.Diagnostics.CodeAnalysis;
using Dhgms.Nucleotide.SampleGenerator;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators.Features.ReactiveUI
{
    [ExcludeFromCodeCoverage]
    public static class ReactiveWindowClassGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<TestReactiveWindowClassGenerator>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<TestReactiveWindowClassGenerator>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }
        }
    }
}
