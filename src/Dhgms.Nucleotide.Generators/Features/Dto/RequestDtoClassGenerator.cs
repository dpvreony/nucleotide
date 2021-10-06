using Dhgms.Nucleotide.Generators.Generators;
using Dhgms.Nucleotide.Generators.Models;

namespace Dhgms.Nucleotide.Generators.Features.Dto
{
    public abstract class RequestDtoClassGenerator : BaseClassLevelCodeGenerator<RequestDtoClassFeatureFlags, RequestDtoClassGeneratorProcessor, IEntityGenerationModel>
    {
        protected override string GetNamespace() => "RequestDtos";
    }
}
