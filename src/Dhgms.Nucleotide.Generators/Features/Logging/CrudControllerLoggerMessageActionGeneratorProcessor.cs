// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using Dhgms.Nucleotide.Generators.Features.Core.XmlDoc;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.Generators.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.Logging
{
    public class CrudControllerLoggerMessageActionGeneratorProcessor : BaseClassLevelCodeGeneratorProcessor<IEntityGenerationModel>
    {
        /// <inheritdoc />
        protected override string[] GetClassPrefixes()
        {
            return Array.Empty<string>();
        }

        /// <inheritdoc />
        protected override string GetClassSuffix()
        {
            return "LoggerMessageActions";
        }

        /// <inheritdoc />
        protected override IList<string> GetUsings()
        {
            return new List<string>
            {
                "System",
                "Microsoft.Extensions.Logging",
            };
        }

        /// <inheritdoc />
        protected override bool GetWhetherClassShouldBePartialClass()
        {
            return false;
        }

        /// <inheritdoc />
        protected override bool GetWhetherClassShouldBeSealedClass()
        {
            return true;
        }

        /// <inheritdoc />
        protected override string[] GetClassLevelCommentSummary(string entityName)
        {
            return new[]
            {
                $"Log Message Actions for the {entityName} Controller."
            };
        }

        /// <inheritdoc />
        protected override string[] GetClassLevelCommentRemarks(string entityName)
        {
            return Array.Empty<string>();
        }

        /// <inheritdoc />
        protected override IList<Tuple<string, IList<string>>> GetClassAttributes(IEntityGenerationModel entityDeclaration)
        {
            return new List<Tuple<string, IList<string>>>();
        }

        protected override IReadOnlyCollection<FieldDeclarationSyntax> GetFieldDeclarations(IEntityGenerationModel entityGenerationModel)
        {
            return null;
        }

        /// <inheritdoc />
        protected override IList<string> GetBaseConstructorArguments()
        {
            return new List<string>();
        }

        /// <inheritdoc />
        protected override MethodDeclarationSyntax[] GetMethodDeclarations(IEntityGenerationModel entityGenerationModel)
        {
            return Array.Empty<MethodDeclarationSyntax>();
        }

        /// <inheritdoc />
        protected override IEnumerable<PropertyDeclarationSyntax> GetPropertyDeclarations(IEntityGenerationModel entityGenerationModel)
        {
            var pocoSummary = SyntaxTriviaFactory.GetSummary(new[] { $"Gets the Logger Message Action {entityGenerationModel.ClassName}." });

            var pocoType = SyntaxFactory.ParseTypeName("global::System.Action<global::Microsoft.Extensions.Logging.ILogger, string, global::System.Exception?>");
            var accessorList = new[]
            {
                SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                SyntaxFactory.AccessorDeclaration(SyntaxKind.InitAccessorDeclaration)
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
            };

            var addLongerMessageAction = RoslynGenerationHelpers.GetPropertyDeclarationSyntax(pocoType, "AddEventLogMessageAction", accessorList, pocoSummary);
            var deleteLongerMessageAction = RoslynGenerationHelpers.GetPropertyDeclarationSyntax(pocoType, "DeleteEventLogMessageAction", accessorList, pocoSummary);
            var listLongerMessageAction = RoslynGenerationHelpers.GetPropertyDeclarationSyntax(pocoType, "ListEventLogMessageAction", accessorList, pocoSummary);
            var updateLongerMessageAction = RoslynGenerationHelpers.GetPropertyDeclarationSyntax(pocoType, "UpdateEventLogMessageAction", accessorList, pocoSummary);
            var viewLongerMessageAction = RoslynGenerationHelpers.GetPropertyDeclarationSyntax(pocoType, "ViewEventLogMessageAction", accessorList, pocoSummary);

            return new []
            {
                addLongerMessageAction,
                deleteLongerMessageAction,
                listLongerMessageAction,
                updateLongerMessageAction,
                viewLongerMessageAction,
            };
        }

        /// <inheritdoc />
        protected override IList<Tuple<Func<string, string>, string, Accessibility>> GetConstructorArguments()
        {
            return new List<Tuple<Func<string, string>, string, Accessibility>>();
        }

        /// <inheritdoc />
        protected override string GetBaseClass(IEntityGenerationModel entityGenerationModel)
        {
            return null;
        }

        /// <inheritdoc />
        protected override IEnumerable<string> GetImplementedInterfaces(IEntityGenerationModel generationModel)
        {
            return new []
            {
                "global::Whipstaff.AspNetCore.Features.Logging.ICrudControllerLogMessageActions"
            };
        }

        /// <inheritdoc />
        protected override SeparatedSyntaxList<AttributeSyntax> GetAttributesForProperty(PropertyInfoBase propertyInfo)
        {
            return default(SeparatedSyntaxList<AttributeSyntax>);
        }
    }
}
