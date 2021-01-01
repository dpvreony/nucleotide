using Dhgms.Nucleotide.Generators.Generators;

namespace Dhgms.Nucleotide.Generators.Features.Dto
{
    public abstract class ResponseDtoClassGenerator : BaseClassLevelCodeGenerator<ResponseDtoClassFeatureFlags, ResponseDtoClassGeneratorProcessor>
    {
        protected override string GetNamespace()
        {
            return "ResponseDtos";
        }
    }
}
