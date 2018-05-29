using System;
using System.Collections.Generic;
using System.Linq;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Model;
using Dhgms.Nucleotide.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Features.EntityFramework
{
    public sealed class EntityFrameworkModelGenerator : BaseClassLevelCodeGenerator
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

        protected override MethodDeclarationSyntax[] GetMethodDeclarations(string entityName)
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

            if (propertyInfo is ClrStringPropertyInfo stringPropertyInfo)
            {
                AddStringAttributes(nodes, stringPropertyInfo);
            }

            var result = SyntaxFactory.SeparatedList(nodes);

            return result;
        }

        private void AddStringAttributes(List<AttributeSyntax> nodes, ClrStringPropertyInfo stringPropertyInfo)
        {
            if (stringPropertyInfo.MaximumLength.HasValue)
            {
                var argumentList = GetAttributeArgumentListSyntax(new List<string>
                {
                    stringPropertyInfo.MaximumLength.Value.ToString()
                });

                nodes.Add(SyntaxFactory.Attribute(SyntaxFactory.ParseName("MaxLength"), argumentList));
            }

            if (stringPropertyInfo.MinimumLength.HasValue)
            {
                var argumentList = GetAttributeArgumentListSyntax(new List<string>
                {
                    stringPropertyInfo.MinimumLength.Value.ToString()
                });

                nodes.Add(SyntaxFactory.Attribute(SyntaxFactory.ParseName("MinLength"), argumentList));
            }
        }
    }
}
