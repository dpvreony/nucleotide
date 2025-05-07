using Dhgms.Nucleotide.SampleGenerator.Cqrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dhgms.Nucleotide.SampleGenerator.AspNetCore;
using Xunit.Abstractions;

namespace Dhgms.Nucleotide.UnitTests.Generators.AspNetCore.MvcControllers
{
    public static class MvcControllerGeneratorTests
    {
        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<TestableMvcControllerGenerator>
        {
            public ConstructorMethod(ITestOutputHelper output) : base(output)
            {
            }
        }

        public sealed class GenerateAsyncMethod : BaseGeneratorTests.BaseGenerateAsyncMethod<TestableMvcControllerGenerator>
        {
            public GenerateAsyncMethod(ITestOutputHelper output) : base(output)
            {
            }
        }
    }
}
