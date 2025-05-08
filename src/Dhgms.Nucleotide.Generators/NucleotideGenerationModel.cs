using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Generators.Features.AspNetCore;
using Dhgms.Nucleotide.Generators.Features.Cqrs;
using Dhgms.Nucleotide.Generators.Features.Logging;
using Dhgms.Nucleotide.SampleGenerator.DataTransferObjects;

namespace Dhgms.Nucleotide.Generators
{
    public sealed class NucleotideGenerationModel
    {
        public AspNetCoreGenerationModel AspNetCore { get; init; } = new ();

        public CqrsGenerationModel Cqrs { get; init; } = new ();

        public IList<DataTransferObjectModel> DataTransferObjects { get; init; } = new List<DataTransferObjectModel>();

        public LoggingGenerationModel Logging { get; init; } = new();

#if TBC
        public EntityFrameworkCoreGenerationModel EntityFrameworkCore { get; set; } = new();

        public ReactiveUIGenerationModel ReactiveUI { get; set; } = new ();

        public WpfGenerationModel Wpf { get; set; } = new ();
#endif
    }
}
