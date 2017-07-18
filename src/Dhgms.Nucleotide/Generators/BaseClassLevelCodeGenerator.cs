﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeGeneration.Roslyn;
using Dhgms.Nucleotide.Helpers;
using Dhgms.Nucleotide.Model;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Validation;

namespace Dhgms.Nucleotide.Generators
{
    /// <summary>
    /// Base class for a code generator that generates code based on the Class Level of Generation Metadata.
    /// </summary>
    public abstract class BaseClassLevelCodeGenerator : BaseGenerator
    {
        private readonly object nucleotideGenerationModel;

        /// <summary>
        ///
        /// </summary>
        /// <param name="attributeData"></param>
        protected BaseClassLevelCodeGenerator(AttributeData attributeData)
        {
            Requires.NotNull(attributeData, nameof(attributeData));
            Requires.That(attributeData.ConstructorArguments.Length > 0, nameof(attributeData), "x");

            this.nucleotideGenerationModel = attributeData.ConstructorArguments;
            //this.nucleotideGenerationModel = (Type) [0].Value;
        }

        /// <summary>
        /// Create the syntax tree representing the expansion of some member to which this attribute is applied.
        /// </summary>
        /// <param name="context">The transformation context being generated for.</param>
        /// <param name="progress">A way to report diagnostic messages.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The generated member syntax to be added to the project.</returns>
        public override async Task<SyntaxList<MemberDeclarationSyntax>> GenerateAsync(
            TransformationContext context,
            IProgress<Diagnostic> progress,
            CancellationToken cancellationToken)
        {
            var namespaceName = this.GetNamespace();
            var namespaceDeclaration = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.IdentifierName(namespaceName));

            var castDetails = (System.Collections.Immutable.ImmutableArray<TypedConstant>)this.nucleotideGenerationModel;

            var a = castDetails.First();
            var namedTypeSymbols = a.Value as INamedTypeSymbol;
            var compilation = context.Compilation;
            var generationModel = await this.GetModel(namedTypeSymbols, compilation);

            /*
            if (generationModel == null)
            {
                namespaceDeclaration = namespaceDeclaration.WithLeadingTrivia(SyntaxFactory.Comment($"#error Failed to find model: {namedTypeSymbols}"));
            }
            else
            {
                namespaceDeclaration = await this.GenerateClasses(namespaceDeclaration, generationModel.ClassGenerationParameters);
            }
            */

            var nodes = new MemberDeclarationSyntax[]
            {
                namespaceDeclaration
            };

            var results = SyntaxFactory.List(nodes);

            return await Task.FromResult(results);
        }

        /// <summary>
        /// Gets the suffix to be applied to a clas
        /// </summary>
        /// <returns>Class suffix</returns>
        protected abstract string GetClassSuffix();

        protected abstract string GetNamespace();

        protected virtual async Task<NamespaceDeclarationSyntax> GenerateClasses(NamespaceDeclarationSyntax namespaceDeclaration, ClassGenerationParameters[] generationModelClassGenerationParameters)
        {
            if (generationModelClassGenerationParameters == null || generationModelClassGenerationParameters.Length < 1)
            {
                namespaceDeclaration = namespaceDeclaration.WithLeadingTrivia(SyntaxFactory.Comment("#error DROP OUT 2"));
                return namespaceDeclaration;
            }

            var classDeclarations = new List<MemberDeclarationSyntax>();

            var prefix = GetClassPrefix();
            var suffix = GetClassSuffix();
            foreach (var generationModelClassGenerationParameter in generationModelClassGenerationParameters)
            {
                classDeclarations.Add(await GetClassDeclarationSyntax(generationModelClassGenerationParameter, prefix, suffix));
            }

            var usings = GetUsings();
            namespaceDeclaration = namespaceDeclaration.AddUsings(usings);

            return await Task.FromResult(namespaceDeclaration.AddMembers(classDeclarations.ToArray()));
        }

        private UsingDirectiveSyntax[] GetUsings()
        {
            var result = new[]
            {
                SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System"))
            };

            return result;
        }

        protected virtual async Task<MemberDeclarationSyntax> GetClassDeclarationSyntax(
            IClassGenerationParameters classDeclaration,
            string prefix,
            string suffix)
        {
            var entityName = classDeclaration.ClassName;
            var className = $"{prefix}{entityName}{suffix}";
            var members = GetMembers(className, entityName);

            // SyntaxFactory.Token(SyntaxKind.SealedKeyword)

            var declaration = SyntaxFactory.ClassDeclaration(className)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddMembers(members);

            var classAttributes = GetClassAttributes();
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

        protected abstract List<Tuple<string, IList<string>>> GetClassAttributes();

        protected MemberDeclarationSyntax[] GetMembers(string className, string entityName)
        {
            var result = new List<MemberDeclarationSyntax>();

            var constructorArguments = GetConstructorArguments();

            var fields = GetFieldDeclarations(constructorArguments, entityName);
            if (fields != null && fields.Length > 0)
            {
                result.AddRange(fields);
            }

            if (constructorArguments != null && constructorArguments.Count > 0)
            {
                result.Add(GenerateConstructor(className, constructorArguments, entityName));
            }

            var methods = GetMethodDeclarations(entityName);
            if (methods != null && methods.Length > 0)
            {
                result.AddRange(methods);
            }

            return result.ToArray();
        }

        protected static AttributeListSyntax GetAttributeListSyntax(IList<Tuple<string, IList<string>>> attributes)
        {
            var attributeList = new SeparatedSyntaxList<AttributeSyntax>();

            foreach (var attribute in attributes)
            {
                var name = SyntaxFactory.ParseName(attribute.Item1);

                var argumentList = GetAttributeArgumentListSyntax(attribute.Item2);


                var attribute2 = SyntaxFactory.Attribute(name, argumentList);

                attributeList = attributeList.Add(attribute2);
            }

            var list = SyntaxFactory.AttributeList(attributeList);
            return list;
        }

        private MemberDeclarationSyntax[] GetFieldDeclarations(
            IList<Tuple<Func<string, string>, string, Accessibility>> constructorArguments,
            string entityName)
        {
            if (constructorArguments == null || constructorArguments.Count < 1)
            {
                return null;
            }

            var result = new List<MemberDeclarationSyntax>();

            foreach (var constructorArgument in constructorArguments)
            {
                var fieldType = constructorArgument.Item1(entityName);

                var fieldDeclaration = SyntaxFactory.FieldDeclaration(
                    SyntaxFactory.VariableDeclaration(
                    SyntaxFactory.ParseTypeName(fieldType),
                    SyntaxFactory.SeparatedList(new[] { SyntaxFactory.VariableDeclarator(SyntaxFactory.Identifier($"_{constructorArgument.Item2}")) })
                    ))
                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PrivateKeyword));
                result.Add(fieldDeclaration);
            }

            return result.ToArray();
        }

        /// <summary>
        /// Gets the method declarations to be generated
        /// </summary>
        /// <returns></returns>
        protected abstract MemberDeclarationSyntax[] GetMethodDeclarations(string entityName);

        protected static ParameterListSyntax GetParams(string[] argCollection)
        {
            var parameters = SyntaxFactory.SeparatedList<ParameterSyntax>();

            foreach (var s in argCollection)
            {
                var node = SyntaxFactory.Parameter(SyntaxFactory.Identifier(s));
                parameters = parameters.Add(node);
            }

            return SyntaxFactory.ParameterList(parameters);
        }

        private ConstructorDeclarationSyntax GenerateConstructor(string className, IList<Tuple<Func<string, string>, string, Accessibility>> constructorArguments, string entityName)
        {
            var parameters = GetParams(constructorArguments.Select(x => $"{x.Item1(entityName)} {x.Item2}").ToArray());
            var body = new List<StatementSyntax>();

            // null checks
            foreach (var constructorArgument in constructorArguments)
            {
                var nullCheck = RoslynGenerationHelpers.GetNullGuardCheckSyntax(constructorArgument.Item2);

                body.Add(nullCheck);
            }

            // assignments
            foreach (var constructorArgument in constructorArguments)
            {
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

        private static AttributeArgumentListSyntax GetAttributeArgumentListSyntax(IList<string> attributeArguments)
        {
            if (attributeArguments == null || attributeArguments.Count < 1)
            {
                return null;
            }

            var argumentList = SyntaxFactory.AttributeArgumentList();

            foreach (var attributeArgument in attributeArguments)
            {
                var name = SyntaxFactory.ParseName(attributeArgument);
                var attribArgSyntax = SyntaxFactory.AttributeArgument(name);
                argumentList = argumentList.AddArguments(attribArgSyntax);
            }

            return argumentList;
        }

        private static MemberDeclarationSyntax GetMethod(string methodName, string returnType, SyntaxTrivia[] leadingTrivia, ParameterListSyntax parameterListSyntax, TypeParameterListSyntax typeParameterListSyntax)
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

        protected abstract string GetClassPrefix();
    }
}
