using Dhgms.Nucleotide.Generators.Generators;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Generators.Features.EntityFramework
{
    /// <summary>
    /// Code Generator for Entity Framework DB Context
    /// </summary>
    public abstract class EntityFrameworkDbContextGenerator : BaseGenerator<EntityFrameworkDbContextFeatureFlags, EntityFrameworkDbContextGeneratorProcessor, IEntityGenerationModel>
    {
        protected override string GetNamespace()
        {
            return "EfModels";
        }
    }
}
