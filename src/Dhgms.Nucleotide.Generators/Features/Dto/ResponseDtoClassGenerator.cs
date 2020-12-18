using Dhgms.Nucleotide.Generators;

namespace Dhgms.Nucleotide.Features.Dto
{
    public sealed class ResponseDtoClassGenerator : BaseClassLevelCodeGenerator<ResponseDtoClassFeatureFlags, ResponseDtoClassGeneratorProcessor>
    {
        protected override string GetNamespace()
        {
            return "ResponseDtos";
        }
    }
}
