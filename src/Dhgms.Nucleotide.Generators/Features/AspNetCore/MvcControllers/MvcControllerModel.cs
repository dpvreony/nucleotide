using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using Dhgms.Nucleotide.Generators.Features.Cqrs.RequestFactories;
using Dhgms.Nucleotide.Generators.Features.Cqrs.Requests;
using Dhgms.Nucleotide.Generators.Features.Cqrs.Responses;
using Microsoft.CodeAnalysis.CSharp;

namespace Dhgms.Nucleotide.Generators.Features.AspNetCore.MvcControllers
{
    public sealed record MvcControllerModel(
        string ContainingNamespace,
        string Name,
        bool IsSealed,
        Func<BaseTypeSyntax> BaseTypeSyntaxFunc,
        string[] XmlDocSummary)
    {
        public static MvcControllerModel VanillaController(
            string containingNamespace,
            string name,
            bool isSealed,
            string[] summary)
        {
            var baseTypeSyntaxFunc = () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"global::Microsoft.AspNetCore.Mvc.Controller"));

            return new MvcControllerModel(
                containingNamespace,
                name,
                isSealed,
                baseTypeSyntaxFunc,
                summary);
        }

#if TBC
        public static MvcControllerModel WhipstaffFullCrudController(
            string containingNamespace,
            string name,
            bool isSealed,
            string entityDescription)
        {
            return new MvcControllerModel(
                containingNamespace,
                name,
                isSealed,
                baseTypeSyntaxFunc,
                [ $"MVC controller for querying {entityDescription}."]);
        }
#endif

        public static MvcControllerModel WhipstaffQueryOnlyController(
            string containingNamespace,
            string name,
            bool isSealed,
            string entityDescription,
            RequestFactoryModel queryFactoryModel,
            RequestModel listRequestModel,
            RequestModel viewRequestModel)
        {
            var listQueryClassName = listRequestModel.GetFullyQualifiedTypeName();
            var listRequestDtoClassName = "";
            var listResponseDtoClassName = listRequestModel.ResponseModel.GetFullyQualifiedTypeName();

            var viewQueryClassName = viewRequestModel.GetFullyQualifiedTypeName();
            var viewResponseDtoClassName = viewRequestModel.ResponseModel.GetFullyQualifiedTypeName();

            var logMessageActionsWrapperClassName = "";

            var baseTypeSyntaxFunc = () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"global::Whipstaff.AspNetCore.QueryOnlyMvcController<{listQueryClassName}, {listRequestDtoClassName}, {listResponseDtoClassName}, {viewQueryClassName}, {viewResponseDtoClassName}, {logMessageActionsWrapperClassName}>"));

            return new MvcControllerModel(
                containingNamespace,
                name,
                isSealed,
                baseTypeSyntaxFunc,
                [$"MVC controller for querying {entityDescription}."]);
        }
    }
}
