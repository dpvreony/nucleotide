using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Common.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.GeneratorProcessors
{
    public class ServiceInterfaceGeneratorProcessor : BaseInterfaceLevelCodeGeneratorProcessor
    {
        protected override string[] GetClassPrefixes() => null;

        protected override string[] GetInterfaceSummary(IEntityGenerationModel entityDeclaration)
        {
            return new[]
            {
                $"Service Interface for {entityDeclaration.ClassName}"
            };
        }

        protected override string GetClassSuffix()
        {
            return "Service";
        }

        protected override PropertyDeclarationSyntax[] GetPropertyDeclarations(
            IEntityGenerationModel entityGenerationModel, string prefix)
        {
            return null;
        }

        protected override MethodDeclarationSyntax[] GetMethodDeclarations(string className, string prefix)
        {
            return null;
        }

        protected override string[] GetBaseInterfaces(IEntityGenerationModel entityGenerationModel, string prefix)
        {
            return null;
        }
    }
}
