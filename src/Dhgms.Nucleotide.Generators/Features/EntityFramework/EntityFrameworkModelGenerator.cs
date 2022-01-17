// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using Dhgms.Nucleotide.Generators.Generators;

namespace Dhgms.Nucleotide.Generators.Features.EntityFramework
{
    public abstract class EntityFrameworkModelGenerator : BaseClassLevelCodeGenerator<EntityFrameworkModelFeatureFlags, EntityFrameworkModelGeneratorProcessor, EntityFrameworkModelEntityGenerationModel>
    {
        ///<inheritdoc />
        protected override string GetNamespace()
        {
            return "EfModels";
        }
    }
}
