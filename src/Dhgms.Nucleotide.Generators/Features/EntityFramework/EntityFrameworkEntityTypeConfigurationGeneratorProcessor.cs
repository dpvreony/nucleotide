// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Dhgms.Nucleotide.Generators.Features.Database;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.Generators.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.EntityFramework
{
    public class EntityFrameworkEntityTypeConfigurationGeneratorProcessor : BaseClassLevelCodeGeneratorProcessor<EntityFrameworkModelEntityGenerationModel>
    {
        ///<inheritdoc />
        protected override bool GetWhetherClassShouldBePartialClass() => false;

        ///<inheritdoc />
        protected override bool GetWhetherClassShouldBeSealedClass() => true;

        protected override IEnumerable<PropertyDeclarationSyntax> GetPropertyDeclarations(EntityFrameworkModelEntityGenerationModel entityGenerationModel)
        {
            return Array.Empty<PropertyDeclarationSyntax>();
        }

        ///<inheritdoc />
        protected override PropertyDeclarationSyntax GetPropertyDeclaration(PropertyInfoBase propertyInfo, AccessorDeclarationSyntax[] accessorList, IEnumerable<SyntaxTrivia> summary)
        {
            return null;
        }

        ///<inheritdoc />
        protected override string GetClassSuffix()
        {
            return "EntityTypeConfiguration";
        }

        ///<inheritdoc />
        protected override MethodDeclarationSyntax[] GetMethodDeclarations(EntityFrameworkModelEntityGenerationModel entityGenerationModel)
        {
            var result = new List<MethodDeclarationSyntax>()
            {
                GetConfigureMethodDeclaration(entityGenerationModel),
            };

            var entityName = entityGenerationModel.ClassName;
            result.Add(GetTableMappingMethodDeclaration(entityName, entityGenerationModel));

            result.Add(GetIdMethodDeclaration(entityName));

            if (entityGenerationModel.Properties != null)
            {
                foreach (var propertyInfoBase in entityGenerationModel.Properties)
                {
                    result.Add(GetPropertyMappingMethodDeclaration(entityName, propertyInfoBase));
                }
            }

            if (entityGenerationModel.GenerateRowVersionColumn)
            {
                result.Add(GetRowVersionMappingMethodDeclaration(entityName));
            }

            if (entityGenerationModel.ChildEntityRelationships != null)
            {
                foreach (var childEntityRelationship in entityGenerationModel.ChildEntityRelationships)
                {
                    result.Add(GetChildRelationshipMethodDeclaration(entityName, childEntityRelationship));
                }
            }

            if (entityGenerationModel.ParentEntityRelationships != null)
            {
                foreach (var parentEntityRelationship in entityGenerationModel.ParentEntityRelationships)
                {
                    result.Add(GetParentRelationshipMethodDeclaration(entityName, parentEntityRelationship, entityGenerationModel.ClassPluralName));
                }
            }

            return result.ToArray();
        }

        ///<inheritdoc />
        protected override IList<string> GetUsings()
        {
            return new List<string>()
            {
                "Microsoft.EntityFrameworkCore",
            };
        }

        ///<inheritdoc />
        protected override string[] GetClassLevelCommentSummary(string entityName)
        {
            return new[]
            {
                $"Entity Framework Entity Type Configuration for {entityName}Ef Model"
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
            return null;
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
            return null;
        }

        ///<inheritdoc />
        protected override IEnumerable<string> GetImplementedInterfaces(EntityFrameworkModelEntityGenerationModel generationModel)
        {
            return new List<string>
            {
                $"IEntityTypeConfiguration<EfModels.{generationModel.ClassName}EfModel>"
            };
        }

        ///<inheritdoc />
        protected override string[] GetClassPrefixes() => null;

        ///<inheritdoc />
        protected override SeparatedSyntaxList<AttributeSyntax> GetAttributesForProperty(PropertyInfoBase propertyInfo)
        {
            return default(SeparatedSyntaxList<AttributeSyntax>);
        }

        private MethodDeclarationSyntax GetConfigureMethodDeclaration(EntityFrameworkModelEntityGenerationModel entityGenerationModel)
        {
            var entityName = entityGenerationModel.ClassName;
            var methodName = $"Configure";

            var body = new List<StatementSyntax>();

            var subMethodParams = new[] {"builder"};

            // do table level operations
            {
                var expression =
                    RoslynGenerationHelpers.GetMethodOnClassInvocationSyntax(
                        "ConfigureTable",
                        subMethodParams,
                        false);
                var statement = SyntaxFactory.ExpressionStatement(expression);
                body.Add(statement);
            }

            // do column level operations
            GenerateConfigurePropertyColumnInvocation("Id", subMethodParams, body);
            if (entityGenerationModel.Properties != null)
            {
                foreach (var propertyInfo in entityGenerationModel.Properties)
                {
                    var propertyName = propertyInfo.Name;
                    GenerateConfigurePropertyColumnInvocation(propertyName, subMethodParams, body);
                }
            }

            if (entityGenerationModel.GenerateRowVersionColumn)
            {
                GenerateConfigurePropertyColumnInvocation("RowVersion", subMethodParams, body);
            }

            if (entityGenerationModel.ChildEntityRelationships != null)
            {
                foreach (var referencedByEntityGenerationModel in entityGenerationModel.ChildEntityRelationships)
                {
                    GenerateEfConfigureInvocation(
                        $"Configure{referencedByEntityGenerationModel.ClassName}ChildRelationship", subMethodParams,
                        body);
                }
            }

            if (entityGenerationModel.ParentEntityRelationships != null)
            {
                foreach (var referencedByEntityGenerationModel in entityGenerationModel.ParentEntityRelationships)
                {
                    GenerateEfConfigureInvocation(
                        $"Configure{referencedByEntityGenerationModel.ClassName}ParentRelationship", subMethodParams,
                        body);
                }
            }


            var parameters = GetParams(new []{ $"Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<EfModels.{entityName}EfModel> builder"});

            var returnType = SyntaxFactory.ParseTypeName("void");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName)
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddBodyStatements(body.ToArray());
            return declaration;
        }

        private static void GenerateConfigurePropertyColumnInvocation(string propertyName, string[] subMethodParams, List<StatementSyntax> body)
        {
            var configureColumnMethodName = $"Configure{propertyName}Column";
            GenerateEfConfigureInvocation(configureColumnMethodName, subMethodParams, body);
        }

        private static void GenerateEfConfigureInvocation(string methodName, string[] subMethodParams, List<StatementSyntax> body)
        {
            var expression =
                RoslynGenerationHelpers.GetMethodOnClassInvocationSyntax(
                    methodName,
                    subMethodParams,
                    false);
            var statement = SyntaxFactory.ExpressionStatement(expression);
            body.Add(statement);
        }

        private MethodDeclarationSyntax GetParentRelationshipMethodDeclaration(
            string entityName,
            ReferencedByEntityGenerationModel parentEntityRelationship,
            string entityPluralName)
        {
            var methodName = $"Configure{parentEntityRelationship.SingularPropertyName}ParentRelationship";

            var body = new List<StatementSyntax>();

            // get the initial property method invoke to use as the basis of chaining others together
            var propertyInvocation = GetEfParentRelationshipInvocation(
                parentEntityRelationship,
                entityPluralName);
            body.Add(propertyInvocation);

            var parameters = GetParams(new[] { $"Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<EfModels.{entityName}EfModel> builder" });

            var returnType = SyntaxFactory.ParseTypeName("void");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName)
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PrivateKeyword))
                .AddBodyStatements(body.ToArray());
            return declaration;
        }

        private MethodDeclarationSyntax GetChildRelationshipMethodDeclaration(
            string entityName,
            ReferencedByEntityGenerationModel childEntityRelationship)
        {
            var methodName = $"Configure{childEntityRelationship.SingularPropertyName}ChildRelationship";

            var body = new List<StatementSyntax>();

            // get the initial property method invoke to use as the basis of chaining others together
            var propertyInvocation = GetEfChildRelationshipInvocation(childEntityRelationship, entityName);
            body.Add(propertyInvocation);

            var parameters = GetParams(new[] { $"Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<EfModels.{entityName}EfModel> builder" });

            var returnType = SyntaxFactory.ParseTypeName("void");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName)
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PrivateKeyword))
                .AddBodyStatements(body.ToArray());
            return declaration;
        }

        private MethodDeclarationSyntax GetIdMethodDeclaration(string entityName)
        {
            var methodName = $"ConfigureIdColumn";

            var body = new List<StatementSyntax>();
            DoPrimaryKeyMethodDeclaration(body);

            var parameters = GetParams(new[] { $"Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<EfModels.{entityName}EfModel> builder" });

            var returnType = SyntaxFactory.ParseTypeName("void");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName)
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PrivateKeyword))
                .AddBodyStatements(body.ToArray());
            return declaration;
        }

        private MethodDeclarationSyntax GetRowVersionMappingMethodDeclaration(string entityName)
        {
            var propertyInvocation = GetRowVersionEfPropertyInvocation();
            return GetPropertyMappingMethodDeclaration(
                entityName,
                "RowVersion",
                propertyInvocation);
        }

        private MethodDeclarationSyntax GetPropertyMappingMethodDeclaration(
            string entityName,
            PropertyInfoBase propertyInfoBase)
        {
            var propertyInvocation = GetEfPropertyInvocation(propertyInfoBase);
            return GetPropertyMappingMethodDeclaration(
                entityName,
                propertyInfoBase.Name,
                propertyInvocation);
        }

        private MethodDeclarationSyntax GetPropertyMappingMethodDeclaration(
            string entityName,
            string propertyName,
            StatementSyntax efPropertyInvocationStatementSyntax)
        {
            var methodName = $"Configure{propertyName}Column";

            // get the initial property method invoke to use as the basis of chaining others together
            var body = new List<StatementSyntax> {
                efPropertyInvocationStatementSyntax
            };


            var parameters = GetParams(new[] { $"Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<EfModels.{entityName}EfModel> builder" });

            var returnType = SyntaxFactory.ParseTypeName("void");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName)
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PrivateKeyword))
                .AddBodyStatements(body.ToArray());
            return declaration;
        }

        private MethodDeclarationSyntax GetTableMappingMethodDeclaration(
            string entityName,
            EntityFrameworkModelEntityGenerationModel entityGenerationModel)
        {
            var methodName = $"ConfigureTable";

            var body = GetTableMappingBodyDeclaration(entityGenerationModel);

            var parameters = GetParams(new[] { $"Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<EfModels.{entityName}EfModel> builder" });

            var returnType = SyntaxFactory.ParseTypeName("void");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName)
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PrivateKeyword))
                .AddBodyStatements(body.ToArray());
            return declaration;
        }

        private StatementSyntax GetEfChildRelationshipInvocation(
            ReferencedByEntityGenerationModel childEntityRelationship,
            string entitySingularName)
        {
            var fluentApiInvocation = RoslynGenerationHelpers.GetMethodOnVariableInvocationExpression(
                "builder",
                "HasMany",
                new[] {$"table => table.{childEntityRelationship.PluralPropertyName}"},
                false);

            fluentApiInvocation = RoslynGenerationHelpers.GetFluentApiChainedInvocationExpression(
                fluentApiInvocation,
                "WithOne",
                new [] { $"one => one.{entitySingularName}"});

            fluentApiInvocation = RoslynGenerationHelpers.GetFluentApiChainedInvocationExpression(
                fluentApiInvocation,
                "HasForeignKey",
                new [] { $"foreign => foreign.{entitySingularName}Id"});

            fluentApiInvocation = RoslynGenerationHelpers.GetFluentApiChainedInvocationExpression(
                fluentApiInvocation,
                "HasPrincipalKey",
                new[] { $"principal => principal.Id" });

            return SyntaxFactory.ExpressionStatement(fluentApiInvocation);
        }

        private StatementSyntax GetEfParentRelationshipInvocation(
            ReferencedByEntityGenerationModel parentEntityRelationship,
            string entityPluralName)
        {
            var fluentApiInvocation = RoslynGenerationHelpers.GetMethodOnVariableInvocationExpression(
                "builder",
                "HasOne",
                new[] {$"table => table.{parentEntityRelationship.SingularPropertyName}"},
                false);

            fluentApiInvocation = RoslynGenerationHelpers.GetFluentApiChainedInvocationExpression(
                fluentApiInvocation,
                "WithMany",
                new [] {$"many => many.{entityPluralName}"});

            fluentApiInvocation = RoslynGenerationHelpers.GetFluentApiChainedInvocationExpression(
                fluentApiInvocation,
                "HasForeignKey",
                new[] { $"foreign => foreign.{parentEntityRelationship.SingularPropertyName}Id" });

            fluentApiInvocation = RoslynGenerationHelpers.GetFluentApiChainedInvocationExpression(
                fluentApiInvocation,
                "HasPrincipalKey",
                new[] { $"principal => principal.Id" });

            return SyntaxFactory.ExpressionStatement(fluentApiInvocation);
        }

        private StatementSyntax GetRowVersionEfPropertyInvocation()
        {
            var fluentApiInvocation = RoslynGenerationHelpers.GetMethodOnVariableInvocationExpression(
                "builder",
                "Property",
                new[] { $"table => table.RowVersion" },
                false);

            fluentApiInvocation = RoslynGenerationHelpers.GetFluentApiChainedInvocationExpression(
                fluentApiInvocation,
                "IsRowVersion",
                null);

            return SyntaxFactory.ExpressionStatement(fluentApiInvocation);
        }

        private StatementSyntax GetEfPropertyInvocation(PropertyInfoBase propertyInfoBase)
        {
            var fluentApiInvocation = RoslynGenerationHelpers.GetMethodOnVariableInvocationExpression(
                "builder",
                "Property",
                new[] {$"table => table.{propertyInfoBase.Name}"},
                false);

            fluentApiInvocation = CheckRequiredMethodDeclaration(fluentApiInvocation, propertyInfoBase.Optional);
            fluentApiInvocation = CheckDescriptionMethodDeclaration(fluentApiInvocation, propertyInfoBase.Description);
            fluentApiInvocation = CheckHasSqlDefaultValueMethodDeclaration(fluentApiInvocation, propertyInfoBase.SqlDefault);
            fluentApiInvocation = CheckHasComputedColumnSqlMethodDeclaration(fluentApiInvocation, propertyInfoBase.SqlComputedColumn);

            if (propertyInfoBase is ClrStringPropertyInfo stringPropertyInfo)
            {
                fluentApiInvocation = CheckHasMaximumLengthMethodDeclaration(fluentApiInvocation, stringPropertyInfo.MaximumLength);
            }

            if (propertyInfoBase is IPropertyWithRangeAsString propertyWithRange)
            {
                fluentApiInvocation = CheckHasMaximumValueMethodDeclaration(fluentApiInvocation, propertyWithRange.MaximumValueAsString);
                fluentApiInvocation = CheckHasMinimumValueMethodDeclaration(fluentApiInvocation, propertyWithRange.MinimumValueAsString);
            }

            return SyntaxFactory.ExpressionStatement(fluentApiInvocation);
        }

        private ExpressionSyntax CheckHasMaximumLengthMethodDeclaration(ExpressionSyntax fluentApiInvocation, int? maximumLength)
        {
            if (maximumLength.HasValue)
            {
                return RoslynGenerationHelpers.GetFluentApiChainedInvocationExpression(
                    fluentApiInvocation,
                    "HasMaxLength",
                    new[] { maximumLength.ToString() });
            }

            return fluentApiInvocation;
        }

        private ExpressionSyntax CheckHasMinimumValueMethodDeclaration(ExpressionSyntax fluentApiInvocation, string minimumValueAsString)
        {
#if TBC
            if (!string.IsNullOrWhiteSpace(minimumValueAsString))
            {
                return RoslynGenerationHelpers.GetFluentApiChainedInvocationExpression(
                    fluentApiInvocation,
                    "HasMinValue",
                    new[] { minimumValueAsString });
            }
#endif

            return fluentApiInvocation;
        }

        private ExpressionSyntax CheckHasMaximumValueMethodDeclaration(ExpressionSyntax fluentApiInvocation, string maximumValueAsString)
        {
#if TBC
            if (!string.IsNullOrWhiteSpace(maximumValueAsString))
            {
                return RoslynGenerationHelpers.GetFluentApiChainedInvocationExpression(
                    fluentApiInvocation,
                    "HasMaxValue",
                    new[] { maximumValueAsString });
            }
#endif

            return fluentApiInvocation;
        }

        private List<StatementSyntax> GetTableMappingBodyDeclaration(IEntityGenerationModel entityGenerationModel)
        {
            var body = new List<StatementSyntax>();
            GenerateIndexDeclarations(entityGenerationModel, body);

            return body;

            /*
            var fluentApiInvocation = RoslynGenerationHelpers.GetMethodOnVariableInvocationExpression(
                "builder",
                "Property",
                new[] { $"table => table" },
                false);

            fluentApiInvocation = CheckTableNameMethodDeclaration(fluentApiInvocation, entityGenerationModel.)

            if (FeatureFlags?.GenerateSqlDescriptions == true)
            {
                fluentApiInvocation = CheckDescriptionMethodDeclaration(fluentApiInvocation, entityGenerationModel.ClassRemarks);
            }

            // could add SQL triggers here.
            return SyntaxFactory.ExpressionStatement(fluentApiInvocation);
            */
        }

        private static void GenerateIndexDeclarations(IEntityGenerationModel entityGenerationModel, List<StatementSyntax> body)
        {
            var indexes = entityGenerationModel.Indexes;
            if (indexes == null)
            {
                return;
            }

            foreach (var index in indexes)
            {
                var statement = GetIndexDeclarationExpressionStatementSyntax(index);
                body.Add(statement);
            }
        }

        private static ExpressionStatementSyntax GetIndexDeclarationExpressionStatementSyntax(IndexGenerationModel index)
        {
            var propertyNames = index.Properties.Select(prop => prop.Name)
                .ToArray();

            var flattedPropertyNames = string.Join(", ", propertyNames);

            var fluentApiInvocation = RoslynGenerationHelpers.GetMethodOnVariableInvocationExpression(
                "builder",
                "HasIndex",
                [ $"t => new {{ {flattedPropertyNames} }}" ],
                false);


            if (index.IsUnique)
            {
                fluentApiInvocation = RoslynGenerationHelpers.GetFluentApiChainedInvocationExpression(
                    fluentApiInvocation,
                    "IsUnique",
                    []);

            }

            var statement = SyntaxFactory.ExpressionStatement(fluentApiInvocation);
            return statement;
        }

        private ExpressionSyntax CheckHasComputedColumnSqlMethodDeclaration(ExpressionSyntax fluentApiInvocation, string sqlComputedColumn)
        {
            if (sqlComputedColumn == null)
            {
                return fluentApiInvocation;
            }

            // doesn't use isnull or whitespace as ef may not need to (or support) know what is used to calculate

            return RoslynGenerationHelpers.GetFluentApiChainedInvocationExpression(
                fluentApiInvocation,
                "HasDefaultValueSql",
                new[] { sqlComputedColumn });
        }

        private ExpressionSyntax CheckHasSqlDefaultValueMethodDeclaration(ExpressionSyntax fluentApiInvocation, string sqlDefault)
        {
            if (string.IsNullOrWhiteSpace(sqlDefault))
            {
                return fluentApiInvocation;
            }

            return RoslynGenerationHelpers.GetFluentApiChainedInvocationExpression(
                fluentApiInvocation,
                "HasDefaultValueSql",
                new[] { $"\"{sqlDefault}\"" });
        }

        private ExpressionSyntax CheckDescriptionMethodDeclaration(ExpressionSyntax fluentApiInvocation, string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                return fluentApiInvocation;
            }

            return RoslynGenerationHelpers.GetFluentApiChainedInvocationExpression(
                fluentApiInvocation,
                "HasComment",
                new[] { $"\"{description}\"" });
        }

        private ExpressionSyntax CheckRequiredMethodDeclaration(ExpressionSyntax fluentApiInvocation, bool optional)
        {
            if (optional)
            {
                return fluentApiInvocation;
            }

            return RoslynGenerationHelpers.GetFluentApiChainedInvocationExpression(
                fluentApiInvocation,
                "IsRequired",
                null);
        }

        private void DoPrimaryKeyMethodDeclaration(List<StatementSyntax> body)
        {
            var statement = RoslynGenerationHelpers.GetMethodOnVariableInvocationSyntax(
                    "builder",
                    "HasKey",
                    new[] {$"x => x.Id"},
                    false);
            body.Add(statement);
        }
    }
}
