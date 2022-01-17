// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Diagnostics.CodeAnalysis;
using Dhgms.Nucleotide.Generators.Features.Logging;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.SampleGenerator;
using Microsoft.CodeAnalysis;
using Xunit.Abstractions;

namespace Dhgms.Nucleotide.UnitTests.Generators.Features.Logging
{
    [ExcludeFromCodeCoverage]
    public static class CrudControllerLoggerMessageActionGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<CrudControllerLoggerMessageActionGenerator, CrudControllerLoggerMessageActionFeatureFlags, CrudControllerLoggerMessageActionGeneratorProcessor, IEntityGenerationModel>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, CrudControllerLoggerMessageActionGenerator> GetFactory()
            {
                return data => new TestCrudControllerLoggerMessageActionGenerator();
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<CrudControllerLoggerMessageActionGenerator, CrudControllerLoggerMessageActionFeatureFlags, CrudControllerLoggerMessageActionGeneratorProcessor, IEntityGenerationModel>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }

            protected override Func<AttributeData, CrudControllerLoggerMessageActionGenerator> GetFactory()
            {
                return data => new TestCrudControllerLoggerMessageActionGenerator();
            }
        }
    }
}
