using Dhgms.Nucleotide.Attributes;
using Dhgms.Nucleotide.Features.Model;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Features.Dto
{
    public sealed class ResponseDtoClassGenerator : BaseClassLevelCodeGenerator<ResponseDtoClassFeatureFlags, ResponseDtoClassGeneratorProcessor, GenerateResponseDtoAttribute>
    {
        protected override string GetNamespace()
        {
            return "ResponseDtos";
        }
    }
}
