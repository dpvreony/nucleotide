using System.Diagnostics.CodeAnalysis;
using Dhgms.Nucleotide.SampleGenerator;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators.Features.ReactiveUI.WPF
{
    [ExcludeFromCodeCoverage]
    public static class ReactiveSimpleChildWindowClassGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<TestReactiveSimpleChildWindowClassGenerator>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<TestReactiveSimpleChildWindowClassGenerator>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }
        }
    }
}
