using Dhgms.Nucleotide.Generators.Features.Database;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.ModelTests
{
    [Generator]
    public sealed class TestForiegnKeyInterfaceGenerator : ForiegnKeyInterfaceGenerator
    {
        protected override INucleotideGenerationModel<ReferencedByEntityGenerationModel> NucleotideGenerationModel => new NucleotideGenerationModel<ReferencedByEntityGenerationModel>(
            "Company.RootNameSpace",
            new []
            {
                new ReferencedByEntityGenerationModel(
                    "SomeNamespace",
                    "SomeEntityName",
                    "global::Dhgms.Nucleotide.GenerationTests.EfModels.UserEfModel",
                    "PropertyName",
                    "PropertyNames",
                    "int")
            });
    }
}
