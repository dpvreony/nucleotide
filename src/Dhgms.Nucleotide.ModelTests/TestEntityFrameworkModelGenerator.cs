using Dhgms.Nucleotide.Generators.Features.EntityFramework;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.ModelTests
{
    [Generator]
    public sealed class TestEntityFrameworkModelGenerator : EntityFrameworkModelGenerator
    {
        protected override INucleotideGenerationModel<EntityFrameworkModelEntityGenerationModel> NucleotideGenerationModel => new NucleotideGenerationModel<EntityFrameworkModelEntityGenerationModel>(
            "Dhgms.Nucleotide.GenerationTests",
            SampleEntityFrameworkModelGenerationModel.EntityFrameworkModelEntityGenerationModels);
    }
}
