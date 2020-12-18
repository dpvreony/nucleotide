using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Features.EntityFramework
{
    /// <summary>
    /// Code Generator for Entity Framework DB Context
    /// </summary>
    [Generator]
    public sealed class EntityFrameworkDbContextGenerator : BaseGenerator<EntityFrameworkDbContextFeatureFlags, EntityFrameworkDbContextGeneratorProcessor>
    {
        protected override string GetNamespace()
        {
            return "EfModels";
        }
    }
}
