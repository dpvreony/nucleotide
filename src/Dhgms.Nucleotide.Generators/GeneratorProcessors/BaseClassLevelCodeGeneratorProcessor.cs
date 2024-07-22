// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.Generators.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.GeneratorProcessors
{
    public abstract class BaseClassLevelCodeGeneratorProcessor<TGenerationModel> : BaseGeneratorProcessor<TGenerationModel>
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
                    classDeclarations.Add(GetClassDeclarationSyntax(generationModelClassGenerationParameter, prefix, suffix));
                }
            }

            var usings = GetUsingDirectives();
            namespaceDeclaration = namespaceDeclaration.AddUsings(usings);

            return namespaceDeclaration.AddMembers(classDeclarations.ToArray());
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

        protected virtual MemberDeclarationSyntax GetClassDeclarationSyntax(
            TGenerationModel entityDeclaration,
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

            var baseClass = GetBaseClass(entityDeclaration);
            if (!string.IsNullOrWhiteSpace(baseClass))
            {
                var b = SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(baseClass));
                declaration = declaration.AddBaseListTypes(b);
            }

            var implementedInterfaces = GetImplementedInterfaces(entityDeclaration);
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

        protected abstract IList<Tuple<string, IList<string>>> GetClassAttributes(TGenerationModel entityDeclaration);

        protected MemberDeclarationSyntax[] GetMembers(string className, string entityName, TGenerationModel entityGenerationModel)
        {
            var result = new List<MemberDeclarationSyntax>();

            var constructorArguments = GetConstructorArguments();
            var baseArguments = GetBaseConstructorArguments();

            var fields = GetConstructorFieldDeclarations(constructorArguments, baseArguments, entityName);
            if (fields is { Count: > 0 })
            {
                result.AddRange(fields);
            }

            fields = GetFieldDeclarations(entityGenerationModel);
            if (fields is { Count: > 0 })
            {
                result.AddRange(fields);
            }

            if (constructorArguments is { Count: > 0 })
            {
                result.Add(GenerateConstructor(className, constructorArguments, entityName, baseArguments));
            }

            var properties = GetPropertyDeclarations(entityGenerationModel);
            if (properties != null)
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

        protected abstract IReadOnlyCollection<FieldDeclarationSyntax> GetFieldDeclarations(TGenerationModel entityGenerationModel);

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

        private IReadOnlyCollection<FieldDeclarationSyntax> GetConstructorFieldDeclarations(
            IList<Tuple<Func<string, string>, string, Accessibility>> constructorArguments,
            IList<string> baseArguments,
            string entityName)
        {
            if (constructorArguments == null || constructorArguments.Count < 1)
            {
                return null;
            }

            var result = new List<FieldDeclarationSyntax>();
            foreach (var constructorArgument in constructorArguments)
            {
                if (baseArguments.Any(ba => ba.Equals(constructorArgument.Item2)))
                {
                    // don't deal with base arguments, should be provided for in base class
                    continue;
                }

                var fieldType = constructorArgument.Item1(entityName);

                result.Add(SyntaxFactory.FieldDeclaration(
                    SyntaxFactory.VariableDeclaration(
                    SyntaxFactory.ParseTypeName(fieldType),
                    SyntaxFactory.SeparatedList(new[] { SyntaxFactory.VariableDeclarator(SyntaxFactory.Identifier($"_{constructorArgument.Item2}")) })
                    ))
                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PrivateKeyword), SyntaxFactory.Token(SyntaxKind.ReadOnlyKeyword)));
            }

            return result;
        }

        /// <summary>
        /// Gets the method declarations to be generated
        /// </summary>
        /// <returns></returns>
        protected abstract MethodDeclarationSyntax[] GetMethodDeclarations(TGenerationModel entityGenerationModel);

        /// <summary>
        /// Gets the property declarations to be generated
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerable<PropertyDeclarationSyntax> GetPropertyDeclarations(TGenerationModel entityGenerationModel);

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
        protected abstract string GetBaseClass(TGenerationModel entityGenerationModel);

        /// <summary>
        /// Gets the implemented interfaces, if any
        /// </summary>
        /// <returns>List of implemented interfaces</returns>
        protected abstract IEnumerable<string> GetImplementedInterfaces(TGenerationModel generationModel);

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
            var type = SyntaxFactory.ParseTypeName(propertyInfo.NetDataType);
            var identifier = propertyInfo.Name;

            if (propertyInfo.Optional)
            {
                type = SyntaxFactory.NullableType(type);
            }

            var attributes = GetAttributesForProperty(propertyInfo);
            var result = SyntaxFactory.PropertyDeclaration(type, identifier)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .WithAccessorList(
                    SyntaxFactory.AccessorList(
                        SyntaxFactory.List(accessorList)
                    ))
                .WithLeadingTrivia(summary);

            // HACK: will rewrite this once I replace the type with ISymbol
            if (!propertyInfo.Optional && propertyInfo.NetDataType.Equals("string"))
            {
                result = result.AddModifiers(SyntaxFactory.Token(SyntaxKind.RequiredKeyword));
            }

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
