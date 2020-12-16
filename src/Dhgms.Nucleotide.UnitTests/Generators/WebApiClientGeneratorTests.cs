using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Dhgms.Nucleotide.Attributes;
using Dhgms.Nucleotide.Features.WebApi;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    [ExcludeFromCodeCoverage]
    public static class WebApiClientGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<WebApiClientGenerator, WebApiClientFeatureFlags, WebApiClientGeneratorProcessor, GenerateWebApiClientClassAttribute>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, WebApiClientGenerator> GetFactory()
            {
                return attributeData => new WebApiClientGenerator();
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<WebApiClientGenerator, WebApiClientFeatureFlags, WebApiClientGeneratorProcessor, GenerateWebApiClientClassAttribute>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, WebApiClientGenerator> GetFactory()
            {
                return data => new WebApiClientGenerator();
            }
        }
    }
}
