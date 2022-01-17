using Dhgms.Nucleotide.Generators.Features.ReactiveUI.Wpf;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.SampleGenerator
{
    [Generator]
    public sealed class TestReactiveMetroWindowClassGenerator : ReactiveMetroWindowClassGenerator
    {
        protected override INucleotideGenerationModel<ReactiveWindowGenerationModel> NucleotideGenerationModel =>
            null;
    }
}
