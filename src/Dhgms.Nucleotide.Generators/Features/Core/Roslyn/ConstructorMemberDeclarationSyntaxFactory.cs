using System.Collections.Generic;
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
            var parameters = new List<ParameterSyntax>();

            if (constructorModel.ArgsForFieldAssignments?.Count > 0)
            {
                ParameterSyntaxFactory.PopulateParameterSyntaxList(parameters, constructorModel.ArgsForFieldAssignments);
            }

            if (constructorModel.ArgsForBaseConstructorPassThrough?.Count > 0)
            {
                ParameterSyntaxFactory.PopulateParameterSyntaxList(parameters, constructorModel.ArgsForBaseConstructorPassThrough);
            }

            return SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList<ParameterSyntax>(parameters));
        }
    }
}
