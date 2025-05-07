using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
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

        public static MvcControllerModel WhipstaffFullCrudController(
            string containingNamespace,
            string name,
            bool isSealed,
            string entityDescription)
        {
            var listQueryClassName = "";
            var listRequestDtoClassName = "";
            var listResponseDtoClassName = "";

            var viewQueryClassName = "";
            var viewResponseDtoClassName = "";

            var logMessageActionsWrapperClassName = "";

            var baseTypeSyntaxFunc = () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"global::Whipstaff.AspNetCore.QueryOnlyMvcController<{listQueryClassName}, {listRequestDtoClassName}, {listResponseDtoClassName}, {viewQueryClassName}, {viewResponseDtoClassName}, {logMessageActionsWrapperClassName}>"));

            return new MvcControllerModel(
                containingNamespace,
                name,
                isSealed,
                baseTypeSyntaxFunc,
                [ $"MVC controller for querying {entityDescription}."]);
        }

        public static MvcControllerModel WhipstaffQueryOnlyController(
            string containingNamespace,
            string name,
            bool isSealed,
            string entityDescription)
        {
            var baseTypeSyntaxFunc = () => "";
            return new MvcControllerModel(
                containingNamespace,
                name,
                isSealed,
                baseTypeSyntaxFunc,
                entityDescription);
        }
    }
}
