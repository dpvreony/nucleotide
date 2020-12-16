using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Dhgms.Nucleotide.Attributes;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    [ExcludeFromCodeCoverage]
    public static class ServiceInterfaceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<ServiceInterfaceGenerator, ServiceInterfaceFeatureFlags, ServiceInterfaceGeneratorProcessor, GenerateServiceInterfaceAttribute>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, ServiceInterfaceGenerator> GetFactory()
            {
                return data => new ServiceInterfaceGenerator();
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<ServiceInterfaceGenerator, ServiceInterfaceFeatureFlags, ServiceInterfaceGeneratorProcessor, GenerateServiceInterfaceAttribute>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, ServiceInterfaceGenerator> GetFactory()
            {
                return data => new ServiceInterfaceGenerator();
            }
        }
    }
}
