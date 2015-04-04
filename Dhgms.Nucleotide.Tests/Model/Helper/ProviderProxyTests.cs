// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProviderProxy.cs" company="DHGMS Solutions">
//   Licensed under GNU General Public License version 2 (GPLv2)
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Dhgms.Nucleotide.Tests.Model.Helper
{
    using System;

    using Xunit;

    /// <summary>
    /// The provider proxy.
    /// </summary>
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
        /// The test provider proxy should succeed.
        /// </summary>
        [Fact]
        public void TestProviderProxyNoProjectName()
        {
            Dhgms.Nucleotide.Model.ProviderProxy[] objectNames =
            {
                new Dhgms.Nucleotide.Model.ProviderProxy("Name", "InfoClass")
            };

            var ex =
                Assert.Throws<ArgumentNullException>(
                    () => Dhgms.Nucleotide.Helper.ProviderProxy.Generate(null, objectNames));

            Assert.Equal("projectName", ex.ParamName);
        }

        /// <summary>
        /// The test provider proxy should succeed.
        /// </summary>
        [Fact]
        public void TestProviderProxyNoObjectNames()
        {
            var ex  = Assert.Throws<ArgumentNullException>(
                () => Dhgms.Nucleotide.Helper.ProviderProxy.Generate("ProjectName", null));

            Assert.Equal("objectNames", ex.ParamName);
        }

        /// <summary>
        /// The test provider proxy should succeed.
        /// </summary>
        [Fact]
        public void TestProviderProxyShouldSucceed()
        {
            Dhgms.Nucleotide.Model.ProviderProxy[] objectNames =
            {
                new Dhgms.Nucleotide.Model.ProviderProxy("Name", "InfoClass")
            };

            var result = Dhgms.Nucleotide.Helper.ProviderProxy.Generate("ProjectName", objectNames);

            Assert.True(!string.IsNullOrWhiteSpace(result));
        }

        #endregion
    }
}