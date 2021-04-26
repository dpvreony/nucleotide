using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Generators.Features.Mvc;
using Dhgms.Nucleotide.Generators.Features.WebApi;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.ModelTests;
using Microsoft.CodeAnalysis;
using Xunit.Abstractions;

namespace Dhgms.Nucleotide.UnitTests.Generators.Mvc
{
    [ExcludeFromCodeCoverage]
    public static class MvcControllerGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<MvcControllerGenerator, MvcControllerFeatureFlags, MvcControllerGeneratorProcessor, IEntityGenerationModel>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, MvcControllerGenerator> GetFactory()
            {
                return attributeData => new TestMvcControllerGenerator();
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<MvcControllerGenerator, MvcControllerFeatureFlags, MvcControllerGeneratorProcessor, IEntityGenerationModel>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, MvcControllerGenerator> GetFactory()
            {
                return data => new TestMvcControllerGenerator();
            }
        }
    }
}
