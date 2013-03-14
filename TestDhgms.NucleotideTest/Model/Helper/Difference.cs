// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Difference.cs" company="DHGMS Solutions">
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
    /// The difference.
    /// </summary>
    [TestClass]
    public class Difference
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
        private const string ClassRemarks = "Unit test for Difference class code generation";

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
                new ClrBoolean(CollectionType.None, "BooleanItem", "A Boolean Item", false, false, null), 
                new ClrDateTime(CollectionType.None, "DateTimeItem", "A DateTime Item", false, null, null, false, null)
            };

        /// <summary>
        /// The properties inheriting.
        /// </summary>
        private readonly Base[] propertiesInheriting = new Base[]
            {
                new ClrBoolean(CollectionType.None, "BooleanNullableItem", "A Boolean Item", true, false, null), 
                new ClrDateTime(CollectionType.None, "DateTimeNullableItem", "A DateTime Item", true, null, null, false, null)
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
        /// The test difference all arguments null.
        /// </summary>
        [TestMethod]
        public void TestDifferenceAllArgumentsNull()
        {
            var instance = new Dhgms.Nucleotide.Model.Helper.Difference();

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
        /// The test difference class name null.
        /// </summary>
        [TestMethod]
        public void TestDifferenceClassNameNull()
        {
            var instance = new Dhgms.Nucleotide.Model.Helper.Difference();

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
        /// The test difference class remarks null.
        /// </summary>
        [TestMethod]
        public void TestDifferenceClassRemarksNull()
        {
            var instance = new Dhgms.Nucleotide.Model.Helper.Difference();

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
        /// The test difference inheriting should succeed.
        /// </summary>
        [TestMethod]
        public void TestDifferenceInheritingShouldSucceed()
        {
            var instance = new Dhgms.Nucleotide.Model.Helper.Difference();
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
        /// The test difference main namespace name null.
        /// </summary>
        [TestMethod]
        public void TestDifferenceMainNamespaceNameNull()
        {
            var instance = new Dhgms.Nucleotide.Model.Helper.Difference();

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
        /// The test difference no base should succeed.
        /// </summary>
        [TestMethod]
        public void TestDifferenceNoBaseShouldSucceed()
        {
            var instance = new Dhgms.Nucleotide.Model.Helper.Difference();
            instance.Generate(
                MainNamespaceName, SubNamespace, ClassNameDefaultBase, ClassRemarks, this.propertiesDefault, null, null);
        }

        /// <summary>
        /// The test difference properties null.
        /// </summary>
        [TestMethod]
        public void TestDifferencePropertiesNull()
        {
            var instance = new Dhgms.Nucleotide.Model.Helper.Difference();

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