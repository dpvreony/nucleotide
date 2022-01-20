using System;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.PropertyInfo;

namespace Dhgms.Nucleotide.Generators.Features.EntityFramework
{
    public sealed class EntityFrameworkDbContextGenerationModel : IClassName
    {
        public PropertyInfoBase[] Properties
        {
            get;
            set;
        }

        public string ClassName => throw new NotImplementedException();
    }
}
