// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections.Generic;

namespace Dhgms.Nucleotide.Generators.Models
{
    public interface IInterfaceMethodGenerationModel : INameable
    {
        string ReturnType { get; }

        IList<IMethodArgumentModel> Arguments { get; }
    }
}
