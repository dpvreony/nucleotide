// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Basics.cs" company="DHGMS Solutions">
//   Licensed under GNU General Public License version 2 (GPLv2)
// </copyright>
// <summary>
//   Unit Tests for PropertyInfo classes
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Designer Generated Code

namespace TestDhgms.NucleotideTest.Model.Info.PropertyInfo
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using Xunit;

    /// <summary>
    /// Unit Tests for PropertyInfo classes
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class PropertyInfoTests : Dhgms.Nucleotide.Tests.Model.Helper.TestBase
    {
        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Fact]
        public static void ThrowExceptionsIfKeywordAsName1()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName2()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName3()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName4()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName5()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName6()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName7()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName8()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName9()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName10()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName11()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName12()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName13()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName14()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName15()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName16()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName17()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName18()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName19()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName20()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName21()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName22()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName23()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName24()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName25()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName26()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName27()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName28()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName29()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName30()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName31()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName32()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName33()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName34()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName35()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName36()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName37()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName38()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName39()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName40()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName41()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName42()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName43()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName44()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName45()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName46()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName47()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName48()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName49()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName50()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName51()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName52()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName53()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName54()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName55()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName56()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName57()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName58()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName59()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName60()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName61()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName62()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName63()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName64()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName65()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName66()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName67()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName68()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName69()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName70()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName71()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName72()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName73()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName74()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName75()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName76()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName77()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName78()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName79()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName80()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName81()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName82()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName83()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName84()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName85()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName86()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName87()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName88()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName89()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName90()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName91()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName92()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName93()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName94()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName95()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName96()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName97()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName98()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName99()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName100()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName101()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName102()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName103()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName104()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName105()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName106()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName107()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName108()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName109()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName110()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName111()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName112()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName113()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName114()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName115()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName116()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName117()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName118()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName119()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName120()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName121()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName122()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName123()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName124()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName125()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName126()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName127()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName128()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName129()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName130()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName131()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName132()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName133()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName134()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName135()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName136()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName137()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName138()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName139()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName140()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName141()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName142()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName143()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName144()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName145()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName146()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName147()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName148()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName149()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName150()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName151()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName152()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName153()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName154()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName155()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName156()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName157()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName158()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName159()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName160()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName161()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName162()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName163()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName164()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName165()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName166()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName167()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName168()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName169()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName170()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName171()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName172()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName173()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName174()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName175()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName176()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName177()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName178()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName179()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName180()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName181()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName182()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName183()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName184()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName185()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName186()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName187()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName188()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName189()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName190()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName191()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName192()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName193()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName194()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName195()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName196()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName197()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName198()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName199()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName200()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName201()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName202()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName203()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName204()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName205()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName206()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName207()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName208()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName209()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName210()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName211()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName212()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName213()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName214()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName215()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName216()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName217()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName218()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName219()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName220()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName221()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName222()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName223()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName224()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName225()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName226()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName227()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName228()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName229()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName230()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName231()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName232()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName233()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName234()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName235()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName236()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName237()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName238()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName239()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName240()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName241()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName242()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName243()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName244()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName245()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName246()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName247()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName248()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName249()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName250()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName251()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName252()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName253()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName254()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName255()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName256()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName257()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName258()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName259()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName260()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName261()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName262()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName263()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName264()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName265()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName266()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName267()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName268()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName269()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName270()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName271()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName272()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName273()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName274()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName275()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName276()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName277()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName278()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName279()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName280()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName281()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName282()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName283()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName284()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName285()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName286()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName287()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName288()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName289()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName290()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName291()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName292()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName293()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName294()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName295()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName296()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName297()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName298()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName299()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName300()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName301()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName302()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName303()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName304()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName305()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName306()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName307()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName308()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName309()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName310()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName311()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName312()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName313()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName314()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName315()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName316()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName317()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName318()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName319()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName320()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName321()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName322()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName323()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName324()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName325()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName326()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName327()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName328()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName329()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName330()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName331()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName332()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName333()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName334()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName335()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName336()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName337()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName338()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName339()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName340()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName341()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName342()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName343()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName344()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName345()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName346()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName347()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName348()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName349()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName350()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName351()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName352()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName353()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName354()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName355()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName356()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName357()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName358()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName359()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName360()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName361()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName362()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName363()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName364()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void ThrowExceptionsIfKeywordAsName365()
        {
            Assert.Throws<ArgumentException>(() => new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
                Dhgms.Nucleotide.Model.CollectionType.None,
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
        public static void TestClrBooleanPropertyInfoConstructorBasicArguments()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrBooleanPropertyInfo(
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
        /// Tests a ClrCharPropertyInfo with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestClrCharPropertyInfoGetMutatorBothNullsOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = true;

            Dhgms.Nucleotide.PropertyInfo.ClrCharPropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrCharPropertyInfo(
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
        /// Tests a ClrCharPropertyInfo with the min null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestClrCharPropertyInfoGetMutatorMinNullOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = true;

            Dhgms.Nucleotide.PropertyInfo.ClrCharPropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrCharPropertyInfo(
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
        /// Tests a ClrCharPropertyInfo with the max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestClrCharPropertyInfoGetMutatorMaxNullOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = true;

            Dhgms.Nucleotide.PropertyInfo.ClrCharPropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrCharPropertyInfo(
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
        public static void TestClrCharPropertyInfoGetMutatorBothNulls()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.ClrCharPropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrCharPropertyInfo(
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
        /// Tests a ClrCharPropertyInfo with the min null
        /// </summary>
        [Fact]
        public static void TestClrCharPropertyInfoGetMutatorMinNull()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.ClrCharPropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrCharPropertyInfo(
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
        /// Tests a ClrCharPropertyInfo with the max null
        /// </summary>
        [Fact]
        public static void TestClrCharPropertyInfoGetMutatorMaxNull()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.ClrCharPropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrCharPropertyInfo(
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
        /// Tests a ClrDateTimePropertyInfo with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestClrDateTimePropertyInfoGetMutatorBothNullsOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = true;

            Dhgms.Nucleotide.PropertyInfo.ClrDateTimePropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrDateTimePropertyInfo(
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
        /// Tests a ClrDateTimePropertyInfo with the min null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestClrDateTimePropertyInfoGetMutatorMinNullOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = true;

            Dhgms.Nucleotide.PropertyInfo.ClrDateTimePropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrDateTimePropertyInfo(
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
        /// Tests a ClrDateTimePropertyInfo with the max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestClrDateTimePropertyInfoGetMutatorMaxNullOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = true;

            Dhgms.Nucleotide.PropertyInfo.ClrDateTimePropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrDateTimePropertyInfo(
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
        public static void TestClrDateTimePropertyInfoGetMutatorBothNulls()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.ClrDateTimePropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrDateTimePropertyInfo(
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
        /// Tests a ClrDateTimePropertyInfo with the min null
        /// </summary>
        [Fact]
        public static void TestClrDateTimePropertyInfoGetMutatorMinNull()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.ClrDateTimePropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrDateTimePropertyInfo(
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
        /// Tests a ClrDateTimePropertyInfo with the max null
        /// </summary>
        [Fact]
        public static void TestClrDateTimePropertyInfoGetMutatorMaxNull()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.ClrDateTimePropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrDateTimePropertyInfo(
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
        public static void TestClrDecimalPropertyInfoConstructorBasicArguments()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.ClrDecimalPropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrDecimalPropertyInfo(
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
        /// Tests a ClrDecimalPropertyInfo with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestClrDecimalPropertyInfoGetMutatorBothNullsOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.ClrDecimalPropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrDecimalPropertyInfo(
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
        /// Tests a ClrDecimalPropertyInfo with the min null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestClrDecimalPropertyInfoGetMutatorMinNullOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.ClrDecimalPropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrDecimalPropertyInfo(
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
        /// Tests a ClrDecimalPropertyInfo with the max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestClrDecimalPropertyInfoGetMutatorMaxNullOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.ClrDecimalPropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrDecimalPropertyInfo(
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
        /// Tests a ClrDecimalPropertyInfo with the min and max null
        /// </summary>
        [Fact]
        public static void TestClrDecimalPropertyInfoGetMutatorBothNulls()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.ClrDecimalPropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrDecimalPropertyInfo(
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
        /// Tests a ClrDecimalPropertyInfo with the min null
        /// </summary>
        [Fact]
        public static void TestClrDecimalPropertyInfoGetMutatorMinNull()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.ClrDecimalPropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrDecimalPropertyInfo(
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
        /// Tests a ClrDecimalPropertyInfo with the max null
        /// </summary>
        [Fact]
        public static void TestClrDecimalPropertyInfoGetMutatorMaxNull()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.ClrDecimalPropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrDecimalPropertyInfo(
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
        public static void TestClrDoublePropertyInfoConstructorBasicArguments()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.ClrDoublePropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrDoublePropertyInfo(
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
        /// Tests a ClrDoublePropertyInfo with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestClrDoublePropertyInfoGetMutatorBothNullsOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.ClrDoublePropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrDoublePropertyInfo(
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
        /// Tests a ClrDoublePropertyInfo with the min null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestClrDoublePropertyInfoGetMutatorMinNullOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.ClrDoublePropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrDoublePropertyInfo(
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
        /// Tests a ClrDoublePropertyInfo with the max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestClrDoublePropertyInfoGetMutatorMaxNullOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.ClrDoublePropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrDoublePropertyInfo(
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
        /// Tests a ClrDoublePropertyInfo with the min and max null
        /// </summary>
        [Fact]
        public static void TestClrDoublePropertyInfoGetMutatorBothNulls()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.ClrDoublePropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrDoublePropertyInfo(
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
        /// Tests a ClrDoublePropertyInfo with the min null
        /// </summary>
        [Fact]
        public static void TestClrDoublePropertyInfoGetMutatorMinNull()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.ClrDoublePropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrDoublePropertyInfo(
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
        /// Tests a ClrDoublePropertyInfo with the max null
        /// </summary>
        [Fact]
        public static void TestClrDoublePropertyInfoGetMutatorMaxNull()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.ClrDoublePropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrDoublePropertyInfo(
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
        public static void TestClrSinglePropertyInfoConstructorBasicArguments()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.ClrSinglePropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrSinglePropertyInfo(
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
        /// Tests a ClrSinglePropertyInfo with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestClrSinglePropertyInfoGetMutatorBothNullsOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.ClrSinglePropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrSinglePropertyInfo(
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
        /// Tests a ClrSinglePropertyInfo with the min null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestClrSinglePropertyInfoGetMutatorMinNullOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.ClrSinglePropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrSinglePropertyInfo(
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
        /// Tests a ClrSinglePropertyInfo with the max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestClrSinglePropertyInfoGetMutatorMaxNullOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.ClrSinglePropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrSinglePropertyInfo(
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
        /// Tests a ClrSinglePropertyInfo with the min and max null
        /// </summary>
        [Fact]
        public static void TestClrSinglePropertyInfoGetMutatorBothNulls()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.ClrSinglePropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrSinglePropertyInfo(
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
        /// Tests a ClrSinglePropertyInfo with the min null
        /// </summary>
        [Fact]
        public static void TestClrSinglePropertyInfoGetMutatorMinNull()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.ClrSinglePropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrSinglePropertyInfo(
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
        /// Tests a ClrSinglePropertyInfo with the max null
        /// </summary>
        [Fact]
        public static void TestClrSinglePropertyInfoGetMutatorMaxNull()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.ClrSinglePropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.ClrSinglePropertyInfo(
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
        public static void TestInteger16PropertyInfoConstructorBasicArguments()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.Integer16PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.Integer16PropertyInfo(
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
        /// Tests a Integer16PropertyInfo with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestInteger16PropertyInfoGetMutatorBothNullsOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.Integer16PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.Integer16PropertyInfo(
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
        /// Tests a Integer16PropertyInfo with the min null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestInteger16PropertyInfoGetMutatorMinNullOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.Integer16PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.Integer16PropertyInfo(
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
        /// Tests a Integer16PropertyInfo with the max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestInteger16PropertyInfoGetMutatorMaxNullOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.Integer16PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.Integer16PropertyInfo(
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
        /// Tests a Integer16PropertyInfo with the min and max null
        /// </summary>
        [Fact]
        public static void TestInteger16PropertyInfoGetMutatorBothNulls()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.Integer16PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.Integer16PropertyInfo(
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
        /// Tests a Integer16PropertyInfo with the min null
        /// </summary>
        [Fact]
        public static void TestInteger16PropertyInfoGetMutatorMinNull()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.Integer16PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.Integer16PropertyInfo(
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
        /// Tests a Integer16PropertyInfo with the max null
        /// </summary>
        [Fact]
        public static void TestInteger16PropertyInfoGetMutatorMaxNull()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.Integer16PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.Integer16PropertyInfo(
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
        public static void TestInteger32PropertyInfoConstructorBasicArguments()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.Integer32PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.Integer32PropertyInfo(
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
        /// Tests a Integer32PropertyInfo with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestInteger32PropertyInfoGetMutatorBothNullsOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.Integer32PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.Integer32PropertyInfo(
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
        /// Tests a Integer32PropertyInfo with the min null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestInteger32PropertyInfoGetMutatorMinNullOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.Integer32PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.Integer32PropertyInfo(
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
        /// Tests a Integer32PropertyInfo with the max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestInteger32PropertyInfoGetMutatorMaxNullOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.Integer32PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.Integer32PropertyInfo(
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
        /// Tests a Integer32PropertyInfo with the min and max null
        /// </summary>
        [Fact]
        public static void TestInteger32PropertyInfoGetMutatorBothNulls()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.Integer32PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.Integer32PropertyInfo(
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
        /// Tests a Integer32PropertyInfo with the min null
        /// </summary>
        [Fact]
        public static void TestInteger32PropertyInfoGetMutatorMinNull()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.Integer32PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.Integer32PropertyInfo(
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
        /// Tests a Integer32PropertyInfo with the max null
        /// </summary>
        [Fact]
        public static void TestInteger32PropertyInfoGetMutatorMaxNull()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.Integer32PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.Integer32PropertyInfo(
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
        public static void TestInteger64PropertyInfoConstructorBasicArguments()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.Integer64PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.Integer64PropertyInfo(
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
        /// Tests a Integer64PropertyInfo with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestInteger64PropertyInfoGetMutatorBothNullsOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.Integer64PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.Integer64PropertyInfo(
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
        /// Tests a Integer64PropertyInfo with the min null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestInteger64PropertyInfoGetMutatorMinNullOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.Integer64PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.Integer64PropertyInfo(
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
        /// Tests a Integer64PropertyInfo with the max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestInteger64PropertyInfoGetMutatorMaxNullOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.Integer64PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.Integer64PropertyInfo(
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
        /// Tests a Integer64PropertyInfo with the min and max null
        /// </summary>
        [Fact]
        public static void TestInteger64PropertyInfoGetMutatorBothNulls()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.Integer64PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.Integer64PropertyInfo(
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
        /// Tests a Integer64PropertyInfo with the min null
        /// </summary>
        [Fact]
        public static void TestInteger64PropertyInfoGetMutatorMinNull()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.Integer64PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.Integer64PropertyInfo(
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
        /// Tests a Integer64PropertyInfo with the max null
        /// </summary>
        [Fact]
        public static void TestInteger64PropertyInfoGetMutatorMaxNull()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.Integer64PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.Integer64PropertyInfo(
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
        public static void TestUnsignedInteger8PropertyInfoConstructorBasicArguments()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.UnsignedInteger8PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.UnsignedInteger8PropertyInfo(
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
        /// Tests a UnsignedInteger8PropertyInfo with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestUnsignedInteger8PropertyInfoGetMutatorBothNullsOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.UnsignedInteger8PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.UnsignedInteger8PropertyInfo(
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
        /// Tests a UnsignedInteger8PropertyInfo with the min null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestUnsignedInteger8PropertyInfoGetMutatorMinNullOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.UnsignedInteger8PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.UnsignedInteger8PropertyInfo(
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
        /// Tests a UnsignedInteger8PropertyInfo with the max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestUnsignedInteger8PropertyInfoGetMutatorMaxNullOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.UnsignedInteger8PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.UnsignedInteger8PropertyInfo(
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
        /// Tests a UnsignedInteger8PropertyInfo with the min and max null
        /// </summary>
        [Fact]
        public static void TestUnsignedInteger8PropertyInfoGetMutatorBothNulls()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.UnsignedInteger8PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.UnsignedInteger8PropertyInfo(
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
        /// Tests a UnsignedInteger8PropertyInfo with the min null
        /// </summary>
        [Fact]
        public static void TestUnsignedInteger8PropertyInfoGetMutatorMinNull()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.UnsignedInteger8PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.UnsignedInteger8PropertyInfo(
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
        /// Tests a UnsignedInteger8PropertyInfo with the max null
        /// </summary>
        [Fact]
        public static void TestUnsignedInteger8PropertyInfoGetMutatorMaxNull()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.UnsignedInteger8PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.UnsignedInteger8PropertyInfo(
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
        public static void TestUnsignedInteger16PropertyInfoConstructorBasicArguments()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.UnsignedInteger16PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.UnsignedInteger16PropertyInfo(
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
        /// Tests a UnsignedInteger16PropertyInfo with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestUnsignedInteger16PropertyInfoGetMutatorBothNullsOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.UnsignedInteger16PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.UnsignedInteger16PropertyInfo(
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
        /// Tests a UnsignedInteger16PropertyInfo with the min null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestUnsignedInteger16PropertyInfoGetMutatorMinNullOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.UnsignedInteger16PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.UnsignedInteger16PropertyInfo(
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
        /// Tests a UnsignedInteger16PropertyInfo with the max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestUnsignedInteger16PropertyInfoGetMutatorMaxNullOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.UnsignedInteger16PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.UnsignedInteger16PropertyInfo(
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
        /// Tests a UnsignedInteger16PropertyInfo with the min and max null
        /// </summary>
        [Fact]
        public static void TestUnsignedInteger16PropertyInfoGetMutatorBothNulls()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.UnsignedInteger16PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.UnsignedInteger16PropertyInfo(
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
        /// Tests a UnsignedInteger16PropertyInfo with the min null
        /// </summary>
        [Fact]
        public static void TestUnsignedInteger16PropertyInfoGetMutatorMinNull()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.UnsignedInteger16PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.UnsignedInteger16PropertyInfo(
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
        /// Tests a UnsignedInteger16PropertyInfo with the max null
        /// </summary>
        [Fact]
        public static void TestUnsignedInteger16PropertyInfoGetMutatorMaxNull()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.UnsignedInteger16PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.UnsignedInteger16PropertyInfo(
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
        public static void TestUnsignedInteger32PropertyInfoConstructorBasicArguments()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.UnsignedInteger32PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.UnsignedInteger32PropertyInfo(
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
        /// Tests a UnsignedInteger32PropertyInfo with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestUnsignedInteger32PropertyInfoGetMutatorBothNullsOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.UnsignedInteger32PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.UnsignedInteger32PropertyInfo(
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
        /// Tests a UnsignedInteger32PropertyInfo with the min null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestUnsignedInteger32PropertyInfoGetMutatorMinNullOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.UnsignedInteger32PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.UnsignedInteger32PropertyInfo(
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
        /// Tests a UnsignedInteger32PropertyInfo with the max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestUnsignedInteger32PropertyInfoGetMutatorMaxNullOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.UnsignedInteger32PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.UnsignedInteger32PropertyInfo(
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
        /// Tests a UnsignedInteger32PropertyInfo with the min and max null
        /// </summary>
        [Fact]
        public static void TestUnsignedInteger32PropertyInfoGetMutatorBothNulls()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.UnsignedInteger32PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.UnsignedInteger32PropertyInfo(
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
        /// Tests a UnsignedInteger32PropertyInfo with the min null
        /// </summary>
        [Fact]
        public static void TestUnsignedInteger32PropertyInfoGetMutatorMinNull()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.UnsignedInteger32PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.UnsignedInteger32PropertyInfo(
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
        /// Tests a UnsignedInteger32PropertyInfo with the max null
        /// </summary>
        [Fact]
        public static void TestUnsignedInteger32PropertyInfoGetMutatorMaxNull()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.UnsignedInteger32PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.UnsignedInteger32PropertyInfo(
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
        public static void TestUnsignedInteger64PropertyInfoConstructorBasicArguments()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.UnsignedInteger64PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.UnsignedInteger64PropertyInfo(
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
        /// Tests a UnsignedInteger64PropertyInfo with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestUnsignedInteger64PropertyInfoGetMutatorBothNullsOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.UnsignedInteger64PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.UnsignedInteger64PropertyInfo(
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
        /// Tests a UnsignedInteger64PropertyInfo with the min null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestUnsignedInteger64PropertyInfoGetMutatorMinNullOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.UnsignedInteger64PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.UnsignedInteger64PropertyInfo(
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
        /// Tests a UnsignedInteger64PropertyInfo with the max null, and allows the property to be optional\ nullable
        /// </summary>
        [Fact]
        public static void TestUnsignedInteger64PropertyInfoGetMutatorMaxNullOptional()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.UnsignedInteger64PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.UnsignedInteger64PropertyInfo(
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
        /// Tests a UnsignedInteger64PropertyInfo with the min and max null
        /// </summary>
        [Fact]
        public static void TestUnsignedInteger64PropertyInfoGetMutatorBothNulls()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.UnsignedInteger64PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.UnsignedInteger64PropertyInfo(
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
        /// Tests a UnsignedInteger64PropertyInfo with the min null
        /// </summary>
        [Fact]
        public static void TestUnsignedInteger64PropertyInfoGetMutatorMinNull()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.UnsignedInteger64PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.UnsignedInteger64PropertyInfo(
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
        /// Tests a UnsignedInteger64PropertyInfo with the max null
        /// </summary>
        [Fact]
        public static void TestUnsignedInteger64PropertyInfoGetMutatorMaxNull()
        {
            const Dhgms.Nucleotide.Model.CollectionType CollectionType = Dhgms.Nucleotide.Model.CollectionType.GenericLinkedList;
            const string Name = "Name";
            const string Description = "Description";
            const bool Optional = false;

            Dhgms.Nucleotide.PropertyInfo.UnsignedInteger64PropertyInfo instance = new Dhgms.Nucleotide.PropertyInfo.UnsignedInteger64PropertyInfo(
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

#endregion