// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchFilter.cs" company="DHGMS Solutions">
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
    /// The search filter.
    /// </summary>
    [TestClass]
    public class SearchFilter
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
        private const string ClassRemarks = "Unit test for SearchFilter class code generation";

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
               new ClrBoolean(CollectionType.None, "BooleanItem", "A Boolean Item", false, false, null) 
            };

        /// <summary>
        /// The properties inheriting.
        /// </summary>
        private readonly Base[] propertiesInheriting = new Base[]
            {
               new ClrBoolean(CollectionType.None, "BooleanNullableItem", "A Boolean Item", true, false, null) 
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
        /// The test search filter all arguments null.
        /// </summary>
        [TestMethod]
        public void TestSearchFilterAllArgumentsNull()
        {
            var instance = new Dhgms.Nucleotide.Model.Helper.SearchFilter();

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
        /// The test search filter class name null.
        /// </summary>
        [TestMethod]
        public void TestSearchFilterClassNameNull()
        {
            var instance = new Dhgms.Nucleotide.Model.Helper.SearchFilter();

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
        /// The test search filter class remarks null.
        /// </summary>
        [TestMethod]
        public void TestSearchFilterClassRemarksNull()
        {
            var instance = new Dhgms.Nucleotide.Model.Helper.SearchFilter();

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
        /// The test search filter inheriting should succeed.
        /// </summary>
        [TestMethod]
        public void TestSearchFilterInheritingShouldSucceed()
        {
            var instance = new Dhgms.Nucleotide.Model.Helper.SearchFilter();
            instance.Generate(
                MainNamespaceName, 
                SubNamespace, 
                ClassNameInheriting, 
                ClassRemarks, 
                this.propertiesInheriting, 
                ClassNameDefaultBase, 
                this.propertiesDefault);
        }

        /// <summary>
        /// The test search filter main namespace name null.
        /// </summary>
        [TestMethod]
        public void TestSearchFilterMainNamespaceNameNull()
        {
            var instance = new Dhgms.Nucleotide.Model.Helper.SearchFilter();

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
        /// The test search filter no base should succeed.
        /// </summary>
        [TestMethod]
        public void TestSearchFilterNoBaseShouldSucceed()
        {
            var instance = new Dhgms.Nucleotide.Model.Helper.SearchFilter();
            instance.Generate(
                MainNamespaceName, SubNamespace, ClassNameDefaultBase, ClassRemarks, this.propertiesDefault, null, null);
        }

        /// <summary>
        /// The test search filter properties null.
        /// </summary>
        [TestMethod]
        public void TestSearchFilterPropertiesNull()
        {
            var instance = new Dhgms.Nucleotide.Model.Helper.SearchFilter();

            try
            {
                instance.Generate(MainNamespaceName, SubNamespace, ClassNameDefaultBase, ClassRemarks, null, null, null);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("properties", e.ParamName);
                return;
            }

            Assert.Fail("Expected System.NullReferenceException");
        }

        #endregion
    }
}