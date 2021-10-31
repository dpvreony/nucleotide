using Dhgms.Nucleotide.Generators.Generators;
using Dhgms.Nucleotide.Generators.Models;

namespace Dhgms.Nucleotide.Generators.Features.Dto
{
    public abstract class ResponseDtoClassGenerator : BaseClassLevelCodeGenerator<ResponseDtoClassFeatureFlags, ResponseDtoClassGeneratorProcessor, IEntityGenerationModel>
    {
        protected override string GetNamespace()
        {
            return "ResponseDtos";
        }
    }
}
