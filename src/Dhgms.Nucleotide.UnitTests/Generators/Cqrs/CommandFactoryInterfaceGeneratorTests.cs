﻿// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Diagnostics.CodeAnalysis;
using Dhgms.Nucleotide.ModelTests;
using Xunit.Abstractions;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    [ExcludeFromCodeCoverage]
    public class CommandFactoryInterfaceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<TestCommandFactoryInterfaceGenerator>
        {
            public ConstructorMethod(ITestOutputHelper output)
                : base(output)
            {
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<TestCommandFactoryInterfaceGenerator>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }
        }
    }
}
