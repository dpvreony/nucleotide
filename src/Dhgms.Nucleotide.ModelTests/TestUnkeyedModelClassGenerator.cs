﻿using Dhgms.Nucleotide.Generators.Features.Model;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.ModelTests
{
    [Generator]
    public sealed class TestUnkeyedModelClassGenerator : UnkeyedModelClassGenerator
    {
        protected override INucleotideGenerationModel<IEntityGenerationModel> NucleotideGenerationModel => new ModelGenerationDetails();
    }
}
