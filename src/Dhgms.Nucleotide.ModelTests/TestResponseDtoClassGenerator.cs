using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Common.Models;
using Dhgms.Nucleotide.Features.Dto;

namespace Dhgms.Nucleotide.ModelTests
{
    public class TestResponseDtoClassGenerator : ResponseDtoClassGenerator
    {
        protected override INucleotideGenerationModel NucleotideGenerationModel => new ModelGenerationDetails();
    }
}
