// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections.Generic;
using Dhgms.Nucleotide.Generators.Features.Cqrs.RequestFactories;
using Dhgms.Nucleotide.Generators.Features.Cqrs.Requests;
using Dhgms.Nucleotide.Generators.Features.Cqrs.Responses;

namespace Dhgms.Nucleotide.Generators.Features.Cqrs
{
    public sealed class CqrsGenerationModel
    {
        public IReadOnlyCollection<RequestFactoryModel>? RequestFactoryClasses { get; init; }

        public IReadOnlyCollection<RequestFactoryModel>? RequestFactoryInterfaces { get; init; }

        public IReadOnlyCollection<RequestModel>? Requests { get; init; }

        public IReadOnlyCollection<ResponseModel>? Responses { get; init; }
    }
}
