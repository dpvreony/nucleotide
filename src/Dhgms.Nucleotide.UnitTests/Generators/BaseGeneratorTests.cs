// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Extensions.Logging;
using NetTestRegimentation.XUnit.Logging;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators
{

    [ExcludeFromCodeCoverage]
    public static class BaseGeneratorTests
    {
        public abstract class BaseConstructorMethod<TGenerator> : TestWithLoggingBase
            where TGenerator : IIncrementalGenerator, new()
        {
            protected BaseConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }

            [Fact]
            public void ReturnsInstance()
            {
                var instance = new TGenerator();

                Assert.NotNull(instance);
            }
        }

        public abstract class BaseGenerateAsyncMethod<TGenerator> : TestWithLoggingBase
            where TGenerator : IIncrementalGenerator, new()
        {
            internal const string DefaultFilePathPrefix = "Test";
            internal const string CSharpDefaultFileExt = "cs";
            internal const string TestProjectName = "TestProject";

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
            //[MemberData(nameof(GeneratesCodeMemberData))]
            public async Task GeneratesCodeForSimpleNucleotideGenerationModel()
            {
                var instance = new TGenerator();
                var comp = CreateCompilation(string.Empty);
                var newComp = RunGenerators(
                    comp,
                    out var generatorDiags,
                    instance.AsSourceGenerator());

                foreach (var generatorDiag in generatorDiags)
                {
                    Logger.LogInformation(generatorDiag.ToString());
                }

                Assert.False(generatorDiags.Any(x => x.Severity == DiagnosticSeverity.Error));

                foreach (var newCompSyntaxTree in newComp.SyntaxTrees)
                {
                    Logger.LogInformation(newCompSyntaxTree.GetText().ToString());
                }
            }

            protected BaseGenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }
        }
    }
}