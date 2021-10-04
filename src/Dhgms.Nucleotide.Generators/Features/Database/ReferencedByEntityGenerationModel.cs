using Dhgms.Nucleotide.Generators.GeneratorProcessors;

namespace Dhgms.Nucleotide.Generators.Features.Database
{
    /// <summary>
    /// Generation Model for a One to Many Relationship
    /// </summary>
    public sealed class ReferencedByEntityGenerationModel : IClassName
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="namespaceForInterface">The namespace the interface will be located in.</param>
        /// <param name="entityName">The name of the entity.</param>
        /// <param name="entityType">The type for the entity</param>
        /// <param name="propertyName">The name of the navigation property</param>
        /// <param name="keyType">The type for the foreign key.</param>
        public ReferencedByEntityGenerationModel(
            string namespaceForInterface,
            string entityName,
            string entityType,
            string propertyName,
            string keyType)
        {
            NamespaceForInterface = namespaceForInterface;
            ClassName = entityName;
            EntityType = entityType;
            PropertyName = propertyName;
            KeyType = keyType;
        }

        /// <summary>
        /// Gets the namespace the interface will be located in.
        /// </summary>
        public string NamespaceForInterface { get; }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        public string ClassName { get; }

        /// <summary>
        /// Gets the type for the entity.
        /// </summary>
        public string EntityType { get; }

        /// <summary>
        /// Gets the name of the navigation property.
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        /// Gets the type for the foreign key.
        /// </summary>
        public string KeyType { get; }
    }
}
