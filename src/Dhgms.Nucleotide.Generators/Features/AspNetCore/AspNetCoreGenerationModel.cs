using System.Collections.Generic;
using Dhgms.Nucleotide.Generators.Features.AspNetCore.MvcControllers;

namespace Dhgms.Nucleotide.Generators.Features.AspNetCore
{
    public sealed class AspNetCoreGenerationModel
    {
        public IReadOnlyCollection<MvcControllerModel>? MvcControllers { get; set; }
    }
}
