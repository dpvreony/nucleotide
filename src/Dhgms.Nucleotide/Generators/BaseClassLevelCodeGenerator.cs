using System;
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
using Dhgms.Nucleotide.PropertyInfo;
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
        /// <summary>
        ///
        /// </summary>
        /// <param name="attributeData"></param>
        protected BaseClassLevelCodeGenerator(AttributeData attributeData) : base(attributeData)
        {
            //this.nucleotideGenerationModel = (Type) [0].Value;
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
                classDeclarations.Add(await GetClassDeclarationSyntax(generationModelClassGenerationParameter, prefix, suffix));
            }

            var usings = GetUsingDirectives();
            namespaceDeclaration = namespaceDeclaration.AddUsings(usings);

            return await Task.FromResult(namespaceDeclaration.AddMembers(classDeclarations.ToArray()));
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

        protected abstract IList<string> GetUsings();

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

        protected abstract List<Tuple<string, IList<string>>> GetClassAttributes();

        protected MemberDeclarationSyntax[] GetMembers(string className, string entityName, IEntityGenerationModel entityGenerationModel)
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

            var properties = GetPropertyDeclarations(entityGenerationModel);
            if (properties != null && properties.Length > 0)
            {
                result.AddRange(properties);
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

        /// <summary>
        /// Gets the property declarations to be generated
        /// </summary>
        /// <returns></returns>
        protected abstract MemberDeclarationSyntax[] GetPropertyDeclarations(IEntityGenerationModel entityGenerationModel);

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
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .WithAccessorList(
                    SyntaxFactory.AccessorList(
                        SyntaxFactory.List(accessorList)
                    ))
                .WithLeadingTrivia(summary);

            return result;
        }
    }
}
