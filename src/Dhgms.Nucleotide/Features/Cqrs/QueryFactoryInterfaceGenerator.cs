using System.Collections.Generic;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Model;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Features.Cqrs
{
    /// <summary>
    /// Generator for Query Factory Interface
    /// </summary>
    public sealed class QueryFactoryInterfaceGenerator : BaseInterfaceLevelCodeGenerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryFactoryInterfaceGenerator"/> class. 
        /// </summary>
        public QueryFactoryInterfaceGenerator(AttributeData attributeData) : base(attributeData)
        {
        }

        protected override string[] GetClassPrefixes() => null;

        protected override string[] GetInterfaceSummary(IEntityGenerationModel entityDeclaration)
        {
            return new[]
            {
                $"Query factory for {entityDeclaration.ClassName}"
            };
        }

        protected override string GetClassSuffix()
        {
            return "QueryFactory";
        }

        protected override string GetNamespace()
        {
            return "QueryFactories";
        }

        protected override PropertyDeclarationSyntax[] GetPropertyDeclarations(
            IEntityGenerationModel entityGenerationModel, string prefix)
        {
            return null;
        }

        protected override MethodDeclarationSyntax[] GetMethodDeclarations(string className, string entityName)
        {
            var result = new List<MethodDeclarationSyntax>
            {
                GetListMethodDeclaration(className),
                GetViewMethodDeclaration(className)
            };

            return result.ToArray();
        }

        protected override string[] GetBaseInterfaces(IEntityGenerationModel entityGenerationModel, string prefix)
        {
            return null;
        }

        private MethodDeclarationSyntax GetListMethodDeclaration(string entityName)
        {
            var methodName = "GetListQueryAsync";

            var returnType = SyntaxFactory.ParseTypeName($"System.Threading.Tasks.Task<Queries.IList{entityName}Query>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
            return declaration;
        }

        private MethodDeclarationSyntax GetViewMethodDeclaration(string entityName)
        {
            var methodName = "GetViewQueryAsync";

            var returnType = SyntaxFactory.ParseTypeName($"System.Threading.Tasks.Task<Queries.IView{entityName}Query>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
            return declaration;
        }
    }
}
