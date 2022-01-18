﻿// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Diagnostics.CodeAnalysis;
using Dhgms.Nucleotide.Generators.Features.Database;
using Dhgms.Nucleotide.ModelTests;
using Microsoft.CodeAnalysis;
using Xunit.Abstractions;

namespace Dhgms.Nucleotide.UnitTests.Generators.Database
{
    [ExcludeFromCodeCoverage]
    public static class ReferencedByEntityGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<ReferencedByEntityGenerator, ReferencedByEntityFeatureFlags, ReferencedByEntityGeneratorProcessor, ReferencedByEntityGenerationModel>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, ReferencedByEntityGenerator> GetFactory()
            {
                return data => new TestReferencedByEntityGenerator();
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<ReferencedByEntityGenerator, ReferencedByEntityFeatureFlags, ReferencedByEntityGeneratorProcessor, ReferencedByEntityGenerationModel>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, ReferencedByEntityGenerator> GetFactory()
            {
                return data => new TestReferencedByEntityGenerator();
            }
        }
    }
}
