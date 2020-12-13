using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Features.EntityFramework
{
    public sealed class EntityFrameworkModelGenerator : BaseClassLevelCodeGenerator<EntityFrameworkModelFeatureFlags, EntityFrameworkModelGeneratorProcessor>
    {
        protected override string GetNamespace()
        {
            return "EfModels";
        }
    }
}
