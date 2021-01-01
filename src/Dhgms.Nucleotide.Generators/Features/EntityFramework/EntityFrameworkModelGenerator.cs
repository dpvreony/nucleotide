using Dhgms.Nucleotide.Generators.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Generators.Features.EntityFramework
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
