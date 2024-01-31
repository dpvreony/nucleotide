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

#error need to inherit from EntityGenerationModel and remove the abstract design from it? this will allow the EF logic to work, and the model generators to work off the base class
#error we need an overload to not generate the default properties on the EF class? (created, modified, rowversion)
#error we need to allow overriding the base class on the generated EF class, so it doesn'ty have to point to a keyed model. Example of this is MsIdentity tables which are already designed for EF.
    }
}
