﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Information.cs" company="DHGMS Solutions">
//   Licensed under GNU General Public License version 2 (GPLv2)
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Dhgms.Nucleotide.Tests.Model.Helper
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using Dhgms.Nucleotide.Model;
    using Dhgms.Nucleotide.PropertyInfo;

    using TestDhgms.NucleotideMocking;

    using Xunit;

    /// <summary>
    /// The information.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Information
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

        #region Fields

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
                    false, null), 
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
        private readonly PropertyInfoBase[] propertiesLists = new PropertyInfoBase[]
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

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The generate method.
        /// </summary>
        public class GenerateMethod
        {
            /// <summary>
            /// The throws argument null exception.
            /// </summary>
            public void ThrowsArgumentNullException()
            {
                var instance = new Generators.InformationClassGenerator();
                var cgp = new MockClassGenerationParameters(null, null, null, null, null, null, null, 2010, null, null);
                var classes = new List<IClassGenerationParameters> { cgp };
                var ex = Assert.Throws<ArgumentNullException>(() => instance.Generate(classes));
                Assert.Equal("cgp", ex.ParamName);
            }
        }

        /*
        /// <summary>
        /// The test information all arguments null.
        /// </summary>
        [TestMethod]
        public void TestInformationAllArgumentsNull()
        {

            try
            {
                instance.Generate(cgp);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("mainNamespaceName", e.ParamName);
                return;
            }

            Assert.Fail();
        }

        /// <summary>
        /// The test information class name null.
        /// </summary>
        [TestMethod]
        public void TestInformationClassNameNull()
        {
            var instance = new Dhgms.Nucleotide.Model.Helper.Information();

            try
            {
                instance.Generate(
                    MainNamespaceName, SubNamespace, null, ClassRemarks, this.propertiesDefault, null, null);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("className", e.ParamName);
                return;
            }

            Assert.Fail("Expected System.NullReferenceException");
        }

        /// <summary>
        /// The test information class remarks null.
        /// </summary>
        [TestMethod]
        public void TestInformationClassRemarksNull()
        {
            var instance = new Dhgms.Nucleotide.Model.Helper.Information();

            try
            {
                instance.Generate(
                    MainNamespaceName, SubNamespace, ClassNameDefaultBase, null, this.propertiesDefault, null, null);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("classRemarks", e.ParamName);
                return;
            }

            Assert.Fail("Expected System.NullReferenceException");
        }

        /// <summary>
        /// The test information inheriting should succeed.
        /// </summary>
        [TestMethod]
        public void TestInformationInheritingShouldSucceed()
        {
            var instance = new Dhgms.Nucleotide.Model.Helper.Information();
            Console.Write(
                instance.Generate(
                    MainNamespaceName, 
                    SubNamespace, 
                    ClassNameInheriting, 
                    ClassRemarks, 
                    this.propertiesInheriting, 
                    ClassNameDefaultBase, 
                    this.propertiesDefault));
        }

        /// <summary>
        /// The test information main namespace name null.
        /// </summary>
        [TestMethod]
        public void TestInformationMainNamespaceNameNull()
        {
            var instance = new Dhgms.Nucleotide.Model.Helper.Information();

            try
            {
                instance.Generate(
                    null, SubNamespace, ClassNameDefaultBase, ClassRemarks, this.propertiesDefault, null, null);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("mainNamespaceName", e.ParamName);
                return;
            }

            Assert.Fail("Expected System.NullReferenceException");
        }

        /// <summary>
        /// The test information no base should succeed.
        /// </summary>
        [TestMethod]
        public void TestInformationNoBaseListsShouldSucceed()
        {
            var instance = new Dhgms.Nucleotide.Model.Helper.Information();
            Console.Write(
                instance.Generate(
                    MainNamespaceName, 
                    SubNamespace, 
                    ClassNameDefaultBase, 
                    ClassRemarks, 
                    this.propertiesLists, 
                    null, 
                    null));
        }

        /// <summary>
        /// The test information no base no sub namespace should succeed.
        /// </summary>
        [TestMethod]
        public void TestInformationNoBaseNoSubNamespaceShouldSucceed()
        {
            var instance = new Dhgms.Nucleotide.Model.Helper.Information();
            Console.Write(
                instance.Generate(
                    MainNamespaceName, null, ClassNameDefaultBase, ClassRemarks, this.propertiesDefault, null, null));
        }

        /// <summary>
        /// The test information no base should succeed.
        /// </summary>
        [TestMethod]
        public void TestInformationNoBaseShouldSucceed()
        {
            var instance = new Dhgms.Nucleotide.Model.Helper.Information();
            Console.Write(
                instance.Generate(
                    MainNamespaceName, 
                    SubNamespace, 
                    ClassNameDefaultBase, 
                    ClassRemarks, 
                    this.propertiesDefault, 
                    null, 
                    null));
        }

        /// <summary>
        /// The test information properties null.
        /// </summary>
        [TestMethod]
        public void TestInformationPropertiesNull()
        {
            var instance = new Dhgms.Nucleotide.Model.Helper.Information();

            try
            {
                instance.Generate(MainNamespaceName, SubNamespace, ClassNameDefaultBase, ClassRemarks, null, null, null);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("properties", e.ParamName);
                return;
            }

            Assert.Fail("Expected System.ArgumentNullException");
        }
         * */

        #endregion
    }
}