using Dhgms.Nucleotide.Attributes;
using Dhgms.Nucleotide.ModelTests;

namespace Dhgms.Nucleotide.GenerationTests
{
    [GenerateEntityFrameworkDbSet(typeof(ModelGenerationDetails))]
    class EntityFrameworkDbSetGeneration
    {
    }
}
