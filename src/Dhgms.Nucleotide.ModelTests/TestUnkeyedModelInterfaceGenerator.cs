using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Common.Models;
using Dhgms.Nucleotide.Features.Model;

namespace Dhgms.Nucleotide.ModelTests
{
    public sealed class TestUnkeyedModelInterfaceGenerator : UnkeyedModelInterfaceGenerator
    {
        protected override INucleotideGenerationModel NucleotideGenerationModel => new ModelGenerationDetails();
    }
}
