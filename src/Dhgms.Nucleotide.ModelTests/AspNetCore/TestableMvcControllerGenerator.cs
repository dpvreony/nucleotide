using Dhgms.Nucleotide.Generators.Features.AspNetCore.MvcControllers;
using Dhgms.Nucleotide.Generators.Features.Core;
using Dhgms.Nucleotide.Generators.Features.Cqrs.RequestFactories;
using Dhgms.Nucleotide.Generators.Features.Cqrs.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dhgms.Nucleotide.SampleGenerator.AspNetCore
{
    public sealed class TestableMvcControllerGenerator : AbstractTestGenerator<MvcControllersMemberDeclarationSyntaxFactory, MvcControllerModel>
    {
        protected override IReadOnlyCollection<MvcControllerModel> GetGenerationModel()
        {
            const string containingNamespace = "Dhgms.Nucleotide.SampleGenerator.Cqrs.TestableRequestGenerator";
            const string responseNamespace = "Dhgms.Nucleotide.SampleGenerator.Cqrs.TestableRequestGenerator";

            var rawRequestDto = new NamedTypeArgumentModel(
                containingNamespace,
                "SomeSimpleRequestDto",
                false);

            var simpleResponseModel = new NamedTypeModel(responseNamespace, "SomeSimpleListResponse");
            var viewResponseModel = new NamedTypeModel(responseNamespace, "SomeSimpleViewResponse");

            var listRequestModel = RequestModel.WhipstaffMediatRQuery(
                containingNamespace,
                "ListSomeEntitiesRequest",
                true,
                Array.Empty<NamedTypeParameterModel>(),
                simpleResponseModel,
                ["Represents a Simple List query."]);

            var viewRequestModel = RequestModel.WhipstaffMediatRQuery(
                containingNamespace,
                "ViewSomeEntitiesRequest",
                true,
                Array.Empty<NamedTypeParameterModel>(),
                viewResponseModel,
                ["Represents a Simple View query."]);

            var queryFactoryModel = RequestFactoryModel.QueryFactory(
                containingNamespace,
                "SomeQueryFactory",
                true,
                listRequestModel,
                viewRequestModel,
                ["Simple Query Factory"]);


            return
            [
                MvcControllerModel.VanillaController(containingNamespace,
                    "VanillaController",
                    true,
                    ["Test Vanilla Controller"]),

                MvcControllerModel.WhipstaffQueryOnlyController(
                    containingNamespace,
                    "QueryOnlyController",
                    true,
                    "Animal",
                    queryFactoryModel,
                    listRequestModel,
                    viewRequestModel),
            ];
        }
    }
}
