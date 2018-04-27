using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CodeGeneration.Roslyn;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Model;
using Dhgms.Nucleotide.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Validation;

namespace Dhgms.Nucleotide.Features.EntityFramework
{
    /// <summary>
    /// Code Generator for Entity Framework DB Sets
    /// </summary>
    public sealed class EntityFrameworkDbSetGenerator : BaseGenerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityFrameworkDbSetGenerator"/> class.
        /// </summary>
        public EntityFrameworkDbSetGenerator(AttributeData attributeData) : base(attributeData)
        {
            Requires.NotNull(attributeData, nameof(attributeData));
        }

        protected override async Task<NamespaceDeclarationSyntax> GenerateObjects(NamespaceDeclarationSyntax namespaceDeclaration,
            IEntityGenerationModel[] generationModelEntityGenerationModel)
        {
            if (generationModelEntityGenerationModel == null || generationModelEntityGenerationModel.Length < 1)
            {
                namespaceDeclaration = namespaceDeclaration.WithLeadingTrivia(SyntaxFactory.Comment("#error DROP OUT 2"));
                return namespaceDeclaration;
            }

            var classDeclarations = new List<MemberDeclarationSyntax>();

            var suffix = GetClassSuffix();
            classDeclarations.Add(await GetClassDeclarationSyntax(generationModelEntityGenerationModel, suffix));

            var usings = GetUsingDirectives();
            namespaceDeclaration = namespaceDeclaration.AddUsings(usings);

            namespaceDeclaration = namespaceDeclaration.AddMembers(classDeclarations.ToArray());

            return await Task.FromResult(namespaceDeclaration);
        }

        protected MemberDeclarationSyntax[] GetMembers(string className, string entityName, IEntityGenerationModel[] generationModelEntityGenerationModel)
        {
            var result = new List<MemberDeclarationSyntax>();

            //var constructorArguments = GetConstructorArguments();
            //var baseArguments = GetBaseConstructorArguments();

            //var fields = GetFieldDeclarations(constructorArguments, entityName);
            //if (fields != null && fields.Length > 0)
            //{
            //    result.AddRange(fields);
            //}

            //if (constructorArguments != null && constructorArguments.Count > 0)
            //{
            //    result.Add(GenerateConstructor(className, constructorArguments, entityName, baseArguments));
            //}

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

        /// <summary>
        /// Gets the method declarations to be generated
        /// </summary>
        /// <returns></returns>
        private MemberDeclarationSyntax[] GetMethodDeclarations(IEntityGenerationModel[] generationModelEntityGenerationModel)
        {
            return null;
        }

        /// <summary>
        /// Gets the property declarations to be generated
        /// </summary>
        /// <returns></returns>
        private PropertyDeclarationSyntax[] GetPropertyDeclarations(IEntityGenerationModel[] generationModelEntityGenerationModel)
        {
            return generationModelEntityGenerationModel?.Select(GetPropertyDeclaration).ToArray();
        }

        private PropertyDeclarationSyntax GetPropertyDeclaration(
            IEntityGenerationModel generationModelEntityGenerationModel)
        {
            var accessorList = new[]
            {
                SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
            };

            var summary = GetSummary(new[] { $"Gets or Sets the DBSet for {generationModelEntityGenerationModel.ClassName}" });

            var type = SyntaxFactory.ParseName($"DbSet<EfModels.{generationModelEntityGenerationModel.ClassName}EfModel>");
            var identifier = generationModelEntityGenerationModel.ClassName;

            var result = SyntaxFactory.PropertyDeclaration(type, identifier)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .WithAccessorList(
                    SyntaxFactory.AccessorList(
                        SyntaxFactory.List(accessorList)
                    ))
                .WithLeadingTrivia(summary);

            return result;
        }

        //private MemberDeclarationSyntax[] GetFieldDeclarations(
        //    IList<Tuple<Func<string, string>, string, Accessibility>> constructorArguments,
        //    string entityName)
        //{
        //    if (constructorArguments == null || constructorArguments.Count < 1)
        //    {
        //        return null;
        //    }

        //    var result = new List<MemberDeclarationSyntax>();

        //    foreach (var constructorArgument in constructorArguments)
        //    {
        //        var fieldType = constructorArgument.Item1(entityName);

        //        var fieldDeclaration = SyntaxFactory.FieldDeclaration(
        //                SyntaxFactory.VariableDeclaration(
        //                    SyntaxFactory.ParseTypeName(fieldType),
        //                    SyntaxFactory.SeparatedList(new[] { SyntaxFactory.VariableDeclarator(SyntaxFactory.Identifier($"_{constructorArgument.Item2}")) })
        //                ))
        //            .AddModifiers(SyntaxFactory.Token(SyntaxKind.PrivateKeyword));
        //        result.Add(fieldDeclaration);
        //    }

        //    return result.ToArray();
        //}

        private async Task<MemberDeclarationSyntax> GetClassDeclarationSyntax(IEntityGenerationModel[] generationModelEntityGenerationModel, string suffix)
        {
            // TODO : our model needs a parent name.
            var entityName = "Test";
            var className = $"{entityName}{suffix}";
            var members = GetMembers(className, entityName, generationModelEntityGenerationModel);

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

        private string GetBaseClass(string entityName)
        {
            return "Microsoft.EntityFrameworkCore.DbContext";
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

        protected override string GetClassSuffix()
        {
            return "DbContext";
        }

        protected override string GetNamespace()
        {
            return "EfModels";
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

    }
}
