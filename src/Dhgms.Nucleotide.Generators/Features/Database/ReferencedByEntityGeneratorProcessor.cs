using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.Database
{
    public sealed class ReferencedByEntityGeneratorProcessor : BaseInterfaceLevelCodeGeneratorProcessor<IEntityGenerationModel>
    {
        protected override string[] GetClassPrefixes()
        {
            throw new NotImplementedException();
        }

        protected override string GetClassSuffix()
        {
            throw new NotImplementedException();
        }

        protected override string[] GetInterfaceSummary(IEntityGenerationModel entityDeclaration)
        {
            throw new NotImplementedException();
        }

        protected override PropertyDeclarationSyntax[] GetPropertyDeclarations(IEntityGenerationModel entityGenerationModel, string prefix)
        {
            throw new NotImplementedException();
        }

        protected override MethodDeclarationSyntax[] GetMethodDeclarations(string className, string prefix)
        {
            throw new NotImplementedException();
        }

        protected override string[] GetBaseInterfaces(IEntityGenerationModel entityGenerationModel, string prefix)
        {
            throw new NotImplementedException();
        }
    }
}
