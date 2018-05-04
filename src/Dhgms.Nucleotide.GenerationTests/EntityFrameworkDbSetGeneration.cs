using Dhgms.Nucleotide.Attributes;
using Dhgms.Nucleotide.ModelTests;

namespace Dhgms.Nucleotide.GenerationTests
{
    [GenerateEntityFrameworkDbContext(typeof(ModelGenerationDetails))]
    class EntityFrameworkDbSetGeneration
    {
    }
}
