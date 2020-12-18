using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Common.Models;
using Dhgms.Nucleotide.Features.WebApi;

namespace Dhgms.Nucleotide.ModelTests
{
    public sealed class TestWebApiServiceGenerator : WebApiServiceGenerator
    {
        protected override INucleotideGenerationModel NucleotideGenerationModel => new ModelGenerationDetails();
    }
}
