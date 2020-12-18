using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Common.Models;
using Dhgms.Nucleotide.Generators;

namespace Dhgms.Nucleotide.ModelTests
{
    public sealed class TestServiceInterfaceGenerator : ServiceInterfaceGenerator
    {
        protected override INucleotideGenerationModel NucleotideGenerationModel => new ModelGenerationDetails();
    }
}
