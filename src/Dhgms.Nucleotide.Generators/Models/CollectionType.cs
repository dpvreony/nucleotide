// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace Dhgms.Nucleotide.Generators.Models
{
    /// <summary>
    /// The type of collection the property uses, if any
    /// </summary>
    public enum CollectionType
    {
        /// <summary>
        /// A collection isn't used
        /// </summary>
        None, 

        /// <summary>
        /// A generic list is used
        /// </summary>
        GenericList, 

        /// <summary>
        /// A generic linked list is used
        /// </summary>
        GenericLinkedList,

        /// <summary>
        /// An array is used
        /// </summary>
        Array
}
}