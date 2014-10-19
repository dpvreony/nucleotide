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
    using Dhgms.Nucleotide.Model.Info;
    using Dhgms.Nucleotide.Model.Info.PropertyInfo;

    /// <summary>
    /// The mock class generation parameters.
    /// </summary>
    public sealed class MockClassGenerationParameters : ClassGenerationParameters
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
        public MockClassGenerationParameters(string mainNamespaceName, string subNamespace, string className, Base[] properties, Base[] baseClassProperties, string companyName, string[] copyrightBanner, int copyrightStartYear, string baseClassName, string classRemarks)
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
        public override string MainNamespaceName
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the sub namespace, if any
        /// </summary>
        public override string SubNamespace
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets name of the information class.
        /// </summary>
        public override string ClassName
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the collection of properties for the class.
        /// </summary>
        public override Base[] Properties
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the collection of properties for the inherited base class, if any.
        /// </summary>
        public override Base[] BaseClassProperties
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the company name.
        /// </summary>
        public override string CompanyName
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the copyright banner.
        /// </summary>
        public override string[] CopyrightBanner
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the copyright start year.
        /// </summary>
        public override int CopyrightStartYear
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets name of the base information class.
        /// </summary>
        public override string BaseClassName
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets name of the information class.
        /// </summary>
        public override string ClassRemarks
        {
            get;
            protected set;
        }
    }
}
