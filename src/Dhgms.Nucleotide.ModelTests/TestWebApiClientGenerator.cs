using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Generators.Features.WebApi;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.ModelTests
{
    [Generator]
    public sealed class TestWebApiClientGenerator : WebApiClientGenerator
    {
        protected override INucleotideGenerationModel NucleotideGenerationModel => new ModelGenerationDetails();
    }
}
