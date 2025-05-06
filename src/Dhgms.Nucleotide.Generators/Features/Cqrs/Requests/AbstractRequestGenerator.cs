// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.Cqrs.Requests
{
    public abstract class AbstractRequestGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var requestModels = GetRequestModels().GroupBy(rm => rm.ContainingNamespace);

            foreach (var groupedRequestModel in requestModels)
            {
                var namespaceDeclaration = GetNamespaceDeclaration(groupedRequestModel);
            }
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
            return SyntaxFactory.RecordDeclaration(
                SyntaxFactory.Token(SyntaxKind.RecordDeclaration),
                requestModel.Name)
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                .WithBaseList(SyntaxFactory.BaseList(SyntaxFactory.SingletonSeparatedList(requestModel.BaseTypeSyntaxFunc())));
        }
    }
}
