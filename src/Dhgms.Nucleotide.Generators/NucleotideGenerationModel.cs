using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Generators.Features.Cqrs;

namespace Dhgms.Nucleotide.Generators
{
    public sealed class NucleotideGenerationModel
    {
        public AspNetCoreGenerationModel AspNetCore { get; set; } = new ();

        public CqrsGenerationModel Cqrs { get; set; } = new ();

#if TBC
        public EntityFrameworkCoreGenerationModel EntityFrameworkCore { get; set; } = new();

        public ReactiveUIGenerationModel ReactiveUI { get; set; } = new ();

        public WpfGenerationModel Wpf { get; set; } = new ();
#endif
    }
}
