﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Dhgms.Nucleotide.Features.EntityFramework;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    [ExcludeFromCodeCoverage]
    public static class EntityFrameworkDbContextGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<EntityFrameworkDbContextGenerator>
        {
            protected override Func<AttributeData, EntityFrameworkDbContextGenerator> GetFactory()
            {
                return data => new EntityFrameworkDbContextGenerator(data);
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<EntityFrameworkDbContextGenerator>
        {
            protected override Func<AttributeData, EntityFrameworkDbContextGenerator> GetFactory()
            {
                return data => new EntityFrameworkDbContextGenerator(data);
            }
        }
    }
}
