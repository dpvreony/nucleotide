using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.Generators.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.EventId
{
    public sealed class EventIdGeneratorProcessor : BaseClassLevelCodeGeneratorProcessor<IEntityGenerationModel>
    {
        /// <inheritdoc />
        protected override string[] GetClassPrefixes()
        {
            return Array.Empty<string>();
        }

        /// <inheritdoc />
        protected override string GetClassSuffix()
        {
            return "EventIdFactory";
        }

        /// <inheritdoc />
        protected override IList<string> GetUsings()
        {
            return Array.Empty<string>();
        }

        /// <inheritdoc />
        protected override bool GetWhetherClassShouldBePartialClass()
        {
            return false;
        }

        /// <inheritdoc />
        protected override bool GetWhetherClassShouldBeSealedClass()
        {
            return false;
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
            return Array.Empty<PropertyDeclarationSyntax>();
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
            return Array.Empty<string>();
        }

        /// <inheritdoc />
        protected override SeparatedSyntaxList<AttributeSyntax> GetAttributesForProperty(PropertyInfoBase propertyInfo)
        {
            return default(SeparatedSyntaxList<AttributeSyntax>);
        }
    }
}
