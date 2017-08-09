﻿using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Generators;
using Microsoft.CodeAnalysis;
using Moq;
using Xunit;

namespace Dhgms.Nucleotide.UnitTests.Generators
{
    public static class SignalRHubClassGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<SignalRHubClassGenerator>
        {
            protected override Func<AttributeData, SignalRHubClassGenerator> GetFactory()
            {
                return data => new SignalRHubClassGenerator(data);
            }
        }
    }
}
