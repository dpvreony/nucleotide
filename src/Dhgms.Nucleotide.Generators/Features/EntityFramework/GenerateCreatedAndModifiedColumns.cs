namespace Dhgms.Nucleotide.Generators.Features.EntityFramework
{
    /// <summary>
    /// Enum to dictate whether to generate created and modified columns on a DBSet.
    /// </summary>
    public enum GenerateCreatedAndModifiedColumns
    {
        /// <summary>
        /// Don't generate either column.
        /// </summary>
        None,

        /// <summary>
        /// Generate only the created column.
        /// </summary>
        CreatedOnly,

        /// <summary>
        /// Generate both the created and modified columns.
        /// </summary>
        CreatedAndModified
    }
}
