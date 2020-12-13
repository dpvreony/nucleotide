using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Features.Cqrs;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.ModelTests;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Microsoft.Extensions.Logging;
using Moq;
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

        public abstract class BaseConstructorMethod<TGenerator, TFeatureFlags, TGeneratorProcessor> : Foundatio.Logging.Xunit.TestWithLoggingBase
            where TGenerator : BaseGenerator<TFeatureFlags, TGeneratorProcessor>
            where TFeatureFlags : class
            where TGeneratorProcessor : BaseGeneratorProcessor, new()
        {
            protected abstract Func<AttributeData, TGenerator> GetFactory();

            [Fact]
            public void ThrowsArgumentNullException()
            {
                var factory = GetFactory();
                var exception = Assert.Throws<ArgumentNullException>(() => factory(null));
                Assert.Equal("attributeData", exception.ParamName);
            }

            [Fact]
            public void ThrowsArgumentException()
            {
                var factory = GetFactory();
                var attributeData = new MockAttributeData();

                var exception = Assert.Throws<ArgumentException>(() => factory(attributeData));
                Assert.Equal("attributeData", exception.ParamName);
            }

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

        public abstract class BaseGenerateAsyncMethod<TGenerator, TFeatureFlags, TGeneratorProcessor> : Foundatio.Logging.Xunit.TestWithLoggingBase
            where TGenerator : BaseGenerator<TFeatureFlags, TGeneratorProcessor>
            where TFeatureFlags : class
            where TGeneratorProcessor : BaseGeneratorProcessor, new()
        {
            internal const string DefaultFilePathPrefix = "Test";
            internal const string CSharpDefaultFileExt = "cs";
            internal const string TestProjectName = "TestProject";

            static BaseGenerateAsyncMethod()
            {
                // logic is based upon
                // https://github.com/AArnott/CodeGeneration.Roslyn/blob/9b7ec97bdcef5c9fae01a10d59e3bb7082382eae/src/CodeGeneration.Roslyn.Tests/Helpers/CompilationTestsBase.cs
                // and
                // https://github.com/AArnott/CodeGeneration.Roslyn/blob/227430f6c8f6afad183a90557ccb2c03653c4028/src/CodeGeneration.Roslyn/DocumentTransform.cs

                var coreAssemblyPath = Path.GetDirectoryName(typeof(object).Assembly.Location);

                var coreAssemblyNames = new[]
                {
                    "mscorlib.dll",
                    "System.dll",
                    "System.Core.dll",
                    "System.Runtime.dll"
                };

                var coreMetaReferences = coreAssemblyNames.Select(x => MetadataReference.CreateFromFile(Path.Combine(coreAssemblyPath, x)));

                var otherAssemblies = new[]
                {
                    typeof(CSharpCompilation).Assembly,
                    typeof(QueryFactoryInterfaceGenerator).Assembly
                };

                MetadataReferences = coreMetaReferences
                    .Concat<MetadataReference>(otherAssemblies.Select(x => MetadataReference.CreateFromFile(x.Location)))
                    .ToImmutableArray();
            }

            internal static readonly ImmutableArray<MetadataReference> MetadataReferences;

            public static IEnumerable<object[]> GeneratesCodeMemberData => new List<object[]>
            {
                _simpleCodeGenerationCase
            };

            public static IEnumerable<object[]> ThrowsArgumentNullExceptionMemberData => new List<object[]>
            {
                _throwsArgumentNullForContext,
                _throwsArgumentNullForProgress
            };

            private static object[] _simpleCodeGenerationCase => new object[]
            {
                GetTransformationContext(),
                new Progress<Diagnostic>(_ => { })
            };

            private static object[] _throwsArgumentNullForContext => new object[]
            {
                null,
                new Progress<Diagnostic>(_ => { }),
                "context"
            };

            private static object[] _throwsArgumentNullForProgress => new object[]
            {
                GetTransformationContext(),
                null,
                "progress"
            };

            protected abstract Func<AttributeData, TGenerator> GetFactory();

            [Theory]
            [MemberData(nameof(ThrowsArgumentNullExceptionMemberData))]
            public async Task ThrowsArgumentNullExceptionAsync(
                TransformationContext context,
                IProgress<Diagnostic> progress,
                string paramNameThatThrowsException)
            {
                var factory = GetFactory();
                var attributeData = new MockAttributeData(new TypedConstant());
                var instance = factory(attributeData);
                var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => instance.GenerateAsync(context, progress, CancellationToken.None));
                Assert.NotNull(ex);
                Assert.Equal(paramNameThatThrowsException, ex.ParamName);
            }

            [Theory]
            [MemberData(nameof(GeneratesCodeMemberData))]
            public async Task GeneratesErrorForNonNucleotideGenerationModel(
                TransformationContext context,
                IProgress<Diagnostic> progress)
            {
                var factory = GetFactory();
                var attributeData = new MockAttributeData(new TypedConstant());
                var instance = factory(attributeData);
                var result = await instance.GenerateAsync(context, progress, CancellationToken.None);
                var resultAsString = result.ToFullString();
                Assert.StartsWith("#error Failed to detect a generation model from attribute indicating the model type.", resultAsString, StringComparison.OrdinalIgnoreCase);
                this._logger.LogInformation(result.ToFullString());
            }

            [Theory]
            [MemberData(nameof(GeneratesCodeMemberData))]
            public async Task GeneratesCodeForSimpleNucleotideGenerationModel(
                TransformationContext context,
                IProgress<Diagnostic> progress)
            {
                var factory = GetFactory();

                // Right now this is difficult to test as the Roslyn Analysis typed constant is internal.
                // Easiest way to test it to split off the CGR loader and the internal generator
                // Then pass in the Nucleotide Model direct.
                var t = new TypedConstant();

                var attributeData = new MockAttributeData(t);
                var instance = factory(attributeData);
                var result = await instance.GenerateAsync(context, progress, CancellationToken.None);
                var resultAsString = result.ToFullString();
                Assert.StartsWith("#error Failed to detect a generation model from attribute indicating the model type.", resultAsString, StringComparison.OrdinalIgnoreCase);
                this._logger.LogInformation(result.ToFullString());
            }

            private static Project CreateProject(params string[] sources)
            {
                var projectId = ProjectId.CreateNewId(debugName: TestProjectName);
                var solution = new AdhocWorkspace()
                    .CurrentSolution
                    .AddProject(projectId, TestProjectName, TestProjectName, LanguageNames.CSharp)
                    .WithProjectCompilationOptions(
                        projectId,
                        new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                    .WithProjectParseOptions(
                        projectId,
                        new CSharpParseOptions(preprocessorSymbols: new[] { "SOMETHING_ACTIVE" }))
                    .AddMetadataReferences(projectId, MetadataReferences);

                int count = 0;
                foreach (var source in sources)
                {
                    var newFileName = DefaultFilePathPrefix + count + "." + CSharpDefaultFileExt;
                    var documentId = DocumentId.CreateNewId(projectId, debugName: newFileName);
                    solution = solution.AddDocument(documentId, newFileName, SourceText.From(source));
                    count++;
                }
                return solution.GetProject(projectId);
            }

            private static object GetTransformationContext()
            {
                var document = CreateProject(string.Empty).Documents.Single();

                var inputDocument = document.GetSyntaxTreeAsync().GetAwaiter().GetResult();

                var compilation = (CSharpCompilation)document.Project.GetCompilationAsync().GetAwaiter().GetResult();


                var inputSemanticModel = compilation.GetSemanticModel(inputDocument);
                var inputCompilationUnit = inputDocument.GetCompilationUnitRoot();

                var compilationUnitExterns = inputCompilationUnit

                    .Externs

                    .Select(x => x.WithoutTrivia())

                    .ToImmutableArray();

                var processingNode = inputDocument
                    .GetRoot()
                    .DescendantNodesAndSelf(n => n is CompilationUnitSyntax || n is NamespaceDeclarationSyntax || n is TypeDeclarationSyntax)
                    .OfType<CSharpSyntaxNode>().First();

                var compilationUnitUsings = inputCompilationUnit
                    .Usings
                    .Select(x => x.WithoutTrivia())
                    .ToImmutableArray();

                var transformationContext = new TransformationContext(
                    processingNode,
                    inputSemanticModel,
                    compilation,
                    null,
                    compilationUnitUsings,
                    compilationUnitExterns);

                return transformationContext;
            }

            protected BaseGenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }
        }
    }
}