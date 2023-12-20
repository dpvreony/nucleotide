// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.Generators.PropertyInfo;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Dhgms.Nucleotide.Generators.Features.EntityFramework
{
    /// <summary>
    /// Code Generator for Entity Framework Injectable Model Creator.
    /// </summary>
    public sealed class EntityFrameworkMsSqlModelCreatorGeneratorProcessor : BaseGeneratorProcessor<EntityFrameworkDbContextGenerationModel>
    {
        ///<inheritdoc />
        public override NamespaceDeclarationSyntax GenerateObjects(
            NamespaceDeclarationSyntax namespaceDeclaration,
            INucleotideGenerationModel<EntityFrameworkDbContextGenerationModel> nucleotideGenerationModel)
        {
            var generationModelEntityGenerationModel = nucleotideGenerationModel.EntityGenerationModel;

            if (generationModelEntityGenerationModel == null || generationModelEntityGenerationModel.Length < 1)
            {
                namespaceDeclaration = namespaceDeclaration.WithLeadingTrivia(SyntaxFactory.Comment("#error DROP OUT 2"));
                return namespaceDeclaration;
            }

            var classDeclarations = new List<MemberDeclarationSyntax>();

            var suffix = GetClassSuffix();

            foreach (var entityFrameworkDbContextGenerationModel in generationModelEntityGenerationModel)
            {
                classDeclarations.Add(GetClassDeclarationSyntax(entityFrameworkDbContextGenerationModel, suffix));
            }


            var usings = GetUsingDirectives();
            namespaceDeclaration = namespaceDeclaration.AddUsings(usings);

            namespaceDeclaration = namespaceDeclaration.AddMembers(classDeclarations.ToArray());

            return namespaceDeclaration;
        }

        private MemberDeclarationSyntax[] GetMembers(string className, EntityGenerationModel[] generationModelEntityGenerationModel)
        {
            var result = new List<MemberDeclarationSyntax>();

            var methods = GetMethodDeclarations(generationModelEntityGenerationModel);
            if (methods != null && methods.Length > 0)
            {
                result.AddRange(methods);
            }

            return result.ToArray();
        }

        /// <summary>
        /// Gets the method declarations to be generated
        /// </summary>
        /// <returns></returns>
        private MemberDeclarationSyntax[] GetMethodDeclarations(EntityGenerationModel[] generationModelEntityGenerationModel)
        {
            var results = new[]
            {
                GetCreateModelMethodDeclaration(generationModelEntityGenerationModel)
            };

            return results;
        }


        private MemberDeclarationSyntax GetClassDeclarationSyntax(EntityFrameworkDbContextGenerationModel generationModelEntityGenerationModel, string suffix)
        {
            var entityName = generationModelEntityGenerationModel.ClassName;
            var className = $"{entityName}{suffix}";
            var members = GetMembers(
                className,
                generationModelEntityGenerationModel.DbSetEntities);

            var modifiers = new List<SyntaxToken>
            {
                SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                SyntaxFactory.Token(SyntaxKind.SealedKeyword)
            };

            var declaration = SyntaxFactory.ClassDeclaration(className)
                .AddModifiers(modifiers.ToArray())
                .AddMembers(members);

            var baseClass = GetBaseClass(entityName);
            if (!string.IsNullOrWhiteSpace(baseClass))
            {
                var b = SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(baseClass));
                declaration = declaration.AddBaseListTypes(b);
            }

            var implementedInterfaces = GetImplementedInterfaces(entityName);
            if (implementedInterfaces != null)
            {
                foreach (var implementedInterface in implementedInterfaces)
                {
                    var b = SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(implementedInterface));
                    declaration = declaration.AddBaseListTypes().AddBaseListTypes(b);
                }
            }

            var summary = GetClassLevelCommentSummary(entityName);
            declaration = DoCommentSection(declaration, summary);

            var remarks = GetClassLevelCommentRemarks(entityName);
            declaration = DoCommentSection(declaration, remarks);

            return declaration;
        }

        private string[] GetClassLevelCommentSummary(string entityName)
        {
            return new[] { "Represents the Entity Framework Db Context." };
        }

        private string[] GetClassLevelCommentRemarks(string entityName)
        {
            return null;
        }

        private T DoCommentSection<T>(T declaration, string[] commentLines)
            where T : MemberDeclarationSyntax
        {
            if (commentLines == null || commentLines.Length < 1)
            {
                return declaration;
            }

            var comments = new List<SyntaxTrivia>(commentLines.Length + 2);
            comments.Add(SyntaxFactory.Comment("///<summary>"));

            foreach (var line in commentLines)
            {
                comments.Add(SyntaxFactory.Comment($"/// {line}"));
            }

            comments.Add(SyntaxFactory.Comment("///</summary>"));

            return declaration.WithLeadingTrivia(comments);
        }

        private IEnumerable<string> GetImplementedInterfaces(string entityName)
        {
            return new []
            {
                "global::Whipstaff.EntityFramework.ModelCreation.IModelCreator"
            };
        }

        private string GetBaseClass(string entityName)
        {
            return null;
        }

        private UsingDirectiveSyntax[] GetUsingDirectives()
        {
            var usings = GetUsings() ?? new List<string>();

            if (usings.All(u => !u.Equals("System", StringComparison.Ordinal)))
            {
                usings.Add("System");
            }

            var directives = usings.Select(u => SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(u))).ToArray();

            return directives;
        }

        private IList<string> GetUsings()
        {
            return new List<string>
            {
                "Microsoft.EntityFrameworkCore"
            };
        }

        protected override string[] GetClassPrefixes()
        {
            return null;
        }

        private string GetClassSuffix()
        {
            return "MsSqlModelCreator";
        }

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

        private MemberDeclarationSyntax GetCreateModelMethodDeclaration(EntityGenerationModel[] generationModelEntityGenerationModel)
        {
            var methodName = $"CreateModel";

            var body = generationModelEntityGenerationModel.Select(GetApplyConfigurationInvocationDeclaration);

            var parameters = GetParams(new[] { $"Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder" });

            var inheritDocSyntaxTrivia = RoslynGenerationHelpers.GetInheritDocSyntaxTrivia();
            var returnType = SyntaxFactory.ParseTypeName("void");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName)
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.ProtectedKeyword), SyntaxFactory.Token(SyntaxKind.OverrideKeyword))
                .AddBodyStatements(body.ToArray())
                .WithLeadingTrivia(inheritDocSyntaxTrivia);
            return declaration;
        }

        private StatementSyntax GetApplyConfigurationInvocationDeclaration(EntityGenerationModel entityGenerationModel)
        {
            var invokeExpression = RoslynGenerationHelpers.GetMethodOnVariableInvocationSyntax("modelBuilder",
                "ApplyConfiguration",
                new[] { $"new EntityTypeConfigurations.{entityGenerationModel.ClassName}EntityTypeConfiguration()" },
                false);

            return invokeExpression;
        }
    }
}
