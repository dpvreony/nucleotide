using System;
using System.Collections.Generic;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.Generators.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.Logging
{
    public class CrudControllerLoggerMessageActionGeneratorProcessor : BaseClassLevelCodeGeneratorProcessor<IEntityGenerationModel>
    {
        /// <inheritdoc />
        protected override string[] GetClassPrefixes()
        {
            return null;
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
            return null;
        }

        /// <inheritdoc />
        protected override IList<Tuple<string, IList<string>>> GetClassAttributes(IEntityGenerationModel entityDeclaration)
        {
            return null;
        }

        /// <inheritdoc />
        protected override IList<string> GetBaseConstructorArguments()
        {
            return null;
        }

        /// <inheritdoc />
        protected override MethodDeclarationSyntax[] GetMethodDeclarations(IEntityGenerationModel entityGenerationModel)
        {
            return null;
        }

        /// <inheritdoc />
        protected override IEnumerable<PropertyDeclarationSyntax> GetPropertyDeclarations(IEntityGenerationModel entityGenerationModel)
        {
            return null;
        }

        /// <inheritdoc />
        protected override IList<Tuple<Func<string, string>, string, Accessibility>> GetConstructorArguments()
        {
            return null;
        }

        /// <inheritdoc />
        protected override string GetBaseClass(string entityName)
        {
            return null;
        }

        /// <inheritdoc />
        protected override IEnumerable<string> GetImplementedInterfaces(IEntityGenerationModel generationModel)
        {
            return new []
            {
                "Whipstaff.AspNetCore.Features.Logging.ICrudControllerLogMessageActions"
            };
        }

        /// <inheritdoc />
        protected override SeparatedSyntaxList<AttributeSyntax> GetAttributesForProperty(PropertyInfoBase propertyInfo)
        {
            return default(SeparatedSyntaxList<AttributeSyntax>);
        }
    }
}
