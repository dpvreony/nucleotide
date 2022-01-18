// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections.Generic;
using Dhgms.Nucleotide.Generators.Features.Database;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.PropertyInfo;

namespace Dhgms.Nucleotide.Generators.Features.EntityFramework
{
    public sealed class EntityFrameworkModelEntityGenerationModel : IClassName
    {
        public string ClassName { get; set; }

        public string ClassPluralName { get; set; }

        public IList<PropertyInfoBase> Properties { get; set; }

        public IList<ReferencedByEntityGenerationModel> ParentEntityRelationships { get; set; }

        public IList<ReferencedByEntityGenerationModel> ChildEntityRelationships { get; set; }
    }
}
