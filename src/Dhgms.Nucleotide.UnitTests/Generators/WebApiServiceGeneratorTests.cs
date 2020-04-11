using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Dhgms.Nucleotide.Features.WebApi;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    [ExcludeFromCodeCoverage]
    public static class WebApiServiceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<WebApiServiceGenerator>
        {
            protected override Func<AttributeData, WebApiServiceGenerator> GetFactory()
            {
                return attributeData => new WebApiServiceGenerator(attributeData);
            }
        }
 
        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<WebApiServiceGenerator>
        {
            protected override Func<AttributeData, WebApiServiceGenerator> GetFactory()
            {
                return data => new WebApiServiceGenerator(data);
            }
        }
    }
}
