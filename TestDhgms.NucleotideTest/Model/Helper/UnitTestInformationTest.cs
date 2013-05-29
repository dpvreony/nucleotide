// -----------------------------------------------------------------------
// <copyright file="UnitTestInformationTest.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace TestDhgms.NucleotideTest.Model.Helper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Dhgms.Nucleotide.Model.Info;
    using Dhgms.Nucleotide.Model.Info.PropertyInfo;

    using NUnit.Framework;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class UnitTestInformationTest
    {
        #region Constants

        /// <summary>
        /// The class name default base.
        /// </summary>
        private const string ClassNameDefaultBase = "ClassNameDefaultBase";

        /// <summary>
        /// The class name inheriting.
        /// </summary>
        private const string ClassNameInheriting = "ClassNameInheriting";

        /// <summary>
        /// The class remarks.
        /// </summary>
        private const string ClassRemarks = "Unit test for information class code generation";

        /// <summary>
        /// The main namespace name.
        /// </summary>
        private const string MainNamespaceName = "TestDhgms.Nucleotide";

        /// <summary>
        /// The sub namespace.
        /// </summary>
        private const string SubNamespace = "SubNamespace";

        #endregion

        /// <summary>
        /// The properties default.
        /// </summary>
        private readonly Base[] propertiesDefault = new Base[]
            {
                new ClrBoolean(CollectionType.None, "SingleBooleanItem", "A Single Boolean Item", false, false, null), 
                new ClrString(
                    CollectionType.None, "SingleStringItem", "A Single String Item", false, null, null, false, false, null), 
                new ClrString(
                    CollectionType.None, 
                    "SingleStringItemMinLength", 
                    "A Single String Item with a Minimum Length", 
                    false, 
                    1, 
                    null, 
                    false, 
                    false, null), 
                new ClrString(
                    CollectionType.None, 
                    "SingleStringItemMaxLength", 
                    "A Single String Item with a Maximum Length", 
                    false, 
                    null, 
                    10, 
                    false, 
                    false, null), 
                new ClrString(
                    CollectionType.None, 
                    "SingleStringItemMinMaxLength", 
                    "A Single String Item with a Minimum and Maximum Length", 
                    false, 
                    1, 
                    10, 
                    false, 
                    false,
                    null)
            };

        /// <summary>
        /// The properties inheriting.
        /// </summary>
        private readonly Base[] propertiesInheriting = new Base[]
            {
               new ClrBoolean(CollectionType.None, "BooleanNullableItem", "A Boolean Item", true, false, null) 
            };

        /// <summary>
        /// The properties default.
        /// </summary>
        private static readonly Base[] propertiesLists = new Base[]
            {
                new ClrBoolean(
                    CollectionType.GenericLinkedList, "LinkedListBooleanItem", "A List of Boolean Item", false, false, null), 
                new ClrBoolean(CollectionType.GenericList, "ListBooleanItem", "A List of Boolean Item", false, false, null), 
                new ClrString(
                    CollectionType.GenericList, 
                    "ListStringItem", 
                    "A List of String Item", 
                    false, 
                    null, 
                    null, 
                    false, 
                    false,
                    null), 
                new ClrString(
                    CollectionType.GenericList, 
                    "ListStringItemMinLength", 
                    "A List of String Item with a Minimum Length", 
                    false, 
                    1, 
                    null, 
                    false, 
                    false,
                    null), 
                new ClrString(
                    CollectionType.GenericList, 
                    "ListStringItemMaxLength", 
                    "A List of String Item with a Maximum Length", 
                    false, 
                    null, 
                    10, 
                    false, 
                    false,
                    null), 
                new ClrString(
                    CollectionType.GenericList, 
                    "ListStringItemMinMaxLength", 
                    "A List of String Item with a Minimum and Maximum Length", 
                    false, 
                    1, 
                    10, 
                    false, 
                    false,
                    null)
            };

        /// <summary>
        /// 
        /// </summary>
        public class BaseTest
        {
            /// <summary>
            /// 
            /// </summary>
            /// <exception cref="Exception"></exception>
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
                {
                    // ReSharper restore EmptyGeneralCatchClause
                    return;
                }

                if (!string.IsNullOrWhiteSpace(assemblyInfo))
                {
                    throw new Exception("Library is installed in the GAC.  Uninstall before performing unit tests.");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestFixture]
        public class GenerateMethod : BaseTest
        {
            /// <summary>
            /// 
            /// </summary>
            [Test]
            public void ShouldSucceed()
            {
                var instance = new Dhgms.Nucleotide.Model.Helper.Information();
                Console.Write(
                    instance.Generate(
                        MainNamespaceName,
                        SubNamespace,
                        ClassNameDefaultBase,
                        ClassRemarks,
                        propertiesLists,
                        null,
                        null));
            }
        }
    }
}
