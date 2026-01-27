using System.Diagnostics.CodeAnalysis;
using Dhgms.Nucleotide.SampleGenerator;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators.Features.ReactiveUI.WPF
{
    [ExcludeFromCodeCoverage]
    public static class ReactiveMetroWindowClassGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<TestReactiveMetroWindowClassGenerator>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<TestReactiveMetroWindowClassGenerator>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }
        }
    }
}
