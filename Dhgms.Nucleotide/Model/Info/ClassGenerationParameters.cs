// -----------------------------------------------------------------------
// <copyright file="ClassGenerationParameters.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Dhgms.Nucleotide.Model.Info
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Dhgms.Nucleotide.PropertyInfo;

    /// <summary>
    /// Represents the parameters for generating an data manager classes
    /// </summary>
    public abstract class ClassGenerationParameters : IClassGenerationParameters
    {
        /// <summary>
        /// Gets or sets the main namespace.
        /// </summary>
        public abstract string MainNamespaceName { get; protected set; }

        /// <summary>
        /// Gets or sets the sub namespace, if any
        /// </summary>
        public abstract string SubNamespace { get; protected set; }

        /// <summary>
        /// Gets or sets name of the information class.
        /// </summary>
        public abstract string ClassName { get; protected set; }

        /// <summary>
        /// Gets or sets name of the information class.
        /// </summary>
        public abstract string ClassRemarks { get; protected set; }

        /// <summary>
        /// Gets or sets the collection of properties for the class.
        /// </summary>
        public abstract Base[] Properties { get; protected set; }

        /// <summary>
        /// Gets or sets the collection of properties for the inherited base class, if any.
        /// </summary>
        public abstract Base[] BaseClassProperties { get; protected set; }

        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        public abstract string CompanyName { get; protected set; }

        /// <summary>
        /// Gets or sets the copyright banner.
        /// </summary>
        public abstract string[] CopyrightBanner { get; protected set; }

        /// <summary>
        /// Gets or sets the copyright start year.
        /// </summary>
        public abstract int CopyrightStartYear { get; protected set; }

        /// <summary>
        /// Gets or sets name of the base information class.
        /// </summary>
        public abstract string BaseClassName { get; protected set; }
    }
}
