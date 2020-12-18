using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Features.EntityFramework
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
