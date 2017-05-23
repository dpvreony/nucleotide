using System;
using System.Collections.Generic;
using System.Linq;
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

        protected override string GetClassPrefix()
        {
            return null;
        }

        protected override string[] GetInterfaceSummary(IClassGenerationParameters classDeclaration)
        {
            return new []
            {
                $"Command factory for {classDeclaration.ClassName}"
            };
        }

        protected override PropertyDeclarationSyntax[] GetPropertyDeclarations(IClassGenerationParameters classGenerationParameters)
        {
            return null;
        }

        protected override MethodDeclarationSyntax[] GetMethodDeclarations(string entityName)
        {
            var result = new List<MethodDeclarationSyntax>
            {
                GetAddMethodDeclaration(entityName),
                GetDeleteMethodDeclaration(entityName),
                GetUpdateMethodDeclaration(entityName),
            };

            return result.ToArray();
        }

        protected override string[] GetBaseInterfaces(IClassGenerationParameters classGenerationParameters)
        {
            return null;
        }

        private MethodDeclarationSyntax GetAddMethodDeclaration(string entityName)
        {
            var methodName = "GetAddCommandAsync";

            var returnType = SyntaxFactory.ParseTypeName($"System.Threading.Tasks.Task<Commands.IAdd{entityName}Command>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
            return declaration;
        }

        private MethodDeclarationSyntax GetDeleteMethodDeclaration(string entityName)
        {
            var methodName = "GetDeleteCommandAsync";

            var returnType = SyntaxFactory.ParseTypeName($"System.Threading.Tasks.Task<Commands.IDelete{entityName}Command>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
            return declaration;
        }

        private MethodDeclarationSyntax GetUpdateMethodDeclaration(string entityName)
        {
            var methodName = "GetUpdateCommandAsync";

            var returnType = SyntaxFactory.ParseTypeName($"System.Threading.Tasks.Task<Commands.IUpdate{entityName}Command>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
            return declaration;
        }
    }
}
