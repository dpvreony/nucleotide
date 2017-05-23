// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProviderProxy.cs" company="DHGMS Solutions">
//   Licensed under GNU General Public License version 2 (GPLv2)
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Dhgms.Nucleotide.Tests.Model.Info
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using Xunit;

    /// <summary>
    /// Test units for Provider Proxy
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ProviderProxyTests
    {
        #region Public Methods and Operators

        /// <summary>
        /// Method checks to see if unit tests can take place
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public ProviderProxyTests()
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
        [Fact]
        public void TestConstructor()
        {
            const string Name = "ProviderProxyName";
            const string InfoClass = "Namespace1.Namespace2.ClassName";
            var instance = new Dhgms.Nucleotide.Model.ProviderProxy(Name, InfoClass);

            Assert.Equal(Name, instance.Name);
            Assert.Equal(InfoClass, instance.InfoClass);
        }

        /// <summary>
        /// Tests where only the info class is set
        /// </summary>
        [Fact]
        public void TestInfoClassProperty()
        {
            const string InfoClass = "Namespace1.Namespace2.ClassName";
            var instance = new Dhgms.Nucleotide.Model.ProviderProxy(null, null);

            Assert.Null(instance.Name);
            Assert.Null(instance.InfoClass);

            instance.InfoClass = InfoClass;
            Assert.Equal(InfoClass, instance.InfoClass);
            Assert.Null(instance.Name);
        }

        /// <summary>
        /// Tests where only the name is set
        /// </summary>
        [Fact]
        public void TestNameProperty()
        {
            const string Name = "ProviderProxyName";
            var instance = new Dhgms.Nucleotide.Model.ProviderProxy(null, null);

            Assert.Null(instance.Name);
            Assert.Null(instance.InfoClass);

            instance.Name = Name;
            Assert.Equal(Name, instance.Name);
            Assert.Null(instance.InfoClass);
        }

        #endregion
    }
}