using System;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Models;

namespace Dhgms.Nucleotide.Generators.Features.EntityFramework
{
    public sealed class EntityFrameworkDbContextGenerationModel : IClassName
    {
        public EntityGenerationModel[] DbSetEntities
        {
            get;
            set;
        }

        public string ClassName
        {
            get;
            set;
        }

        public string OverrideBaseDbContextType
        {
            get;
            set;
        }
    }
}
