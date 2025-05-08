// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using Dhgms.Nucleotide.Generators.Features.Core;
using Dhgms.Nucleotide.Generators.Features.Cqrs.Requests;
using Dhgms.Nucleotide.Generators.Features.Cqrs.Responses;

namespace Dhgms.Nucleotide.SampleGenerator.Cqrs
{
    public sealed class TestableRequestGenerator : AbstractTestGenerator<RequestMemberDeclarationSyntaxFactory, RequestModel>
    {
        protected override IList<RequestModel> GetGenerationModel()
        {
            const string containingNamespace = "Dhgms.Nucleotide.SampleGenerator.Cqrs.TestableRequestGenerator";
            const string responseNamespace = "Dhgms.Nucleotide.SampleGenerator.Cqrs.TestableRequestGenerator";

            var rawRequestDto = new NamedTypeArgumentModel(
                containingNamespace,
                "SomeSimpleRequestDto",
                false);

            var simpleResponseModel = new NamedTypeArgumentModel(responseNamespace, "SomeSimpleListResponse", false);
            var viewResponseModel = new NamedTypeArgumentModel(responseNamespace, "SomeSimpleViewResponse", true);

            return new[]
            {
                RequestModel.MediatRRequest(
                    containingNamespace,
                    "SimpleMediatRRequest",
                    true,
                    Array.Empty<NamedTypeParameterModel>(),
                    simpleResponseModel,
                    [ "Represents a simple MediatR request."]),

                RequestModel.WhipstaffMediatRAuditableRequest(
                    containingNamespace,
                    "SimpleMediatRRequest",
                    true,
                    rawRequestDto,
                    simpleResponseModel,
                    [ "Represents an auditable request."]),

                RequestModel.WhipstaffMediatRCommand(
                    containingNamespace,
                    "SimpleMediatRRequest",
                    true,
                    Array.Empty<NamedTypeParameterModel>(),
                    simpleResponseModel,
                    [ "Represents a Simple Command request."]),

                RequestModel.WhipstaffMediatRQuery(
                    containingNamespace,
                    "ListSomeEntitiesRequest",
                    true,
                    Array.Empty<NamedTypeParameterModel>(),
                    simpleResponseModel,
                    [ "Represents a Simple List query."]),

                RequestModel.WhipstaffMediatRQuery(
                    containingNamespace,
                    "ViewSomeEntitiesRequest",
                    true,
                    Array.Empty<NamedTypeParameterModel>(),
                    viewResponseModel,
                    [ "Represents a Simple View query."]),
            };
        }
    }
}
