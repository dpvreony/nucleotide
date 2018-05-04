using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Features.WebApi;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public static class WebApiClientGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<WebApiClientGenerator>
        {
            protected override Func<AttributeData, WebApiClientGenerator> GetFactory()
            {
                return attributeData => new WebApiClientGenerator(attributeData);
            }
        }
    }
}
