// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProviderProxy.cs" company="DHGMS Solutions">
//   Licensed under GNU General Public License version 2 (GPLv2)
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace TestDhgms.NucleotideTest.Model.Helper
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The provider proxy.
    /// </summary>
    [TestClass]
    public class ProviderProxy
    {
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
        /// The test provider proxy should succeed.
        /// </summary>
        [TestMethod]
        public void TestProviderProxyNoProjectName()
        {
            Dhgms.Nucleotide.Model.Info.ProviderProxy[] objectNames =
            {
                new Dhgms.Nucleotide.Model.Info.ProviderProxy("Name", "InfoClass")
            };

            try
            {
                Dhgms.Nucleotide.Helper.ProviderProxy.Generate(null, objectNames);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("projectName", e.ParamName);
                return;
            }

            Assert.Fail("Expected System.ArgumentNullException");
        }

        /// <summary>
        /// The test provider proxy should succeed.
        /// </summary>
        [TestMethod]
        public void TestProviderProxyNoObjectNames()
        {
            try
            {
                Dhgms.Nucleotide.Helper.ProviderProxy.Generate("ProjectName", null);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("objectNames", e.ParamName);
                return;
            }

            Assert.Fail("Expected System.ArgumentNullException");
        }

        /// <summary>
        /// The test provider proxy should succeed.
        /// </summary>
        [TestMethod]
        public void TestProviderProxyShouldSucceed()
        {
            Dhgms.Nucleotide.Model.Info.ProviderProxy[] objectNames =
            {
                new Dhgms.Nucleotide.Model.Info.ProviderProxy("Name", "InfoClass")
            };

            Dhgms.Nucleotide.Helper.ProviderProxy.Generate("ProjectName", objectNames);
        }

        #endregion
    }
}