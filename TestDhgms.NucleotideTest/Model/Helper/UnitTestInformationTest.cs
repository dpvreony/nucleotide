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
    using Dhgms.Nucleotide.PropertyInfo;

    using TestDhgms.NucleotideMocking;

    using Xunit;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
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
        public class GenerateMethod : TestBase
        {
            /// <summary>
            /// 
            /// </summary>
            [Fact]
            public void ShouldSucceed()
            {
                var instance = new Dhgms.Nucleotide.Helper.Information();
                var cgp = new MockClassGenerationParameters(
                        MainNamespaceName,
                        SubNamespace,
                        ClassNameDefaultBase,
                        propertiesLists,
                        null,
                        null,
                null, 2010, null, ClassRemarks);
                Console.Write(instance.Generate(cgp));
            }
        }
    }
}
