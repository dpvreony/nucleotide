using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Dhgms.Nucleotide.Generators.Features.AspNetCore.MvcControllers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.Core.Roslyn
{
    public static class ConstructorMemberDeclarationSyntaxFactory
    {
        public static ConstructorDeclarationSyntax GetConstructorDeclaration(string name, ConstructorModel constructorModel)
        {
            var constructorDeclarationSyntax = SyntaxFactory.ConstructorDeclaration(
                SyntaxFactory.Identifier(name))
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                .WithBody(SyntaxFactory.Block());

            var parameterList = GetParameterList(constructorModel);
            if (parameterList != null)
            {
                constructorDeclarationSyntax = constructorDeclarationSyntax.WithParameterList(parameterList);
            }

            if (constructorModel.ArgsForFieldAssignments != null)
            {
                foreach (var arg in constructorModel.ArgsForFieldAssignments)
                {
                    // Add field assignment logic here
                }
            }
            if (constructorModel.ArgsForBaseConstructorPassThrough != null)
            {
                foreach (var arg in constructorModel.ArgsForBaseConstructorPassThrough)
                {
                    // Add base constructor pass-through logic here
                }
                var seperatedSyntaxList = new SeparatedSyntaxList<ArgumentSyntax>();

                foreach (var baseArgument in constructorModel.ArgsForBaseConstructorPassThrough)
                {
                    seperatedSyntaxList = seperatedSyntaxList.Add(
                        SyntaxFactory.Argument(
                            SyntaxFactory.IdentifierName(SyntaxFactory.Identifier(baseArgument.ParameterName))));
                }

                var baseInitializerArgumentList = SyntaxFactory.ArgumentList(seperatedSyntaxList);

                var initializer = SyntaxFactory.ConstructorInitializer(
                    SyntaxKind.BaseConstructorInitializer,
                    baseInitializerArgumentList);
                constructorDeclarationSyntax = constructorDeclarationSyntax.WithInitializer(initializer);
            }
            return constructorDeclarationSyntax;
        }

        private static ParameterListSyntax? GetParameterList(ConstructorModel constructorModel)
        {
            var parameters = SyntaxFactory.SeparatedList<ParameterSyntax>();

            if (constructorModel.ArgsForFieldAssignments?.Count > 0)
            {
                foreach (var p in constructorModel.ArgsForFieldAssignments)
                {
                    parameters = parameters.Add(
                        SyntaxFactory.Parameter(
                            SyntaxFactory.List<AttributeListSyntax>(),
                            SyntaxFactory.TokenList(),
                            SyntaxFactory.ParseTypeName(p.ContainingNamespace),
                            SyntaxFactory.Identifier(p.Name),
                            null));
                }
            }

            if (constructorModel.ArgsForBaseConstructorPassThrough?.Count > 0)
            {
                foreach (var p in constructorModel.ArgsForBaseConstructorPassThrough)
                {
                    parameters = parameters.Add(
                        SyntaxFactory.Parameter(
                            SyntaxFactory.List<AttributeListSyntax>(),
                            SyntaxFactory.TokenList(),
                            SyntaxFactory.ParseTypeName(p.ContainingNamespace),
                            SyntaxFactory.Identifier(p.Name),
                            null));
                }
            }

            return SyntaxFactory.ParameterList(parameters);
        }
    }
}
