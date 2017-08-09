﻿using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public static class QueryInterfaceGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<QueryInterfaceGenerator>
        {
            protected override Func<AttributeData, QueryInterfaceGenerator> GetFactory()
            {
                return data => new QueryInterfaceGenerator(data);
            }
        }
    }
}
