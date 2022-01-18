// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

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
            string singularPropertyName,
            string pluralPropertyName,
            string keyType)
        {
            NamespaceForInterface = namespaceForInterface;
            ClassName = entityName;
            EntityType = entityType;
            SingularPropertyName = singularPropertyName;
            PluralPropertyName = pluralPropertyName;
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
        /// Gets the singular name of the navigation property.
        /// </summary>
        public string SingularPropertyName { get; }

        /// <summary>
        /// Gets the plural name of the navigation property.
        /// </summary>
        public string PluralPropertyName { get; }

        /// <summary>
        /// Gets the type for the foreign key.
        /// </summary>
        public string KeyType { get; }
    }
}
