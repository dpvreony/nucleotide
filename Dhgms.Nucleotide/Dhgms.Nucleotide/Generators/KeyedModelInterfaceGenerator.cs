﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeGeneration.Roslyn;
using Dhgms.Nucleotide.Model;
using Dhgms.Nucleotide.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Validation;

namespace Dhgms.Nucleotide.Generators
{
    public sealed class KeyedModelInterfaceGenerator : BaseInterfaceLevelCodeGenerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyedModelInterfaceGenerator"/> class. 
        /// </summary>
        public KeyedModelInterfaceGenerator(AttributeData attributeData) : base(attributeData)
        {
        }

        protected override string GetClassSuffix()
        {
            return "Model";
        }

        protected override string GetNamespace()
        {
            return "Models";
        }

        protected override string GetClassPrefix()
        {
            return null;
        }

        protected override FieldDeclarationSyntax[] GetFieldDeclarations(IClassGenerationParameters classGenerationParameters)
        {
            return null;
        }

        protected override PropertyDeclarationSyntax[] GetPropertyDeclarations(PropertyInfoBase[] properties)
        {
            var idColumn = new Integer32PropertyInfo(
                CollectionType.None,
                "Id",
                "Unique Identifier for the object",
                false,
                1,
                int.MaxValue,
                true,
                null);

            return new []
            {
                GetPropertyDeclaration(idColumn)
            };
        }

        private PropertyDeclarationSyntax GetPropertyDeclaration(PropertyInfoBase propertyInfo)
        {
            var type = SyntaxFactory.ParseName(propertyInfo.NetDataType);
            var identifier = propertyInfo.Name;
            var result = SyntaxFactory.PropertyDeclaration(type, identifier)
                .WithAccessorList(
                    SyntaxFactory.AccessorList(
                        SyntaxFactory.List(new []
                        {
                            SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                                .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                            SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                                .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
                        }
                            )));

            return result;
        }

        protected override MethodDeclarationSyntax[] GetMethodDeclarations(string entityName)
        {
            return null;
        }

        protected override string[] GetBaseInterfaces(IClassGenerationParameters classGenerationParameters)
        {
            return new []
            {
                $"IUnkeyed{classGenerationParameters.ClassName}Model"
            };
        }

        private MemberDeclarationSyntax[] GetMembers()
        {
            var members = GetUnkeyedInterfaces()
                .Concat(GetKeyedInterfaces())
                .ToArray();

            return members;
        }

        private MemberDeclarationSyntax[] GetUnkeyedInterfaces()
        {
            var name = "Test";

            var leadingTrivia = new[]
            {
                SyntaxFactory.Comment($"/// <summary>Interface for the Unkeyed {name} model. Typically used for adding a new record.</summary>"),
            };

            return new MemberDeclarationSyntax[]
            {
                SyntaxFactory.InterfaceDeclaration($"IUnkeyed{name}Model")
                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                    .WithLeadingTrivia(leadingTrivia)
            };
        }

        private MemberDeclarationSyntax[] GetKeyedInterfaces()
        {
            var name = "Test";

            var leadingTrivia = new[]
            {
                SyntaxFactory.Comment($"/// <summary>Interface for the {name} model.</summary>"),
            };

            var baseTypes = new BaseTypeSyntax[]
            {
                SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"IUnkeyed{name}Model"))
            };

            var accessor = new[]
            {
                SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                //SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                //.WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
                //.AddModifiers(SyntaxFactory.Token(SyntaxKind.ProtectedKeyword))
            };

            var members = new MemberDeclarationSyntax[]
            {
                SyntaxFactory.PropertyDeclaration(SyntaxFactory.ParseTypeName("long"), "Id").AddAccessorListAccessors(accessor)
            };

            return new MemberDeclarationSyntax[]
            {

                SyntaxFactory.InterfaceDeclaration($"I{name}Model")
                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                    .AddBaseListTypes(baseTypes)
                    .AddMembers(members)
                    .WithLeadingTrivia(leadingTrivia)
            };
        }
    }
}