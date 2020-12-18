using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Common.Models;
using Dhgms.Nucleotide.Features.Cqrs;

namespace Dhgms.Nucleotide.ModelTests
{
    public sealed class TestCommandInterfaceGenerator : CommandInterfaceGenerator
    {
        protected override INucleotideGenerationModel NucleotideGenerationModel => new ModelGenerationDetails();
    }
}
