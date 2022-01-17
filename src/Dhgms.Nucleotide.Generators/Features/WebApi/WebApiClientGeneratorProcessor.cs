// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.Generators.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.WebApi
{
    public sealed class WebApiClientGeneratorProcessor : BaseClassLevelCodeGeneratorProcessor<IEntityGenerationModel>
    {
        protected override IEnumerable<PropertyDeclarationSyntax> GetPropertyDeclarations(IEntityGenerationModel entityGenerationModel)
        {
            return null;
        }

        protected override bool GetWhetherClassShouldBePartialClass() => true;

        protected override bool GetWhetherClassShouldBeSealedClass() => true;

        protected override IList<string> GetBaseConstructorArguments() => null;

        /// <inheritdoc />
        protected override string[] GetClassPrefixes() => null;

        protected override string GetClassSuffix()
        {
            return "ApiClient";
        }

        protected override IList<string> GetUsings()
        {
            return null;
        }

        /// <inheritdoc />
        protected override string GetBaseClass(string entityName)
        {
            return null;
        }

        protected override IEnumerable<string> GetImplementedInterfaces(IEntityGenerationModel entityGenerationModel)
        {
            return new List<string>
            {
                $"Services.I{entityGenerationModel.ClassName}Service"
            };
        }

        /// <inheritdoc />
        protected override IList<Tuple<Func<string, string>, string, Accessibility>> GetConstructorArguments()
        {
            return null;
            //var result = new List<Tuple<Func<string, string>, string, Accessibility>>
            //{
            //    new Tuple<Func<string, string>, string, Accessibility>(entityName => $"I{entityName}SignalRHub", "signalRHub", Accessibility.Private),
            //    new Tuple<Func<string, string>, string, Accessibility>(entityName => $"I{entityName}CommandFactory", "commandFactory", Accessibility.Private),
            //    new Tuple<Func<string, string>, string, Accessibility>(entityName => $"I{entityName}QueryFactory", "queryFactory", Accessibility.Private),
            //};

            //return result;
        }

        protected override IList<Tuple<string, IList<string>>> GetClassAttributes(IEntityGenerationModel entityDeclaration)
        {
            return null;
        }

        /// <inheritdoc />
        protected override MethodDeclarationSyntax[] GetMethodDeclarations(IEntityGenerationModel entityGenerationModel)
        {
            var entityName = entityGenerationModel.ClassName;
            var result = new List<MethodDeclarationSyntax>();

            result.Add(GetAddMethodDeclaration(entityName));
            result.Add(GetDeleteMethodDeclaration(entityName));
            result.Add(GetListMethodDeclaration(entityName));
            result.Add(GetUpdateMethodDeclaration(entityName));
            result.Add(GetViewMethodDeclaration(entityName));

            return result.ToArray();
        }

        protected override string[] GetClassLevelCommentSummary(string entityName)
        {
            return new[]
            {
                $"Web API Client for {entityName}"
            };
        }

        protected override string[] GetClassLevelCommentRemarks(string entityName)
        {
            return null;
        }

        private MethodDeclarationSyntax GetAddMethodDeclaration(string entityName)
        {
            var methodName = "AddAsync";
            var throwStatement = RoslynGenerationHelpers.GetThrowNotImplementedExceptionSyntax() as StatementSyntax;

            var body = new[] { throwStatement };

            var returnType = SyntaxFactory.ParseTypeName("System.Threading.Tasks.Task<int>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName)
                //.WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddBodyStatements(body);
            return declaration;
        }

        private MethodDeclarationSyntax GetDeleteMethodDeclaration(string entityName)
        {
            var throwStatement = RoslynGenerationHelpers.GetThrowNotImplementedExceptionSyntax() as StatementSyntax;

            var body = new[] { throwStatement };

            var returnType = SyntaxFactory.ParseTypeName("System.Threading.Tasks.Task");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, "DeleteAsync")
                //.WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddBodyStatements(body);
            return declaration;
        }

        private MethodDeclarationSyntax GetListMethodDeclaration(string entityName)
        {
            var throwStatement = RoslynGenerationHelpers.GetThrowNotImplementedExceptionSyntax() as StatementSyntax;

            var body = new[] { throwStatement };
            var returnType = SyntaxFactory.ParseTypeName($"System.Threading.Tasks.Task<ResponseDtos.List{entityName}ResponseDto>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, "ListAsync")
                //.WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddBodyStatements(body);
            return declaration;
        }

        private MethodDeclarationSyntax GetUpdateMethodDeclaration(string entityName)
        {
            var throwStatement = RoslynGenerationHelpers.GetThrowNotImplementedExceptionSyntax() as StatementSyntax;

            var body = new[] { throwStatement };

            var returnType = SyntaxFactory.ParseTypeName("System.Threading.Tasks.Task");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, "UpdateAsync")
                //.WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddBodyStatements(body);
            return declaration;
        }

        private MethodDeclarationSyntax GetViewMethodDeclaration(string entityName)
        {
            var throwStatement = RoslynGenerationHelpers.GetThrowNotImplementedExceptionSyntax() as StatementSyntax;

            var body = new[] { throwStatement };

            var returnType = SyntaxFactory.ParseTypeName($"System.Threading.Tasks.Task<ResponseDtos.View{entityName}ResponseDto>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, "ViewAsync")
                //.WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddBodyStatements(body);
            return declaration;
        }

        protected override SeparatedSyntaxList<AttributeSyntax> GetAttributesForProperty(PropertyInfoBase propertyInfo)
        {
            return default(SeparatedSyntaxList<AttributeSyntax>);
        }
    }
}
