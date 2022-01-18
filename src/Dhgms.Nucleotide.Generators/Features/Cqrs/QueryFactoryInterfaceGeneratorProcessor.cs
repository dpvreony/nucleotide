// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.Cqrs
{
    /// <summary>
    /// Generator for Query Factory Interface
    /// </summary>
    public sealed class QueryFactoryInterfaceGeneratorProcessor : BaseInterfaceLevelCodeGeneratorProcessor<IEntityGenerationModel>
    {
        protected override string[] GetClassPrefixes() => Array.Empty<string>();

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

        protected override PropertyDeclarationSyntax[] GetPropertyDeclarations(
            IEntityGenerationModel entityGenerationModel, string prefix)
        {
            return Array.Empty<PropertyDeclarationSyntax>();
        }

        protected override MethodDeclarationSyntax[] GetMethodDeclarations(string className, string prefix)
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
            var className = entityGenerationModel.ClassName;
            return new []
            {
                $"global::Whipstaff.Core.IAuditableQueryFactory<Queries.IList{className}Query, RequestDtos.List{className}RequestDto, ResponseDtos.List{className}ResponseDto, Queries.IView{className}Query, ResponseDtos.View{className}ResponseDto>"
            };
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
