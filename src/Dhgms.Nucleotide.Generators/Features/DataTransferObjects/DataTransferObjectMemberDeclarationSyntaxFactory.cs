using System.Collections.Generic;
using System.Linq;
using Dhgms.Nucleotide.Generators.Features.Core.Roslyn;
using Dhgms.Nucleotide.Generators.Features.Core.XmlDoc;
using Dhgms.Nucleotide.Generators.Features.Core;
using Dhgms.Nucleotide.Generators.Features.Cqrs.Requests;
using Dhgms.Nucleotide.SampleGenerator.DataTransferObjects;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.Generators.Features.DataTransferObjects
{
    public sealed class DataTransferObjectMemberDeclarationSyntaxFactory : IMemberDeclarationSyntaxFactory<DataTransferObjectModel>
    {
        public SyntaxList<MemberDeclarationSyntax> GetMemberDeclarationSyntaxCollection(IList<DataTransferObjectModel> featureModels)
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

        private RecordDeclarationSyntax GetRecordDeclaration(DataTransferObjectModel requestModel)
        {
            var record = SyntaxFactory.RecordDeclaration(
                    SyntaxFactory.Token(SyntaxKind.RecordKeyword),
                    requestModel.TypeName)
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
                        SyntaxFactory.ParseTypeName($"{p.ContainingNamespace}.{p.TypeName}"),
                        SyntaxFactory.Identifier(p.ParameterName),
                        null))
                    .ToArray();

                var parameters = properties;

                record = record.AddParameterListParameters(parameters);
            }

            var xmlDoc = SyntaxTriviaFactory.GetXmlDocumentation(
                requestModel.XmlDocSummary,
                [
                    $"var request = new {requestModel.TypeName}({string.Join(", ", requestModel.Properties.Select(p => p.ParameterName))});",
                ]);

            var leadingTrivia = SyntaxTriviaFactory.GetSummary(["Represents a request model."]);

            if (requestModel.BaseTypeSyntaxFunc != null)
            {
                record = record.WithBaseList(SyntaxFactory.BaseList(SyntaxFactory.SingletonSeparatedList(requestModel.BaseTypeSyntaxFunc())));
            }

            return record
                .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
                .WithLeadingTrivia(leadingTrivia)
                .WithLeadingTrivia(xmlDoc);
        }
    }
}
