using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Generators;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;
using Xunit.Abstractions;

namespace Dhgms.Nucleotide.UnitTests.Generators
{

    [ExcludeFromCodeCoverage]
    public class BaseGeneratorTests
    {
        public class MockAttributeData : AttributeData
        {
            public MockAttributeData()
            {
            }

            public MockAttributeData(TypedConstant constructorArg)
            {
                this.CommonConstructorArguments = ImmutableArray.Create(constructorArg);
            }

            protected override INamedTypeSymbol CommonAttributeClass { get; }
            protected override IMethodSymbol CommonAttributeConstructor { get; }
            protected override SyntaxReference CommonApplicationSyntaxReference { get; }
            protected override ImmutableArray<TypedConstant> CommonConstructorArguments { get; }
            protected override ImmutableArray<KeyValuePair<string, TypedConstant>> CommonNamedArguments { get; }
        }

        public abstract class BaseConstructorMethod<TGenerator, TFeatureFlags, TGeneratorProcessor, TGenerationModel> : Foundatio.Logging.Xunit.TestWithLoggingBase
            where TGenerator : BaseGenerator<TFeatureFlags, TGeneratorProcessor, TGenerationModel>
            where TFeatureFlags : class
            where TGeneratorProcessor : BaseGeneratorProcessor<TGenerationModel>, new()
            where TGenerationModel : IClassName
        {
            protected abstract Func<AttributeData, TGenerator> GetFactory();

            [Fact]
            public void ReturnsInstance()
            {
                var factory = GetFactory();
                var attributeData = new MockAttributeData(new TypedConstant());
                var instance = factory(attributeData);

                Assert.NotNull(instance);
            }

            protected BaseConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }
        }

        public abstract class BaseGenerateAsyncMethod<TGenerator, TFeatureFlags, TGeneratorProcessor, TGenerationModel> : Foundatio.Logging.Xunit.TestWithLoggingBase
            where TGenerator : BaseGenerator<TFeatureFlags, TGeneratorProcessor, TGenerationModel>
            where TFeatureFlags : class
            where TGeneratorProcessor : BaseGeneratorProcessor<TGenerationModel>, new()
            where TGenerationModel : IClassName
        {
            internal const string DefaultFilePathPrefix = "Test";
            internal const string CSharpDefaultFileExt = "cs";
            internal const string TestProjectName = "TestProject";

            protected abstract Func<AttributeData, TGenerator> GetFactory();

            private static Compilation CreateCompilation(string source) => CSharpCompilation.Create(
                assemblyName: "compilation",
                syntaxTrees: new[] { CSharpSyntaxTree.ParseText(source, new CSharpParseOptions(LanguageVersion.Preview)) },
                references: new[] { MetadataReference.CreateFromFile(typeof(Binder).GetTypeInfo().Assembly.Location) },
                options: new CSharpCompilationOptions(OutputKind.ConsoleApplication)
            );

            private static GeneratorDriver CreateDriver(Compilation compilation, params ISourceGenerator[] generators) => CSharpGeneratorDriver.Create(
                generators: ImmutableArray.Create(generators),
                additionalTexts: ImmutableArray<AdditionalText>.Empty,
                parseOptions: (CSharpParseOptions)compilation.SyntaxTrees.First().Options,
                optionsProvider: null
            );

            private static Compilation RunGenerators(Compilation compilation, out ImmutableArray<Diagnostic> diagnostics, params ISourceGenerator[] generators)
            {
                CreateDriver(compilation, generators).RunGeneratorsAndUpdateCompilation(compilation, out var updatedCompilation, out diagnostics);
                return updatedCompilation;
            }

            [Fact]
            public async Task GeneratesErrorForNonNucleotideGenerationModel()
            {
                var comp = CreateCompilation(string.Empty);

                var factory = GetFactory();
                var attributeData = new MockAttributeData(new TypedConstant());
                var instance = factory(attributeData);
                var newComp = RunGenerators(
                    comp,
                    out var generatorDiags,
                    instance);
            }

            [Fact]
            //[MemberData(nameof(GeneratesCodeMemberData))]
            public async Task GeneratesCodeForSimpleNucleotideGenerationModel()
            {
                var factory = GetFactory();

                // Right now this is difficult to test as the Roslyn Analysis typed constant is internal.
                // Easiest way to test it to split off the CGR loader and the internal generator
                // Then pass in the Nucleotide Model direct.
                var t = new TypedConstant();

                var attributeData = new MockAttributeData(t);
                var instance = factory(attributeData);
                var comp = CreateCompilation(string.Empty);
                var newComp = RunGenerators(
                    comp,
                    out var generatorDiags,
                    instance);
            }

            protected BaseGenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }
        }
    }
}