﻿using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Common.Models;
using Dhgms.Nucleotide.Features.Cqrs;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.ModelTests
{
    [Generator]
    public sealed class TestQueryInterfaceGenerator : QueryInterfaceGenerator
    {
        protected override INucleotideGenerationModel NucleotideGenerationModel => new ModelGenerationDetails();
    }
}
