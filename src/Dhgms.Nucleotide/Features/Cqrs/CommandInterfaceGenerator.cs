using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Model;
using Dhgms.Nucleotide.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Features.Cqrs
{
    public sealed class CommandInterfaceGenerator : BaseGenerator
    {
        public CommandInterfaceGenerator(AttributeData attributeData) : base(attributeData)
        {
        }

        protected override string GetClassPrefix() => null;

        protected override string GetClassSuffix() => "Command";

        protected override string GetNamespace() => "Commands";

        protected override PropertyDeclarationSyntax GetPropertyDeclaration(PropertyInfoBase propertyInfo)
        {
            return null;
        }

        protected override PropertyDeclarationSyntax GetReadOnlyPropertyDeclaration(PropertyInfoBase propertyInfo)
        {
            return null;
        }

        protected override PropertyDeclarationSyntax GetPropertyDeclaration(PropertyInfoBase propertyInfo,
            AccessorDeclarationSyntax[] accessorList, IEnumerable<SyntaxTrivia> summary)
        {
            return null;
        }

        protected override async Task<NamespaceDeclarationSyntax> GenerateObjects(NamespaceDeclarationSyntax namespaceDeclaration, EntityGenerationModel[] generationModelEntityGenerationModel)
        {
            if (generationModelEntityGenerationModel == null || generationModelEntityGenerationModel.Length < 1)
            {
                namespaceDeclaration = namespaceDeclaration.WithLeadingTrivia(SyntaxFactory.Comment("#error DROP OUT 2"));
                return namespaceDeclaration;
            }

            var classDeclarations = new List<MemberDeclarationSyntax>();

            var prefix = GetClassPrefix();
            var suffix = GetClassSuffix();
            foreach (var generationModelClassGenerationParameter in generationModelEntityGenerationModel)
            {
                classDeclarations.Add(await GetAddInterfaceDeclarationSyntax(generationModelClassGenerationParameter, prefix, suffix));
                classDeclarations.Add(await GetDeleteInterfaceDeclarationSyntax(generationModelClassGenerationParameter, prefix, suffix));
                classDeclarations.Add(await GetUpdateInterfaceDeclarationSyntax(generationModelClassGenerationParameter, prefix, suffix));
            }

            return await Task.FromResult(namespaceDeclaration.AddMembers(classDeclarations.ToArray()));
        }

        protected string[] GetInterfaceSummary(IEntityGenerationModel entityDeclaration)
        {
            return new[]
            {
                $"{GetClassPrefix()} Command for {entityDeclaration.ClassName}"
            };
        }

        protected PropertyDeclarationSyntax[] GetPropertyDeclarations(IEntityGenerationModel entityGenerationModel)
        {
            return null;
        }

        //protected MethodDeclarationSyntax[] GetMethodDeclarations(string entityName)
        //{
        //    return new[]
        //    {
        //        GetExecuteMethodDeclaration(entityName)
        //    };
        //}

        //protected MethodDeclarationSyntax GetExecuteMethodDeclaration(string entityName)
        //{
        //    var methodName = "ExecuteAsync";

        //    var parameters = GetParams(new[] { GetExecuteRequestParameter(entityName), "System.Security.Claims.ClaimsPrincipal claimsPrincipal" });
        //    var returnType = SyntaxFactory.ParseTypeName("System.Threading.Tasks.Task<string>");
        //    var declaration = SyntaxFactory
        //        .MethodDeclaration(returnType, methodName)
        //        .WithParameterList(parameters)
        //        .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        //    return declaration;
        //}

        private async Task<MemberDeclarationSyntax> GetAddInterfaceDeclarationSyntax(IEntityGenerationModel entityDeclaration, string prefix, string suffix)
        {
            var className = $"IAdd{entityDeclaration.ClassName}{suffix}";
            var members = GetMembers(entityDeclaration);
            var leadingTrivia = GetInterfaceLeadingTrivia(entityDeclaration);
            var declaration = SyntaxFactory.InterfaceDeclaration(className)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddMembers(members)
                .WithLeadingTrivia(leadingTrivia);

            //var baseInterfaces = GetBaseInterfaces(entityDeclaration);
            //if (baseInterfaces != null && baseInterfaces.Length > 0)
            //{
            //    var b = baseInterfaces.Select(bi => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(bi)) as BaseTypeSyntax).ToArray();
            //    declaration = declaration.AddBaseListTypes(b);
            //}

            return await Task.FromResult(declaration);
        }

        private async Task<MemberDeclarationSyntax> GetDeleteInterfaceDeclarationSyntax(IEntityGenerationModel entityDeclaration, string prefix, string suffix)
        {
            var className = $"IDelete{entityDeclaration.ClassName}{suffix}";
            var members = GetMembers(entityDeclaration);
            var leadingTrivia = GetInterfaceLeadingTrivia(entityDeclaration);
            var declaration = SyntaxFactory.InterfaceDeclaration(className)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddMembers(members)
                .WithLeadingTrivia(leadingTrivia);

            //var baseInterfaces = GetBaseInterfaces(entityDeclaration);
            //if (baseInterfaces != null && baseInterfaces.Length > 0)
            //{
            //    var b = baseInterfaces.Select(bi => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(bi)) as BaseTypeSyntax).ToArray();
            //    declaration = declaration.AddBaseListTypes(b);
            //}

            return await Task.FromResult(declaration);
        }

        private async Task<MemberDeclarationSyntax> GetUpdateInterfaceDeclarationSyntax(IEntityGenerationModel entityDeclaration, string prefix, string suffix)
        {
            var className = $"IUpdate{entityDeclaration.ClassName}{suffix}";
            var members = GetMembers(entityDeclaration);
            var leadingTrivia = GetInterfaceLeadingTrivia(entityDeclaration);
            var declaration = SyntaxFactory.InterfaceDeclaration(className)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddMembers(members)
                .WithLeadingTrivia(leadingTrivia);

            //var baseInterfaces = GetBaseInterfaces(entityDeclaration);
            //if (baseInterfaces != null && baseInterfaces.Length > 0)
            //{
            //    var b = baseInterfaces.Select(bi => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(bi)) as BaseTypeSyntax).ToArray();
            //    declaration = declaration.AddBaseListTypes(b);
            //}

            return await Task.FromResult(declaration);
        }

        protected MemberDeclarationSyntax[] GetMembers(IEntityGenerationModel entityGenerationModel)
        {
            var result = new List<MemberDeclarationSyntax>();

            //var properties = GetPropertyDeclarations(entityGenerationModel);
            //AddToList(result, properties);

            //var methods = GetMethodDeclarations(entityGenerationModel.ClassName);
            //AddToList(result, methods);

            return result.ToArray();
        }

        private IEnumerable<SyntaxTrivia> GetInterfaceLeadingTrivia(IEntityGenerationModel entityDeclaration)
        {
            var interfaceSummary = GetInterfaceSummary(entityDeclaration);

            return GetSummary(interfaceSummary);
        }
    }
}
