namespace Dhgms.Nucleotide.Tests.Model.Helper
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The test base.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class TestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestBase"/> class.
        /// </summary>
        /// <exception cref="Exception">
        /// Library 
        /// </exception>
        public TestBase()
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
                throw new BadImageFormatException("Library is installed in the GAC.  Uninstall before performing unit tests.");
            }
        }
    }
}
