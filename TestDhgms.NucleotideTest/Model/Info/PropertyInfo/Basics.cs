// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Basics.cs" company="DHGMS Solutions">
//   Licensed under GNU General Public License version 2 (GPLv2)
// </copyright>
// <summary>
//   Unit Tests for PropertyInfo classes
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TestDhgms.NucleotideTest.Model.Info.PropertyInfo
{
    using System;

    using Xunit;

    /// <summary>
    /// Unit Tests for PropertyInfo classes
    /// </summary>
    public class PropertyInfoTests : TestDhgms.NucleotideTest.Model.Helper.TestBase
    {
        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName1()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "abstract",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName2()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "event",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName3()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "new",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName4()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "struct",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName5()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "as",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName6()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "explicit",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName7()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "null",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName8()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "switch",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName9()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "base",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName10()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "extern",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName11()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "object",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName12()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "this",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName13()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "bool",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName14()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "false",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName15()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "operator",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName16()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "throw",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName17()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "break",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName18()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "finally",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName19()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "out",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName20()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "true",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName21()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "byte",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName22()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "fixed",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName23()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "override",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName24()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "try",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName25()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "case",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName26()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "float",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName27()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "params",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName28()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "typeof",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName29()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "catch",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName30()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "for",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName31()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "private",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName32()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "uint",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName33()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "char",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName34()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "foreach",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName35()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "protected",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName36()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "ulong",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName37()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "checked",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName38()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "goto",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName39()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "public",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName40()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "unchecked",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName41()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "class",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName42()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "if",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName43()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "readonly",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName44()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "unsafe",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName45()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "const",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName46()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "implicit",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName47()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "ref",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName48()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "ushort",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName49()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "continue",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName50()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "in",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName51()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "return",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName52()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "using",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName53()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "decimal",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName54()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "int",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName55()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "sbyte",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName56()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "virtual",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName57()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "default",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName58()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "interface",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName59()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "sealed",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName60()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "volatile",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName61()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "delegate",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName62()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "internal",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName63()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "short",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName64()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "void",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName65()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "do",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName66()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "is",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName67()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "sizeof",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName68()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "while",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName69()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "double",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName70()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "lock",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName71()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "stackalloc",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName72()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "else",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName73()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "long",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName74()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "static",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName75()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "enum",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName76()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "namespace",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName77()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "string",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName78()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "AddHandler",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName79()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "AddressOf",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName80()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Alias",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName81()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "And",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName82()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Ansi",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName83()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "As",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName84()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Assembly",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName85()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Auto",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName86()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Base",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName87()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Boolean",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName88()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "ByRef",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName89()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Byte",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName90()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "ByVal",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName91()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Call",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName92()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Case",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName93()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Catch",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName94()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "CBool",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName95()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "CByte",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName96()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "CChar",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName97()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "CDate",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName98()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "CDec",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName99()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "CDbl",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName100()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Char",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName101()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "CInt",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName102()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Class",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName103()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "CLng",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName104()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "CObj",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName105()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Const",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName106()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "CShort",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName107()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "CSng",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName108()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "CStr",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName109()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "CType",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName110()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Date",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName111()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Decimal",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName112()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Declare",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName113()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Default",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName114()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Delegate",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName115()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Dim",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName116()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Do",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName117()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Double",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName118()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Each",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName119()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Else",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName120()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "ElseIf",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName121()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "End",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName122()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Enum",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName123()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Erase",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName124()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Error",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName125()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Event",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName126()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Exit",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName127()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "ExternalSource",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName128()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "False",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName129()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Finalize",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName130()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Finally",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName131()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Float",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName132()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "For",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName133()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Friend",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName134()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Function",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName135()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Get",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName136()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "GetType",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName137()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Goto",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName138()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Handles",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName139()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "If",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName140()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Implements",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName141()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Imports",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName142()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "In",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName143()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Inherits",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName144()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Integer",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName145()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Interface",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName146()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Is",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName147()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Let",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName148()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Lib",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName149()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Like",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName150()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Long",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName151()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Loop",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName152()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Me",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName153()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Mod",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName154()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Module",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName155()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "MustInherit",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName156()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "MustOverride",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName157()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "MyBase",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName158()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "MyClass",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName159()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Namespace",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName160()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "New",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName161()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Next",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName162()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Not",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName163()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Nothing",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName164()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "NotInheritable",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName165()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "NotOverridable",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName166()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Object",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName167()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "On",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName168()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Option",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName169()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Optional",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName170()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Or",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName171()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Overloads",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName172()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Overridable",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName173()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Overrides",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName174()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "ParamArray",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName175()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Preserve",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName176()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Private",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName177()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Property",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName178()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Protected",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName179()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Public",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName180()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "RaiseEvent",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName181()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "ReadOnly",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName182()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "ReDim",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName183()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Region",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName184()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "REM",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName185()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "RemoveHandler",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName186()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Resume",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName187()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Return",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName188()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Select",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName189()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Set",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName190()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Shadows",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName191()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Shared",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName192()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Short",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName193()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Single",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName194()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Static",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName195()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Step",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName196()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Stop",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName197()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "String",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName198()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Structure",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName199()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Sub",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName200()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "SyncLock",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName201()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Then",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName202()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Throw",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName203()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "To",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName204()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "True",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName205()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Try",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName206()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "TypeOf",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName207()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Unicode",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName208()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Until",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName209()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "volatile",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName210()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "When",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName211()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "While",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName212()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "With",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName213()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "WithEvents",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName214()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "WriteOnly",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName215()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "Xor",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName216()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "eval",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName217()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "extends",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName218()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "instanceof",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName219()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "package",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName220()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "var",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName221()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__abstract",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName222()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__alignof",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName223()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__asm",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName224()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__assume",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName225()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__based",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName226()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__box",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName227()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__cdecl",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName228()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__declspec",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName229()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__delegate",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName230()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__event",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName231()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__except",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName232()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__fastcall",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName233()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__finally",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName234()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__forceinline",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName235()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__gc",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName236()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__hook",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName237()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__identifier",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName238()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__if_exists",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName239()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__if_not_exists",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName240()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__inline",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName241()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__int16",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName242()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__int32",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName243()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__int64",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName244()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__int8",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName245()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__interface",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName246()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__leave",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName247()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__m128",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName248()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__m128d",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName249()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__m128i",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName250()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__m64",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName251()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__multiple_inheritance",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName252()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__nogc",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName253()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__noop",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName254()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__pin",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName255()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__property",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName256()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__raise",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName257()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__sealed",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName258()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__single_inheritance",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName259()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__stdcall",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName260()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__super",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName261()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__thiscall",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName262()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__try",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName263()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__except",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName264()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__finally",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName265()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__try_cast",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName266()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__unaligned",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName267()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__unhook",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName268()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__uuidof",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName269()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__value",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName270()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__virtual_inheritance",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName271()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__w64",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName272()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "__wchar_t",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName273()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "wchar_t",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName274()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "abstract",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName275()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "array",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName276()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "auto",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName277()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "bool",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName278()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "break",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName279()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "case",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName280()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "catch",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName281()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "char",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName282()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "class",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName283()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "const",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName284()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "const_cast",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName285()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "continue",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName286()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "decltype",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName287()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "default",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName288()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "delegate",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName289()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "delete",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName290()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "deprecated",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName291()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "dllexport",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName292()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "dllimport",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName293()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "do",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName294()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "double",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName295()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "dynamic_cast",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName296()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "else",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName297()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "enum",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName298()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "event",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName299()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "explicit",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName300()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "extern",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName301()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "false",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName302()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "finally",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName303()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "float",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName304()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "for",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName305()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "each",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName306()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "in",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName307()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "friend",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName308()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "friend_as",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName309()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "gcnew",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName310()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "generic",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName311()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "goto",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName312()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "if",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName313()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "initonly",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName314()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "inline",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName315()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "int",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName316()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "interface",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName317()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "interior_ptr",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName318()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "literal",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName319()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "long",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName320()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "mutable",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName321()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "naked",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName322()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "namespace",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName323()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "new",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName324()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "noinline",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName325()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "noreturn",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName326()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "nothrow",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName327()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "novtable",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName328()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "nullptr",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName329()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "operator",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName330()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "private",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName331()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "property",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName332()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "protected",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName333()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "public",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName334()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "ref",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName335()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "register",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName336()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "reinterpret_cast",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName337()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "return",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName338()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "safecast",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName339()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "sealed",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName340()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "selectany",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName341()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "short",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName342()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "signed",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName343()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "sizeof",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName344()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "static",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName345()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "static_assert",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName346()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "static_cast",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName347()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "struct",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName348()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "switch",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName349()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "template",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName350()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "this",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName351()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "thread",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName352()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "true",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName353()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "try",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName354()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "typedef",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName355()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "typeid",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName356()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "typename",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName357()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "union",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName358()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "unsigned",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName359()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "using",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName360()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "uuid",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName361()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "value",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName362()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "virtual",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName363()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "void",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName364()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "volatile",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public void ThrowExceptionsIfKeywordAsName365()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                Dhgms.Nucleotide.Model.Info.CollectionType.None,
                "while",
                "Description",
                false,
                true,
                null));
        }

        /// <summary>
        /// Tests a ClrBoolean with basic arguments passed into the constructor
        /// </summary>
        [Fact]
        public void TestClrBooleanConstructorBasicArguments()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrBoolean(
                CollectionType,
                Name,
                Description,
                Optional,
                true,
                null);

            Assert.Equal(CollectionType, instance.Collection);
            Assert.Equal(Name, instance.Name);
            Assert.Equal(Description, instance.Description);
            Assert.Equal(Optional, instance.Optional);
        }

        /// <summary>
        /// Tests a ClrChar with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestClrCharGetMutatorBothNullsOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = true;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrChar instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrChar(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                false,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a ClrChar with the min null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestClrCharGetMutatorMinNullOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = true;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrChar instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrChar(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                char.MaxValue,
                false,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a ClrChar with the max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestClrCharGetMutatorMaxNullOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = true;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrChar instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrChar(
                CollectionType,
                Name,
                Description,
                Optional,
                char.MinValue,
                null,
                false,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a ClrChar with the min and max null
        /// </summary>
        [Fact]
        public void TestClrCharGetMutatorBothNulls()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrChar instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrChar(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                false,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a ClrChar with the min null
        /// </summary>
        [Fact]
        public void TestClrCharGetMutatorMinNull()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrChar instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrChar(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                char.MaxValue,
                false,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a ClrChar with the max null
        /// </summary>
        [Fact]
        public void TestClrCharGetMutatorMaxNull()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrChar instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrChar(
                CollectionType,
                Name,
                Description,
                Optional,
                char.MinValue,
                null,
                false,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a ClrDateTime with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestClrDateTimeGetMutatorBothNullsOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = true;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDateTime instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDateTime(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                false,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a ClrDateTime with the min null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestClrDateTimeGetMutatorMinNullOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = true;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDateTime instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDateTime(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                DateTime.MaxValue,
                false,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a ClrDateTime with the max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestClrDateTimeGetMutatorMaxNullOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = true;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDateTime instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDateTime(
                CollectionType,
                Name,
                Description,
                Optional,
                DateTime.MinValue,
                null,
                false,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a ClrDateTime with the min and max null
        /// </summary>
        [Fact]
        public void TestClrDateTimeGetMutatorBothNulls()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDateTime instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDateTime(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                false,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a ClrDateTime with the min null
        /// </summary>
        [Fact]
        public void TestClrDateTimeGetMutatorMinNull()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDateTime instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDateTime(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                DateTime.MaxValue,
                false,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a ClrDateTime with the max null
        /// </summary>
        [Fact]
        public void TestClrDateTimeGetMutatorMaxNull()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDateTime instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDateTime(
                CollectionType,
                Name,
                Description,
                Optional,
                DateTime.MinValue,
                null,
                false,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a ClrDecimal with basic arguments passed into the constructor
        /// </summary>
        [Fact]
        public void TestClrDecimalConstructorBasicArguments()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDecimal instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDecimal(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Assert.Equal(CollectionType, instance.Collection);
            Assert.Equal(Name, instance.Name);
            Assert.Equal(Description, instance.Description);
            Assert.Equal(Optional, instance.Optional);
        }

        /// <summary>
        /// Tests a ClrDecimal with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestClrDecimalGetMutatorBothNullsOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDecimal instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDecimal(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a ClrDecimal with the min null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestClrDecimalGetMutatorMinNullOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDecimal instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDecimal(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                255,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a ClrDecimal with the max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestClrDecimalGetMutatorMaxNullOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDecimal instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDecimal(
                CollectionType,
                Name,
                Description,
                Optional,
                1,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a ClrDecimal with the min and max null
        /// </summary>
        [Fact]
        public void TestClrDecimalGetMutatorBothNulls()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDecimal instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDecimal(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a ClrDecimal with the min null
        /// </summary>
        [Fact]
        public void TestClrDecimalGetMutatorMinNull()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDecimal instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDecimal(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                255,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a ClrDecimal with the max null
        /// </summary>
        [Fact]
        public void TestClrDecimalGetMutatorMaxNull()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDecimal instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDecimal(
                CollectionType,
                Name,
                Description,
                Optional,
                1,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a ClrDouble with basic arguments passed into the constructor
        /// </summary>
        [Fact]
        public void TestClrDoubleConstructorBasicArguments()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDouble instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDouble(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Assert.Equal(CollectionType, instance.Collection);
            Assert.Equal(Name, instance.Name);
            Assert.Equal(Description, instance.Description);
            Assert.Equal(Optional, instance.Optional);
        }

        /// <summary>
        /// Tests a ClrDouble with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestClrDoubleGetMutatorBothNullsOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDouble instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDouble(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a ClrDouble with the min null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestClrDoubleGetMutatorMinNullOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDouble instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDouble(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                255,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a ClrDouble with the max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestClrDoubleGetMutatorMaxNullOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDouble instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDouble(
                CollectionType,
                Name,
                Description,
                Optional,
                1,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a ClrDouble with the min and max null
        /// </summary>
        [Fact]
        public void TestClrDoubleGetMutatorBothNulls()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDouble instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDouble(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a ClrDouble with the min null
        /// </summary>
        [Fact]
        public void TestClrDoubleGetMutatorMinNull()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDouble instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDouble(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                255,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a ClrDouble with the max null
        /// </summary>
        [Fact]
        public void TestClrDoubleGetMutatorMaxNull()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDouble instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrDouble(
                CollectionType,
                Name,
                Description,
                Optional,
                1,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a ClrSingle with basic arguments passed into the constructor
        /// </summary>
        [Fact]
        public void TestClrSingleConstructorBasicArguments()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrSingle instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrSingle(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Assert.Equal(CollectionType, instance.Collection);
            Assert.Equal(Name, instance.Name);
            Assert.Equal(Description, instance.Description);
            Assert.Equal(Optional, instance.Optional);
        }

        /// <summary>
        /// Tests a ClrSingle with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestClrSingleGetMutatorBothNullsOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrSingle instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrSingle(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a ClrSingle with the min null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestClrSingleGetMutatorMinNullOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrSingle instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrSingle(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                255,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a ClrSingle with the max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestClrSingleGetMutatorMaxNullOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrSingle instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrSingle(
                CollectionType,
                Name,
                Description,
                Optional,
                1,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a ClrSingle with the min and max null
        /// </summary>
        [Fact]
        public void TestClrSingleGetMutatorBothNulls()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrSingle instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrSingle(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a ClrSingle with the min null
        /// </summary>
        [Fact]
        public void TestClrSingleGetMutatorMinNull()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrSingle instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrSingle(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                255,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a ClrSingle with the max null
        /// </summary>
        [Fact]
        public void TestClrSingleGetMutatorMaxNull()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrSingle instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.ClrSingle(
                CollectionType,
                Name,
                Description,
                Optional,
                1,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a Integer16 with basic arguments passed into the constructor
        /// </summary>
        [Fact]
        public void TestInteger16ConstructorBasicArguments()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer16 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer16(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Assert.Equal(CollectionType, instance.Collection);
            Assert.Equal(Name, instance.Name);
            Assert.Equal(Description, instance.Description);
            Assert.Equal(Optional, instance.Optional);
        }

        /// <summary>
        /// Tests a Integer16 with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestInteger16GetMutatorBothNullsOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer16 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer16(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a Integer16 with the min null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestInteger16GetMutatorMinNullOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer16 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer16(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                255,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a Integer16 with the max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestInteger16GetMutatorMaxNullOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer16 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer16(
                CollectionType,
                Name,
                Description,
                Optional,
                1,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a Integer16 with the min and max null
        /// </summary>
        [Fact]
        public void TestInteger16GetMutatorBothNulls()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer16 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer16(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a Integer16 with the min null
        /// </summary>
        [Fact]
        public void TestInteger16GetMutatorMinNull()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer16 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer16(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                255,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a Integer16 with the max null
        /// </summary>
        [Fact]
        public void TestInteger16GetMutatorMaxNull()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer16 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer16(
                CollectionType,
                Name,
                Description,
                Optional,
                1,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a Integer32 with basic arguments passed into the constructor
        /// </summary>
        [Fact]
        public void TestInteger32ConstructorBasicArguments()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer32 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer32(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Assert.Equal(CollectionType, instance.Collection);
            Assert.Equal(Name, instance.Name);
            Assert.Equal(Description, instance.Description);
            Assert.Equal(Optional, instance.Optional);
        }

        /// <summary>
        /// Tests a Integer32 with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestInteger32GetMutatorBothNullsOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer32 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer32(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a Integer32 with the min null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestInteger32GetMutatorMinNullOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer32 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer32(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                255,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a Integer32 with the max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestInteger32GetMutatorMaxNullOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer32 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer32(
                CollectionType,
                Name,
                Description,
                Optional,
                1,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a Integer32 with the min and max null
        /// </summary>
        [Fact]
        public void TestInteger32GetMutatorBothNulls()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer32 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer32(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a Integer32 with the min null
        /// </summary>
        [Fact]
        public void TestInteger32GetMutatorMinNull()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer32 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer32(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                255,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a Integer32 with the max null
        /// </summary>
        [Fact]
        public void TestInteger32GetMutatorMaxNull()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer32 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer32(
                CollectionType,
                Name,
                Description,
                Optional,
                1,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a Integer64 with basic arguments passed into the constructor
        /// </summary>
        [Fact]
        public void TestInteger64ConstructorBasicArguments()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer64 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer64(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Assert.Equal(CollectionType, instance.Collection);
            Assert.Equal(Name, instance.Name);
            Assert.Equal(Description, instance.Description);
            Assert.Equal(Optional, instance.Optional);
        }

        /// <summary>
        /// Tests a Integer64 with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestInteger64GetMutatorBothNullsOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer64 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer64(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a Integer64 with the min null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestInteger64GetMutatorMinNullOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer64 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer64(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                255,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a Integer64 with the max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestInteger64GetMutatorMaxNullOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer64 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer64(
                CollectionType,
                Name,
                Description,
                Optional,
                1,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a Integer64 with the min and max null
        /// </summary>
        [Fact]
        public void TestInteger64GetMutatorBothNulls()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer64 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer64(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a Integer64 with the min null
        /// </summary>
        [Fact]
        public void TestInteger64GetMutatorMinNull()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer64 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer64(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                255,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a Integer64 with the max null
        /// </summary>
        [Fact]
        public void TestInteger64GetMutatorMaxNull()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer64 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.Integer64(
                CollectionType,
                Name,
                Description,
                Optional,
                1,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a UnsignedInteger8 with basic arguments passed into the constructor
        /// </summary>
        [Fact]
        public void TestUnsignedInteger8ConstructorBasicArguments()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger8 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger8(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Assert.Equal(CollectionType, instance.Collection);
            Assert.Equal(Name, instance.Name);
            Assert.Equal(Description, instance.Description);
            Assert.Equal(Optional, instance.Optional);
        }

        /// <summary>
        /// Tests a UnsignedInteger8 with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestUnsignedInteger8GetMutatorBothNullsOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger8 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger8(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a UnsignedInteger8 with the min null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestUnsignedInteger8GetMutatorMinNullOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger8 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger8(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                255,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a UnsignedInteger8 with the max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestUnsignedInteger8GetMutatorMaxNullOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger8 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger8(
                CollectionType,
                Name,
                Description,
                Optional,
                1,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a UnsignedInteger8 with the min and max null
        /// </summary>
        [Fact]
        public void TestUnsignedInteger8GetMutatorBothNulls()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger8 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger8(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a UnsignedInteger8 with the min null
        /// </summary>
        [Fact]
        public void TestUnsignedInteger8GetMutatorMinNull()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger8 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger8(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                255,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a UnsignedInteger8 with the max null
        /// </summary>
        [Fact]
        public void TestUnsignedInteger8GetMutatorMaxNull()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger8 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger8(
                CollectionType,
                Name,
                Description,
                Optional,
                1,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a UnsignedInteger16 with basic arguments passed into the constructor
        /// </summary>
        [Fact]
        public void TestUnsignedInteger16ConstructorBasicArguments()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger16 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger16(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Assert.Equal(CollectionType, instance.Collection);
            Assert.Equal(Name, instance.Name);
            Assert.Equal(Description, instance.Description);
            Assert.Equal(Optional, instance.Optional);
        }

        /// <summary>
        /// Tests a UnsignedInteger16 with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestUnsignedInteger16GetMutatorBothNullsOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger16 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger16(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a UnsignedInteger16 with the min null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestUnsignedInteger16GetMutatorMinNullOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger16 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger16(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                255,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a UnsignedInteger16 with the max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestUnsignedInteger16GetMutatorMaxNullOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger16 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger16(
                CollectionType,
                Name,
                Description,
                Optional,
                1,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a UnsignedInteger16 with the min and max null
        /// </summary>
        [Fact]
        public void TestUnsignedInteger16GetMutatorBothNulls()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger16 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger16(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a UnsignedInteger16 with the min null
        /// </summary>
        [Fact]
        public void TestUnsignedInteger16GetMutatorMinNull()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger16 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger16(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                255,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a UnsignedInteger16 with the max null
        /// </summary>
        [Fact]
        public void TestUnsignedInteger16GetMutatorMaxNull()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger16 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger16(
                CollectionType,
                Name,
                Description,
                Optional,
                1,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a UnsignedInteger32 with basic arguments passed into the constructor
        /// </summary>
        [Fact]
        public void TestUnsignedInteger32ConstructorBasicArguments()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger32 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger32(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Assert.Equal(CollectionType, instance.Collection);
            Assert.Equal(Name, instance.Name);
            Assert.Equal(Description, instance.Description);
            Assert.Equal(Optional, instance.Optional);
        }

        /// <summary>
        /// Tests a UnsignedInteger32 with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestUnsignedInteger32GetMutatorBothNullsOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger32 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger32(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a UnsignedInteger32 with the min null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestUnsignedInteger32GetMutatorMinNullOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger32 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger32(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                255,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a UnsignedInteger32 with the max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestUnsignedInteger32GetMutatorMaxNullOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger32 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger32(
                CollectionType,
                Name,
                Description,
                Optional,
                1,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a UnsignedInteger32 with the min and max null
        /// </summary>
        [Fact]
        public void TestUnsignedInteger32GetMutatorBothNulls()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger32 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger32(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a UnsignedInteger32 with the min null
        /// </summary>
        [Fact]
        public void TestUnsignedInteger32GetMutatorMinNull()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger32 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger32(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                255,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a UnsignedInteger32 with the max null
        /// </summary>
        [Fact]
        public void TestUnsignedInteger32GetMutatorMaxNull()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger32 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger32(
                CollectionType,
                Name,
                Description,
                Optional,
                1,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a UnsignedInteger64 with basic arguments passed into the constructor
        /// </summary>
        [Fact]
        public void TestUnsignedInteger64ConstructorBasicArguments()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger64 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger64(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Assert.Equal(CollectionType, instance.Collection);
            Assert.Equal(Name, instance.Name);
            Assert.Equal(Description, instance.Description);
            Assert.Equal(Optional, instance.Optional);
        }

        /// <summary>
        /// Tests a UnsignedInteger64 with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestUnsignedInteger64GetMutatorBothNullsOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger64 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger64(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a UnsignedInteger64 with the min null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestUnsignedInteger64GetMutatorMinNullOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger64 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger64(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                255,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a UnsignedInteger64 with the max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public void TestUnsignedInteger64GetMutatorMaxNullOptional()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger64 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger64(
                CollectionType,
                Name,
                Description,
                Optional,
                1,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a UnsignedInteger64 with the min and max null
        /// </summary>
        [Fact]
        public void TestUnsignedInteger64GetMutatorBothNulls()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger64 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger64(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a UnsignedInteger64 with the min null
        /// </summary>
        [Fact]
        public void TestUnsignedInteger64GetMutatorMinNull()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger64 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger64(
                CollectionType,
                Name,
                Description,
                Optional,
                null,
                255,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

        /// <summary>
        /// Tests a UnsignedInteger64 with the max null
        /// </summary>
        [Fact]
        public void TestUnsignedInteger64GetMutatorMaxNull()
        {
            const Dhgms.Nucleotide.Model.Info.CollectionType CollectionType = Dhgms.Nucleotide.Model.Info.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger64 instance = new Dhgms.Nucleotide.Model.Info.PropertyInfo.UnsignedInteger64(
                CollectionType,
                Name,
                Description,
                Optional,
                1,
                null,
                true,
                null);

            Console.Write(instance.GetMutator());
        }

    }
}