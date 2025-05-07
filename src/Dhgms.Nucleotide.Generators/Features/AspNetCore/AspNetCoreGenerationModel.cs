using System;
using System.Collections.Generic;
using System.Text;

namespace Dhgms.Nucleotide.Generators.Features.AspNetCore
{
    public sealed class AspNetCoreGenerationModel
    {
        public IReadOnlyCollection<MvcControllerGenerationModel>? MvcControllers { get; set; }
    }
}
