﻿using Dhgms.Nucleotide.Generators.Features.ReactiveUI;
using Dhgms.Nucleotide.Generators.Features.ReactiveUI.Wpf;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.ModelTests;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.SampleGenerator
{
    [Generator]
    public sealed class TestReactiveWindowClassGenerator : ReactiveWindowClassGenerator
    {
        protected override INucleotideGenerationModel<ReactiveWindowGenerationModel> NucleotideGenerationModel =>
            new ReactiveUIViewForViewModel();
    }
}
