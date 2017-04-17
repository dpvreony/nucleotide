using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeGeneration.Roslyn;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Validation;

namespace Dhgms.Nucleotide.Generators
{
    /// <summary>
    /// Generator for SignalR Hub Interface
    /// </summary>
    public sealed class SignalRHubInterfaceGenerator : BaseInterfaceLevelCodeGenerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SignalRHubInterfaceGenerator"/> class.
        /// </summary>
        public SignalRHubInterfaceGenerator(AttributeData attributeData) : base(attributeData)
        {
        }

        protected override string GetClassSuffix()
        {
            return "Hub";
        }

        protected override string GetNamespace()
        {
            return "Hubs";
        }

        protected override MemberDeclarationSyntax[] GetMethodDeclarations(string entityName)
        {
            return new []
            {
                this.GetOnAddMethod(),
                this.GetOnDeleteMethod(),
                this.GetOnUpdateMethod()
            };
        }

        protected override string[] GetBaseInterfaces()
        {
            return null;
        }

        private MemberDeclarationSyntax GetOnAddMethod()
        {
            var methodName = "OnAddAsync";

            var returnType = SyntaxFactory.ParseTypeName($"System.Threading.Tasks.Task");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
            return declaration;
        }

        private MemberDeclarationSyntax GetOnDeleteMethod()
        {
            var methodName = "OnDeleteAsync";

            var returnType = SyntaxFactory.ParseTypeName($"System.Threading.Tasks.Task");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
            return declaration;
        }

        private MemberDeclarationSyntax GetOnUpdateMethod()
        {
            var methodName = "OnUpdateAsync";

            var returnType = SyntaxFactory.ParseTypeName($"System.Threading.Tasks.Task");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
            return declaration;
        }
    }
}
