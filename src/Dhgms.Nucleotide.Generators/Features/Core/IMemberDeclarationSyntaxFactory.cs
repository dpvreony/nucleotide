using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.Core
{
    public interface IMemberDeclarationSyntaxFactory<in TFeatureModel>
    {
        SyntaxList<MemberDeclarationSyntax> GetMemberDeclarationSyntaxCollection(IReadOnlyCollection<TFeatureModel> featureModels);
    }
}
