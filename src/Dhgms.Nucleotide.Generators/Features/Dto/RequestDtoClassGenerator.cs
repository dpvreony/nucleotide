using Dhgms.Nucleotide.Generators;

namespace Dhgms.Nucleotide.Features.Dto
{
    public sealed class RequestDtoClassGenerator : BaseClassLevelCodeGenerator<RequestDtoClassFeatureFlags, RequestDtoClassGeneratorProcessor>
    {
        protected override string GetNamespace() => "RequestDtos";
    }
}
