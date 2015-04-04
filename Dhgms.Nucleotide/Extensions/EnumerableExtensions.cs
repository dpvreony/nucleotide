namespace Dhgms.Nucleotide.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// LINQ Extensions for the Enumerable classes
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Take items from a list which suit a predicate
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TSource> Take<TSource>(this IList<TSource> instance, Func<TSource, bool> predicate)
        {
            Contract.Requires<ArgumentNullException>(instance != null);
            Contract.Requires<ArgumentNullException>(predicate != null);

            var result = new List<TSource>();

            var position = 0;
            while (position < instance.Count)
            {
                var item = instance[position];
                if (predicate(item))
                {
                    result.Add(item);
                    instance.Remove(item);
                }
                else
                {
                    position++;
                }
            }

            return result;
        }
    }
}
