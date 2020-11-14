﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Helpers;
using Dhgms.Nucleotide.Model;
using Dhgms.Nucleotide.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.GeneratorProcessors
{
    public abstract class BaseClassLevelCodeGeneratorProcessor : BaseGeneratorProcessor
    {
        public override async Task<NamespaceDeclarationSyntax> GenerateObjects(
            NamespaceDeclarationSyntax namespaceDeclaration,
            INucleotideGenerationModel nucleotideGenerationModel)
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
                    classDeclarations.Add(await GetClassDeclarationSyntax(generationModelClassGenerationParameter, prefix, suffix));
                }
            }

            var usings = GetUsingDirectives();
            namespaceDeclaration = namespaceDeclaration.AddUsings(usings);

            return await Task.FromResult(namespaceDeclaration.AddMembers(classDeclarations.ToArray()));
        }

        protected abstract string GetClassSuffix();

        protected abstract IList<string> GetUsings();

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

        protected virtual async Task<MemberDeclarationSyntax> GetClassDeclarationSyntax(
            IEntityGenerationModel entityDeclaration,
            string prefix,
            string suffix)
        {
            var entityName = entityDeclaration.ClassName;
            var className = $"{prefix}{entityName}{suffix}";
            var members = GetMembers(className, entityName, entityDeclaration);

            // SyntaxFactory.Token(SyntaxKind.SealedKeyword)

            var modifiers = new List<SyntaxToken>
            {
                SyntaxFactory.Token(SyntaxKind.PublicKeyword)
            };

            if (this.GetWhetherClassShouldBeSealedClass())
            {
                modifiers.Add(SyntaxFactory.Token(SyntaxKind.SealedKeyword));
            }

            if (this.GetWhetherClassShouldBePartialClass())
            {
                modifiers.Add(SyntaxFactory.Token(SyntaxKind.PartialKeyword));
            }

            var declaration = SyntaxFactory.ClassDeclaration(className)
                .AddModifiers(modifiers.ToArray())
                .AddMembers(members);

            var classAttributes = GetClassAttributes(entityDeclaration);
            if (classAttributes != null && classAttributes.Count > 0)
            {
                var attributeListSyntax = GetAttributeListSyntax(classAttributes);
                declaration = declaration.AddAttributeLists(attributeListSyntax);
            }

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

            return await Task.FromResult(declaration);
        }

        protected abstract bool GetWhetherClassShouldBePartialClass();

        protected abstract bool GetWhetherClassShouldBeSealedClass();

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

        protected abstract string[] GetClassLevelCommentSummary(string entityName);

        protected abstract string[] GetClassLevelCommentRemarks(string entityName);

        protected abstract IList<Tuple<string, IList<string>>> GetClassAttributes(IEntityGenerationModel entityDeclaration);

        protected MemberDeclarationSyntax[] GetMembers(string className, string entityName, IEntityGenerationModel entityGenerationModel)
        {
            var result = new List<MemberDeclarationSyntax>();

            var constructorArguments = GetConstructorArguments();
            var baseArguments = GetBaseConstructorArguments();

            var fields = GetFieldDeclarations(constructorArguments, baseArguments, entityName);
            if (fields != null && fields.Length > 0)
            {
                result.AddRange(fields);
            }

            if (constructorArguments != null && constructorArguments.Count > 0)
            {
                result.Add(GenerateConstructor(className, constructorArguments, entityName, baseArguments));
            }

            var properties = GetPropertyDeclarations(entityGenerationModel);
            if (properties != null && properties.Length > 0)
            {
                result.AddRange(properties);
            }

            var methods = GetMethodDeclarations(entityGenerationModel);
            if (methods != null && methods.Length > 0)
            {
                result.AddRange(methods);
            }

            return result.ToArray();
        }

        protected abstract IList<string> GetBaseConstructorArguments();

        protected static AttributeListSyntax GetAttributeListSyntax(IList<Tuple<string, IList<string>>> attributes)
        {
            var attributeList = new SeparatedSyntaxList<AttributeSyntax>();

            foreach (var attribute in attributes)
            {
                var name = SyntaxFactory.ParseName(attribute.Item1);

                var argumentList = RoslynGenerationHelpers.GetAttributeArgumentListSyntax(attribute.Item2);


                var attribute2 = SyntaxFactory.Attribute(name, argumentList);

                attributeList = attributeList.Add(attribute2);
            }

            var list = SyntaxFactory.AttributeList(attributeList);
            return list;
        }

        private MemberDeclarationSyntax[] GetFieldDeclarations(
            IList<Tuple<Func<string, string>, string, Accessibility>> constructorArguments,
            IList<string> baseArguments,
            string entityName)
        {
            if (constructorArguments == null || constructorArguments.Count < 1)
            {
                return null;
            }

            var result = new List<MemberDeclarationSyntax>();

            foreach (var constructorArgument in constructorArguments)
            {
                if (baseArguments.Any(ba => ba.Equals(constructorArgument.Item2)))
                {
                    // don't deal with base arguments, should be provided for in base class
                    continue;
                }

                var fieldType = constructorArgument.Item1(entityName);

                var fieldDeclaration = SyntaxFactory.FieldDeclaration(
                    SyntaxFactory.VariableDeclaration(
                    SyntaxFactory.ParseTypeName(fieldType),
                    SyntaxFactory.SeparatedList(new[] { SyntaxFactory.VariableDeclarator(SyntaxFactory.Identifier($"_{constructorArgument.Item2}")) })
                    ))
                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PrivateKeyword), SyntaxFactory.Token(SyntaxKind.ReadOnlyKeyword));
                result.Add(fieldDeclaration);
            }

            return result.ToArray();
        }

        /// <summary>
        /// Gets the method declarations to be generated
        /// </summary>
        /// <returns></returns>
        protected abstract MethodDeclarationSyntax[] GetMethodDeclarations(IEntityGenerationModel entityGenerationModel);

        /// <summary>
        /// Gets the property declarations to be generated
        /// </summary>
        /// <returns></returns>
        protected abstract PropertyDeclarationSyntax[] GetPropertyDeclarations(IEntityGenerationModel entityGenerationModel);

        private ConstructorDeclarationSyntax GenerateConstructor(
            string className,
            IList<Tuple<Func<string, string>, string, Accessibility>> constructorArguments,
            string entityName,
            IList<string> baseArguments)
        {
            var parameters = GetParams(constructorArguments.Select(x => $"{x.Item1(entityName)} {x.Item2}").ToArray());
            var body = new List<StatementSyntax>();

            // null checks
            foreach (var constructorArgument in constructorArguments)
            {
                if (baseArguments.Any(ba => ba.Equals(constructorArgument.Item2)))
                {
                    // don't deal with base arguments, should be validated in base class
                    continue;
                }

                var nullCheck = RoslynGenerationHelpers.GetNullGuardCheckSyntax(constructorArgument.Item2);

                body.Add(nullCheck);
            }

            // assignments
            foreach (var constructorArgument in constructorArguments)
            {
                if (baseArguments.Any(ba => ba.Equals(constructorArgument.Item2)))
                {
                    // don't deal with base arguments, should be assigned in base class
                    continue;
                }

                var left = SyntaxFactory.MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    SyntaxFactory.ThisExpression(),
                    SyntaxFactory.Token(SyntaxKind.DotToken),
                    SyntaxFactory.IdentifierName(SyntaxFactory.Identifier($"_{constructorArgument.Item2}")));

                var right = SyntaxFactory.IdentifierName(SyntaxFactory.Identifier(constructorArgument.Item2));

                var assignment = SyntaxFactory.ExpressionStatement(
                    SyntaxFactory.AssignmentExpression(
                        SyntaxKind.SimpleAssignmentExpression,
                        left,
                        SyntaxFactory.Token(SyntaxKind.EqualsToken),
                        right),
                    SyntaxFactory.Token(SyntaxKind.SemicolonToken)
                    );

                body.Add(assignment);
            }

            var declaration = SyntaxFactory.ConstructorDeclaration(className)
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddBodyStatements(body.ToArray());

            if (baseArguments != null && baseArguments.Count > 0)
            {
                var seperatedSyntaxList = new SeparatedSyntaxList<ArgumentSyntax>();

                foreach (var baseArgument in baseArguments)
                {
                    seperatedSyntaxList = seperatedSyntaxList.Add(
                        SyntaxFactory.Argument(
                            SyntaxFactory.IdentifierName(SyntaxFactory.Identifier(baseArgument))));
                }

                var baseInitializerArgumentList = SyntaxFactory.ArgumentList(seperatedSyntaxList);

                var initializer = SyntaxFactory.ConstructorInitializer(
                    SyntaxKind.BaseConstructorInitializer,
                    baseInitializerArgumentList);
                declaration = declaration.WithInitializer(initializer);
            }

            var summary = new[]
            {
                $"Creates an instance of {className}"
            };

            declaration = this.DoCommentSection(declaration, summary);

            return declaration;
        }

        /// <summary>
        /// Gets arguments the constructor needs to deal with
        /// </summary>
        /// <returns></returns>
        protected abstract IList<Tuple<Func<string, string>, string, Accessibility>> GetConstructorArguments();

        protected static MemberDeclarationSyntax GetMethod(string methodName, string returnType, SyntaxTrivia[] leadingTrivia, ParameterListSyntax parameterListSyntax, TypeParameterListSyntax typeParameterListSyntax)
        {
            var method = SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName(returnType), methodName);

            if (parameterListSyntax != null &&
                parameterListSyntax.Parameters.Count > 0)
            {
                method = method.WithParameterList(parameterListSyntax);
            }

            if (typeParameterListSyntax != null &&
                typeParameterListSyntax.Parameters.Count > 0)
            {
                method = method.WithTypeParameterList(typeParameterListSyntax);
            }

            method = method.WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
            method = method.WithLeadingTrivia(leadingTrivia);
            return method;
        }

        /// <summary>
        /// Gets the base class, if any
        /// </summary>
        /// <returns>Base class</returns>
        protected abstract string GetBaseClass(string entityName);

        /// <summary>
        /// Gets the implemented interfaces, if any
        /// </summary>
        /// <returns>List of implemented interfaces</returns>
        protected abstract IList<string> GetImplementedInterfaces(string entityName);

        protected abstract SeparatedSyntaxList<AttributeSyntax> GetAttributesForProperty(PropertyInfoBase propertyInfo);

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

            var attributes = GetAttributesForProperty(propertyInfo);
            var result = SyntaxFactory.PropertyDeclaration(type, identifier)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .WithAccessorList(
                    SyntaxFactory.AccessorList(
                        SyntaxFactory.List(accessorList)
                    ))
                .WithLeadingTrivia(summary);

            if (attributes.Count > 0)
            {
                var attributeLists = SyntaxFactory.AttributeList(attributes);
                result = result.AddAttributeLists(attributeLists);
            }

            return result;
        }

        protected MethodDeclarationSyntax GetEventIdMethodDeclaration(string entityName, string eventName)
        {
            var methodName = $"Get{eventName}EventIdAsync";

            var returnStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.ParseExpression($"System.Threading.Tasks.Task.FromResult(new EventId(NumericEventIds.{entityName}Controller{eventName}Id, \"{entityName}Controller{eventName}\"))"));

            var body = new StatementSyntax[]
            {
                returnStatement
            };

            var returnType = SyntaxFactory.ParseTypeName("System.Threading.Tasks.Task<EventId>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.ProtectedKeyword), SyntaxFactory.Token(SyntaxKind.OverrideKeyword))
                .AddBodyStatements(body);
            return declaration;
        }

    }
}