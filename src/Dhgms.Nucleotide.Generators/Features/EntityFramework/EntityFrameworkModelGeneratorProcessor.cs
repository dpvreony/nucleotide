// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Dhgms.Nucleotide.Generators.Features.Common.AttributeGenerators;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.EntityFramework
{
    public sealed class EntityFrameworkModelGeneratorProcessor : BaseClassLevelCodeGeneratorProcessor<EntityFrameworkModelEntityGenerationModel>
    {
        ///<inheritdoc />
        protected override bool GetWhetherClassShouldBePartialClass() => true;

        ///<inheritdoc />
        protected override bool GetWhetherClassShouldBeSealedClass() => true;

        ///<inheritdoc />
        protected override IEnumerable<PropertyDeclarationSyntax> GetPropertyDeclarations(EntityFrameworkModelEntityGenerationModel entityGenerationModel)
        {
            var inheritDocSyntaxTrivia = RoslynGenerationHelpers.GetInheritDocSyntaxTrivia().ToArray();
            var datetimeOffSetType = SyntaxFactory.ParseTypeName("System.DateTimeOffset");

            if (entityGenerationModel.GenerateCreatedAndModifiedColumns is GenerateCreatedAndModifiedColumns.CreatedOnly or GenerateCreatedAndModifiedColumns.CreatedAndModified)
            {
                yield return RoslynGenerationHelpers.GetPropertyDeclarationSyntax(
                    datetimeOffSetType,
                    $"Created",
                    inheritDocSyntaxTrivia);
            }

            if (entityGenerationModel.GenerateCreatedAndModifiedColumns == GenerateCreatedAndModifiedColumns.CreatedAndModified)
            {
                yield return RoslynGenerationHelpers.GetPropertyDeclarationSyntax(
                    datetimeOffSetType,
                    $"Modified",
                    inheritDocSyntaxTrivia);
            }

            if (entityGenerationModel.GenerateRowVersionColumn)
            {
                var ulongType = SyntaxFactory.ParseTypeName("ulong");
                yield return RoslynGenerationHelpers.GetPropertyDeclarationSyntax(
                    ulongType,
                    $"RowVersion",
                    inheritDocSyntaxTrivia);
            }

            if (entityGenerationModel.ParentEntityRelationships != null)
            {
                foreach (var referencedByEntityGenerationModel in entityGenerationModel.ParentEntityRelationships)
                {
                    var foriegnKeyType = SyntaxFactory.ParseTypeName(referencedByEntityGenerationModel.KeyType);

                    yield return RoslynGenerationHelpers.GetPropertyDeclarationSyntax(
                        foriegnKeyType,
                        $"{referencedByEntityGenerationModel.SingularPropertyName}Id",
                        inheritDocSyntaxTrivia);

                    var pocoType = SyntaxFactory.ParseTypeName($"EfModels.{referencedByEntityGenerationModel.EntityType}EfModel");

                    var firstLetterLower = char.ToLower(referencedByEntityGenerationModel.SingularPropertyName[0]);
                    var fieldName = $"_{firstLetterLower}{referencedByEntityGenerationModel.SingularPropertyName.Substring(1)}";

                    var assignment = SyntaxFactory.AssignmentExpression(
                        SyntaxKind.SimpleAssignmentExpression,
                        SyntaxFactory.IdentifierName(fieldName),
                        SyntaxFactory.IdentifierName("value"));

                    var getAccessor = SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithExpressionBody(SyntaxFactory.ArrowExpressionClause(SyntaxFactory.LiteralExpression(SyntaxKind.TrueLiteralExpression))).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));

                    var setAccessor = SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithExpressionBody(SyntaxFactory.ArrowExpressionClause(assignment))
                        .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));

                    var accessorList = new[]
                    {
                        getAccessor,
                        setAccessor
                    };

                    yield return RoslynGenerationHelpers.GetPropertyDeclarationSyntax(
                        pocoType,
                        referencedByEntityGenerationModel.SingularPropertyName,
                        accessorList,
                        inheritDocSyntaxTrivia).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
                }
            }

            if (entityGenerationModel.ChildEntityRelationships != null)
            {
                foreach (var referencedByEntityGenerationModel in entityGenerationModel.ChildEntityRelationships)
                {
                    var pocoType = SyntaxFactory.ParseTypeName($"global::System.Collections.Generic.ICollection<EfModels.{referencedByEntityGenerationModel.EntityType}EfModel>");

                    var suppress = SyntaxFactory.PostfixUnaryExpression(SyntaxKind.SuppressNullableWarningExpression,
                        SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression));

                    var initializer = SyntaxFactory.EqualsValueClause(
                        SyntaxFactory.Token(SyntaxKind.EqualsToken),
                        suppress);

                    yield return RoslynGenerationHelpers.GetPropertyDeclarationSyntax(
                        pocoType,
                        referencedByEntityGenerationModel.PluralPropertyName,
                        inheritDocSyntaxTrivia).WithInitializer(initializer).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
                }
            }
        }

        ///<inheritdoc />
        protected override PropertyDeclarationSyntax GetPropertyDeclaration(PropertyInfoBase propertyInfo, AccessorDeclarationSyntax[] accessorList, IEnumerable<SyntaxTrivia> summary)
        {
            var type = SyntaxFactory.ParseTypeName(propertyInfo.NetDataType);
            var identifier = propertyInfo.Name;

            var attributes = GetAttributesForProperty(propertyInfo);
            var result = SyntaxFactory.PropertyDeclaration(type, identifier)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.OverrideKeyword))
                .WithAccessorList(
                    SyntaxFactory.AccessorList(
                        SyntaxFactory.List(accessorList)
                    ));

            if (attributes.Count > 0)
            {
                var attributeLists = SyntaxFactory.AttributeList(attributes);
                result = result.AddAttributeLists(attributeLists);
            }

            result = result.WithLeadingTrivia(summary);

            return result;
        }

        ///<inheritdoc />
        protected override string GetClassSuffix()
        {
            return "EfModel";
        }

        ///<inheritdoc />
        protected override MethodDeclarationSyntax[] GetMethodDeclarations(EntityFrameworkModelEntityGenerationModel entityGenerationModel)
        {
            return null;
        }

        ///<inheritdoc />
        protected override IList<string> GetUsings()
        {
            return new List<string>
            {
                "System.ComponentModel.DataAnnotations"
            };
        }

        ///<inheritdoc />
        protected override string[] GetClassLevelCommentSummary(string entityName)
        {
            return new[]
            {
                $"Entity Framework Model for {entityName}"
            };
        }

        ///<inheritdoc />
        protected override string[] GetClassLevelCommentRemarks(string entityName)
        {
            return null;
        }

        ///<inheritdoc />
        protected override IList<Tuple<string, IList<string>>> GetClassAttributes(EntityFrameworkModelEntityGenerationModel entityDeclaration)
        {
            return null;
        }

        protected override IReadOnlyCollection<FieldDeclarationSyntax> GetFieldDeclarations(EntityFrameworkModelEntityGenerationModel entityGenerationModel)
        {
            if (entityGenerationModel.ParentEntityRelationships == null)
            {
                return null;
            }

            var result = new List<FieldDeclarationSyntax>();
            foreach (var referencedByEntityGenerationModel in entityGenerationModel.ParentEntityRelationships)
            {
                var fieldType = SyntaxFactory.ParseTypeName($"EfModels.{referencedByEntityGenerationModel.EntityType}EfModel?");

                var firstLetterLower = char.ToLower(referencedByEntityGenerationModel.SingularPropertyName[0]);
                var fieldName = $"_{firstLetterLower}{referencedByEntityGenerationModel.SingularPropertyName.Substring(1)}";

                var declaration = SyntaxFactory.FieldDeclaration(
                        SyntaxFactory.VariableDeclaration(
                            fieldType,
                            SyntaxFactory.SeparatedList(new[] { SyntaxFactory.VariableDeclarator(SyntaxFactory.Identifier(fieldName)) })
                        ))
                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PrivateKeyword));
                result.Add(declaration);
            }

            return result.ToArray();
        }

        ///<inheritdoc />
        protected override IList<string> GetBaseConstructorArguments() => null;

        ///<inheritdoc />
        protected override IList<Tuple<Func<string, string>, string, Accessibility>> GetConstructorArguments()
        {
            return null;
        }

        ///<inheritdoc />
        protected override string GetBaseClass(EntityFrameworkModelEntityGenerationModel entityGenerationModel)
        {
            if (entityGenerationModel.BaseTypeEntityGenerationModel != null)
            {
                return entityGenerationModel.BaseTypeEntityGenerationModel.FullyQualifiedClassName;
            }

            var entityName = entityGenerationModel.ClassName;
            return $"Models.{entityName}Model";
        }

        ///<inheritdoc />
        protected override IEnumerable<string> GetImplementedInterfaces(EntityFrameworkModelEntityGenerationModel entityGenerationModel)
        {
            if (entityGenerationModel.GenerateRowVersionColumn)
            {
                yield return $"global::Whipstaff.Core.Entities.ILongRowVersion";
            }

            switch (entityGenerationModel.GenerateCreatedAndModifiedColumns)
            {
                case GenerateCreatedAndModifiedColumns.CreatedOnly:
                    yield return $"global::Whipstaff.Core.Entities.ICreatable";
                    break;
                case GenerateCreatedAndModifiedColumns.CreatedAndModified:
                    yield return $"global::Whipstaff.Core.Entities.IModifiable";
                    break;
            }

            if (entityGenerationModel?.ParentEntityRelationships != null)
            {
                foreach (var referencedByEntityGenerationModel in entityGenerationModel.ParentEntityRelationships)
                {
                    yield return $"{referencedByEntityGenerationModel.NamespaceForInterface}.I{referencedByEntityGenerationModel.ClassName}ForeignKey";
                }
            }

            if (entityGenerationModel?.ChildEntityRelationships != null)
            {
                foreach (var referencedByEntityGenerationModel in entityGenerationModel.ChildEntityRelationships)
                {
                    yield return $"{referencedByEntityGenerationModel.NamespaceForInterface}.I{referencedByEntityGenerationModel.ClassName}ReferencedByEntity";
                }
            }
        }

        ///<inheritdoc />
        protected override string[] GetClassPrefixes() => null;

        ///<inheritdoc />
        protected override SeparatedSyntaxList<AttributeSyntax> GetAttributesForProperty(PropertyInfoBase propertyInfo)
        {
            var nodes = new List<AttributeSyntax>();

            if (!propertyInfo.Optional)
            {
                nodes.Add(SyntaxFactory.Attribute(SyntaxFactory.ParseName("Required")));
            }

            switch (propertyInfo)
            {
                case ClrStringPropertyInfo stringPropertyInfo:
                    AddStringAttributes(nodes, stringPropertyInfo);
                    break;
                case ClrBytePropertyInfo numericPropertyInfo:
                    AddNumericAttributes(nodes, numericPropertyInfo);
                    break;
                case ClrCharPropertyInfo numericPropertyInfo:
                    AddNumericAttributes(nodes, numericPropertyInfo);
                    break;
                case ClrDecimalPropertyInfo numericPropertyInfo:
                    AddNumericAttributes(nodes, numericPropertyInfo);
                    break;
                case ClrDoublePropertyInfo numericPropertyInfo:
                    AddNumericAttributes(nodes, numericPropertyInfo);
                    break;
                case ClrSinglePropertyInfo numericPropertyInfo:
                    AddNumericAttributes(nodes, numericPropertyInfo);
                    break;
                case Integer16PropertyInfo numericPropertyInfo:
                    AddNumericAttributes(nodes, numericPropertyInfo);
                    break;
                case Integer32PropertyInfo numericPropertyInfo:
                    AddNumericAttributes(nodes, numericPropertyInfo);
                    break;
                case Integer64PropertyInfo numericPropertyInfo:
                    AddNumericAttributes(nodes, numericPropertyInfo);
                    break;
                case UnsignedInteger8PropertyInfo numericPropertyInfo:
                    AddNumericAttributes(nodes, numericPropertyInfo);
                    break;
                case UnsignedInteger16PropertyInfo numericPropertyInfo:
                    AddNumericAttributes(nodes, numericPropertyInfo);
                    break;
                case UnsignedInteger32PropertyInfo numericPropertyInfo:
                    AddNumericAttributes(nodes, numericPropertyInfo);
                    break;
                case UnsignedInteger64PropertyInfo numericPropertyInfo:
                    AddNumericAttributes(nodes, numericPropertyInfo);
                    break;
            }

            var result = SyntaxFactory.SeparatedList(nodes);

            return result;
        }

        private void AddNumericAttributes<T>(
            List<AttributeSyntax> nodes,
            NumericPropertyInfo<T> numericPropertyInfo)
            where T : struct
        {
            var propertyAnnotationGenerator = new NumericPropertyAttributeGenerator<T>();
            nodes.AddRange(propertyAnnotationGenerator.GetAttributes(numericPropertyInfo));
        }

        private void AddStringAttributes(List<AttributeSyntax> nodes, ClrStringPropertyInfo stringPropertyInfo)
        {
            var propertyAnnotationGenerator = new StringPropertyAttributeGenerator();
            nodes.AddRange(propertyAnnotationGenerator.GetAttributes(stringPropertyInfo));
        }
    }
}