// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace Dhgms.Nucleotide.Generators.Features.EntityFramework
{
    /// <summary>
    /// Specifies the type of modifier applied to a class, indicating its inheritance behavior.
    /// </summary>
    /// <remarks>
    /// This enumeration is used to represent whether a class is declared with no modifier,  as
    /// abstract (requiring inheritance), or as sealed (preventing inheritance).
    /// </remarks>
    public enum AbstractOrSealed
    {
        /// <summary>
        /// No modifier is applied to the class.
        /// </summary>
        None,

        /// <summary>
        /// Abstract modifier is applied to the class, indicating that it cannot be instantiated directly and must be inherited.
        /// </summary>
        Abstract,

        /// <summary>
        /// Sealed modifier is applied to the class, indicating that it cannot be inherited from.
        /// </summary>
        Sealed
    }
}