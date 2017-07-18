using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeGeneration.Roslyn;
using Dhgms.Nucleotide.Model;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Validation;

namespace Dhgms.Nucleotide.Generators
{
    public abstract class BaseGenerator : ICodeGenerator
    {
        public abstract Task<SyntaxList<MemberDeclarationSyntax>> GenerateAsync(
            TransformationContext context,
            IProgress<Diagnostic> progress,
            CancellationToken cancellationToken);

        protected async Task<INucleotideGenerationModel> GetModel(INamedTypeSymbol namedTypeSymbols, CSharpCompilation compilation)
        {
            var assembly = GetAssembly(namedTypeSymbols.ContainingAssembly, compilation);

            var typeName = $"{namedTypeSymbols.ContainingNamespace}.{namedTypeSymbols.Name}";
            var modelType = assembly.GetType(typeName);
            //var modelType = Type.GetType(typeName);
            if (modelType == null)
            {
                throw new InvalidOperationException($"Unable to find model type: {typeName}");
            }

            var instance = Activator.CreateInstance(modelType);
            if (instance == null)
            {
                throw new InvalidOperationException($"Unable to create instance: {typeName}");
            }

            // namedTypeSymbols.ContainingAssembly
            //namedTypeSymbols.Name
            return await Task.FromResult(instance as INucleotideGenerationModel);
        }

        protected Assembly GetAssembly(IAssemblySymbol symbol, Compilation compilation)
        {
            Requires.NotNull(symbol, "symbol");
            Requires.NotNull(compilation, "compilation");

            var matchingReferences = (from reference in compilation.References.OfType<PortableExecutableReference>()
                where string.Equals(Path.GetFileNameWithoutExtension(reference.FilePath), symbol.Identity.Name, StringComparison.OrdinalIgnoreCase)
                select reference).ToArray();

            if (matchingReferences == null || matchingReferences.Length == 0)
            {
                throw new InvalidOperationException($"Failed to find {symbol.Identity}");
            }

            var assembly = this.GetType().GetTypeInfo().Assembly;
            var loadContext = AssemblyLoadContext.GetLoadContext(assembly);
            return loadContext.LoadFromAssemblyPath(matchingReferences[0].FilePath);
        }
    }
}
