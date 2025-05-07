using System;
using System.Collections.Generic;
using Dhgms.Nucleotide.Generators.Features.Core;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.AspNetCore.MvcControllers
{
    public sealed class MvcControllersMemberDeclarationSyntaxFactory : IMemberDeclarationSyntaxFactory<MvcControllerModel>
    {
        public SyntaxList<MemberDeclarationSyntax> GetMemberDeclarationSyntaxCollection(IReadOnlyCollection<MvcControllerModel> featureModels)
        {
            throw new NotImplementedException();
        }
    }
}
