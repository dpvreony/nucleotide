﻿// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace Dhgms.Nucleotide.Generators.Models
{
    /// <summary>
    /// Generation Model for Service Boundaries
    /// </summary>
    public interface IServiceGenerationModel
    {
        IEntityGenerationModel EntityGenerationModel { get; }

        /// <summary>
        /// Whether to generate only the list and get methods on a service.
        /// Useful for services that represent entities that can only be
        /// generated by an internal process.
        /// </summary>
        bool ReadOnly { get; }
    }
}
