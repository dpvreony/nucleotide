using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Generators.Features.Core;
using Dhgms.Nucleotide.Generators.Features.AspNetCore.MvcControllers;
using Dhgms.Nucleotide.Generators.Features.Cqrs.RequestFactories;
using Dhgms.Nucleotide.Generators.Features.Cqrs.Requests;
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

            var listRawRequestDto = new NamedTypeArgumentModel(containingNamespace, "ListFeatureRequest", false);

            var listResponseModel = new NamedTypeModel(containingNamespace, "ListFeatureResponse");

            var listRequestModel = RequestModel.WhipstaffMediatRAuditableRequest(
                containingNamespace,
                "ListFirstFeature",
                true,
                listRawRequestDto,
                listResponseModel,
                []);

            var viewRawRequestDto = new NamedTypeArgumentModel(containingNamespace, "ListFeatureRequest", false);

            var viewResponseModel = new NamedTypeModel(containingNamespace, "ViewFeatureResponse");

            var viewRequestModel = RequestModel.WhipstaffMediatRAuditableRequest(
                containingNamespace,
                "ListFirstFeature",
                true,
                viewRawRequestDto,
                viewResponseModel,
                []);

            var queryFactoryModel = RequestFactoryModel.QueryFactory(
                containingNamespace,
                "MyFirstQueryFactory",
                true,
                listRequestModel,
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
