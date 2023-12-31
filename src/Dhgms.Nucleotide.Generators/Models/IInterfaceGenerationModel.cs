// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections.Generic;

namespace Dhgms.Nucleotide.Generators.Models
{
    /// <summary>
    /// Represents the model for an interface.
    /// </summary>
    /// <param name="ClassName">Name of the interface.</param>
    /// <param name="Properties">Properties directly defined on the interface.</param>
    /// <param name="Methods">Methods directly defined on the interface.</param>
    /// <param name="BaseInterfaces">Interfaces that this interface inherits from.</param>
    public record InterfaceGenerationModel(string ClassName, IList<PropertyGenerationModel> Properties, IList<IInterfaceMethodGenerationModel> Methods, IList<InterfaceGenerationModel> BaseInterfaces) : IObjectGenerationModel
    {
    }
}