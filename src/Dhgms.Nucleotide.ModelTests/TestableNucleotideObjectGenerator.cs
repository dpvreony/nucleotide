using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Generators.Features.Core;
using Dhgms.Nucleotide.Generators.Features.AspNetCore.MvcControllers;
using Dhgms.Nucleotide.Generators.Features.Cqrs.RequestFactories;
using Dhgms.Nucleotide.Generators.Features.Cqrs.Requests;
using Dhgms.Nucleotide.Generators.Features.Cqrs.Responses;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.SampleGenerator
{
    [Generator]
    public sealed class TestableNucleotideObjectGenerator : AbstractNucleotideObjectGenerator
    {
        protected override NucleotideGenerationModel GetGenerationModel()
        {
            var model = new NucleotideGenerationModel();

            PopulateFirstFeature(model);

            return model;
        }

        private void PopulateFirstFeature(NucleotideGenerationModel model)
        {
            var containingNamespace = "SampleApp.Features.FirstFeature";

            var listRawRequestDto = RawDataTransferObject.Create(containingNamespace, "ListFeatureRawQuery", false);

            var listResponseModel = ResponseModel.ResponseWithNoInheritance(
                containingNamespace,
                "ListResponse",
                true,
                [],
                ["Some list response model."]);
            model.Cqrs.Responses.Add(listResponseModel);

            var listRequestModel = RequestModel.WhipstaffMediatRAuditableRequest(
                containingNamespace,
                "ListFirstFeatureQuery",
                true,
                listRawRequestDto,
                listResponseModel,
                []);
            model.Cqrs.Requests.Add(listRequestModel);

            var viewRawRequestDto = RawDataTransferObject.Create(containingNamespace, "ViewFeatureRawQuery", false);

            var viewResponseModel = ResponseModel.ResponseWithNoInheritance(
                containingNamespace,
                "ViewResponse",
                true,
                [],
                ["Some view response model."]);
            model.Cqrs.Responses.Add(viewResponseModel);

            var viewRequestModel = RequestModel.WhipstaffMediatRAuditableRequest(
                containingNamespace,
                "ViewFirstFeatureQuery",
                true,
                viewRawRequestDto,
                viewResponseModel,
                []);
            model.Cqrs.Requests.Add(viewRequestModel);

            var queryFactoryModel = RequestFactoryModel.QueryFactory(
                containingNamespace,
                "MyFirstQueryFactory",
                true,
                listRequestModel,
                listRawRequestDto,
                viewRequestModel,
                ["Query factory for my first feature"]);
            model.Cqrs.RequestFactoryClasses.Add(queryFactoryModel);

            var loggerMessageActionsModel = new NamedTypeModel(containingNamespace, "FirstFeatureLoggerMessageActions");

            var queryController = MvcControllerModel.WhipstaffQueryOnlyController(
                containingNamespace,
                "FirstFeatureController",
                true,
                false,
                "First Feature",
                queryFactoryModel,
                listRequestModel,
                viewRequestModel,
                loggerMessageActionsModel);
            model.AspNetCore.MvcControllers.Add(queryController);
        }
    }
}
