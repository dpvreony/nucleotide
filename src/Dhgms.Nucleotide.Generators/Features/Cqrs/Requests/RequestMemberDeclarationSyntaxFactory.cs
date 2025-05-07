using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dhgms.Nucleotide.Generators.Features.Core;
using Dhgms.Nucleotide.Generators.Features.Core.Roslyn;
using Dhgms.Nucleotide.Generators.Features.Core.XmlDoc;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.Cqrs.Requests
{
    public sealed class RequestMemberDeclarationSyntaxFactory : IMemberDeclarationSyntaxFactory<RequestModel>
    {
        public SyntaxList<MemberDeclarationSyntax> GetMemberDeclarationSyntaxCollection(IList<RequestModel> featureModels)
        {
            var requestModels = featureModels.GroupBy(rm => rm.ContainingNamespace);

            var namespaceDeclarations = new List<MemberDeclarationSyntax>();
            foreach (var groupedRequestModel in requestModels)
            {
                namespaceDeclarations.Add(NamespaceDeclarationFactory.GetNamespaceDeclaration(
                    groupedRequestModel,
                    model => GetRecordDeclaration(model)));
            }

            return new SyntaxList<MemberDeclarationSyntax>(namespaceDeclarations);
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

            if (requestModel.Properties.Length > 0)
            {
                var properties = requestModel.Properties
                    .Select(static p => SyntaxFactory.Parameter(
                        SyntaxFactory.List<AttributeListSyntax>(),
                        SyntaxFactory.TokenList(),
                        SyntaxFactory.ParseTypeName(p.ContainingNamespace),
                        SyntaxFactory.Identifier(p.Name),
                        null))
                    .ToArray();

                var parameters = properties;

                record = record.AddParameterListParameters(parameters);
            }

            var xmlDoc = SyntaxTriviaFactory.GetXmlDocumentation(
                requestModel.XmlDocSummary,
                [
                    $"var request = new {requestModel.Name}({string.Join(", ", requestModel.Properties.Select(p => p.Name))});",
                    "var response = await mediator.Send(request).ConfigureAwait(false);"
                ]);

            var leadingTrivia = SyntaxTriviaFactory.GetSummary(["Represents a request model."]);

            return record.WithBaseList(SyntaxFactory.BaseList(SyntaxFactory.SingletonSeparatedList(requestModel.BaseTypeSyntaxFunc())))
                .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
                .WithLeadingTrivia(leadingTrivia)
                .WithLeadingTrivia(xmlDoc);
        }
    }
}
