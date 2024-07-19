// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.Generators.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.Model
{
    /// <summary>
    /// Generates models
    /// </summary>
    public class KeyedModelClassGeneratorProcessor : BaseClassLevelCodeGeneratorProcessor<IEntityGenerationModel>
    {

        protected override bool GetWhetherClassShouldBePartialClass() => false;

        protected override bool GetWhetherClassShouldBeSealedClass() => false;

        protected override string[] GetClassPrefixes() => null;

        protected override string GetClassSuffix() => "Model";

        protected override IList<string> GetBaseConstructorArguments() => null;

        protected override IList<string> GetUsings()
        {
            return null;
        }

        protected override string[] GetClassLevelCommentSummary(string entityName)
        {
            return new[]
            {
                $"Keyed Model Class for {entityName}"
            };
        }

        protected override string[] GetClassLevelCommentRemarks(string entityName)
        {
            return null;
        }

        protected override IList<Tuple<string, IList<string>>> GetClassAttributes(IEntityGenerationModel entityDeclaration)
        {
            return null;
        }

        protected override MethodDeclarationSyntax[] GetMethodDeclarations(IEntityGenerationModel entityGenerationModel)
        {
            return null;
        }

        protected override IEnumerable<PropertyDeclarationSyntax> GetPropertyDeclarations(IEntityGenerationModel entityGenerationModel)
        {
            var idColumn = GetIdColumn(entityGenerationModel.KeyType);

            if (idColumn == null)
            {
                return Array.Empty<PropertyDeclarationSyntax>();
            }

            return new[]
            {
                GetPropertyDeclaration(idColumn)
            };
        }

        private static PropertyInfoBase GetIdColumn(KeyType keyType)
        {
            switch (keyType)
            {
                case KeyType.Guid:
                    return new ClrGuidPropertyInfo(
                        CollectionType.None,
                        "Id",
                        "Unique Identifier for the object",
                        false,
                        true,
                        null);
                case KeyType.Int32:
                    return new Integer32PropertyInfo(
                        CollectionType.None,
                        "Id",
                        "Unique Identifier for the object",
                        false,
                        1,
                        int.MaxValue,
                        true,
                        null);
                case KeyType.Int64:
                    return new Integer64PropertyInfo(
                        CollectionType.None,
                        "Id",
                        "Unique Identifier for the object",
                        false,
                        1,
                        int.MaxValue,
                        true,
                        null);
                case KeyType.Inherited:
                    // TODO: this need validation that the base class has a key
                    return null;
                default:
                    throw new ArgumentOutOfRangeException(nameof(keyType));
            }
        }

        protected override IList<Tuple<Func<string, string>, string, Accessibility>> GetConstructorArguments()
        {
            return null;
        }

        protected override string GetBaseClass(IEntityGenerationModel entityGenerationModel)
        {
            var entityName = entityGenerationModel.ClassName;
            return $"Unkeyed{entityName}Model";
        }

        protected override IEnumerable<string> GetImplementedInterfaces(IEntityGenerationModel entityGenerationModel)
        {
            return new List<string>
            {
                $"I{entityGenerationModel.ClassName}Model"
            };
        }

        protected override SeparatedSyntaxList<AttributeSyntax> GetAttributesForProperty(PropertyInfoBase propertyInfo)
        {
            return default(SeparatedSyntaxList<AttributeSyntax>);
        }
    }
}
