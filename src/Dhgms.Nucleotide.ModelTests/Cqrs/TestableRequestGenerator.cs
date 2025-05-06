// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using Dhgms.Nucleotide.Generators.Features.Cqrs.Requests;

namespace Dhgms.Nucleotide.SampleGenerator.Cqrs
{
    public sealed class TestableRequestGenerator : AbstractRequestGenerator
    {
        protected override IEnumerable<RequestModel> GetRequestModels()
        {
            const string containingNamespace = "Dhgms.Nucleotide.SampleGenerator.Cqrs.TestableRequestGenerator";
            const string responseNamespace = "Dhgms.Nucleotide.SampleGenerator.Cqrs.TestableRequestGenerator";
            var simpleResponseModel = new NamedTypeParameterModel(responseNamespace, "SomeSimpleListResponse", false);
            var viewResponseModel = new NamedTypeParameterModel(responseNamespace, "SomeSimpleViewResponse", true);

            return new[]
            {
                RequestModel.MediatRRequest(
                    containingNamespace,
                    "SimpleMediatRRequest",
                    true,
                    Array.Empty<string>(),
                    simpleResponseModel),

                RequestModel.WhipstaffMediatRAuditableRequest(
                    containingNamespace,
                    "SimpleMediatRRequest",
                    true,
                    simpleResponseModel),

                RequestModel.WhipstaffMediatRCommand(
                    containingNamespace,
                    "SimpleMediatRRequest",
                    true,
                    Array.Empty<string>(),
                    simpleResponseModel),

                RequestModel.WhipstaffMediatRQuery(
                    containingNamespace,
                    "ListSomeEntitiesRequest",
                    true,
                    Array.Empty<string>(),
                    simpleResponseModel),

                RequestModel.WhipstaffMediatRQuery(
                    containingNamespace,
                    "ViewSomeEntitiesRequest",
                    true,
                    Array.Empty<string>(),
                    viewResponseModel),
            };
        }
    }
}
