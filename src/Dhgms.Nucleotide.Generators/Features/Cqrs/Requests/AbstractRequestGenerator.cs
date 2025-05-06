// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.Cqrs.Requests
{
    public abstract class AbstractRequestGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var rawModels = GetRequestModels();
            var rawModelsHashCode = rawModels.Select(rm => rm.GetHashCode()).GetHashCode();

            var requestModels = rawModels.GroupBy(rm => rm.ContainingNamespace);

            var namespaceDeclarations = new List<MemberDeclarationSyntax>();
            foreach (var groupedRequestModel in requestModels)
            {
                namespaceDeclarations.Add(GetNamespaceDeclaration(groupedRequestModel));
            }

            var parseOptions = context.ParseOptions;

            // TODO: need to review this might be better way than generate, loop, copy.
            // compilationUnit = compilationUnit.AddMembers(memberDeclarationSyntax);

            var nullableSyntaxDirective = SyntaxFactory.NullableDirectiveTrivia(SyntaxFactory.Token(SyntaxKind.EnableKeyword), true);
            var trivia = SyntaxFactory.Trivia(nullableSyntaxDirective);
            var triviaList = SyntaxFactory.TriviaList(trivia);

            var cu = SyntaxFactory.CompilationUnit()
                .AddMembers(namespaceDeclarations.ToArray())
                .WithLeadingTrivia(triviaList)
                .NormalizeWhitespace();

            var sourceText = SyntaxFactory.SyntaxTree(
                    cu,
                    parseOptions,
                    encoding: Encoding.UTF8)
                .GetText();

            var hintName = $"Nucelotide.Cqrs.Requests.g.cs";

            context.AddSource(
                hintName,
                sourceText);

        }

        public void Initialize(GeneratorInitializationContext context)
        {
        }

        protected abstract IEnumerable<RequestModel> GetRequestModels();

        private NamespaceDeclarationSyntax GetNamespaceDeclaration(IGrouping<string, RequestModel> groupedRequestModel)
        {
            var namespaceDeclaration = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(groupedRequestModel.Key));

            foreach (var requestModel in groupedRequestModel)
            {
                var recordDeclaration = GetRecordDeclaration(requestModel);
                namespaceDeclaration = namespaceDeclaration.AddMembers(recordDeclaration);
            }

            return namespaceDeclaration;
        }

        private RecordDeclarationSyntax GetRecordDeclaration(RequestModel requestModel)
        {
            var record = SyntaxFactory.RecordDeclaration(
                    SyntaxFactory.Token(SyntaxKind.RecordKeyword),
                    requestModel.Name)
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword)));

            if (requestModel.IsSealed)
            {
                record = record.AddModifiers(SyntaxFactory.Token(SyntaxKind.SealedKeyword));
            }

            return record.WithBaseList(SyntaxFactory.BaseList(SyntaxFactory.SingletonSeparatedList(requestModel.BaseTypeSyntaxFunc())))
                .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }
    }
}
