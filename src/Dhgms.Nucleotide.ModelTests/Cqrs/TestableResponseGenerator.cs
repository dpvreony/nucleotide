using System;
using System.Collections.Generic;
using Dhgms.Nucleotide.Generators.Features.Core;
using Dhgms.Nucleotide.Generators.Features.Cqrs.Requests;
using Dhgms.Nucleotide.Generators.Features.Cqrs.Responses;

namespace Dhgms.Nucleotide.SampleGenerator.Cqrs
{
    public sealed class TestableResponseGenerator : AbstractTestGenerator<ResponseMemberDeclarationSyntaxFactory, ResponseModel>
    {
        protected override IReadOnlyCollection<ResponseModel> GetGenerationModel()
        {
            const string containingNamespace = "Dhgms.Nucleotide.SampleGenerator.Cqrs.TestableRequestGenerator";
            const string responseNamespace = "Dhgms.Nucleotide.SampleGenerator.Cqrs.TestableRequestGenerator";

            var rawRequestDto = new NamedTypeArgumentModel(
                containingNamespace,
                "SomeSimpleRequestDto",
                false);

            var simpleResponseModel = new NamedTypeModel(responseNamespace, "SomeSimpleListResponse");
            var viewResponseModel = new NamedTypeModel(responseNamespace, "SomeSimpleViewResponse");

            return new[]
            {
                ResponseModel.ResponseWithNoInheritance(
                    containingNamespace,
                    "SimpleResponse",
                    true,
                    Array.Empty<NamedTypeParameterModel>(),
                    [ "Represents a simple response."]),

                ResponseModel.ResponseWithNoInheritance(
                    containingNamespace,
                    "UnsealedSimpleResponse",
                    false,
                    Array.Empty<NamedTypeParameterModel>(),
                    [ "Represents an unsealed response."]),
            };
        }
    }
}
