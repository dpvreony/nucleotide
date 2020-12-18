using Dhgms.Nucleotide.Generators;

namespace Dhgms.Nucleotide.Features.Dto
{
    public abstract class ResponseDtoClassGenerator : BaseClassLevelCodeGenerator<ResponseDtoClassFeatureFlags, ResponseDtoClassGeneratorProcessor>
    {
        protected override string GetNamespace()
        {
            return "ResponseDtos";
        }
    }
}
