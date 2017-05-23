// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProviderProxy.cs" company="DHGMS Solutions">
//   Licensed under GNU General Public License version 2 (GPLv2)
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace TestDhgms.NucleotideTest.Model.Info
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test units for Provider Proxy
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
        /// Tests where the name and infoclass are both set
        /// </summary>
        [TestMethod]
        public void TestConstructor()
        {
            const string Name = "ProviderProxyName";
            const string InfoClass = "Namespace1.Namespace2.ClassName";
            var instance = new Dhgms.Nucleotide.Model.Info.ProviderProxy(Name, InfoClass);

            Assert.AreEqual(Name, instance.Name);
            Assert.AreEqual(InfoClass, instance.InfoClass);
        }

        /// <summary>
        /// Tests where only the info class is set
        /// </summary>
        [TestMethod]
        public void TestInfoClassProperty()
        {
            const string InfoClass = "Namespace1.Namespace2.ClassName";
            var instance = new Dhgms.Nucleotide.Model.Info.ProviderProxy(null, null);

            Assert.IsNull(instance.Name);
            Assert.IsNull(instance.InfoClass);

            instance.InfoClass = InfoClass;
            Assert.AreEqual(InfoClass, instance.InfoClass);
            Assert.IsNull(instance.Name);
        }

        /// <summary>
        /// Tests where only the name is set
        /// </summary>
        [TestMethod]
        public void TestNameProperty()
        {
            const string Name = "ProviderProxyName";
            var instance = new Dhgms.Nucleotide.Model.Info.ProviderProxy(null, null);

            Assert.IsNull(instance.Name);
            Assert.IsNull(instance.InfoClass);

            instance.Name = Name;
            Assert.AreEqual(Name, instance.Name);
            Assert.IsNull(instance.InfoClass);
        }

        #endregion
    }
}