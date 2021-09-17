﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.Generators.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.Dto
{
    public sealed class RequestDtoClassGeneratorProcessor : BaseClassLevelCodeGeneratorProcessor<IEntityGenerationModel>
    {
        protected override bool GetWhetherClassShouldBePartialClass() => true;

        protected override bool GetWhetherClassShouldBeSealedClass() => true;

        protected override IList<string> GetBaseConstructorArguments() => Array.Empty<string>();

        protected override IList<string> GetUsings() => Array.Empty<string>();

        protected override string[] GetClassPrefixes() => Array.Empty<string>();

        protected override string GetClassSuffix() => "RequestDto";

        protected override MethodDeclarationSyntax[] GetMethodDeclarations(IEntityGenerationModel entityGenerationModel) => Array.Empty<MethodDeclarationSyntax>();

        protected override PropertyDeclarationSyntax[] GetPropertyDeclarations(IEntityGenerationModel entityGenerationModel) => Array.Empty<PropertyDeclarationSyntax>();

        protected override string[] GetClassLevelCommentSummary(string entityName)
        {
            return new[]
            {
                $"Request DTO for {entityName}"
            };
        }

        protected override string[] GetClassLevelCommentRemarks(string entityName) => Array.Empty<string>();

        protected override IList<Tuple<Func<string, string>, string, Accessibility>> GetConstructorArguments() => Array.Empty<Tuple<Func<string, string>, string, Accessibility>>();

        protected override string GetBaseClass(string entityName) => null;

        protected override IList<string> GetImplementedInterfaces(string entityName) => Array.Empty<string>();

        protected override IList<Tuple<string, IList<string>>> GetClassAttributes(IEntityGenerationModel entityDeclaration)
        {
            return Array.Empty<Tuple<string, IList<string>>>();
        }

        public override NamespaceDeclarationSyntax GenerateObjects(
            NamespaceDeclarationSyntax namespaceDeclaration,
            INucleotideGenerationModel<IEntityGenerationModel> nucleotideGenerationModel)
        {
            var generationModelEntityGenerationModel = nucleotideGenerationModel.EntityGenerationModel;

            if (generationModelEntityGenerationModel == null || generationModelEntityGenerationModel.Length < 1)
            {
                namespaceDeclaration = namespaceDeclaration.WithLeadingTrivia(SyntaxFactory.Comment("#error DROP OUT 2"));
                return namespaceDeclaration;
            }

            var classDeclarations = new List<MemberDeclarationSyntax>();

            var suffix = GetClassSuffix();
            foreach (var generationModelClassGenerationParameter in generationModelEntityGenerationModel)
            {
                classDeclarations.Add(GetAddClassDeclarationSyntax(generationModelClassGenerationParameter, suffix));
                classDeclarations.Add(GetDeleteClassDeclarationSyntax(generationModelClassGenerationParameter, suffix));
                classDeclarations.Add(GetListClassDeclarationSyntax(generationModelClassGenerationParameter, suffix));
                classDeclarations.Add(GetViewClassDeclarationSyntax(generationModelClassGenerationParameter, suffix));
                classDeclarations.Add(GetUpdateClassDeclarationSyntax(generationModelClassGenerationParameter, suffix));
            }

            return namespaceDeclaration.AddMembers(classDeclarations.ToArray());
        }

        private MemberDeclarationSyntax GetAddClassDeclarationSyntax(IEntityGenerationModel entityDeclaration, string suffix)
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

            return declaration;
        }

        private MemberDeclarationSyntax GetDeleteClassDeclarationSyntax(IEntityGenerationModel entityDeclaration, string suffix)
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

            return declaration;
        }

        private MemberDeclarationSyntax GetListClassDeclarationSyntax(IEntityGenerationModel entityDeclaration, string suffix)
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

            return declaration;
        }

        private MemberDeclarationSyntax GetViewClassDeclarationSyntax(IEntityGenerationModel entityDeclaration, string suffix)
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

            return declaration;
        }

        private MemberDeclarationSyntax GetUpdateClassDeclarationSyntax(IEntityGenerationModel entityDeclaration, string suffix)
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

            return declaration;
        }

        protected override SeparatedSyntaxList<AttributeSyntax> GetAttributesForProperty(PropertyInfoBase propertyInfo)
        {
            return default(SeparatedSyntaxList<AttributeSyntax>);
        }
    }
}
