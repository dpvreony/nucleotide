using System.Collections.Generic;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Model;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Features.Cqrs
{
    /// <summary>
    /// Generator for Command Factory Interface
    /// </summary>
    public sealed class CommandFactoryInterfaceGenerator : BaseInterfaceLevelCodeGenerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandFactoryInterfaceGenerator"/> class. 
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

        protected override string[] GetClassPrefixes() => null;

        protected override string[] GetInterfaceSummary(IEntityGenerationModel entityDeclaration)
        {
            return new []
            {
                $"Command factory for {entityDeclaration.ClassName}"
            };
        }

        protected override PropertyDeclarationSyntax[] GetPropertyDeclarations(
            IEntityGenerationModel entityGenerationModel, string prefix)
        {
            return null;
        }

        protected override MethodDeclarationSyntax[] GetMethodDeclarations(string className, string prefix)
        {
            var result = new List<MethodDeclarationSyntax>
            {
                GetAddMethodDeclaration(className),
                GetDeleteMethodDeclaration(className),
                GetUpdateMethodDeclaration(className),
            };

            return result.ToArray();
        }

        protected override string[] GetBaseInterfaces(IEntityGenerationModel entityGenerationModel, string prefix)
        {
            var className = entityGenerationModel.ClassName;
            return new []
            {
                $"Dhgms.AspNetCoreContrib.Abstractions.IAuditableCommandFactory<Commands.IAdd{className}Command, RequestDtos.Add{className}RequestDto, ResponseDtos.Add{className}ResponseDto, Commands.IDelete{className}Command, ResponseDtos.Delete{className}ResponseDto, Commands.IUpdate{className}Command, RequestDtos.Update{className}RequestDto, ResponseDtos.Update{className}ResponseDto>"
            };
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
