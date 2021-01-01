namespace Dhgms.Nucleotide.Generators.Features.EntityFramework
{
    public sealed class EntityFrameworkEntityTypeConfigurationFeatureFlags
    {
        public bool GenerateNumericRangeValidations { get; set; }

        public bool GenerateSqlDescriptions { get; set; }

        public bool GenerateSqlCheckConstraints { get; set; }
    }
}
