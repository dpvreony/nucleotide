using Dhgms.Nucleotide.Common.Models;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Features.SignalR
{
    /// <summary>
    /// Generator for SignalR Hub Interface
    /// </summary>
    public sealed class SignalRHubInterfaceGeneratorProcessor : BaseInterfaceLevelCodeGeneratorProcessor
    {
        protected override string[] GetClassPrefixes() => null;

        protected override string[] GetInterfaceSummary(IEntityGenerationModel entityDeclaration)
        {
            return new[]
            {
                $"SignalR Hub interface for {entityDeclaration.ClassName}"
            };
        }

        protected override string GetClassSuffix()
        {
            return "Hub";
        }

        protected override PropertyDeclarationSyntax[] GetPropertyDeclarations(
            IEntityGenerationModel entityGenerationModel, string prefix)
        {
            return null;
        }

        protected override MethodDeclarationSyntax[] GetMethodDeclarations(string className, string prefix)
        {
            return new []
            {
                this.GetOnAddMethod(),
                this.GetOnDeleteMethod(),
                this.GetOnUpdateMethod()
            };
        }

        protected override string[] GetBaseInterfaces(IEntityGenerationModel entityGenerationModel, string prefix)
        {
            return null;
        }

        private MethodDeclarationSyntax GetOnAddMethod()
        {
            var methodName = "OnAddAsync";

            var returnType = SyntaxFactory.ParseTypeName($"System.Threading.Tasks.Task");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
            return declaration;
        }

        private MethodDeclarationSyntax GetOnDeleteMethod()
        {
            var methodName = "OnDeleteAsync";

            var returnType = SyntaxFactory.ParseTypeName($"System.Threading.Tasks.Task");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
            return declaration;
        }

        private MethodDeclarationSyntax GetOnUpdateMethod()
        {
            var methodName = "OnUpdateAsync";

            var returnType = SyntaxFactory.ParseTypeName($"System.Threading.Tasks.Task");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
            return declaration;
        }
    }
}
