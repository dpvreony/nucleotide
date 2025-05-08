using Dhgms.Nucleotide.Generators.Features.Core;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dhgms.Nucleotide.SampleGenerator.DataTransferObjects
{
    public sealed record DataTransferObjectModel(
        string ContainingNamespace,
        string TypeName,
        bool IsSealed,
        NamedTypeParameterModel[] Properties,
        Func<BaseTypeSyntax>? BaseTypeSyntaxFunc,
        string[] XmlDocSummary)
    {
        public static DataTransferObjectModel PocoWithNoInheritance(
            string containingNamespace,
            string name,
            bool isSealed,
            NamedTypeParameterModel[] properties,
            string[] xmlDocSummary)
        {
            return new DataTransferObjectModel(
                containingNamespace,
                name,
                isSealed,
                properties,
                null,
                xmlDocSummary);
        }
    }
}
