using Dhgms.Nucleotide.Generators.Features.Database;
using Dhgms.Nucleotide.Generators.Models;

namespace Dhgms.Nucleotide.ModelTests
{
    public sealed class TestReferencedByEntityGenerator : ReferencedByEntityGenerator
    {
        protected override INucleotideGenerationModel<IEntityGenerationModel> NucleotideGenerationModel => new ModelGenerationDetails();
    }
}
