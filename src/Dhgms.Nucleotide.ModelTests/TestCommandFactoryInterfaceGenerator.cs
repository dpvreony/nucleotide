﻿using Dhgms.Nucleotide.Generators.Features.Cqrs;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.ModelTests
{
    [Generator]
    public sealed class TestCommandFactoryInterfaceGenerator : CommandFactoryInterfaceGenerator
    {
        protected override INucleotideGenerationModel<IEntityGenerationModel> NucleotideGenerationModel => new ModelGenerationDetails();
    }
}
