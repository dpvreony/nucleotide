// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using Dhgms.Nucleotide.Generators.Features.Cqrs.XmlDoc;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.Database
{
    public sealed class ReferencedByEntityGeneratorProcessor : BaseInterfaceLevelCodeGeneratorProcessor<ReferencedByEntityGenerationModel>
    {
        /// <inheritdoc />
        protected override string[] GetClassPrefixes()
        {
            return null;
        }

        /// <inheritdoc />
        protected override string GetClassSuffix()
        {
            return "ReferencedByEntity";
        }

        /// <inheritdoc />
        protected override string[] GetInterfaceSummary(ReferencedByEntityGenerationModel entityDeclaration)
        {
            return new[]
            {
                $"Represents a one to many relationship for the {entityDeclaration.ClassName} entity where this is the one (principal) side.",
            };
        }

        /// <inheritdoc />
        protected override PropertyDeclarationSyntax[] GetPropertyDeclarations(ReferencedByEntityGenerationModel entityGenerationModel, string prefix)
        {
            var pocoSummary = SyntaxTriviaFactory.GetSummary(new[] { $"Gets or Sets the Foreign Entity for {entityGenerationModel.ClassName}" });

            var pocoType = SyntaxFactory.ParseTypeName($"global::System.Collections.Generic.ICollection<EfModels.{entityGenerationModel.EntityType}EfModel>");
            var pocoIdentifier = entityGenerationModel.PluralPropertyName;

            var pocoObject = RoslynGenerationHelpers.GetPropertyDeclarationSyntax(pocoType, pocoIdentifier, pocoSummary);

            return new []
            {
                pocoObject,
            };
        }

        /// <inheritdoc />
        protected override MethodDeclarationSyntax[] GetMethodDeclarations(string className, string prefix)
        {
            return null;
        }

        /// <inheritdoc />
        protected override string[] GetBaseInterfaces(ReferencedByEntityGenerationModel entityGenerationModel, string prefix)
        {
            return null;
        }
    }
}
