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
        public string ClassPluralName { get; }

        public IList<ReferencedByEntityGenerationModel> ParentEntityRelationships { get; }

        public IList<ReferencedByEntityGenerationModel> ChildEntityRelationships { get; }

        public bool GenerateCreatedColumn { get; }

#error need to merge Created and Modified into a single property as they dictate the interface to inherit.
        public bool GenerateModifiedColumn { get; }

        public bool GenerateRowVersionColumn { get; }

#error change EntityGenerationModel to use a record to make it easier to use?
    }
}
