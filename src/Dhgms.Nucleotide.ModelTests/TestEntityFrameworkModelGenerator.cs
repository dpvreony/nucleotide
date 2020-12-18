using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Common.Models;
using Dhgms.Nucleotide.Features.EntityFramework;

namespace Dhgms.Nucleotide.ModelTests
{
    public sealed class TestEntityFrameworkModelGenerator : EntityFrameworkModelGenerator
    {
        protected override INucleotideGenerationModel NucleotideGenerationModel => new ModelGenerationDetails();
    }
}
