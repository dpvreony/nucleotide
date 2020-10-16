using Dhgms.Nucleotide.Features.Model;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Features.Dto
{
    public sealed class RequestDtoClassGenerator : BaseClassLevelCodeGenerator<RequestDtoClassFeatureFlags, RequestDtoClassGeneratorProcessor>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnkeyedModelClassGenerator"/> class.
        /// </summary>
        public RequestDtoClassGenerator(AttributeData attributeData) : base(attributeData)
        {
        }

        protected override string GetNamespace() => "RequestDtos";
    }
}
