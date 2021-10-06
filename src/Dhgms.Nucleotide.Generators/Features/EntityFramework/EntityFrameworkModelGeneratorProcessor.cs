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
        protected override PropertyDeclarationSyntax[] GetPropertyDeclarations(EntityFrameworkModelEntityGenerationModel entityGenerationModel)
        {
            return entityGenerationModel.Properties?.Select(GetPropertyDeclaration).ToArray();
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
            return $"Models.{entityName}Model";
        }

        ///<inheritdoc />
        protected override IList<string> GetImplementedInterfaces(string entityName)
        {
            return null;
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