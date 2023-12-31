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

            var properties = entityGenerationModel.Properties?.Select(GetPropertyDeclaration).ToArray();
            if (properties != null)
            {
                result.AddRange(properties);
            }

            if (entityGenerationModel.InterfaceGenerationModels != null)
            {
                foreach (var interfaceGenerationModel in entityGenerationModel.InterfaceGenerationModels)
                {
                    if (interfaceGenerationModel.BaseInterfaces == null)
                    {
                        continue;
                    }

                    foreach (var baseInterface in interfaceGenerationModel.BaseInterfaces)
                    {
                        properties = baseInterface.Properties?.Select(GetPropertyDeclaration).ToArray();
                        if (properties != null)
                        {
                            result.AddRange(properties);
                        }
                    }
                }
            }

            return result;
        }

        private PropertyDeclarationSyntax GetPropertyDeclaration(PropertyGenerationModel propertyGenerationModel)
        {
            var type = SyntaxFactory.ParseName(propertyGenerationModel.TypeName);
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
            return result;
        }

        private static AccessorDeclarationSyntax[] GetPropertyAccessorDeclarationSyntaxCollection(
            PropertyAccessorFlags propertyAccessorFlags)
        {
            return propertyAccessorFlags switch
            {
                PropertyAccessorFlags.Get => new[]
                                {
                    SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                        .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                },
                PropertyAccessorFlags.GetInit => new[]
                {
                    SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                        .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                    SyntaxFactory.AccessorDeclaration(SyntaxKind.InitAccessorDeclaration)
                        .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
                },
                PropertyAccessorFlags.GetSet => new[]
                {
                    SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                        .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                    SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                        .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
                },
                _ => throw new ArgumentOutOfRangeException(nameof(propertyAccessorFlags), propertyAccessorFlags, null)
            };
        }

        protected override PropertyDeclarationSyntax GetPropertyDeclaration(PropertyInfoBase propertyInfo, AccessorDeclarationSyntax[] accessorList, IEnumerable<SyntaxTrivia> summary)
        {
            var type = SyntaxFactory.ParseName(propertyInfo.NetDataType);
            var identifier = propertyInfo.Name;

            var attributes = GetAttributesForProperty(propertyInfo);
            var result = SyntaxFactory.PropertyDeclaration(type, identifier)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.VirtualKeyword))
                .WithAccessorList(
                    SyntaxFactory.AccessorList(
                        SyntaxFactory.List(accessorList)
                    ))
                .WithLeadingTrivia(summary);

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

        private MemberDeclarationSyntax[] GetUnkeyedClasses()
        {
            var name = "Test";

            var leadingTrivia = new[]
            {
                SyntaxFactory.Comment($"/// <summary>Represents the Unkeyed {name} model. Typically used for adding a new record.</summary>"),
            };

            var baseTypes = new BaseTypeSyntax[]
            {
                SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"IUnkeyed{name}Model"))
            };

            return new MemberDeclarationSyntax[]
            {
                SyntaxFactory.ClassDeclaration($"Unkeyed{name}Model")
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddBaseListTypes(baseTypes)
                .WithLeadingTrivia(leadingTrivia)
            };
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
