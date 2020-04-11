// -----------------------------------------------------------------------
// <copyright file="EntityGenerationModel.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using Dhgms.Nucleotide.Models;

namespace Dhgms.Nucleotide.Model
{
    using Dhgms.Nucleotide.PropertyInfo;

    /// <summary>
    /// Represents the parameters for generating an data manager classes
    /// </summary>
    public abstract class EntityGenerationModel : IEntityGenerationModel
    {
        /// <summary>
        /// Gets the main namespace.
        /// </summary>
        public abstract string MainNamespaceName { get; }

        /// <summary>
        /// Gets the sub namespace, if any
        /// </summary>
        public abstract string SubNamespace { get; }

        /// <summary>
        /// Gets the name of the information class.
        /// </summary>
        public abstract string ClassName { get; }

        public abstract KeyType KeyType { get; }

        public abstract IEntityGenerationModel BaseTypeEntityGenerationModel { get; }
        public abstract IInterfaceGenerationModel[] InterfaceGenerationModels { get; }

        /// <summary>
        /// Gets the name of the information class.
        /// </summary>
        public abstract string ClassRemarks { get; }

        /// <summary>
        /// Gets the collection of properties for the class.
        /// </summary>
        public abstract PropertyInfoBase[] Properties { get; }
    }
}
