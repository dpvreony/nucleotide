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
using Dhgms.Nucleotide.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Validation;

namespace Dhgms.Nucleotide.Generators
{
    /// <summary>
    /// Base class for a code generator that generates code based on the Interface Level of Generation Metadata.
    /// </summary>
    public abstract class BaseInterfaceLevelCodeGenerator : ICodeGenerator
    {
        private readonly object nucleotideGenerationModel;

        /// <summary>
        ///
        /// </summary>
        /// <param name="attributeData"></param>
        protected BaseInterfaceLevelCodeGenerator(AttributeData attributeData)
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
        public async Task<SyntaxList<MemberDeclarationSyntax>> GenerateAsync(
            TransformationContext context,
            IProgress<Diagnostic> progress,
            CancellationToken cancellationToken)
        {
            var namespaceName = GetNamespace();
            var namespaceDeclaration = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.IdentifierName(namespaceName));

            var castDetails = (System.Collections.Immutable.ImmutableArray<TypedConstant>)this.nucleotideGenerationModel;

            var a = castDetails.First();
            var namedTypeSymbols = a.Value as INamedTypeSymbol;
            var compilation = context.Compilation;
            var generationModel = await this.GetModel(namedTypeSymbols, compilation);

            if (generationModel == null)
            {
                namespaceDeclaration = namespaceDeclaration.WithLeadingTrivia(SyntaxFactory.Comment($"#error Failed to find model: {namedTypeSymbols}"));
            }
            else
            {
                namespaceDeclaration = await this.GenerateInterfaces(namespaceDeclaration, generationModel.ClassGenerationParameters);
            }

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

        protected PropertyDeclarationSyntax GetPropertyDeclaration(PropertyInfoBase propertyInfo)
        {
            var accessorList = new[]
            {
                SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
            };

            var summary = GetSummary(new[] {$"Gets or sets {propertyInfo.Name}"});

            return GetPropertyDeclaration(propertyInfo, accessorList, summary);
        }

        protected PropertyDeclarationSyntax GetReadOnlyPropertyDeclaration(PropertyInfoBase propertyInfo)
        {
            var accessorList = new[]
            {
                SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
            };

            var summary = GetSummary(new[] { $"Gets {propertyInfo.Name}" });

            return GetPropertyDeclaration(propertyInfo, accessorList, summary);
        }

        protected virtual async Task<NamespaceDeclarationSyntax> GenerateInterfaces(NamespaceDeclarationSyntax namespaceDeclaration, ClassGenerationParameters[] generationModelClassGenerationParameters)
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
                classDeclarations.Add(await GetInterfaceDeclarationSyntax(generationModelClassGenerationParameter, prefix, suffix));
            }

            return await Task.FromResult(namespaceDeclaration.AddMembers(classDeclarations.ToArray()));
        }

        protected abstract string GetClassPrefix();

        protected virtual async Task<MemberDeclarationSyntax> GetInterfaceDeclarationSyntax(IClassGenerationParameters classDeclaration, string prefix, string suffix)
        {
            var className = $"I{prefix}{classDeclaration.ClassName}{suffix}";
            var members = GetMembers(classDeclaration);
            var leadingTrivia = GetInterfaceLeadingTrivia(classDeclaration);
            var declaration = SyntaxFactory.InterfaceDeclaration(className)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddMembers(members)
                .WithLeadingTrivia(leadingTrivia);

            var baseInterfaces = GetBaseInterfaces(classDeclaration);
            if (baseInterfaces != null && baseInterfaces.Length > 0)
            {
                var b = baseInterfaces.Select(bi => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(bi)) as BaseTypeSyntax).ToArray();
                declaration = declaration.AddBaseListTypes(b);
            }

            return await Task.FromResult(declaration);
        }

        protected abstract string[] GetInterfaceSummary(IClassGenerationParameters classDeclaration);

        protected MemberDeclarationSyntax[] GetMembers(IClassGenerationParameters classGenerationParameters)
        {
            var result = new List<MemberDeclarationSyntax>();

            var properties = GetPropertyDeclarations(classGenerationParameters);
            AddToList(result, properties);

            var methods = GetMethodDeclarations(classGenerationParameters.ClassName);
            AddToList(result, methods);

            return result.ToArray();
        }

        protected abstract PropertyDeclarationSyntax[] GetPropertyDeclarations(IClassGenerationParameters classGenerationParameters);

        /// <summary>
        /// Gets the method declarations to be generated
        /// </summary>
        /// <returns></returns>
        protected abstract MethodDeclarationSyntax[] GetMethodDeclarations(string entityName);

        /// <summary>
        /// Gets the base class, if any
        /// </summary>
        /// <returns>Base class</returns>
        protected abstract string[] GetBaseInterfaces(IClassGenerationParameters classGenerationParameters);

        private static void AddToList<T>(List<MemberDeclarationSyntax> list, IReadOnlyCollection<T> items)
            where T : MemberDeclarationSyntax
        {
            if (items != null && items.Count > 0)
            {
                list.AddRange(items);
            }
        }

        private IEnumerable<SyntaxTrivia> GetInterfaceLeadingTrivia(IClassGenerationParameters classDeclaration)
        {
            var interfaceSummary = GetInterfaceSummary(classDeclaration);

            return GetSummary(interfaceSummary);
        }

        private IEnumerable<SyntaxTrivia> GetSummary(string[] summaryLines)
        {
            var result = new List<SyntaxTrivia>
            {
                SyntaxFactory.Comment($"/// <summary>")
            };

            var lines = summaryLines.Select(line => SyntaxFactory.Comment($"/// {line}"));
            result.AddRange(lines);

            result.Add(SyntaxFactory.Comment($"/// </summary>"));

            return result;
        }

        private PropertyDeclarationSyntax GetPropertyDeclaration(PropertyInfoBase propertyInfo, AccessorDeclarationSyntax[] accessorList, IEnumerable<SyntaxTrivia> summary)
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

        private async Task<INucleotideGenerationModel> GetModel(INamedTypeSymbol namedTypeSymbols, CSharpCompilation compilation)
        {
            //var compilation = await document.Project.GetCompilationAsync();
            var assembly = GetAssembly(namedTypeSymbols.ContainingAssembly, compilation);

            var modelType = assembly.GetType($"{ namedTypeSymbols.ContainingNamespace}.{ namedTypeSymbols.Name}");
            if (modelType == null)
            {
                throw new Exception("Unable to find model type");
            }

            var instance = Activator.CreateInstance(modelType);
            if (instance == null)
            {
                throw new Exception("Unable to create instance");
            }

            // namedTypeSymbols.ContainingAssembly
            //namedTypeSymbols.Name
            return await Task.FromResult(instance as INucleotideGenerationModel);
        }


        private static Assembly GetAssembly(IAssemblySymbol symbol, Compilation compilation)
        {
            Requires.NotNull(symbol, "symbol");
            Requires.NotNull(compilation, "compilation");

            var matchingReferences = from reference in compilation.References.OfType<PortableExecutableReference>()
                where string.Equals(Path.GetFileNameWithoutExtension(reference.FilePath), symbol.Identity.Name, StringComparison.OrdinalIgnoreCase)
                select new AssemblyName(Path.GetFileNameWithoutExtension(reference.FilePath));

            return Assembly.Load(matchingReferences.First());
        }

    }
}