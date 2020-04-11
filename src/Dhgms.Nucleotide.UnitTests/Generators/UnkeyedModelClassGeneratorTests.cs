﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Dhgms.Nucleotide.Features.Model;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    [ExcludeFromCodeCoverage]
    public static class UnkeyedModelClassGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<UnkeyedModelClassGenerator>
        {
            protected override Func<AttributeData, UnkeyedModelClassGenerator> GetFactory()
            {
                return data => new UnkeyedModelClassGenerator(data);
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<UnkeyedModelClassGenerator>
        {
            protected override Func<AttributeData, UnkeyedModelClassGenerator> GetFactory()
            {
                return data => new UnkeyedModelClassGenerator(data);
            }
        }
    }
}
