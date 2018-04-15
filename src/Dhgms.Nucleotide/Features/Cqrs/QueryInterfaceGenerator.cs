using System.Collections.Generic;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Model;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Features.Cqrs
{
    /// <summary>
    /// Generator for Query Interface
    /// </summary>
    public sealed class QueryInterfaceGenerator : BaseInterfaceLevelCodeGenerator
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryInterfaceGenerator"/> class. 
        /// </summary>
        public QueryInterfaceGenerator(AttributeData attributeData) : base(attributeData)
        {
        }

        protected override string[] GetClassPrefixes() => new []{ "List", "View" };

        protected override string[] GetInterfaceSummary(IEntityGenerationModel entityDeclaration)
        {
            return new[]
            {
                $"Query for {entityDeclaration.ClassName}"
            };
        }

        protected override string GetClassSuffix() => "Query";

        protected override string GetNamespace() => "Queries";

        protected override PropertyDeclarationSyntax[] GetPropertyDeclarations(
            IEntityGenerationModel entityGenerationModel, string prefix)
        {
            //var result = new List<PropertyDeclarationSyntax>
            //{
            //    GetRequestDtoPropertyDeclaration(entityGenerationModel, prefix),
            //    GetClaimsPrincipalDeclaration()
            //};

            //return result.ToArray();
            return null;
        }

        private PropertyDeclarationSyntax GetClaimsPrincipalDeclaration()
        {
            var methodName = "ClaimsPrincipal";

            var accessor = new[]
            {
                SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
            };

            var returnType = SyntaxFactory.ParseTypeName($"System.Security.Claims.ClaimsPrincipal");
            var declaration = SyntaxFactory.PropertyDeclaration(returnType, methodName)
                .AddAccessorListAccessors(accessor);

            return declaration;
        }

        private PropertyDeclarationSyntax GetRequestDtoPropertyDeclaration(IEntityGenerationModel entityGenerationModel,
            string prefix)
        {
            var methodName = "RequestDto";

            var accessor = new[]
            {
                SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
            };

            var returnType = SyntaxFactory.ParseTypeName($"RequestDtos.{prefix}{entityGenerationModel.ClassName}RequestDto");
            var declaration = SyntaxFactory.PropertyDeclaration(returnType, methodName)
                .AddAccessorListAccessors(accessor);

            return declaration;
            return null;
        }

        protected override MethodDeclarationSyntax[] GetMethodDeclarations(string className, string prefix)
        {
            return null;
        }

        protected override string[] GetBaseInterfaces(IEntityGenerationModel entityGenerationModel, string prefix)
        {
            // this is a temporary workaround
            // this class needs splitting into 2 levels
            // there is a namespace \ interface collection level generator
            // then a class\interface level generator
            // the prefixes thing needs to go, it's flawed
            // the collection level should create instances of a reusable interface level generator.
            if (prefix.Equals("View"))
            {
                return new[]
                {
                    $"Dhgms.AspNetCoreContrib.Abstractions.IAuditableRequest<long, ResponseDtos.{prefix}{entityGenerationModel.ClassName}ResponseDto>"
                };
            }
            
            return new[]
            {
                $"Dhgms.AspNetCoreContrib.Abstractions.IAuditableRequest<RequestDtos.{prefix}{entityGenerationModel.ClassName}RequestDto, ResponseDtos.{prefix}{entityGenerationModel.ClassName}ResponseDto>"
            };
        }
    }
}
