﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Features.Model;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Model;
using Dhgms.Nucleotide.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Features.Dto
{
    public sealed class ResponseDtoClassGenerator : BaseClassLevelCodeGenerator<ResponseDtoClassFeatureFlags>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnkeyedModelClassGenerator"/> class.
        /// </summary>
        public ResponseDtoClassGenerator(AttributeData attributeData) : base(attributeData)
        {
        }


        protected override bool GetWhetherClassShouldBePartialClass() => true;

        protected override bool GetWhetherClassShouldBeSealedClass() => true;

        protected override IList<string> GetBaseConstructorArguments() => null;

        protected override PropertyDeclarationSyntax[] GetPropertyDeclarations(IEntityGenerationModel entityGenerationModel)
        {
            return null;
        }

        protected override IList<string> GetUsings()
        {
            return null;
        }

        protected override string[] GetClassLevelCommentSummary(string entityName)
        {
            return new[]
            {
                $"Response DTO for {entityName}"
            };
        }

        protected override string[] GetClassLevelCommentRemarks(string entityName)
        {
            return null;
        }

        protected override string[] GetClassPrefixes() => null;

        protected override string GetClassSuffix()
        {
            return "ResponseDto";
        }

        protected override string GetNamespace()
        {
            return "ResponseDtos";
        }

        protected override MethodDeclarationSyntax[] GetMethodDeclarations(IEntityGenerationModel entityGenerationModel)
        {
            return null;
        }

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
            return null;
        }

        protected override IList<Tuple<string, IList<string>>> GetClassAttributes(IEntityGenerationModel entityDeclaration)
        {
            return null;
        }

        protected override async Task<NamespaceDeclarationSyntax> GenerateObjects(NamespaceDeclarationSyntax namespaceDeclaration, IEntityGenerationModel[] generationModelEntityGenerationModel)
        {
            if (generationModelEntityGenerationModel == null || generationModelEntityGenerationModel.Length < 1)
            {
                namespaceDeclaration = namespaceDeclaration.WithLeadingTrivia(SyntaxFactory.Comment("#error DROP OUT 2"));
                return namespaceDeclaration;
            }

            var classDeclarations = new List<MemberDeclarationSyntax>();

            var suffix = GetClassSuffix();
            foreach (var generationModelClassGenerationParameter in generationModelEntityGenerationModel)
            {
                classDeclarations.Add(await GetAddClassDeclarationSyntax(generationModelClassGenerationParameter, suffix));
                classDeclarations.Add(await GetDeleteClassDeclarationSyntax(generationModelClassGenerationParameter, suffix));
                classDeclarations.Add(await GetListClassDeclarationSyntax(generationModelClassGenerationParameter, suffix));
                classDeclarations.Add(await GetUpdateClassDeclarationSyntax(generationModelClassGenerationParameter, suffix));
                classDeclarations.Add(await GetViewClassDeclarationSyntax(generationModelClassGenerationParameter, suffix));
            }

            return await Task.FromResult(namespaceDeclaration.AddMembers(classDeclarations.ToArray()));
        }

        private async Task<MemberDeclarationSyntax> GetAddClassDeclarationSyntax(IEntityGenerationModel entityDeclaration, string suffix)
        {
            var className = $"Add{entityDeclaration.ClassName}{suffix}";
            var members = GetMembers(className, entityDeclaration.ClassName, entityDeclaration);
            var declaration = SyntaxFactory.ClassDeclaration(className)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.SealedKeyword))
                .AddMembers(members);

            var baseClass = GetBaseClass(null);
            if (!string.IsNullOrWhiteSpace(baseClass))
            {
                var b = SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(baseClass));
                declaration = declaration.AddBaseListTypes(b);
            }

            return await Task.FromResult(declaration);
        }

        private async Task<MemberDeclarationSyntax> GetDeleteClassDeclarationSyntax(IEntityGenerationModel entityDeclaration, string suffix)
        {
            var className = $"Delete{entityDeclaration.ClassName}{suffix}";
            var members = GetMembers(className, entityDeclaration.ClassName, entityDeclaration);
            var declaration = SyntaxFactory.ClassDeclaration(className)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.SealedKeyword))
                .AddMembers(members);

            var baseClass = GetBaseClass(null);
            if (!string.IsNullOrWhiteSpace(baseClass))
            {
                var b = SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(baseClass));
                declaration = declaration.AddBaseListTypes(b);
            }

            return await Task.FromResult(declaration);
        }

        private async Task<MemberDeclarationSyntax> GetListClassDeclarationSyntax(IEntityGenerationModel entityDeclaration, string suffix)
        {
            var className = $"List{entityDeclaration.ClassName}{suffix}";
            var members = GetMembers(className, entityDeclaration.ClassName, entityDeclaration);
            var declaration = SyntaxFactory.ClassDeclaration(className)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.SealedKeyword))
                .AddMembers(members);

            var baseClass = GetBaseClass(null);
            if (!string.IsNullOrWhiteSpace(baseClass))
            {
                var b = SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(baseClass));
                declaration = declaration.AddBaseListTypes(b);
            }

            return await Task.FromResult(declaration);
        }

        private async Task<MemberDeclarationSyntax> GetUpdateClassDeclarationSyntax(IEntityGenerationModel entityDeclaration, string suffix)
        {
            var className = $"Update{entityDeclaration.ClassName}{suffix}";
            var members = GetMembers(className, entityDeclaration.ClassName, entityDeclaration);
            var declaration = SyntaxFactory.ClassDeclaration(className)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.SealedKeyword))
                .AddMembers(members);

            var baseClass = GetBaseClass(null);
            if (!string.IsNullOrWhiteSpace(baseClass))
            {
                var b = SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(baseClass));
                declaration = declaration.AddBaseListTypes(b);
            }

            return await Task.FromResult(declaration);
        }

        private async Task<MemberDeclarationSyntax> GetViewClassDeclarationSyntax(IEntityGenerationModel entityDeclaration, string suffix)
        {
            var className = $"View{entityDeclaration.ClassName}{suffix}";
            var members = GetMembers(className, entityDeclaration.ClassName, entityDeclaration);
            var declaration = SyntaxFactory.ClassDeclaration(className)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.SealedKeyword))
                .AddMembers(members);

            var baseClass = GetBaseClass(null);
            if (!string.IsNullOrWhiteSpace(baseClass))
            {
                var b = SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(baseClass));
                declaration = declaration.AddBaseListTypes(b);
            }

            return await Task.FromResult(declaration);
        }

        protected override SeparatedSyntaxList<AttributeSyntax> GetAttributesForProperty(PropertyInfoBase propertyInfo)
        {
            return default(SeparatedSyntaxList<AttributeSyntax>);
        }
    }
}