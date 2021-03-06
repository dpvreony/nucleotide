﻿using Dhgms.Nucleotide.Generators.Features.Dto;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.ModelTests
{
    [Generator]
    public sealed class TestRequestDtoClassGenerator : RequestDtoClassGenerator
    {
        protected override INucleotideGenerationModel<IEntityGenerationModel> NucleotideGenerationModel => new ModelGenerationDetails();
    }
}
