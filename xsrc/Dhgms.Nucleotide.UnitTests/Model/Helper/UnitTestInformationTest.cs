// -----------------------------------------------------------------------
// <copyright file="UnitTestInformationTest.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Dhgms.Nucleotide.Tests.Model.Helper
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    using Dhgms.Nucleotide.Model;
    using Dhgms.Nucleotide.PropertyInfo;

    using TestDhgms.NucleotideMocking;

    using Xunit;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [ExcludeFromCodeCoverage]
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
        private readonly PropertyInfoBase[] propertiesDefault = new PropertyInfoBase[]
            {
                new ClrBooleanPropertyInfo(CollectionType.None, "SingleBooleanItem", "A Single Boolean Item", false, false, null), 
                new ClrStringPropertyInfo(
                    CollectionType.None, "SingleStringItem", "A Single String Item", false, null, null, false, false, null), 
                new ClrStringPropertyInfo(
                    CollectionType.None, 
                    "SingleStringItemMinLength", 
                    "A Single String Item with a Minimum Length", 
                    false, 
                    1, 
                    null, 
                    false, 
                    false, null), 
                new ClrStringPropertyInfo(
                    CollectionType.None, 
                    "SingleStringItemMaxLength", 
                    "A Single String Item with a Maximum Length", 
                    false, 
                    null, 
                    10, 
                    false, 
                    false, null), 
                new ClrStringPropertyInfo(
                    CollectionType.None, 
                    "SingleStringItemMinMaxLength", 
                    "A Single String Item with a Minimum and Maximum Length", 
                    false, 
                    1, 
                    10, 
                    false, 
                    false,
                    null), 
            };

        /// <summary>
        /// The properties inheriting.
        /// </summary>
        private readonly PropertyInfoBase[] propertiesInheriting = new PropertyInfoBase[]
            {
               new ClrBooleanPropertyInfo(CollectionType.None, "BooleanNullableItem", "A Boolean Item", true, false, null),  
            };

        /// <summary>
        /// The properties default.
        /// </summary>
        private static readonly PropertyInfoBase[] propertiesLists = new PropertyInfoBase[]
            {
                new ClrBooleanPropertyInfo(
                    CollectionType.GenericLinkedList, "LinkedListBooleanItem", "A List of Boolean Item", false, false, null), 
                new ClrBooleanPropertyInfo(CollectionType.GenericList, "ListBooleanItem", "A List of Boolean Item", false, false, null), 
                new ClrStringPropertyInfo(
                    CollectionType.GenericList, 
                    "ListStringItem", 
                    "A List of String Item", 
                    false, 
                    null, 
                    null, 
                    false, 
                    false,
                    null), 
                new ClrStringPropertyInfo(
                    CollectionType.GenericList, 
                    "ListStringItemMinLength", 
                    "A List of String Item with a Minimum Length", 
                    false, 
                    1, 
                    null, 
                    false, 
                    false,
                    null), 
                new ClrStringPropertyInfo(
                    CollectionType.GenericList, 
                    "ListStringItemMaxLength", 
                    "A List of String Item with a Maximum Length", 
                    false, 
                    null, 
                    10, 
                    false, 
                    false,
                    null), 
                new ClrStringPropertyInfo(
                    CollectionType.GenericList, 
                    "ListStringItemMinMaxLength", 
                    "A List of String Item with a Minimum and Maximum Length", 
                    false, 
                    1, 
                    10, 
                    false, 
                    false,
                    null), 
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
                var instance = new Generators.InformationClassGenerator();
                var cgp = new MockClassGenerationParameters(
                        MainNamespaceName,
                        SubNamespace,
                        ClassNameDefaultBase,
                        propertiesLists,
                        null,
                        "DHGMS Solutions",
                        new[] { "Copyright DHGMS Solutions" },
                        2010,
                        null,
                        ClassRemarks);
                var classes = new List<IClassGenerationParameters> { cgp };
                Console.Write(instance.Generate(classes));
            }
        }
    }
}
