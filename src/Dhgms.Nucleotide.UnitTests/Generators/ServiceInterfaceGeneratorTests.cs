using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    [ExcludeFromCodeCoverage]
    public static class ServiceInterfaceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<ServiceInterfaceGenerator>
        {
            protected override Func<AttributeData, ServiceInterfaceGenerator> GetFactory()
            {
                return data => new ServiceInterfaceGenerator(data);
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<ServiceInterfaceGenerator>
        {
            protected override Func<AttributeData, ServiceInterfaceGenerator> GetFactory()
            {
                return data => new ServiceInterfaceGenerator(data);
            }
        }
    }
}
