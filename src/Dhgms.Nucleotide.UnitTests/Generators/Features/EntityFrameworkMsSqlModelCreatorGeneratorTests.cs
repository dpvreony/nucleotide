using Dhgms.Nucleotide.Generators.Features.EntityFramework;
using Dhgms.Nucleotide.ModelTests;
using Dhgms.Nucleotide.SampleGenerator;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Dhgms.Nucleotide.UnitTests.Generators.Features
{
    [ExcludeFromCodeCoverage]
    public static class EntityFrameworkMsSqlModelCreatorGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<TestEntityFrameworkMsSqlModelCreatorGenerator>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<TestEntityFrameworkMsSqlModelCreatorGenerator>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }
        }
    }
}
