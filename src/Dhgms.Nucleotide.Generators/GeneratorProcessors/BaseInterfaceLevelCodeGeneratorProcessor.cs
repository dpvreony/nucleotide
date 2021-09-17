using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.Generators.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.GeneratorProcessors
{
    public abstract class BaseInterfaceLevelCodeGeneratorProcessor<TGenerationModel> : BaseGeneratorProcessor<TGenerationModel>
        where TGenerationModel : IClassName
    {
        public override NamespaceDeclarationSyntax GenerateObjects(
            NamespaceDeclarationSyntax namespaceDeclaration,
            INucleotideGenerationModel<TGenerationModel> nucleotideGenerationModel)
        {
            var generationModelEntityGenerationModel = nucleotideGenerationModel.EntityGenerationModel;

            if (generationModelEntityGenerationModel == null || generationModelEntityGenerationModel.Length < 1)
            {
                namespaceDeclaration = namespaceDeclaration.WithLeadingTrivia(SyntaxFactory.Comment("#error DROP OUT 2"));
                return namespaceDeclaration;
            }

            var classDeclarations = new List<MemberDeclarationSyntax>();

            var prefixes = GetClassPrefixes();
            if (prefixes == null || prefixes.Length == 0)
            {
                prefixes = new[] { string.Empty };
            }

            var suffix = GetClassSuffix();
            foreach (var generationModelClassGenerationParameter in generationModelEntityGenerationModel)
            {
                foreach (var prefix in prefixes)
                {
                    classDeclarations.Add(GetInterfaceDeclarationSyntax(generationModelClassGenerationParameter, prefix, suffix));
                }

            }

            return namespaceDeclaration.AddMembers(classDeclarations.ToArray());
        }

        protected abstract string GetClassSuffix();

        protected virtual MemberDeclarationSyntax GetInterfaceDeclarationSyntax(TGenerationModel entityDeclaration, string prefix, string suffix)
        {
            var className = $"I{prefix}{entityDeclaration.ClassName}{suffix}";
            var members = GetMembers(entityDeclaration, prefix);
            var leadingTrivia = GetInterfaceLeadingTrivia(entityDeclaration);
            var declaration = SyntaxFactory.InterfaceDeclaration(className)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddMembers(members)
                .WithLeadingTrivia(leadingTrivia);

            var baseInterfaces = GetBaseInterfaces(entityDeclaration, prefix);
            if (baseInterfaces != null && baseInterfaces.Length > 0)
            {
                var b = baseInterfaces.Select(bi => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(bi)) as BaseTypeSyntax).ToArray();
                declaration = declaration.AddBaseListTypes(b);
            }

            return declaration;
        }

        protected abstract string[] GetInterfaceSummary(TGenerationModel entityDeclaration);

        protected MemberDeclarationSyntax[] GetMembers(TGenerationModel entityGenerationModel, string prefix)
        {
            var result = new List<MemberDeclarationSyntax>();

            var properties = GetPropertyDeclarations(entityGenerationModel, prefix);
            AddToList(result, properties);

            var methods = GetMethodDeclarations(entityGenerationModel.ClassName, prefix);
            AddToList(result, methods);

            return result.ToArray();
        }

        protected abstract PropertyDeclarationSyntax[] GetPropertyDeclarations(
            TGenerationModel entityGenerationModel, string prefix);

        /// <summary>
        /// Gets the method declarations to be generated
        /// </summary>
        /// <returns></returns>
        protected abstract MethodDeclarationSyntax[] GetMethodDeclarations(string className, string prefix);

        /// <summary>
        /// Gets the base class, if any
        /// </summary>
        /// <returns>Base class</returns>
        protected abstract string[] GetBaseInterfaces(TGenerationModel entityGenerationModel, string prefix);

        protected override PropertyDeclarationSyntax GetPropertyDeclaration(PropertyInfoBase propertyInfo)
        {
            var accessorList = new[]
            {
                SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
            };

            var summary = GetSummary(new[] { $"Gets or sets {propertyInfo.Name}" });

            return GetPropertyDeclaration(propertyInfo, accessorList, summary);
        }

        protected override PropertyDeclarationSyntax GetReadOnlyPropertyDeclaration(PropertyInfoBase propertyInfo)
        {
            var accessorList = new[]
            {
                SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
            };

            var summary = GetSummary(new[] { $"Gets {propertyInfo.Name}" });

            return GetPropertyDeclaration(propertyInfo, accessorList, summary);
        }

        protected override PropertyDeclarationSyntax GetPropertyDeclaration(PropertyInfoBase propertyInfo, AccessorDeclarationSyntax[] accessorList, IEnumerable<SyntaxTrivia> summary)
        {
            var type = SyntaxFactory.ParseName(propertyInfo.NetDataType);
            var identifier = propertyInfo.Name;
            var result = SyntaxFactory.PropertyDeclaration(type, identifier)
                .WithAccessorList(
                    SyntaxFactory.AccessorList(
                        SyntaxFactory.List(accessorList)
                    ))
                .WithLeadingTrivia(summary);

            return result;
        }

        private IEnumerable<SyntaxTrivia> GetInterfaceLeadingTrivia(TGenerationModel entityDeclaration)
        {
            var interfaceSummary = GetInterfaceSummary(entityDeclaration);

            return GetSummary(interfaceSummary);
        }
    }
}
