using System;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.Generators.PropertyInfo;

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
    }
}
