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
        protected override IList<MvcControllerModel> GetGenerationModel()
        {
            const string containingNamespace = "Dhgms.Nucleotide.SampleGenerator.Cqrs.TestableRequestGenerator";
            const string responseNamespace = "Dhgms.Nucleotide.SampleGenerator.Cqrs.TestableRequestGenerator";

            var rawRequestDto = new NamedTypeArgumentModel(
                containingNamespace,
                "SomeSimpleRequestDto",
                false);

            var simpleResponseModel = new NamedTypeArgumentModel(responseNamespace, "SomeSimpleListResponse", false);
            var viewResponseModel = new NamedTypeArgumentModel(responseNamespace, "SomeSimpleViewResponse", true);

            var listRequestModel = RequestModel.WhipstaffMediatorQuery(
                containingNamespace,
                "ListSomeEntitiesRequest",
                true,
                Array.Empty<NamedTypeParameterModel>(),
                simpleResponseModel,
                ["Represents a Simple List query."]);

            var viewRequestModel = RequestModel.WhipstaffMediatorQuery(
                containingNamespace,
                "ViewSomeEntitiesRequest",
                true,
                Array.Empty<NamedTypeParameterModel>(),
                viewResponseModel,
                ["Represents a Simple View query."]);

            var queryFactoryModel = RequestFactoryModel.AuditableQueryFactoryWithStraightPassThrough(
                containingNamespace,
                "SomeQueryFactory",
                true,
                listRequestModel,
                rawRequestDto,
                viewRequestModel,
                ["Simple Query Factory"]);


            return
            [
                MvcControllerModel.VanillaController(containingNamespace,
                    "VanillaController",
                    true,
                    false,
                    ["Test Vanilla Controller"]),

                MvcControllerModel.WhipstaffQueryOnlyController(
                    containingNamespace,
                    "QueryOnlyController",
                    true,
                    false,
                    "Animal",
                    queryFactoryModel,
                    listRequestModel,
                    rawRequestDto,
                    viewRequestModel,
                    new NamedTypeModel("SomeLoggingNamespace", "LoggerActions")),
            ];
        }
    }
}
