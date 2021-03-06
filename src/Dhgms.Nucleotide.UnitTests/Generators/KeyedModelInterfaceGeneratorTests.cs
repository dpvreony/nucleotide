﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Generators.Features.Model;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.ModelTests;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    [ExcludeFromCodeCoverage]
    public static class KeyedModelInterfaceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<KeyedModelInterfaceGenerator, KeyedModelInterfaceFeatureFlags, KeyedModelInterfaceGeneratorProcessor, IEntityGenerationModel>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, KeyedModelInterfaceGenerator> GetFactory()
            {
                return data => new TestKeyedModelInterfaceGenerator();
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<KeyedModelInterfaceGenerator, KeyedModelInterfaceFeatureFlags, KeyedModelInterfaceGeneratorProcessor, IEntityGenerationModel>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, KeyedModelInterfaceGenerator> GetFactory()
            {
                return data => new TestKeyedModelInterfaceGenerator();
            }
        }
    }
}
