using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeGeneration.Roslyn;
using Dhgms.Nucleotide.Helpers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Validation;

namespace Dhgms.Nucleotide.Generators
{
    /// <summary>
    /// Generator for Command Factory Interface
    /// </summary>
    public sealed class CommandFactoryInterfaceGenerator : BaseInterfaceLevelCodeGenerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WcfServiceGenerator"/> class. 
        /// </summary>
        public CommandFactoryInterfaceGenerator(AttributeData attributeData) : base(attributeData)
        {
        }

        protected override string GetClassSuffix()
        {
            return "CommandFactory";
        }

        protected override string GetNamespace()
        {
            return "CommandFactories";
        }

        protected override MemberDeclarationSyntax[] GetMethodDeclarations(string entityName)
        {
            var result = new List<MemberDeclarationSyntax>
            {
                GetAddMethodDeclaration(entityName),
                GetDeleteMethodDeclaration(entityName),
                GetUpdateMethodDeclaration(entityName),
            };

            return result.ToArray();
        }

        protected override string[] GetBaseInterfaces()
        {
            return null;
        }

        private MemberDeclarationSyntax GetAddMethodDeclaration(string entityName)
        {
            var methodName = "GetAddCommandAsync";

            var returnType = SyntaxFactory.ParseTypeName($"System.Threading.Tasks.Task<Commands.IAdd{entityName}Command>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
            return declaration;
        }

        private MemberDeclarationSyntax GetDeleteMethodDeclaration(string entityName)
        {
            var methodName = "GetDeleteCommandAsync";

            var returnType = SyntaxFactory.ParseTypeName($"System.Threading.Tasks.Task<Commands.IDelete{entityName}Command>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
            return declaration;
        }

        private MemberDeclarationSyntax GetUpdateMethodDeclaration(string entityName)
        {
            var methodName = "GetUpdateCommandAsync";

            var returnType = SyntaxFactory.ParseTypeName($"System.Threading.Tasks.Task<Commands.IUpdate{entityName}Command>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
            return declaration;
        }
    }
}
