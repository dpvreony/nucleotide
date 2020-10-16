using Dhgms.Nucleotide.Features.Model;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Features.Dto
{
    public sealed class ResponseDtoClassGenerator : BaseClassLevelCodeGenerator<ResponseDtoClassFeatureFlags, ResponseDtoClassGeneratorProcessor>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnkeyedModelClassGenerator"/> class.
        /// </summary>
        public ResponseDtoClassGenerator(AttributeData attributeData) : base(attributeData)
        {
        }

        protected override string GetNamespace()
        {
            return "ResponseDtos";
        }
    }
}
