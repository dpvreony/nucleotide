using System.Linq;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.Model
{
    public sealed class UnkeyedModelInterfaceGeneratorProcessor : BaseInterfaceLevelCodeGeneratorProcessor<IEntityGenerationModel>
    {
        protected override string GetClassSuffix()
        {
            return "Model";
        }

        protected override string[] GetInterfaceSummary(IEntityGenerationModel entityDeclaration)
        {
            return new[]
            {
                $"Unkeyed Model Interface for {entityDeclaration.ClassName}"
            };
        }

        protected override string[] GetClassPrefixes()
        {
            return new[] { "Unkeyed"};
        }

        protected override PropertyDeclarationSyntax[] GetPropertyDeclarations(
            IEntityGenerationModel entityGenerationModel, string prefix)
        {
            return entityGenerationModel.Properties?.Select(GetPropertyDeclaration).ToArray();
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