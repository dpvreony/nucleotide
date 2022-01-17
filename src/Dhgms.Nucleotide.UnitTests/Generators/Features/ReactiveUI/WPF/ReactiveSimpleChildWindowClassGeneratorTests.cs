using System;
using System.Diagnostics.CodeAnalysis;
using Dhgms.Nucleotide.Generators.Features.ReactiveUI.Wpf;
using Dhgms.Nucleotide.SampleGenerator;
using Microsoft.CodeAnalysis;
using Xunit.Abstractions;

namespace Dhgms.Nucleotide.UnitTests.Generators.Features.ReactiveUI.WPF
{
    [ExcludeFromCodeCoverage]
    public static class ReactiveSimpleChildWindowClassGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<ReactiveMetroWindowClassGenerator, ReactiveWindowClassFeatureFlags, ReactiveMetroWindowClassGeneratorProcessor, ReactiveWindowGenerationModel>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, ReactiveMetroWindowClassGenerator> GetFactory()
            {
                return data => new TestReactiveMetroWindowClassGenerator();
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<ReactiveMetroWindowClassGenerator, ReactiveWindowClassFeatureFlags, ReactiveMetroWindowClassGeneratorProcessor, ReactiveWindowGenerationModel>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, ReactiveMetroWindowClassGenerator> GetFactory()
            {
                return data => new TestReactiveMetroWindowClassGenerator();
            }
        }
    }
}
