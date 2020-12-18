using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Features.EntityFramework
{
    [Generator]
    public abstract class EntityFrameworkModelGenerator : BaseClassLevelCodeGenerator<EntityFrameworkModelFeatureFlags, EntityFrameworkModelGeneratorProcessor>
    {
        protected override string GetNamespace()
        {
            return "EfModels";
        }
    }
}
