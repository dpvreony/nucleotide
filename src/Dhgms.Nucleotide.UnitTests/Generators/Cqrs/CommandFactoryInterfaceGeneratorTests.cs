﻿// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Diagnostics.CodeAnalysis;
using Dhgms.Nucleotide.Generators.Features.Cqrs;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.ModelTests;
using Microsoft.CodeAnalysis;
using Xunit.Abstractions;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    [ExcludeFromCodeCoverage]
    public class CommandFactoryInterfaceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<CommandFactoryInterfaceGenerator, CommandFactoryInterfaceFeatureFlags, CommandFactoryInterfaceGeneratorProcessor, IEntityGenerationModel>
        {
            public ConstructorMethod(ITestOutputHelper output)
                : base(output)
            {
            }

            protected override Func<AttributeData, CommandFactoryInterfaceGenerator> GetFactory()
            {
                return attributeData => new TestCommandFactoryInterfaceGenerator();
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<CommandFactoryInterfaceGenerator, CommandFactoryInterfaceFeatureFlags, CommandFactoryInterfaceGeneratorProcessor, IEntityGenerationModel>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, CommandFactoryInterfaceGenerator> GetFactory()
            {
                return data => new TestCommandFactoryInterfaceGenerator();
            }
        }
    }
}
