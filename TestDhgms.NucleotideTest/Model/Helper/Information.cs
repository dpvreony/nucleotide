// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Information.cs" company="DHGMS Solutions">
//   Licensed under GNU General Public License version 2 (GPLv2)
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace TestDhgms.NucleotideTest.Model.Helper
{
    using System;

    using Dhgms.Nucleotide.Model.Info;
    using Dhgms.Nucleotide.Model.Info.PropertyInfo;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The information.
    /// </summary>
    [TestClass]
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
                    false, null)
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
        private readonly Base[] propertiesLists = new Base[]
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

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Method checks to see if unit tests can take place
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        [ClassInitialize]
        public static void ClassInit(TestContext context)
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

        /// <summary>
        /// The test information all arguments null.
        /// </summary>
        [TestMethod]
        public void TestInformationAllArgumentsNull()
        {
            var instance = new Dhgms.Nucleotide.Model.Helper.Information();

            try
            {
                instance.Generate(null, null, null, null, null, null, null);
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

        #endregion
    }
}