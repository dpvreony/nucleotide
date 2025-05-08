// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;
using Dhgms.Nucleotide.Generators.Features.Core;
using Dhgms.Nucleotide.Generators.Features.Core.Roslyn;
using Dhgms.Nucleotide.Generators.Features.Core.XmlDoc;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.Cqrs.Responses
{
    public sealed class ResponseMemberDeclarationSyntaxFactory : IMemberDeclarationSyntaxFactory<ResponseModel>
    {
        public SyntaxList<MemberDeclarationSyntax> GetMemberDeclarationSyntaxCollection(IList<ResponseModel> featureModels)
        {
            var responseModels = featureModels.GroupBy(rm => rm.ContainingNamespace);

            var namespaceDeclarations = new List<MemberDeclarationSyntax>();
            foreach (var groupedResponseModel in responseModels)
            {
                namespaceDeclarations.Add(NamespaceDeclarationFactory.GetNamespaceDeclaration(
                    groupedResponseModel, 
                    model => GetRecordDeclaration(model)));
            }

            return new SyntaxList<MemberDeclarationSyntax>(namespaceDeclarations);
        }

        private RecordDeclarationSyntax GetRecordDeclaration(ResponseModel responseModel)
        {
            var record = SyntaxFactory.RecordDeclaration(
                    SyntaxFactory.Token(SyntaxKind.RecordKeyword),
                    responseModel.Name)
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword)));

            if (responseModel.IsSealed)
            {
                record = record.AddModifiers(SyntaxFactory.Token(SyntaxKind.SealedKeyword));
            }

            if (responseModel.Properties.Length > 0)
            {
                var properties = responseModel.Properties
                    .Select(static p => SyntaxFactory.Parameter(
                        SyntaxFactory.List<AttributeListSyntax>(),
                        SyntaxFactory.TokenList(),
                        SyntaxFactory.ParseTypeName(p.ContainingNamespace),
                        SyntaxFactory.Identifier(p.TypeName),
                        null))
                    .ToArray();

                var parameters = properties;

                record = record.AddParameterListParameters(parameters);
            }

            var xmlDoc = SyntaxTriviaFactory.GetSummary(responseModel.XmlDocSummary);

            var leadingTrivia = SyntaxTriviaFactory.GetSummary(["Represents a response model."]);

            if (responseModel.BaseTypeSyntaxFunc != null)
            {
                record = record.WithBaseList(SyntaxFactory.BaseList(SyntaxFactory.SingletonSeparatedList(responseModel.BaseTypeSyntaxFunc())));
            }

            return record.WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
                .WithLeadingTrivia(leadingTrivia)
                .WithLeadingTrivia(xmlDoc);
        }
    }
}
