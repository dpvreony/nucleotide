using System;
using System.Collections.Generic;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.Generators.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.EntityFramework
{
    public class EntityFrameworkEntityTypeConfigurationGeneratorProcessor : BaseClassLevelCodeGeneratorProcessor<IEntityGenerationModel>
    {
        ///<inheritdoc />
        protected override bool GetWhetherClassShouldBePartialClass() => false;

        ///<inheritdoc />
        protected override bool GetWhetherClassShouldBeSealedClass() => true;

        ///<inheritdoc />
        protected override PropertyDeclarationSyntax[] GetPropertyDeclarations(IEntityGenerationModel entityGenerationModel)
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
        protected override MethodDeclarationSyntax[] GetMethodDeclarations(IEntityGenerationModel entityGenerationModel)
        {
            var result = new List<MethodDeclarationSyntax>()
            {
                GetConfigureMethodDeclaration(entityGenerationModel),
            };

            var entityName = entityGenerationModel.ClassName;
            result.Add(GetTableMappingMethodDeclaration(entityName, entityGenerationModel));

            foreach (var propertyInfoBase in entityGenerationModel.Properties)
            {
                result.Add(GetPropertyMappingMethodDeclaration(entityName, propertyInfoBase));
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
        protected override IList<Tuple<string, IList<string>>> GetClassAttributes(IEntityGenerationModel entityDeclaration)
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
        protected override string GetBaseClass(string entityName)
        {
            return null;
        }

        ///<inheritdoc />
        protected override IList<string> GetImplementedInterfaces(string entityName)
        {
            return new List<string>
            {
                $"IEntityTypeConfiguration<EfModels.{entityName}EfModel>"
            };
        }

        ///<inheritdoc />
        protected override string[] GetClassPrefixes() => null;

        ///<inheritdoc />
        protected override SeparatedSyntaxList<AttributeSyntax> GetAttributesForProperty(PropertyInfoBase propertyInfo)
        {
            return default(SeparatedSyntaxList<AttributeSyntax>);
        }

        private MethodDeclarationSyntax GetConfigureMethodDeclaration(IEntityGenerationModel entityGenerationModel)
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
            foreach (var propertyInfo in entityGenerationModel.Properties)
            {
                var configureColumnMethodName = $"Configure{propertyInfo.Name}Column";
                var expression =
                    RoslynGenerationHelpers.GetMethodOnClassInvocationSyntax(
                        configureColumnMethodName,
                        subMethodParams,
                        false);
                var statement = SyntaxFactory.ExpressionStatement(expression);
                body.Add(statement);
            }

            var parameters = GetParams(new []{ $"Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<EfModels.{entityName}EfModel> builder"});

            var returnType = SyntaxFactory.ParseTypeName("void");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName)
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddBodyStatements(body.ToArray());
            return declaration;
        }

        private MethodDeclarationSyntax GetPropertyMappingMethodDeclaration(
            string entityName,
            PropertyInfoBase propertyInfoBase)
        {
            var methodName = $"Configure{propertyInfoBase.Name}Column";

            var body = new List<StatementSyntax>();
            CheckPrimaryKeyMethodDeclaration(body, propertyInfoBase);

            // get the initial property method invoke to use as the basis of chaining others together
            var propertyInvocation = GetEfPropertyInvocation(propertyInfoBase);
            body.Add(propertyInvocation);


            var parameters = GetParams(new[] { $"Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<EfModels.{entityName}EfModel> builder" });

            var returnType = SyntaxFactory.ParseTypeName("void");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName)
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddBodyStatements(body.ToArray());
            return declaration;
        }

        private MethodDeclarationSyntax GetTableMappingMethodDeclaration(
            string entityName,
            IEntityGenerationModel entityGenerationModel)
        {
            var methodName = $"ConfigureTable";

            var body = new List<StatementSyntax>();

            //var tableInvocation = GetEfTableInvocation(entityGenerationModel);
            //body.Add(tableInvocation);

            var parameters = GetParams(new[] { $"Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<EfModels.{entityName}EfModel> builder" });

            var returnType = SyntaxFactory.ParseTypeName("void");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName)
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddBodyStatements(body.ToArray());
            return declaration;
        }

        private StatementSyntax GetEfPropertyInvocation(PropertyInfoBase propertyInfoBase)
        {
            var fluentApiInvocation = RoslynGenerationHelpers.GetMethodOnVariableInvocationExpression(
                "builder",
                "Property",
                new[] {$"table => table.{propertyInfoBase.Name}"},
                false);

            fluentApiInvocation = CheckRequiredMethodDeclaration(fluentApiInvocation, propertyInfoBase.Optional);
#if TBC
            if (FeatureFlags?.GenerateSqlDescriptions == true)
            {
                fluentApiInvocation = CheckDescriptionMethodDeclaration(fluentApiInvocation, propertyInfoBase.Description);
            }
#endif
            fluentApiInvocation = CheckHasSqlDefaultValueMethodDeclaration(fluentApiInvocation, propertyInfoBase.SqlDefault);
            fluentApiInvocation = CheckHasComputedColumnSqlMethodDeclaration(fluentApiInvocation, propertyInfoBase.SqlComputedColumn);

            return SyntaxFactory.ExpressionStatement(fluentApiInvocation);
        }

        private StatementSyntax GetEfTableInvocation(IEntityGenerationModel entityGenerationModel)
        {
            throw new NotImplementedException();
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
                "HasDescriptionSql",
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

        private void CheckPrimaryKeyMethodDeclaration(List<StatementSyntax> body, PropertyInfoBase propertyInfoBase)
        {
            if (!propertyInfoBase.IsKey)
            {
                return;
            }

            var statement =
                RoslynGenerationHelpers.GetMethodOnVariableInvocationSyntax(
                    "builder",
                    "HasKey",
                    new[] {$"x => x.{propertyInfoBase.Name}"}, false);
            body.Add(statement);
        }
    }
}
