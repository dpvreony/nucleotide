﻿// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using Dhgms.Nucleotide.Generators.Generators;
using Dhgms.Nucleotide.Generators.Models;

namespace Dhgms.Nucleotide.Generators.Features.Mvc
{
    /// <summary>
    /// Generates the MVC Controllers
    /// </summary>
    public abstract class MvcControllerGenerator : BaseClassLevelCodeGenerator<MvcControllerFeatureFlags, MvcControllerGeneratorProcessor, IEntityGenerationModel>
    {
        protected override string GetNamespace()
        {
            return "MvcControllers";
        }
    }
}
