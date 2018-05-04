//using System;
//using System.Collections.Generic;
//using System.Text;
//using Dhgms.Nucleotide.Features.Cqrs;
//using Dhgms.Nucleotide.Generators;
//using Microsoft.CodeAnalysis;
//using Moq;
//using Xunit;

//namespace Dhgms.Nucleotide.UnitTests.Generators
//{
//    public static class CommandFactoryClassGeneratorTests
//    {
//        public sealed class ConstructorMethod : BaseGeneratorTests.BaseConstructorMethod<CommandFactoryClassGenerator>
//        {
//            protected override Func<AttributeData, CommandFactoryClassGenerator> GetFactory()
//            {
//                return attributeData => new CommandFactoryClassGenerator(attributeData);
//            }
//        }
//    }
//}
