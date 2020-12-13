using Dhgms.Nucleotide.Features.Model;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Features.Dto
{
    public sealed class RequestDtoClassGenerator : BaseClassLevelCodeGenerator<RequestDtoClassFeatureFlags, RequestDtoClassGeneratorProcessor>
    {
        protected override string GetNamespace() => "RequestDtos";
    }
}
