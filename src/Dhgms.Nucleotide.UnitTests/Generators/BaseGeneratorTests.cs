// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Generators;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Extensions.Logging;
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

        public abstract class BaseConstructorMethod<TGenerator> : Foundatio.Xunit.TestWithLoggingBase
            where TGenerator : IIncrementalGenerator
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

        public abstract class BaseGenerateAsyncMethod<TGenerator> : Foundatio.Xunit.TestWithLoggingBase
            where TGenerator : IIncrementalGenerator
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
                    instance.AsSourceGenerator());

                foreach (var generatorDiag in generatorDiags)
                {
                    this._logger.LogInformation(generatorDiag.ToString());
                }

                Assert.False(generatorDiags.Any(x => x.Severity == DiagnosticSeverity.Error));

                foreach (var newCompSyntaxTree in newComp.SyntaxTrees)
                {
                    this._logger.LogInformation(newCompSyntaxTree.GetText().ToString());
                }
            }

            protected BaseGenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }
        }
    }
}