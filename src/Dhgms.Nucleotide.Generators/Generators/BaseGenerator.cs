// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Text;
using System.Threading;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Generators
{
    public abstract class BaseGenerator<TFeatureFlags, TGeneratorProcessor, TGenerationModel> : ISourceGenerator
        where TFeatureFlags : class
        where TGeneratorProcessor : BaseGeneratorProcessor<TGenerationModel>, new()
        where TGenerationModel : IClassName
    {
        protected abstract INucleotideGenerationModel<TGenerationModel> NucleotideGenerationModel { get; }

        protected TFeatureFlags FeatureFlags { get; }

        public void Initialize(GeneratorInitializationContext context)
        {
        }

        public static Diagnostic InfoDiagnostic(string message)
        {
            return Diagnostic.Create(
                "NUCI0001",
                "Nucleotide Generation",
                message,
                DiagnosticSeverity.Info,
                DiagnosticSeverity.Info,
                true,
                1,
                "Model Generation");
        }

        public static Diagnostic ErrorDiagnostic(string message)
        {
            return Diagnostic.Create(
                "NUCE0001",
                "Nucleotide Generation",
                message,
                DiagnosticSeverity.Error,
                DiagnosticSeverity.Error,
                true,
                0,
                "Model load error");
        }

        public void Execute(GeneratorExecutionContext context)
        {
            try
            {
                context.ReportDiagnostic(InfoDiagnostic(typeof(TGeneratorProcessor).ToString()));

                // TODO: this is running async code inside non-async
                var memberDeclarationSyntax = Generate(context, CancellationToken.None);

                var parseOptions = context.ParseOptions;

                // TODO: need to review this might be better way than generate, loop, copy.
                // compilationUnit = compilationUnit.AddMembers(memberDeclarationSyntax);

                var cu = SyntaxFactory.CompilationUnit()
                    .AddMembers(memberDeclarationSyntax)
                    .NormalizeWhitespace();

                var feature = typeof(TGeneratorProcessor).ToString();

                var sourceText = SyntaxFactory.SyntaxTree(
                        cu,
                        parseOptions,
                        encoding: Encoding.UTF8)
                    .GetText();

                var hintName = $"{feature}.g.cs";

                context.AddSource(
                    hintName,
                    sourceText);
            }
            catch (Exception e)
            {
                var diagnostic = ErrorDiagnostic(e.ToString());
                context.ReportDiagnostic(diagnostic);
            }
        }

        protected abstract string GetNamespace();

        /// <summary>
        /// Create the syntax tree representing the expansion of some member to which this attribute is applied.
        /// </summary>
        /// <param name="context">The transformation context being generated for.</param>
        /// <param name="progress">A way to report diagnostic messages.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The generated member syntax to be added to the project.</returns>
        private MemberDeclarationSyntax Generate(
            GeneratorExecutionContext context,
            CancellationToken cancellationToken)
        {
            var namespaceName = GetNamespace();

            var generationModel = this.NucleotideGenerationModel;

            var rootNamespace = generationModel.RootNamespace;
            var namespaceDeclaration = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.IdentifierName($"{rootNamespace}.{namespaceName}"));

            var generatorProcessor = new TGeneratorProcessor();

            var result = generatorProcessor.GenerateObjects(
                namespaceDeclaration,
                generationModel);

            return result;
        }
    }
}
