using Dhgms.Nucleotide.Generators.Features.Database;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis;

namespace Dhgms.Nucleotide.ModelTests
{
    [Generator]
    public sealed class TestReferencedByEntityGenerator : ReferencedByEntityGenerator
    {
        protected override INucleotideGenerationModel<ReferencedByEntityGenerationModel> NucleotideGenerationModel => new NucleotideGenerationModel<ReferencedByEntityGenerationModel>(
            "Company.RootNameSpace",
            new []
            {
                new ReferencedByEntityGenerationModel(
                    "SomeNamespace",
                    "User",
                    "global::Dhgms.Nucleotide.GenerationTests.EfModels.UserEfModel",
                    "User",
                    "int"),

                new ReferencedByEntityGenerationModel(
                    "SomeNamespace",
                    "Address",
                    "global::Dhgms.Nucleotide.GenerationTests.EfModels.AddressEfModel",
                    "Address",
                    "int")
            });
    }
}
