using Dhgms.Nucleotide.Generators.Features.EntityFramework;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.ModelTests
{
    [Generator]
    public sealed class TestEntityFrameworkEntityTypeConfigurationGenerator : EntityFrameworkEntityTypeConfigurationGenerator
    {
        protected override INucleotideGenerationModel<EntityFrameworkModelEntityGenerationModel> NucleotideGenerationModel => new EfModelGenerationDetails();
    }
}
