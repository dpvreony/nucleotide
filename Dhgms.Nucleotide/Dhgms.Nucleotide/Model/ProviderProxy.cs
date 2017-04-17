// --------------------------------------------------------------------------------------------------------------------
// <copyright company="DHGMS Solutions" file="ProviderProxy.cs">
//   Licensed under GNU General Public License version 2 (GPLv2)
// </copyright>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace Dhgms.Nucleotide.Model
{
    /// <summary>
    /// Provider Proxy Information Class
    /// </summary>
    public class ProviderProxy
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderProxy"/> class. 
        /// Constructor
        /// </summary>
        /// <param name="name">
        /// Name of the provider proxy class
        /// </param>
        /// <param name="infoClass">
        /// The information class the provider proxy relates to
        /// </param>
        public ProviderProxy(string name, string infoClass)
        {
            this.Name = name;
            this.InfoClass = infoClass;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets The information class the provider proxy relates to
        /// </summary>
        public string InfoClass { get; set; }

        /// <summary>
        /// Gets or sets Name of the provider proxy class
        /// </summary>
        public string Name { get; set; }

        #endregion
    }
}