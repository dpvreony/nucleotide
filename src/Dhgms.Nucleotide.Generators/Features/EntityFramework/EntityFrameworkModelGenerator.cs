using Dhgms.Nucleotide.Attributes;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Features.EntityFramework
{
    [Generator]
    public sealed class EntityFrameworkModelGenerator : BaseClassLevelCodeGenerator<EntityFrameworkModelFeatureFlags, EntityFrameworkModelGeneratorProcessor, GenerateEntityFrameworkModelClassAttribute>
    {
        protected override string GetNamespace()
        {
            return "EfModels";
        }
    }
}
