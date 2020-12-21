using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Dhgms.Nucleotide.Features.SignalR
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
