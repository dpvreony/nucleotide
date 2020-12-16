using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Dhgms.Nucleotide.Attributes;
using Dhgms.Nucleotide.Features.WebApi;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Generators.Features.WebApi;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    [ExcludeFromCodeCoverage]
    public static class WebApiServiceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<WebApiServiceGenerator, WebApiServiceFeatureFlags, WebApiServiceGeneratorProcessor, GenerateWebApiServiceClassAttribute>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, WebApiServiceGenerator> GetFactory()
            {
                return attributeData => new WebApiServiceGenerator();
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<WebApiServiceGenerator, WebApiServiceFeatureFlags, WebApiServiceGeneratorProcessor, GenerateWebApiServiceClassAttribute>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, WebApiServiceGenerator> GetFactory()
            {
                return data => new WebApiServiceGenerator();
            }
        }
    }
}
