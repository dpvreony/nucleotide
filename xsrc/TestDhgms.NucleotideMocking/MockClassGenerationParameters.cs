// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockClassGenerationParameters.cs" company="">
//   
// </copyright>
// <summary>
//   The mock class generation parameters.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TestDhgms.NucleotideMocking
{
    using System.Diagnostics.CodeAnalysis;

    using Dhgms.Nucleotide.Model;
    using Dhgms.Nucleotide.PropertyInfo;

    /// <summary>
    /// The mock class generation parameters.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class MockClassGenerationParameters : IClassGenerationParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MockClassGenerationParameters"/> class.
        /// </summary>
        /// <param name="mainNamespaceName">
        /// The main namespace name.
        /// </param>
        /// <param name="subNamespace">
        /// The sub namespace.
        /// </param>
        /// <param name="className">
        /// The class name.
        /// </param>
        /// <param name="properties">
        /// The properties.
        /// </param>
        /// <param name="baseClassProperties">
        /// The base class properties.
        /// </param>
        /// <param name="companyName">
        /// The company name.
        /// </param>
        /// <param name="copyrightBanner">
        /// The copyright banner.
        /// </param>
        /// <param name="copyrightStartYear">
        /// The copyright start year.
        /// </param>
        /// <param name="baseClassName">
        /// The base class name.
        /// </param>
        /// <param name="classRemarks">
        /// The class remarks.
        /// </param>
        public MockClassGenerationParameters(string mainNamespaceName, string subNamespace, string className, PropertyInfoBase[] properties, PropertyInfoBase[] baseClassProperties, string companyName, string[] copyrightBanner, int copyrightStartYear, string baseClassName, string classRemarks)
        {
            this.MainNamespaceName = mainNamespaceName;
            this.SubNamespace = subNamespace;
            this.ClassName = className;
            this.Properties = properties;
            this.BaseClassProperties = baseClassProperties;
            this.CompanyName = companyName;
            this.CopyrightBanner = copyrightBanner;
            this.CopyrightStartYear = copyrightStartYear;
            this.BaseClassName = baseClassName;
            this.ClassRemarks = classRemarks;
        }

        /// <summary>
        /// Gets the main namespace.
        /// </summary>
        public string MainNamespaceName
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the sub namespace, if any
        /// </summary>
        public string SubNamespace
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets name of the information class.
        /// </summary>
        public string ClassName
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the collection of properties for the class.
        /// </summary>
        public PropertyInfoBase[] Properties
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the collection of properties for the inherited base class, if any.
        /// </summary>
        public PropertyInfoBase[] BaseClassProperties
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the company name.
        /// </summary>
        public string CompanyName
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the copyright banner.
        /// </summary>
        public string[] CopyrightBanner
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the copyright start year.
        /// </summary>
        public int CopyrightStartYear
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets name of the base information class.
        /// </summary>
        public string BaseClassName
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the class remarks.
        /// </summary>
        public string ClassRemarks
        {
            get;
            private set;
        }
    }
}
