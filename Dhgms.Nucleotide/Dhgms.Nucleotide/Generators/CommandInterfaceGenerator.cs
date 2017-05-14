using System;
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
    /// <summary>
    /// Generator for Command Interface
    /// </summary>
    public sealed class CommandInterfaceGenerator : BaseInterfaceLevelCodeGenerator
    {
        public CommandInterfaceGenerator(AttributeData attributeData) : base(attributeData)
        {
        }

        protected override string GetClassSuffix()
        {
            return "Command";
        }

        protected override string GetNamespace()
        {
            return "Commands";
        }

        protected override MethodDeclarationSyntax[] GetMethodDeclarations(string entityName)
        {
            return new[]
            {
                GetExecuteMethodDeclaration()
            };
        }

        protected override FieldDeclarationSyntax[] GetFieldDeclarations(IClassGenerationParameters classGenerationParameters)
        {
            return null;
        }

        protected override PropertyDeclarationSyntax[] GetPropertyDeclarations(PropertyInfoBase[] properties)
        {
            return null;
        }

        private MethodDeclarationSyntax GetExecuteMethodDeclaration()
        {
            var methodName = "ExecuteAsync";

            var returnType = SyntaxFactory.ParseTypeName($"System.Threading.Tasks.Task<string>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
            return declaration;
        }

        protected override string[] GetBaseInterfaces()
        {
            return null;
        }

        protected override async Task<NamespaceDeclarationSyntax> GenerateInterfaces(NamespaceDeclarationSyntax namespaceDeclaration, ClassGenerationParameters[] generationModelClassGenerationParameters)
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
                classDeclarations.Add(await GetAddCommandInterfaceDeclarationSyntax(generationModelClassGenerationParameter, suffix));
                classDeclarations.Add(await GetDeleteCommandInterfaceDeclarationSyntax(generationModelClassGenerationParameter, suffix));
                classDeclarations.Add(await GetUpdateCommandInterfaceDeclarationSyntax(generationModelClassGenerationParameter, suffix));
            }

            return await Task.FromResult(namespaceDeclaration.AddMembers(classDeclarations.ToArray()));
        }

        //protected override async Task<MemberDeclarationSyntax> GetInterfaceDeclarationSyntax(IClassGenerationParameters classDeclaration, string suffix)
        //{
        //    var className = $"I{classDeclaration.ClassName}{suffix}";
        //    var members = GetMembers(classDeclaration.ClassName);
        //    var declaration = SyntaxFactory.InterfaceDeclaration(className)
        //        .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
        //        .AddMembers(members);

        //    var baseInterfaces = GetBaseInterfaces();
        //    if (baseInterfaces != null && baseInterfaces.Length > 0)
        //    {
        //        var b = baseInterfaces.Select(bi => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(bi)) as BaseTypeSyntax).ToArray();
        //        declaration = declaration.AddBaseListTypes(b);
        //    }

        //    return await Task.FromResult(declaration);
        //}

        private async Task<MemberDeclarationSyntax> GetAddCommandInterfaceDeclarationSyntax(IClassGenerationParameters classDeclaration, string suffix)
        {
            var className = $"IAdd{classDeclaration.ClassName}{suffix}";
            var members = GetMembers(classDeclaration.ClassName);
            var declaration = SyntaxFactory.InterfaceDeclaration(className)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddMembers(members);

            var baseInterfaces = GetBaseInterfaces();
            if (baseInterfaces != null && baseInterfaces.Length > 0)
            {
                var b = baseInterfaces.Select(bi => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(bi)) as BaseTypeSyntax).ToArray();
                declaration = declaration.AddBaseListTypes(b);
            }

            return await Task.FromResult(declaration);
        }

        private async Task<MemberDeclarationSyntax> GetDeleteCommandInterfaceDeclarationSyntax(IClassGenerationParameters classDeclaration, string suffix)
        {
            var className = $"IDelete{classDeclaration.ClassName}{suffix}";
            //var members = GetMembers(classDeclaration.ClassName);
            var declaration = SyntaxFactory.InterfaceDeclaration(className)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));
            //.AddMembers(members);

            var baseInterfaces = GetBaseInterfaces();
            if (baseInterfaces != null && baseInterfaces.Length > 0)
            {
                var b = baseInterfaces.Select(bi => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(bi)) as BaseTypeSyntax).ToArray();
                declaration = declaration.AddBaseListTypes(b);
            }

            return await Task.FromResult(declaration);
        }

        private async Task<MemberDeclarationSyntax> GetUpdateCommandInterfaceDeclarationSyntax(IClassGenerationParameters classDeclaration, string suffix)
        {
            var className = $"IUpdate{classDeclaration.ClassName}{suffix}";
            //var members = GetMembers(classDeclaration.ClassName);
            var declaration = SyntaxFactory.InterfaceDeclaration(className)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));
            //.AddMembers(members);

            var baseInterfaces = GetBaseInterfaces();
            if (baseInterfaces != null && baseInterfaces.Length > 0)
            {
                var b = baseInterfaces.Select(bi => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(bi)) as BaseTypeSyntax).ToArray();
                declaration = declaration.AddBaseListTypes(b);
            }

            return await Task.FromResult(declaration);
        }
    }
}
