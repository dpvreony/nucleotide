using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dhgms.Nucleotide.Features.AttributeGenerators;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Helpers;
using Dhgms.Nucleotide.Model;
using Dhgms.Nucleotide.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Features.EntityFramework
{
    public class EntityFrameworkEntityTypeConfigurationGenerator : BaseClassLevelCodeGenerator
    {
        public EntityFrameworkEntityTypeConfigurationGenerator(AttributeData attributeData) : base(attributeData)
        {
        }

        protected override bool GetWhetherClassShouldBePartialClass() => false;

        protected override bool GetWhetherClassShouldBeSealedClass() => true;


        protected override PropertyDeclarationSyntax[] GetPropertyDeclarations(IEntityGenerationModel entityGenerationModel)
        {
            return Array.Empty<PropertyDeclarationSyntax>();
        }

        protected override PropertyDeclarationSyntax GetPropertyDeclaration(PropertyInfoBase propertyInfo, AccessorDeclarationSyntax[] accessorList, IEnumerable<SyntaxTrivia> summary)
        {
            return null;
        }

        protected override string GetClassSuffix()
        {
            return "EntityTypeConfiguration";
        }

        protected override string GetNamespace()
        {
            return "EntityTypeConfigurations";
        }

        protected override MethodDeclarationSyntax[] GetMethodDeclarations(IEntityGenerationModel entityGenerationModel)
        {
            var result = new List<MethodDeclarationSyntax>()
            {
                GetConfigureMethodDeclaration(entityGenerationModel),
            };

            var entityName = entityGenerationModel.ClassName;
            foreach (var propertyInfoBase in entityGenerationModel.Properties)
            {
                result.Add(GetPropertyMappingMethodDeclaration(entityName ,propertyInfoBase));
            }

            return result.ToArray();
        }

        protected override IList<string> GetUsings()
        {
            return new List<string>()
            {
                "Microsoft.EntityFrameworkCore"
            };
        }

        protected override string[] GetClassLevelCommentSummary(string entityName)
        {
            return new[]
            {
                $"Entity Framework Entity Type Configuration for {entityName}Ef Model"
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

        protected override IList<string> GetBaseConstructorArguments() => null;

        protected override IList<Tuple<Func<string, string>, string, Accessibility>> GetConstructorArguments()
        {
            return null;
        }

        protected override string GetBaseClass(string entityName)
        {
            return null;
        }

        protected override IList<string> GetImplementedInterfaces(string entityName)
        {
            return new List<string>
            {
                $"IEntityTypeConfiguration<EfModels.{entityName}EfModel>"
            };
        }

        protected override string[] GetClassPrefixes() => null;

        protected override SeparatedSyntaxList<AttributeSyntax> GetAttributesForProperty(PropertyInfoBase propertyInfo)
        {
            return default(SeparatedSyntaxList<AttributeSyntax>);
        }

        private MethodDeclarationSyntax GetConfigureMethodDeclaration(IEntityGenerationModel entityGenerationModel)
        {
            var entityName = entityGenerationModel.ClassName;
            var methodName = $"Configure";

            var body = new List<StatementSyntax>();

            foreach (var propertyInfo in entityGenerationModel.Properties)
            {
                var configureColumnMethodName = $"Configure{propertyInfo.Name}Column";
                var expression =
                    RoslynGenerationHelpers.GetMethodOnClassInvocationSyntax(configureColumnMethodName,
                        new[] {"builder"}, false);
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

            var body = new StatementSyntax[]
            {
            };

            var parameters = GetParams(new []{ $"Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<EfModels.{entityName}EfModel> builder"});

            var returnType = SyntaxFactory.ParseTypeName("void");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName)
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddBodyStatements(body);
            return declaration;
        }

    }
}
