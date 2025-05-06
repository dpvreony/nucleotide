using Dhgms.Nucleotide.Generators.Features.Core;
using Dhgms.Nucleotide.Generators.Features.Cqrs.Requests;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dhgms.Nucleotide.Generators.Features.Cqrs.RequestFactories
{
    public sealed class RequestFactoryInterfaceMemberDeclarationSyntaxFactory : IMemberDeclarationSyntaxFactory<RequestFactoryModel>
    {
        public SyntaxList<MemberDeclarationSyntax> GetMemberDeclarationSyntaxCollection(IReadOnlyCollection<RequestFactoryModel> featureModels)
        {
            throw new NotImplementedException();
        }
    }
}
