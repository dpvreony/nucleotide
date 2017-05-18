using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Model;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators
{
    public sealed class RequestDtoClassGenerator : BaseClassLevelCodeGenerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnkeyedModelClassGenerator"/> class. 
        /// </summary>
        public RequestDtoClassGenerator(AttributeData attributeData) : base(attributeData)
        {
        }

        protected override string GetClassPrefix()
        {
            return null;
        }

        protected override string GetClassSuffix()
        {
            return "RequestDto";
        }

        protected override string GetNamespace()
        {
            return "RequestDtos";
        }

        protected override MemberDeclarationSyntax[] GetMethodDeclarations(string entityName)
        {
            return null;
        }

        protected override string[] GetClassLevelCommentSummary(string entityName)
        {
            return new[]
            {
                $"Request DTO for {entityName}"
            };
        }

        protected override string[] GetClassLevelCommentRemarks(string entityName)
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

        protected override List<Tuple<string, IList<string>>> GetClassAttributes()
        {
            return null;
        }

        protected override async Task<NamespaceDeclarationSyntax> GenerateClasses(NamespaceDeclarationSyntax namespaceDeclaration, ClassGenerationParameters[] generationModelClassGenerationParameters)
        {
            if (generationModelClassGenerationParameters == null || generationModelClassGenerationParameters.Length < 1)
            {
                namespaceDeclaration = namespaceDeclaration.WithLeadingTrivia(SyntaxFactory.Comment("#error DROP OUT 2"));
                return namespaceDeclaration;
            }

            var classDeclarations = new List<MemberDeclarationSyntax>();

            var suffix = GetClassSuffix();
            foreach (var generationModelClassGenerationParameter in generationModelClassGenerationParameters)
            {
                classDeclarations.Add(await GetAddClassDeclarationSyntax(generationModelClassGenerationParameter, suffix));
                classDeclarations.Add(await GetListClassDeclarationSyntax(generationModelClassGenerationParameter, suffix));
                classDeclarations.Add(await GetUpdateClassDeclarationSyntax(generationModelClassGenerationParameter, suffix));
            }

            return await Task.FromResult(namespaceDeclaration.AddMembers(classDeclarations.ToArray()));
        }

        private async Task<MemberDeclarationSyntax> GetAddClassDeclarationSyntax(IClassGenerationParameters classDeclaration, string suffix)
        {
            var className = $"Add{classDeclaration.ClassName}{suffix}";
            var members = GetMembers(className, classDeclaration.ClassName);
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

        private async Task<MemberDeclarationSyntax> GetListClassDeclarationSyntax(IClassGenerationParameters classDeclaration, string suffix)
        {
            var className = $"List{classDeclaration.ClassName}{suffix}";
            var members = GetMembers(className, classDeclaration.ClassName);
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

        private async Task<MemberDeclarationSyntax> GetUpdateClassDeclarationSyntax(IClassGenerationParameters classDeclaration, string suffix)
        {
            var className = $"Update{classDeclaration.ClassName}{suffix}";
            var members = GetMembers(className, classDeclaration.ClassName);
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
    }
}
