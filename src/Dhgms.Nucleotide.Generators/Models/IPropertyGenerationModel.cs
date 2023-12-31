// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace Dhgms.Nucleotide.Generators.Models
{
    /// <summary>
    /// Represents a property on an object.
    /// </summary>
    /// <param name="TypeName">The fully qualified name of the type.</param>
    /// <param name="PropertyAccessorFlags">Accessor flags for the property.</param>
    public record PropertyGenerationModel(
        string TypeName,
        string Name,
        PropertyAccessorFlags PropertyAccessorFlags)
        : INameable;
}
