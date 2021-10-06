using Dhgms.Nucleotide.Generators.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Generators.Features.EntityFramework
{
    public abstract class EntityFrameworkModelGenerator : BaseClassLevelCodeGenerator<EntityFrameworkModelFeatureFlags, EntityFrameworkModelGeneratorProcessor>
    {
        ///<inheritdoc />
        protected override string GetNamespace()
        {
            return "EfModels";
        }
    }
}
