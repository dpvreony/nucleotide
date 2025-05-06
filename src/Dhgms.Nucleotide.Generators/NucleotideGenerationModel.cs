using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Generators.Features.Cqrs;

namespace Dhgms.Nucleotide.Generators
{
    public sealed class NucleotideGenerationModel
    {
        public CqrsGenerationModel CqrsGenerationModel { get; set; } = new CqrsGenerationModel();
    }
}
