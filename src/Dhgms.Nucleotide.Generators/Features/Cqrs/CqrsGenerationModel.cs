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
        public IList<RequestFactoryModel> RequestFactoryClasses { get; init; } = new List<RequestFactoryModel>();

        public IList<RequestModel> Requests { get; init; } = new List<RequestModel>();

        public IList<ResponseModel> Responses { get; init; } = new List<ResponseModel>();
    }
}
