using System.Linq;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Model;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Features.Model
{
    public sealed class UnkeyedModelInterfaceGenerator : BaseInterfaceLevelCodeGenerator<UnkeyedModelInterfaceFeatureFlags, UnkeyedModelInterfaceGeneratorProcessor>
    {
        protected override string GetNamespace()
        {
            return "Models";
        }
    }
}
