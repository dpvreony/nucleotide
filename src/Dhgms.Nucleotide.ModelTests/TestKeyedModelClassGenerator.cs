using Dhgms.Nucleotide.Common.Models;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.ModelTests
{
    [Generator]
    public class TestKeyedModelClassGenerator : Dhgms.Nucleotide.Features.Model.KeyedModelClassGenerator
    {
        protected override INucleotideGenerationModel NucleotideGenerationModel => new ModelGenerationDetails();
    }
}
