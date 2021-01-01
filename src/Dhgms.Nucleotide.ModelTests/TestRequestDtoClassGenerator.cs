using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Generators.Features.Dto;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.ModelTests
{
    [Generator]
    public sealed class TestRequestDtoClassGenerator : RequestDtoClassGenerator
    {
        protected override INucleotideGenerationModel NucleotideGenerationModel => new ModelGenerationDetails();
    }
}
