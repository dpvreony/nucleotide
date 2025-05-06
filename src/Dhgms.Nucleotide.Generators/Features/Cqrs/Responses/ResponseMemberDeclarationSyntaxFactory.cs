using Dhgms.Nucleotide.Generators.Features.Core;
using Dhgms.Nucleotide.Generators.Features.Cqrs.Requests;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dhgms.Nucleotide.Generators.Features.Cqrs.Responses
{
    public sealed class ResponseMemberDeclarationSyntaxFactory : IMemberDeclarationSyntaxFactory<ResponseModel>
    {
        public SyntaxList<MemberDeclarationSyntax> GetMemberDeclarationSyntaxCollection(IReadOnlyCollection<ResponseModel> featureModels)
        {
            throw new NotImplementedException();
        }
    }
}
