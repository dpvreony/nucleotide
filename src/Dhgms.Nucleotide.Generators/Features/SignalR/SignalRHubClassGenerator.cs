// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if TBC
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.SignalR
{
    /// <summary>
    /// Generator for SignalR Hub Class
    /// </summary>
    public sealed class SignalRHubClassGenerator : ISourceGenerator
    {
        private MemberDeclarationSyntax[] GetClasses()
        {
            return new MemberDeclarationSyntax[] { };
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            // context.RegisterForSyntaxNotifications();
        }

        public void Execute(GeneratorExecutionContext context)
        {
            var compilationUnit = SyntaxFactory.CompilationUnit();
            var parseOptions = context.ParseOptions;

            var sourceText = SyntaxFactory.SyntaxTree(
                compilationUnit,
                parseOptions,
                encoding: Encoding.UTF8)
                .GetText();

            context.AddSource("nucleotide.signlarhubclass.generated.cs", sourceText);
        }
    }
}
#endif