﻿// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace Dhgms.Nucleotide.Generators.Models
{
    public interface IPropertyGenerationModel : INameable
    {
        string Type { get; }

        PropertyAccessorFlags PropertyAccessorFlags { get; }
    }
}
