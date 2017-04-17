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
        /// <param name="applyTo">The syntax node this attribute is found on.</param>
        /// <param name="compilation">The overall compilation being generated for.</param>
        /// <param name="progress">A way to report diagnostic messages.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The generated member syntax to be added to the project.</returns>
        public async Task<SyntaxList<MemberDeclarationSyntax>> GenerateAsync(
            MemberDeclarationSyntax applyTo,
            CSharpCompilation compilation,
            IProgress<Diagnostic> progress,
            CancellationToken cancellationToken)
        {
            var namespaceName = GetNamespace();
            var namespaceDeclaration = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.IdentifierName(namespaceName));

            var castDetails = (System.Collections.Immutable.ImmutableArray<TypedConstant>)this.nucleotideGenerationModel;

            var a = castDetails.First();
            var namedTypeSymbols = a.Value as INamedTypeSymbol;
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
                where string.Equals(Path.GetFileNameWithoutExtension(reference.FilePath), symbol.Identity.Name, StringComparison.OrdinalIgnoreCase) // TODO: make this more correct
                select new AssemblyName(Path.GetFileNameWithoutExtension(reference.FilePath));

            return Assembly.Load(matchingReferences.First());
        }

        protected virtual async Task<NamespaceDeclarationSyntax> GenerateInterfaces(NamespaceDeclarationSyntax namespaceDeclaration, ClassGenerationParameters[] generationModelClassGenerationParameters)
        {
            if (generationModelClassGenerationParameters == null || generationModelClassGenerationParameters.Length < 1)
            {
                namespaceDeclaration = namespaceDeclaration.WithLeadingTrivia(SyntaxFactory.Comment("#error DROP OUT 2"));
                return namespaceDeclaration;
            }

            var classDeclarations = new List<MemberDeclarationSyntax>();

            var suffix = GetClassSuffix();
            foreach (var generationModelClassGenerationParameter in generationModelClassGenerationParameters)
            {
                classDeclarations.Add(await GetInterfaceDeclarationSyntax(generationModelClassGenerationParameter, suffix));
            }

            return await Task.FromResult(namespaceDeclaration.AddMembers(classDeclarations.ToArray()));
        }

        protected virtual async Task<MemberDeclarationSyntax> GetInterfaceDeclarationSyntax(IClassGenerationParameters classDeclaration, string suffix)
        {
            var className = $"I{classDeclaration.ClassName}{suffix}";
            var members = GetMembers(classDeclaration.ClassName);
            var declaration = SyntaxFactory.InterfaceDeclaration(className)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddMembers(members);

            var baseInterfaces = GetBaseInterfaces();
            if (baseInterfaces != null && baseInterfaces.Length > 0)
            {
                var b = baseInterfaces.Select(bi => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(bi)) as BaseTypeSyntax).ToArray();
                declaration = declaration.AddBaseListTypes(b);
            }

            return await Task.FromResult(declaration);
        }

        protected MemberDeclarationSyntax[] GetMembers(string entityName)
        {
            var result = new List<MemberDeclarationSyntax>();

            var methods = GetMethodDeclarations(entityName);
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
        protected abstract MemberDeclarationSyntax[] GetMethodDeclarations(string entityName);

        /// <summary>
        /// Gets the base class, if any
        /// </summary>
        /// <returns>Base class</returns>
        protected abstract string[] GetBaseInterfaces();
    }
}
