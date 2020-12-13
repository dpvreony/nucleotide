using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Features.EntityFramework
{
    public class EntityFrameworkEntityTypeConfigurationGenerator : BaseClassLevelCodeGenerator<EntityFrameworkEntityTypeConfigurationFeatureFlags, EntityFrameworkEntityTypeConfigurationGeneratorProcessor>
    {
        protected override string GetNamespace()
        {
            return "EntityTypeConfigurations";
        }
    }
}
