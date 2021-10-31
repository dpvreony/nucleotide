﻿using Dhgms.Nucleotide.Generators.Features.Database;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.ModelTests
{
    [Generator]
    public sealed class TestReferencedByEntityGenerator : ReferencedByEntityGenerator
    {
        protected override INucleotideGenerationModel<ReferencedByEntityGenerationModel> NucleotideGenerationModel =>
            new ReferencedByEntityGenerationModelGenerationDetails();
    }
}
