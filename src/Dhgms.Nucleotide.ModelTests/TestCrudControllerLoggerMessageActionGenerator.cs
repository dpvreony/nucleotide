using Dhgms.Nucleotide.Generators.Features.Logging;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.ModelTests;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.SampleGenerator
{
    [Generator]
    public sealed class TestCrudControllerLoggerMessageActionGenerator : CrudControllerLoggerMessageActionGenerator
    {
        protected override INucleotideGenerationModel<IEntityGenerationModel> NucleotideGenerationModel => new ModelGenerationDetails();
    }
}
