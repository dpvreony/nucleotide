﻿// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.SignalR
{
    /// <summary>
    /// Generator for SignalR Hub Interface
    /// </summary>
    public sealed class SignalRHubInterfaceGeneratorProcessor : BaseInterfaceLevelCodeGeneratorProcessor<IEntityGenerationModel>
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
