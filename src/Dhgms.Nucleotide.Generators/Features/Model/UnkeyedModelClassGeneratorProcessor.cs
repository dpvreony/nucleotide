// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.Generators.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.Model
{
    /// <summary>
    /// Generates models
    /// </summary>
    public class UnkeyedModelClassGeneratorProcessor : BaseClassLevelCodeGeneratorProcessor<IEntityGenerationModel>
    {
        protected override bool GetWhetherClassShouldBePartialClass() => false;

        protected override bool GetWhetherClassShouldBeSealedClass() => false;

        protected override IList<string> GetBaseConstructorArguments() => null;

        protected override IEnumerable<PropertyDeclarationSyntax> GetPropertyDeclarations(IEntityGenerationModel entityGenerationModel)
        {
            var result = new List<PropertyDeclarationSyntax>();

            return GetPropertyDeclarations(entityGenerationModel, result);
        }

        private IEnumerable<PropertyDeclarationSyntax> GetPropertyDeclarations(IEntityGenerationModel entityGenerationModel, List<PropertyDeclarationSyntax> result)
        {
            var properties = entityGenerationModel.Properties?.Select(GetPropertyDeclaration).ToArray();
            if (properties != null)
            {
                result.AddRange(properties);
            }

            if (entityGenerationModel.InterfaceGenerationModels != null)
            {
                foreach (var interfaceGenerationModel in entityGenerationModel.InterfaceGenerationModels)
                {
                    DoPropertyDeclarations(interfaceGenerationModel, result);
                }
            }

            return result;
        }

        private void DoPropertyDeclarations(InterfaceGenerationModel interfaceGenerationModel, List<PropertyDeclarationSyntax> result)
        {
            PropertyDeclarationSyntax[] properties;
            if (interfaceGenerationModel.Properties != null)
            {
                properties = interfaceGenerationModel.Properties?.Select(GetPropertyDeclaration).ToArray();
                if (properties != null)
                {
                    result.AddRange(properties);
                }
            }

            if (interfaceGenerationModel.BaseInterfaces == null)
            {
                return;
            }

            foreach (var baseInterface in interfaceGenerationModel.BaseInterfaces)
            {
                DoPropertyDeclarations(baseInterface, result);
            }
        }

        private PropertyDeclarationSyntax GetPropertyDeclaration(PropertyGenerationModel propertyGenerationModel)
        {
            var type = SyntaxFactory.ParseTypeName(propertyGenerationModel.TypeName);
            if (propertyGenerationModel.Optional)
            {
                type = SyntaxFactory.NullableType(type);
            }

            var identifier = propertyGenerationModel.Name;

            var summary = new[]
            {
                SyntaxFactory.Comment($"/// <inheritdoc />"),
            };

            var accessorList = GetPropertyAccessorDeclarationSyntaxCollection(propertyGenerationModel.PropertyAccessorFlags);

            var result = SyntaxFactory.PropertyDeclaration(type, identifier)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .WithAccessorList(
                    SyntaxFactory.AccessorList(
                        SyntaxFactory.List(accessorList)
                    ))
                .WithLeadingTrivia(summary);
            // HACK: will rewrite this once I replace the type with ISymbol
            if (!propertyGenerationModel.Optional && propertyGenerationModel.TypeName.Equals("string"))
            {
                result = result.AddModifiers(SyntaxFactory.Token(SyntaxKind.RequiredKeyword));
            }
            return result;
        }

        private static AccessorDeclarationSyntax[] GetPropertyAccessorDeclarationSyntaxCollection(
            PropertyAccessorFlags propertyAccessorFlags)
        {
            return
            [
                SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
            ];
        }

        protected override PropertyDeclarationSyntax GetPropertyDeclaration(PropertyInfoBase propertyInfo, AccessorDeclarationSyntax[] accessorList, IEnumerable<SyntaxTrivia> summary)
        {
            var type = SyntaxFactory.ParseTypeName(propertyInfo.NetDataType);
            var identifier = propertyInfo.Name;

            if (propertyInfo.Optional)
            {
                type = SyntaxFactory.NullableType(type);
            }

            var attributes = GetAttributesForProperty(propertyInfo);
            var result = SyntaxFactory.PropertyDeclaration(type, identifier)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .WithAccessorList(
                    SyntaxFactory.AccessorList(
                        SyntaxFactory.List(accessorList)
                    ))
                .WithLeadingTrivia(summary);

            // HACK: will rewrite this once I replace the type with ISymbol
            if (!propertyInfo.Optional && propertyInfo.NetDataType.Equals("string"))
            {
                result = result.AddModifiers(SyntaxFactory.Token(SyntaxKind.RequiredKeyword));
            }

            if (attributes.Count > 0)
            {
                var attributeLists = SyntaxFactory.AttributeList(attributes);
                result = result.AddAttributeLists(attributeLists);
            }

            return result;
        }


        protected override IList<string> GetUsings()
        {
            return null;
        }

        protected override string[] GetClassPrefixes() => new [] {"Unkeyed"};

        protected override string GetClassSuffix() => "Model";

        protected override string[] GetClassLevelCommentSummary(string entityName)
        {
            return new[]
            {
                $"Unkeyed Model Class for {entityName}"
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

        protected override IList<Tuple<Func<string, string>, string, Accessibility>> GetConstructorArguments()
        {
            return null;
        }

        protected override string GetBaseClass(IEntityGenerationModel entityGenerationModel)
        {
            return null;
        }

        protected override IEnumerable<string> GetImplementedInterfaces(IEntityGenerationModel entityGenerationModel)
        {
            return new List<string>
            {
                $"IUnkeyed{entityGenerationModel.ClassName}Model"
            };
        }

        protected override SeparatedSyntaxList<AttributeSyntax> GetAttributesForProperty(PropertyInfoBase propertyInfo)
        {
            return default(SeparatedSyntaxList<AttributeSyntax>);
        }
    }
}
