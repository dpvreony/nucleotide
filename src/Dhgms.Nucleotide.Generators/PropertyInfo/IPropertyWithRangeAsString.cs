namespace Dhgms.Nucleotide.Generators.PropertyInfo
{
    /// <summary>
    /// This represents a property with range, but allows extracting it for code generation as strings.
    /// This has been done like this because having the code can't use an unbound generic, the language
    /// doesn't support it, and it would probably be a headache to consume anyway.
    /// </summary>
    public interface IPropertyWithRangeAsString
    {
        string MaximumValueAsString { get; }

        string MinimumValueAsString { get; }
    }
}