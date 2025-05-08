// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using Dhgms.Nucleotide.Generators.Features.Core;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Dhgms.Nucleotide.Generators.Features.Core.XmlDoc;
using Dhgms.Nucleotide.Generators.Models;

namespace Dhgms.Nucleotide.Generators.Features.Logging
{
    public sealed record LogMessageActionModel(
        string ContainingNamespace,
        string TypeName,
        bool Sealed,
        bool Partial,
        Func<BaseTypeSyntax>? BaseTypeSyntaxFunc,
        PropertyDeclarationSyntax[] PropertyDeclarations)
        : NamedTypeModel(
            ContainingNamespace,
            TypeName)
    {
        public static LogMessageActionModel QueryOnlyControllerLogMessageActions(
            string containingNamespace,
            string typeName,
            string controllerNamespace,
            string controllerTypeName)
        {
            var baseTypeSyntaxFunc = () => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"global::Whipstaff.AspNetCore.Features.Logging.IQueryOnlyControllerLogMessageActions"));

            var accessorList = new[]
            {
                SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                SyntaxFactory.AccessorDeclaration(SyntaxKind.InitAccessorDeclaration)
                .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
            };

            var pocoSummary = SyntaxTriviaFactory.GetSummary(new[] { $"Gets the Logger Message Action." }).ToArray();
            var pocoType = SyntaxFactory.ParseTypeName("global::System.Action<global::Microsoft.Extensions.Logging.ILogger, string, global::System.Exception?>");
            var listLongerMessageAction = RoslynGenerationHelpers.GetPropertyDeclarationSyntax(pocoType, "ListEventLogMessageAction", accessorList, pocoSummary);
            var viewLongerMessageAction = RoslynGenerationHelpers.GetPropertyDeclarationSyntax(pocoType, "ViewEventLogMessageAction", accessorList, pocoSummary);

            var properties= new[]
            {
                listLongerMessageAction,
                viewLongerMessageAction,
            };

            return new LogMessageActionModel(
                containingNamespace,
                typeName,
                true,
                false,
                baseTypeSyntaxFunc,
                properties);
        }
    }
}
