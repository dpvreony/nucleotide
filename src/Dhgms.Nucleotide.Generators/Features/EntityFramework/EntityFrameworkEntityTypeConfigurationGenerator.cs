using Dhgms.Nucleotide.Generators.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Generators.Features.EntityFramework
{
    [Generator]
    public abstract class EntityFrameworkEntityTypeConfigurationGenerator : BaseClassLevelCodeGenerator<EntityFrameworkEntityTypeConfigurationFeatureFlags, EntityFrameworkEntityTypeConfigurationGeneratorProcessor>
    {
        protected override string GetNamespace()
        {
            return "EntityTypeConfigurations";
        }
    }
}
