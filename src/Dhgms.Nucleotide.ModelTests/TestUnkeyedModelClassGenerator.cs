using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Common.Models;
using Dhgms.Nucleotide.Features.Model;

namespace Dhgms.Nucleotide.ModelTests
{
    public sealed class TestUnkeyedModelClassGenerator : UnkeyedModelClassGenerator
    {
        protected override INucleotideGenerationModel NucleotideGenerationModel => new ModelGenerationDetails();
    }
}
