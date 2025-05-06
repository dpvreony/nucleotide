// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections.Generic;
using Dhgms.Nucleotide.Generators.Features.Cqrs.Requests;

namespace Dhgms.Nucleotide.SampleGenerator.Cqrs
{
    public sealed class TestableRequestGenerator : AbstractRequestGenerator
    {
        private readonly IEnumerable<RequestModel> _requestModels;

        public TestableRequestGenerator(IEnumerable<RequestModel> requestModels)
        {
            _requestModels = requestModels;
        }


        protected override IEnumerable<RequestModel> GetRequestModels() => _requestModels;
    }
}
