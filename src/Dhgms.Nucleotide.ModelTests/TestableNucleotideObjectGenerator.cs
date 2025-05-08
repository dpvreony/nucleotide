using System;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Generators.Features.Core;
using Dhgms.Nucleotide.Generators.Features.AspNetCore.MvcControllers;
using Dhgms.Nucleotide.Generators.Features.Cqrs.RequestFactories;
using Dhgms.Nucleotide.Generators.Features.Cqrs.Requests;
using Dhgms.Nucleotide.Generators.Features.Cqrs.Responses;
using Dhgms.Nucleotide.Generators.Features.Logging;
using Dhgms.Nucleotide.SampleGenerator.DataTransferObjects;
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

            var listRawRequestDto = DataTransferObjectModel.PocoWithNoInheritance(
                containingNamespace,
                "ListFeatureRawQuery",
                true,
                [],
                ["List Request DTO"]);
            var listRawRequestDtoType = new NamedTypeArgumentModel(containingNamespace, listRawRequestDto.TypeName, false);
            model.DataTransferObjects.Add(listRawRequestDto);

            var listResponseModel = ResponseModel.ResponseWithNoInheritance(
                containingNamespace,
                "ListResponse",
                true,
                [],
                ["Some list response model."],
                false);
            model.Cqrs.Responses.Add(listResponseModel);

            var listRequestModel = RequestModel.WhipstaffMediatRAuditableRequest(
                containingNamespace,
                "ListFirstFeatureQuery",
                true,
                listRawRequestDtoType,
                listResponseModel,
                []);
            model.Cqrs.Requests.Add(listRequestModel);

            var viewRawRequestDto = new NamedTypeArgumentModel(string.Empty, "long", false);

            var viewResponseModel = ResponseModel.ResponseWithNoInheritance(
                containingNamespace,
                "ViewResponse",
                true,
                [],
                ["Some view response model."],
                true);
            model.Cqrs.Responses.Add(viewResponseModel);

            var viewRequestModel = RequestModel.WhipstaffMediatRAuditableRequest(
                containingNamespace,
                "ViewFirstFeatureQuery",
                true,
                viewRawRequestDto,
                viewResponseModel,
                []);
            model.Cqrs.Requests.Add(viewRequestModel);

            var queryFactoryModel = RequestFactoryModel.AuditableQueryFactoryWithStraightPassThrough(
                containingNamespace,
                "MyFirstQueryFactory",
                true,
                listRequestModel,
                listRawRequestDtoType,
                viewRequestModel,
                ["Query factory for my first feature"]);
            model.Cqrs.RequestFactoryClasses.Add(queryFactoryModel);

            var loggerMessageActionsModel = LogMessageActionModel.QueryOnlyControllerLogMessageActions(
                containingNamespace,
                "FirstFeatureLoggerMessageActions",
                containingNamespace,
                "FirstFeatureController");
            model.Logging.LogMessageActions.Add(loggerMessageActionsModel);

            var queryController = MvcControllerModel.WhipstaffQueryOnlyController(
                containingNamespace,
                "FirstFeatureController",
                true,
                false,
                "First Feature",
                queryFactoryModel,
                listRequestModel,
                listRawRequestDtoType,
                viewRequestModel,
                loggerMessageActionsModel);
            model.AspNetCore.MvcControllers.Add(queryController);
        }
    }
}
