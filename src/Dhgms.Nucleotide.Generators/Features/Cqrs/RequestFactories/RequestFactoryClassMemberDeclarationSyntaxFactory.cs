using Dhgms.Nucleotide.Generators.Features.Core;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dhgms.Nucleotide.Generators.Features.Cqrs.RequestFactories
{
    public sealed class RequestFactoryClassMemberDeclarationSyntaxFactory : IMemberDeclarationSyntaxFactory<RequestFactoryModel>
    {
        public SyntaxList<MemberDeclarationSyntax> GetMemberDeclarationSyntaxCollection(IReadOnlyCollection<RequestFactoryModel> featureModels)
        {
            throw new NotImplementedException();
        }
    }
}
