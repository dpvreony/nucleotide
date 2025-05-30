﻿// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Dhgms.Nucleotide.Generators.Features.Core.XmlDoc;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.Generators.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.EntityFramework
{
    /// <summary>
    /// Code Generator for Entity Framework DB Context
    /// </summary>
    public sealed class EntityFrameworkDbContextGeneratorProcessor : BaseGeneratorProcessor<EntityFrameworkDbContextGenerationModel>
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

            //var constructorArguments = GetConstructorArguments();
            //var baseArguments = GetBaseConstructorArguments();

            var fields = GetFieldDeclarations(className);
            if (fields != null && fields.Length > 0)
            {
                result.AddRange(fields);
            }

            //if (constructorArguments != null && constructorArguments.Count > 0)
            //{
            //    result.Add(GenerateConstructor(className, constructorArguments, entityName, baseArguments));
            //}
            result.Add(GetConstructorWithDbOptions(className));

            var properties = GetPropertyDeclarations(generationModelEntityGenerationModel);
            if (properties != null && properties.Length > 0)
            {
                result.AddRange(properties);
            }

            var methods = GetMethodDeclarations(generationModelEntityGenerationModel);
            if (methods != null && methods.Length > 0)
            {
                result.AddRange(methods);
            }

            return result.ToArray();
        }

        private ConstructorDeclarationSyntax GetConstructorWithDbOptions(string className)
        {
            var parameters = GetParams(new []
            {
                $"DbContextOptions<{className}> dbContextOptions",
                $"Func<Whipstaff.EntityFramework.ModelCreation.IModelCreator<{className}>> modelCreatorFunc"
            });

            var seperatedSyntaxList = new SeparatedSyntaxList<ArgumentSyntax>();

            seperatedSyntaxList = seperatedSyntaxList.Add(
                SyntaxFactory.Argument(
                    SyntaxFactory.IdentifierName(SyntaxFactory.Identifier("dbContextOptions"))));

            var baseInitializerArgumentList = SyntaxFactory.ArgumentList(seperatedSyntaxList);

            var initializer = SyntaxFactory.ConstructorInitializer(
                SyntaxKind.BaseConstructorInitializer,
                baseInitializerArgumentList);

            var body = new List<StatementSyntax>
            {
                RoslynGenerationHelpers.GetNullGuardCheckSyntax("modelCreatorFunc"),
            };

            var left = SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                SyntaxFactory.ThisExpression(),
                SyntaxFactory.Token(SyntaxKind.DotToken),
                SyntaxFactory.IdentifierName(SyntaxFactory.Identifier($"_modelCreatorFunc")));

            var right = SyntaxFactory.IdentifierName(SyntaxFactory.Identifier("modelCreatorFunc"));

            var assignment = SyntaxFactory.ExpressionStatement(
                SyntaxFactory.AssignmentExpression(
                    SyntaxKind.SimpleAssignmentExpression,
                    left,
                    SyntaxFactory.Token(SyntaxKind.EqualsToken),
                    right),
                SyntaxFactory.Token(SyntaxKind.SemicolonToken)
            );

            body.Add(assignment);

            var declaration = SyntaxFactory.ConstructorDeclaration(className)
                .WithParameterList(parameters)
                .WithInitializer(initializer)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddBodyStatements(body.ToArray());

            return declaration;

        }

        /// <summary>
        /// Gets the method declarations to be generated
        /// </summary>
        /// <returns></returns>
        private MemberDeclarationSyntax[] GetMethodDeclarations(EntityGenerationModel[] generationModelEntityGenerationModel)
        {
            var results = new[]
            {
                GetOnModelCreatingMethodDeclaration(generationModelEntityGenerationModel)
            };

            return results;
        }

        /// <summary>
        /// Gets the property declarations to be generated
        /// </summary>
        /// <returns></returns>
        private PropertyDeclarationSyntax[] GetPropertyDeclarations(EntityGenerationModel[] generationModelEntityGenerationModel)
        {
            return generationModelEntityGenerationModel?.Select(GetPropertyDeclaration).ToArray();
        }

        private PropertyDeclarationSyntax GetPropertyDeclaration(
            EntityGenerationModel generationModelEntityGenerationModel)
        {
            var setType = SyntaxFactory.ParseTypeName($"Set<EfModels.{generationModelEntityGenerationModel.ClassName}EfModel>");
            var setCreation = SyntaxFactory.InvocationExpression(setType);
            var arrowExpression = SyntaxFactory.ArrowExpressionClause(setCreation);

            var summary = SyntaxTriviaFactory.GetSummary(new[] { $"Gets the DBSet for {generationModelEntityGenerationModel.ClassName}" });

            var type = SyntaxFactory.ParseTypeName($"DbSet<EfModels.{generationModelEntityGenerationModel.ClassName}EfModel>");
            var identifier = generationModelEntityGenerationModel.ClassName;

            var result = SyntaxFactory.PropertyDeclaration(type, identifier)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .WithExpressionBody(arrowExpression)
                .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
                .WithLeadingTrivia(summary);

            return result;
        }

        private MemberDeclarationSyntax[] GetFieldDeclarations(string className)
        {

            var result = new List<MemberDeclarationSyntax>();

            var fieldDeclaration = SyntaxFactory.FieldDeclaration(
                    SyntaxFactory.VariableDeclaration(
                        SyntaxFactory.ParseTypeName($"Func<Whipstaff.EntityFramework.ModelCreation.IModelCreator<{className}>>"),
                        SyntaxFactory.SeparatedList(new[] { SyntaxFactory.VariableDeclarator(SyntaxFactory.Identifier($"_modelCreatorFunc")) })
                    ))
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PrivateKeyword), SyntaxFactory.Token(SyntaxKind.ReadOnlyKeyword));
            result.Add(fieldDeclaration);

            return result.ToArray();
        }

        private MemberDeclarationSyntax GetClassDeclarationSyntax(EntityFrameworkDbContextGenerationModel generationModelEntityGenerationModel, string suffix)
        {
            // TODO : our model needs a parent name.
            var entityName = generationModelEntityGenerationModel.ClassName;
            var className = $"{entityName}{suffix}";
            var members = GetMembers(
                className,
                generationModelEntityGenerationModel.DbSetEntities);

            // SyntaxFactory.Token(SyntaxKind.SealedKeyword)

            var modifiers = new List<SyntaxToken>
            {
                SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                SyntaxFactory.Token(SyntaxKind.SealedKeyword)
            };

            var declaration = SyntaxFactory.ClassDeclaration(className)
                .AddModifiers(modifiers.ToArray())
                .AddMembers(members);

            //var classAttributes = GetClassAttributes(generationModelEntityGenerationModel);
            //if (classAttributes != null && classAttributes.Count > 0)
            //{
            //    var attributeListSyntax = GetAttributeListSyntax(generationModelEntityGenerationModel);
            //    declaration = declaration.AddAttributeLists(attributeListSyntax);
            //}

            var baseClass = GetBaseClass(generationModelEntityGenerationModel.OverrideBaseDbContextType);
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
                    declaration = declaration.AddBaseListTypes(b);
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
            return new []{ "Represents the Entity Framework Db Context."};
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
            return null;
        }

        private string GetBaseClass(string overrideBaseDbContextType)
        {
            const string baseDbContextType = "Microsoft.EntityFrameworkCore.DbContext";
            if (overrideBaseDbContextType != null)
            {
                /*
                if (!overrideBaseDbContextType.IsSubclassOf(Type.GetType(baseDbContextType)))
                {
                    throw new ArgumentException($"The {nameof(overrideBaseDbContextType)} type \"{overrideBaseDbContextType.FullName}\" does not inherit from {baseDbContextType}");
                };
                */

                return overrideBaseDbContextType;
            }

            return baseDbContextType;
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
            return "DbContext";
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

        private MemberDeclarationSyntax GetOnModelCreatingMethodDeclaration(EntityGenerationModel[] generationModelEntityGenerationModel)
        {
            var methodName = $"OnModelCreating";

            var body = new List<StatementSyntax>
            {
                RoslynGenerationHelpers.GetMethodOnVariableInvocationSyntax(
                    "base",
                    methodName,
                    new [] { "modelBuilder" },
                    false),
                RoslynGenerationHelpers.GetVariableAssignmentFromFuncVariableInvocationSyntax(
                    "modelCreator",
                    "_modelCreatorFunc",
                    Array.Empty<string>(),
                    false),
                RoslynGenerationHelpers.GetMethodOnVariableInvocationSyntax(
                    "modelCreator",
                    "CreateModel",
                    new [] { "modelBuilder" },
                    false),
            };

            var parameters = GetParams(new []{ $"Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder"});

            var inheritDocSyntaxTrivia = RoslynGenerationHelpers.GetInheritDocSyntaxTrivia();
            var returnType = SyntaxFactory.ParseTypeName("void");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName)
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.ProtectedKeyword), SyntaxFactory.Token(SyntaxKind.OverrideKeyword))
                .AddBodyStatements(body.ToArray())
                .WithLeadingTrivia(inheritDocSyntaxTrivia);
            return declaration;
        }
    }
}
