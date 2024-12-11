// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections.Generic;
using Dhgms.Nucleotide.Generators.Features.Database;
using Dhgms.Nucleotide.Generators.Models;

namespace Dhgms.Nucleotide.Generators.Features.EntityFramework
{
    public sealed class EntityFrameworkModelEntityGenerationModel : EntityGenerationModel
    {
        public string ClassPluralName { get; init; }

        public IList<ReferencedByEntityGenerationModel> ParentEntityRelationships { get; init; }

        public IList<ReferencedByEntityGenerationModel> ChildEntityRelationships { get; init; }

        public GenerateCreatedAndModifiedColumns GenerateCreatedAndModifiedColumns { get; init; } = GenerateCreatedAndModifiedColumns.CreatedAndModified;

        public bool GenerateRowVersionColumn { get; init; } = true;

        public IList<AdditionalKeyModel> AdditionalKeys { get; init; }

        public IList<AdditionalIndexModel> AdditionalIndexes { get; init; }
    }
}
