using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Generators.Features.EntityFramework;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.ModelTests
{
    [Generator]
    public sealed class TestEntityFrameworkDbContextGenerator :  EntityFrameworkDbContextGenerator
    {
        protected override INucleotideGenerationModel NucleotideGenerationModel => new ModelGenerationDetails();
    }
}
