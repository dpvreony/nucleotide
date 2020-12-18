using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Features.EntityFramework
{
    [Generator]
    public class EntityFrameworkEntityTypeConfigurationGenerator : BaseClassLevelCodeGenerator<EntityFrameworkEntityTypeConfigurationFeatureFlags, EntityFrameworkEntityTypeConfigurationGeneratorProcessor>
    {
        protected override string GetNamespace()
        {
            return "EntityTypeConfigurations";
        }
    }
}
