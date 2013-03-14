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

    using Dhgms.Nucleotide.Model.Info.Interface;
    using Dhgms.Nucleotide.Model.Info.PropertyInfo;

    /// <summary>
    /// Represents the parameters for generating an data manager classes
    /// </summary>
    public class ClassGenerationParameters : IClassGenerationParameters
    {
        /// <summary>
        /// Gets or sets the main namespace
        /// </summary>
        public string MainNamespaceName { get; set; }

        /// <summary>
        /// Gets or sets the sub namespace, if any
        /// </summary>
        public string SubNamespace { get; set; }

        /// <summary>
        /// Gets or sets name of the information class.
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// Gets or sets collection of properties for the class.
        /// </summary>
        public Base[] Properties { get; set; }

        /// <summary>
        /// Gets or sets collection of properties for the inherited base class, if any.
        /// </summary>
        public Base[] BaseClassProperties { get; set; }
    }
}
