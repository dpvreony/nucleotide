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
    using NUnit.Framework;

    /// <summary>
    /// Unit Tests for PropertyInfo classes
    /// </summary>
    [TestFixture]
    public class PropertyInfo
    {
        /// <summary>
        /// Method checks to see if unit tests can take place
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        [TestFixtureSetUp]
        public static void ClassInit()
        {
            string assemblyInfo;
            try
            {
                assemblyInfo = AssemblyCache.QueryAssemblyInfo("Dhgms.Nucleotide");
            }
            // ReSharper disable EmptyGeneralCatchClause
            catch
            // ReSharper restore EmptyGeneralCatchClause
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(assemblyInfo))
            {
                throw new Exception("Library is installed in the GAC.  Uninstall before performing unit tests.");
            }
        }

        /// <summary>
        /// Tests to ensure exception is thrown when a keyword is passed as a name
        /// </summary>
        [Test]
        public void TestKeywordAsName1()
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
        [Test]
        public void TestKeywordAsName2()
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
        [Test]
        public void TestKeywordAsName3()
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
        [Test]
        public void TestKeywordAsName4()
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
        [Test]
        public void TestKeywordAsName5()
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
        [Test]
        public void TestKeywordAsName6()
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
        [Test]
        public void TestKeywordAsName7()
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
        [Test]
        public void TestKeywordAsName8()
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
        [Test]
        public void TestKeywordAsName9()
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
        [Test]
        public void TestKeywordAsName10()
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
        [Test]
        public void TestKeywordAsName11()
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
        [Test]
        public void TestKeywordAsName12()
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
        [Test]
        public void TestKeywordAsName13()
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
        [Test]
        public void TestKeywordAsName14()
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
        [Test]
        public void TestKeywordAsName15()
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
        [Test]
        public void TestKeywordAsName16()
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
        [Test]
        public void TestKeywordAsName17()
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
        [Test]
        public void TestKeywordAsName18()
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
        [Test]
        public void TestKeywordAsName19()
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
        [Test]
        public void TestKeywordAsName20()
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
        [Test]
        public void TestKeywordAsName21()
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
        [Test]
        public void TestKeywordAsName22()
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
        [Test]
        public void TestKeywordAsName23()
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
        [Test]
        public void TestKeywordAsName24()
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
        [Test]
        public void TestKeywordAsName25()
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
        [Test]
        public void TestKeywordAsName26()
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
        [Test]
        public void TestKeywordAsName27()
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
        [Test]
        public void TestKeywordAsName28()
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
        [Test]
        public void TestKeywordAsName29()
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
        [Test]
        public void TestKeywordAsName30()
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
        [Test]
        public void TestKeywordAsName31()
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
        [Test]
        public void TestKeywordAsName32()
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
        [Test]
        public void TestKeywordAsName33()
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
        [Test]
        public void TestKeywordAsName34()
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
        [Test]
        public void TestKeywordAsName35()
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
        [Test]
        public void TestKeywordAsName36()
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
        [Test]
        public void TestKeywordAsName37()
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
        [Test]
        public void TestKeywordAsName38()
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
        [Test]
        public void TestKeywordAsName39()
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
        [Test]
        public void TestKeywordAsName40()
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
        [Test]
        public void TestKeywordAsName41()
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
        [Test]
        public void TestKeywordAsName42()
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
        [Test]
        public void TestKeywordAsName43()
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
        [Test]
        public void TestKeywordAsName44()
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
        [Test]
        public void TestKeywordAsName45()
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
        [Test]
        public void TestKeywordAsName46()
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
        [Test]
        public void TestKeywordAsName47()
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
        [Test]
        public void TestKeywordAsName48()
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
        [Test]
        public void TestKeywordAsName49()
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
        [Test]
        public void TestKeywordAsName50()
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
        [Test]
        public void TestKeywordAsName51()
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
        [Test]
        public void TestKeywordAsName52()
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
        [Test]
        public void TestKeywordAsName53()
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
        [Test]
        public void TestKeywordAsName54()
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
        [Test]
        public void TestKeywordAsName55()
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
        [Test]
        public void TestKeywordAsName56()
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
        [Test]
        public void TestKeywordAsName57()
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
        [Test]
        public void TestKeywordAsName58()
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
        [Test]
        public void TestKeywordAsName59()
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
        [Test]
        public void TestKeywordAsName60()
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
        [Test]
        public void TestKeywordAsName61()
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
        [Test]
        public void TestKeywordAsName62()
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
        [Test]
        public void TestKeywordAsName63()
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
        [Test]
        public void TestKeywordAsName64()
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
        [Test]
        public void TestKeywordAsName65()
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
        [Test]
        public void TestKeywordAsName66()
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
        [Test]
        public void TestKeywordAsName67()
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
        [Test]
        public void TestKeywordAsName68()
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
        [Test]
        public void TestKeywordAsName69()
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
        [Test]
        public void TestKeywordAsName70()
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
        [Test]
        public void TestKeywordAsName71()
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
        [Test]
        public void TestKeywordAsName72()
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
        [Test]
        public void TestKeywordAsName73()
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
        [Test]
        public void TestKeywordAsName74()
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
        [Test]
        public void TestKeywordAsName75()
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
        [Test]
        public void TestKeywordAsName76()
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
        [Test]
        public void TestKeywordAsName77()
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
        [Test]
        public void TestKeywordAsName78()
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
        [Test]
        public void TestKeywordAsName79()
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
        [Test]
        public void TestKeywordAsName80()
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
        [Test]
        public void TestKeywordAsName81()
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
        [Test]
        public void TestKeywordAsName82()
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
        [Test]
        public void TestKeywordAsName83()
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
        [Test]
        public void TestKeywordAsName84()
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
        [Test]
        public void TestKeywordAsName85()
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
        [Test]
        public void TestKeywordAsName86()
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
        [Test]
        public void TestKeywordAsName87()
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
        [Test]
        public void TestKeywordAsName88()
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
        [Test]
        public void TestKeywordAsName89()
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
        [Test]
        public void TestKeywordAsName90()
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
        [Test]
        public void TestKeywordAsName91()
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
        [Test]
        public void TestKeywordAsName92()
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
        [Test]
        public void TestKeywordAsName93()
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
        [Test]
        public void TestKeywordAsName94()
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
        [Test]
        public void TestKeywordAsName95()
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
        [Test]
        public void TestKeywordAsName96()
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
        [Test]
        public void TestKeywordAsName97()
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
        [Test]
        public void TestKeywordAsName98()
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
        [Test]
        public void TestKeywordAsName99()
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
        [Test]
        public void TestKeywordAsName100()
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
        [Test]
        public void TestKeywordAsName101()
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
        [Test]
        public void TestKeywordAsName102()
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
        [Test]
        public void TestKeywordAsName103()
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
        [Test]
        public void TestKeywordAsName104()
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
        [Test]
        public void TestKeywordAsName105()
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
        [Test]
        public void TestKeywordAsName106()
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
        [Test]
        public void TestKeywordAsName107()
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
        [Test]
        public void TestKeywordAsName108()
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
        [Test]
        public void TestKeywordAsName109()
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
        [Test]
        public void TestKeywordAsName110()
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
        [Test]
        public void TestKeywordAsName111()
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
        [Test]
        public void TestKeywordAsName112()
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
        [Test]
        public void TestKeywordAsName113()
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
        [Test]
        public void TestKeywordAsName114()
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
        [Test]
        public void TestKeywordAsName115()
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
        [Test]
        public void TestKeywordAsName116()
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
        [Test]
        public void TestKeywordAsName117()
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
        [Test]
        public void TestKeywordAsName118()
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
        [Test]
        public void TestKeywordAsName119()
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
        [Test]
        public void TestKeywordAsName120()
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
        [Test]
        public void TestKeywordAsName121()
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
        [Test]
        public void TestKeywordAsName122()
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
        [Test]
        public void TestKeywordAsName123()
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
        [Test]
        public void TestKeywordAsName124()
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
        [Test]
        public void TestKeywordAsName125()
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
        [Test]
        public void TestKeywordAsName126()
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
        [Test]
        public void TestKeywordAsName127()
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
        [Test]
        public void TestKeywordAsName128()
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
        [Test]
        public void TestKeywordAsName129()
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
        [Test]
        public void TestKeywordAsName130()
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
        [Test]
        public void TestKeywordAsName131()
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
        [Test]
        public void TestKeywordAsName132()
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
        [Test]
        public void TestKeywordAsName133()
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
        [Test]
        public void TestKeywordAsName134()
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
        [Test]
        public void TestKeywordAsName135()
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
        [Test]
        public void TestKeywordAsName136()
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
        [Test]
        public void TestKeywordAsName137()
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
        [Test]
        public void TestKeywordAsName138()
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
        [Test]
        public void TestKeywordAsName139()
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
        [Test]
        public void TestKeywordAsName140()
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
        [Test]
        public void TestKeywordAsName141()
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
        [Test]
        public void TestKeywordAsName142()
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
        [Test]
        public void TestKeywordAsName143()
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
        [Test]
        public void TestKeywordAsName144()
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
        [Test]
        public void TestKeywordAsName145()
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
        [Test]
        public void TestKeywordAsName146()
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
        [Test]
        public void TestKeywordAsName147()
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
        [Test]
        public void TestKeywordAsName148()
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
        [Test]
        public void TestKeywordAsName149()
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
        [Test]
        public void TestKeywordAsName150()
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
        [Test]
        public void TestKeywordAsName151()
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
        [Test]
        public void TestKeywordAsName152()
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
        [Test]
        public void TestKeywordAsName153()
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
        [Test]
        public void TestKeywordAsName154()
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
        [Test]
        public void TestKeywordAsName155()
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
        [Test]
        public void TestKeywordAsName156()
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
        [Test]
        public void TestKeywordAsName157()
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
        [Test]
        public void TestKeywordAsName158()
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
        [Test]
        public void TestKeywordAsName159()
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
        [Test]
        public void TestKeywordAsName160()
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
        [Test]
        public void TestKeywordAsName161()
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
        [Test]
        public void TestKeywordAsName162()
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
        [Test]
        public void TestKeywordAsName163()
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
        [Test]
        public void TestKeywordAsName164()
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
        [Test]
        public void TestKeywordAsName165()
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
        [Test]
        public void TestKeywordAsName166()
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
        [Test]
        public void TestKeywordAsName167()
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
        [Test]
        public void TestKeywordAsName168()
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
        [Test]
        public void TestKeywordAsName169()
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
        [Test]
        public void TestKeywordAsName170()
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
        [Test]
        public void TestKeywordAsName171()
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
        [Test]
        public void TestKeywordAsName172()
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
        [Test]
        public void TestKeywordAsName173()
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
        [Test]
        public void TestKeywordAsName174()
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
        [Test]
        public void TestKeywordAsName175()
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
        [Test]
        public void TestKeywordAsName176()
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
        [Test]
        public void TestKeywordAsName177()
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
        [Test]
        public void TestKeywordAsName178()
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
        [Test]
        public void TestKeywordAsName179()
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
        [Test]
        public void TestKeywordAsName180()
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
        [Test]
        public void TestKeywordAsName181()
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
        [Test]
        public void TestKeywordAsName182()
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
        [Test]
        public void TestKeywordAsName183()
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
        [Test]
        public void TestKeywordAsName184()
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
        [Test]
        public void TestKeywordAsName185()
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
        [Test]
        public void TestKeywordAsName186()
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
        [Test]
        public void TestKeywordAsName187()
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
        [Test]
        public void TestKeywordAsName188()
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
        [Test]
        public void TestKeywordAsName189()
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
        [Test]
        public void TestKeywordAsName190()
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
        [Test]
        public void TestKeywordAsName191()
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
        [Test]
        public void TestKeywordAsName192()
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
        [Test]
        public void TestKeywordAsName193()
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
        [Test]
        public void TestKeywordAsName194()
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
        [Test]
        public void TestKeywordAsName195()
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
        [Test]
        public void TestKeywordAsName196()
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
        [Test]
        public void TestKeywordAsName197()
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
        [Test]
        public void TestKeywordAsName198()
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
        [Test]
        public void TestKeywordAsName199()
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
        [Test]
        public void TestKeywordAsName200()
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
        [Test]
        public void TestKeywordAsName201()
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
        [Test]
        public void TestKeywordAsName202()
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
        [Test]
        public void TestKeywordAsName203()
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
        [Test]
        public void TestKeywordAsName204()
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
        [Test]
        public void TestKeywordAsName205()
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
        [Test]
        public void TestKeywordAsName206()
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
        [Test]
        public void TestKeywordAsName207()
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
        [Test]
        public void TestKeywordAsName208()
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
        [Test]
        public void TestKeywordAsName209()
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
        [Test]
        public void TestKeywordAsName210()
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
        [Test]
        public void TestKeywordAsName211()
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
        [Test]
        public void TestKeywordAsName212()
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
        [Test]
        public void TestKeywordAsName213()
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
        [Test]
        public void TestKeywordAsName214()
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
        [Test]
        public void TestKeywordAsName215()
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
        [Test]
        public void TestKeywordAsName216()
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
        [Test]
        public void TestKeywordAsName217()
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
        [Test]
        public void TestKeywordAsName218()
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
        [Test]
        public void TestKeywordAsName219()
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
        [Test]
        public void TestKeywordAsName220()
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
        [Test]
        public void TestKeywordAsName221()
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
        [Test]
        public void TestKeywordAsName222()
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
        [Test]
        public void TestKeywordAsName223()
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
        [Test]
        public void TestKeywordAsName224()
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
        [Test]
        public void TestKeywordAsName225()
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
        [Test]
        public void TestKeywordAsName226()
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
        [Test]
        public void TestKeywordAsName227()
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
        [Test]
        public void TestKeywordAsName228()
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
        [Test]
        public void TestKeywordAsName229()
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
        [Test]
        public void TestKeywordAsName230()
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
        [Test]
        public void TestKeywordAsName231()
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
        [Test]
        public void TestKeywordAsName232()
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
        [Test]
        public void TestKeywordAsName233()
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
        [Test]
        public void TestKeywordAsName234()
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
        [Test]
        public void TestKeywordAsName235()
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
        [Test]
        public void TestKeywordAsName236()
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
        [Test]
        public void TestKeywordAsName237()
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
        [Test]
        public void TestKeywordAsName238()
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
        [Test]
        public void TestKeywordAsName239()
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
        [Test]
        public void TestKeywordAsName240()
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
        [Test]
        public void TestKeywordAsName241()
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
        [Test]
        public void TestKeywordAsName242()
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
        [Test]
        public void TestKeywordAsName243()
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
        [Test]
        public void TestKeywordAsName244()
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
        [Test]
        public void TestKeywordAsName245()
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
        [Test]
        public void TestKeywordAsName246()
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
        [Test]
        public void TestKeywordAsName247()
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
        [Test]
        public void TestKeywordAsName248()
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
        [Test]
        public void TestKeywordAsName249()
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
        [Test]
        public void TestKeywordAsName250()
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
        [Test]
        public void TestKeywordAsName251()
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
        [Test]
        public void TestKeywordAsName252()
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
        [Test]
        public void TestKeywordAsName253()
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
        [Test]
        public void TestKeywordAsName254()
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
        [Test]
        public void TestKeywordAsName255()
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
        [Test]
        public void TestKeywordAsName256()
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
        [Test]
        public void TestKeywordAsName257()
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
        [Test]
        public void TestKeywordAsName258()
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
        [Test]
        public void TestKeywordAsName259()
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
        [Test]
        public void TestKeywordAsName260()
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
        [Test]
        public void TestKeywordAsName261()
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
        [Test]
        public void TestKeywordAsName262()
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
        [Test]
        public void TestKeywordAsName263()
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
        [Test]
        public void TestKeywordAsName264()
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
        [Test]
        public void TestKeywordAsName265()
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
        [Test]
        public void TestKeywordAsName266()
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
        [Test]
        public void TestKeywordAsName267()
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
        [Test]
        public void TestKeywordAsName268()
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
        [Test]
        public void TestKeywordAsName269()
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
        [Test]
        public void TestKeywordAsName270()
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
        [Test]
        public void TestKeywordAsName271()
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
        [Test]
        public void TestKeywordAsName272()
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
        [Test]
        public void TestKeywordAsName273()
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
        [Test]
        public void TestKeywordAsName274()
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
        [Test]
        public void TestKeywordAsName275()
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
        [Test]
        public void TestKeywordAsName276()
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
        [Test]
        public void TestKeywordAsName277()
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
        [Test]
        public void TestKeywordAsName278()
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
        [Test]
        public void TestKeywordAsName279()
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
        [Test]
        public void TestKeywordAsName280()
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
        [Test]
        public void TestKeywordAsName281()
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
        [Test]
        public void TestKeywordAsName282()
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
        [Test]
        public void TestKeywordAsName283()
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
        [Test]
        public void TestKeywordAsName284()
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
        [Test]
        public void TestKeywordAsName285()
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
        [Test]
        public void TestKeywordAsName286()
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
        [Test]
        public void TestKeywordAsName287()
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
        [Test]
        public void TestKeywordAsName288()
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
        [Test]
        public void TestKeywordAsName289()
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
        [Test]
        public void TestKeywordAsName290()
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
        [Test]
        public void TestKeywordAsName291()
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
        [Test]
        public void TestKeywordAsName292()
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
        [Test]
        public void TestKeywordAsName293()
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
        [Test]
        public void TestKeywordAsName294()
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
        [Test]
        public void TestKeywordAsName295()
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
        [Test]
        public void TestKeywordAsName296()
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
        [Test]
        public void TestKeywordAsName297()
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
        [Test]
        public void TestKeywordAsName298()
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
        [Test]
        public void TestKeywordAsName299()
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
        [Test]
        public void TestKeywordAsName300()
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
        [Test]
        public void TestKeywordAsName301()
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
        [Test]
        public void TestKeywordAsName302()
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
        [Test]
        public void TestKeywordAsName303()
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
        [Test]
        public void TestKeywordAsName304()
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
        [Test]
        public void TestKeywordAsName305()
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
        [Test]
        public void TestKeywordAsName306()
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
        [Test]
        public void TestKeywordAsName307()
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
        [Test]
        public void TestKeywordAsName308()
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
        [Test]
        public void TestKeywordAsName309()
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
        [Test]
        public void TestKeywordAsName310()
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
        [Test]
        public void TestKeywordAsName311()
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
        [Test]
        public void TestKeywordAsName312()
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
        [Test]
        public void TestKeywordAsName313()
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
        [Test]
        public void TestKeywordAsName314()
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
        [Test]
        public void TestKeywordAsName315()
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
        [Test]
        public void TestKeywordAsName316()
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
        [Test]
        public void TestKeywordAsName317()
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
        [Test]
        public void TestKeywordAsName318()
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
        [Test]
        public void TestKeywordAsName319()
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
        [Test]
        public void TestKeywordAsName320()
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
        [Test]
        public void TestKeywordAsName321()
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
        [Test]
        public void TestKeywordAsName322()
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
        [Test]
        public void TestKeywordAsName323()
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
        [Test]
        public void TestKeywordAsName324()
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
        [Test]
        public void TestKeywordAsName325()
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
        [Test]
        public void TestKeywordAsName326()
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
        [Test]
        public void TestKeywordAsName327()
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
        [Test]
        public void TestKeywordAsName328()
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
        [Test]
        public void TestKeywordAsName329()
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
        [Test]
        public void TestKeywordAsName330()
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
        [Test]
        public void TestKeywordAsName331()
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
        [Test]
        public void TestKeywordAsName332()
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
        [Test]
        public void TestKeywordAsName333()
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
        [Test]
        public void TestKeywordAsName334()
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
        [Test]
        public void TestKeywordAsName335()
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
        [Test]
        public void TestKeywordAsName336()
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
        [Test]
        public void TestKeywordAsName337()
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
        [Test]
        public void TestKeywordAsName338()
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
        [Test]
        public void TestKeywordAsName339()
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
        [Test]
        public void TestKeywordAsName340()
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
        [Test]
        public void TestKeywordAsName341()
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
        [Test]
        public void TestKeywordAsName342()
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
        [Test]
        public void TestKeywordAsName343()
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
        [Test]
        public void TestKeywordAsName344()
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
        [Test]
        public void TestKeywordAsName345()
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
        [Test]
        public void TestKeywordAsName346()
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
        [Test]
        public void TestKeywordAsName347()
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
        [Test]
        public void TestKeywordAsName348()
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
        [Test]
        public void TestKeywordAsName349()
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
        [Test]
        public void TestKeywordAsName350()
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
        [Test]
        public void TestKeywordAsName351()
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
        [Test]
        public void TestKeywordAsName352()
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
        [Test]
        public void TestKeywordAsName353()
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
        [Test]
        public void TestKeywordAsName354()
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
        [Test]
        public void TestKeywordAsName355()
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
        [Test]
        public void TestKeywordAsName356()
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
        [Test]
        public void TestKeywordAsName357()
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
        [Test]
        public void TestKeywordAsName358()
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
        [Test]
        public void TestKeywordAsName359()
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
        [Test]
        public void TestKeywordAsName360()
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
        [Test]
        public void TestKeywordAsName361()
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
        [Test]
        public void TestKeywordAsName362()
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
        [Test]
        public void TestKeywordAsName363()
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
        [Test]
        public void TestKeywordAsName364()
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
        [Test]
        public void TestKeywordAsName365()
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
        [Test]
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

            Assert.AreEqual(CollectionType, instance.Collection);
            Assert.AreEqual(Name, instance.Name);
            Assert.AreEqual(Description, instance.Description);
            Assert.AreEqual(Optional, instance.Optional);
        }

        /// <summary>
        /// Tests a ClrChar with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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

            Assert.AreEqual(CollectionType, instance.Collection);
            Assert.AreEqual(Name, instance.Name);
            Assert.AreEqual(Description, instance.Description);
            Assert.AreEqual(Optional, instance.Optional);
        }

        /// <summary>
        /// Tests a ClrDecimal with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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

            Assert.AreEqual(CollectionType, instance.Collection);
            Assert.AreEqual(Name, instance.Name);
            Assert.AreEqual(Description, instance.Description);
            Assert.AreEqual(Optional, instance.Optional);
        }

        /// <summary>
        /// Tests a ClrDouble with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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

            Assert.AreEqual(CollectionType, instance.Collection);
            Assert.AreEqual(Name, instance.Name);
            Assert.AreEqual(Description, instance.Description);
            Assert.AreEqual(Optional, instance.Optional);
        }

        /// <summary>
        /// Tests a ClrSingle with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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

            Assert.AreEqual(CollectionType, instance.Collection);
            Assert.AreEqual(Name, instance.Name);
            Assert.AreEqual(Description, instance.Description);
            Assert.AreEqual(Optional, instance.Optional);
        }

        /// <summary>
        /// Tests a Integer16 with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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

            Assert.AreEqual(CollectionType, instance.Collection);
            Assert.AreEqual(Name, instance.Name);
            Assert.AreEqual(Description, instance.Description);
            Assert.AreEqual(Optional, instance.Optional);
        }

        /// <summary>
        /// Tests a Integer32 with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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

            Assert.AreEqual(CollectionType, instance.Collection);
            Assert.AreEqual(Name, instance.Name);
            Assert.AreEqual(Description, instance.Description);
            Assert.AreEqual(Optional, instance.Optional);
        }

        /// <summary>
        /// Tests a Integer64 with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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

            Assert.AreEqual(CollectionType, instance.Collection);
            Assert.AreEqual(Name, instance.Name);
            Assert.AreEqual(Description, instance.Description);
            Assert.AreEqual(Optional, instance.Optional);
        }

        /// <summary>
        /// Tests a UnsignedInteger8 with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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

            Assert.AreEqual(CollectionType, instance.Collection);
            Assert.AreEqual(Name, instance.Name);
            Assert.AreEqual(Description, instance.Description);
            Assert.AreEqual(Optional, instance.Optional);
        }

        /// <summary>
        /// Tests a UnsignedInteger16 with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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

            Assert.AreEqual(CollectionType, instance.Collection);
            Assert.AreEqual(Name, instance.Name);
            Assert.AreEqual(Description, instance.Description);
            Assert.AreEqual(Optional, instance.Optional);
        }

        /// <summary>
        /// Tests a UnsignedInteger32 with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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

            Assert.AreEqual(CollectionType, instance.Collection);
            Assert.AreEqual(Name, instance.Name);
            Assert.AreEqual(Description, instance.Description);
            Assert.AreEqual(Optional, instance.Optional);
        }

        /// <summary>
        /// Tests a UnsignedInteger64 with the min and max null, and allows the property to be optional\ nullable
        /// </summary>
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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