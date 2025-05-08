using System.Collections.Generic;
using Dhgms.Nucleotide.Generators.Features.AspNetCore.MvcControllers;
using Dhgms.Nucleotide.Generators.Features.AspNetCore.WebApiControllers;

namespace Dhgms.Nucleotide.Generators.Features.AspNetCore
{
    public sealed class AspNetCoreGenerationModel
    {
        public IList<MvcControllerModel> MvcControllers { get; init; } = new List<MvcControllerModel>();

        public IList<WebApiControllerModel> WebApiControllers { get; init; } = new List<WebApiControllerModel>();
    }
}
