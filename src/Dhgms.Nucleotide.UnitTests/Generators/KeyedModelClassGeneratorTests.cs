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
    public static class KeyedModelClassGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<KeyedModelClassGenerator, KeyedModelClassFeatureFlags, KeyedModelClassGeneratorProcessor, IEntityGenerationModel>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, KeyedModelClassGenerator> GetFactory()
            {
                return data => new TestKeyedModelClassGenerator();
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<KeyedModelClassGenerator, KeyedModelClassFeatureFlags, KeyedModelClassGeneratorProcessor, IEntityGenerationModel>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, KeyedModelClassGenerator> GetFactory()
            {
                return data => new TestKeyedModelClassGenerator();
            }
        }
    }
}
