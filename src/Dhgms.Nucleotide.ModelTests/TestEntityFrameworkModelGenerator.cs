// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using Dhgms.Nucleotide.Generators.Features.EntityFramework;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.ModelTests
{
    [Generator]
    public sealed class TestEntityFrameworkModelGenerator : EntityFrameworkModelGenerator
    {
        protected override INucleotideGenerationModel<EntityFrameworkModelEntityGenerationModel> NucleotideGenerationModel => new NucleotideGenerationModel<EntityFrameworkModelEntityGenerationModel>(
            "Dhgms.Nucleotide.GenerationTests",
            SampleEntityFrameworkModelGenerationModel.EntityFrameworkModelEntityGenerationModels);
    }
}
