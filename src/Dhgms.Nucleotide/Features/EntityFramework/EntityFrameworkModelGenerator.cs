using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    public sealed class EntityFrameworkModelGenerator : BaseClassLevelCodeGenerator<EntityFrameworkModelFeatureFlags>
    {
        public EntityFrameworkModelGenerator(AttributeData attributeData) : base(attributeData)
        {
        }

        protected override bool GetWhetherClassShouldBePartialClass() => true;

        protected override bool GetWhetherClassShouldBeSealedClass() => true;


        protected override PropertyDeclarationSyntax[] GetPropertyDeclarations(IEntityGenerationModel entityGenerationModel)
        {
            return entityGenerationModel.Properties?.Select(GetPropertyDeclaration).ToArray();
        }

        protected override PropertyDeclarationSyntax GetPropertyDeclaration(PropertyInfoBase propertyInfo, AccessorDeclarationSyntax[] accessorList, IEnumerable<SyntaxTrivia> summary)
        {
            var type = SyntaxFactory.ParseName(propertyInfo.NetDataType);
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

        protected override string GetClassSuffix()
        {
            return "EfModel";
        }

        protected override string GetNamespace()
        {
            return "EfModels";
        }

        protected override MethodDeclarationSyntax[] GetMethodDeclarations(IEntityGenerationModel entityGenerationModel)
        {
            return null;
        }

        protected override IList<string> GetUsings()
        {
            return new List<string>
            {
                "System.ComponentModel.DataAnnotations"
            };
        }

        protected override string[] GetClassLevelCommentSummary(string entityName)
        {
            return new[]
            {
                $"Entity Framework Model for {entityName}"
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
            return $"Models.{entityName}Model";
        }

        protected override IList<string> GetImplementedInterfaces(string entityName)
        {
            return null;
        }

        protected override string[] GetClassPrefixes() => null;

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
