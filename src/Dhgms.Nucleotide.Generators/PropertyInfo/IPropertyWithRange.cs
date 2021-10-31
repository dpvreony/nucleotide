namespace Dhgms.Nucleotide.Generators.PropertyInfo
{
    public interface IPropertyWithRange<out T> : IPropertyWithRangeAsString
    {
        T? MaximumValue { get; }

        T? MinimumValue { get; }
    }
}
