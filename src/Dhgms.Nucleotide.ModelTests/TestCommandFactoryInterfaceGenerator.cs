using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Common.Models;
using Dhgms.Nucleotide.Features.Cqrs;

namespace Dhgms.Nucleotide.ModelTests
{
    public sealed class TestCommandFactoryInterfaceGenerator : CommandFactoryInterfaceGenerator
    {
        protected override INucleotideGenerationModel NucleotideGenerationModel => new ModelGenerationDetails();
    }
}
