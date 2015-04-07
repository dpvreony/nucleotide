// --------------------------------------------------------------------------------------------------------------------
// <copyright company="DHGMS Solutions" file="CollectionType.cs">
//   Licensed under GNU General Public License version 2 (GPLv2)
// </copyright>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace Dhgms.Nucleotide.Model
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