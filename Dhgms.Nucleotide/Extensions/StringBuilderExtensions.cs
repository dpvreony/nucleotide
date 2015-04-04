namespace Dhgms.Nucleotide.Extensions
{
    using System.Text;

    /// <summary>
    /// String Builder Extensions
    /// </summary>
    public static class StringBuilderExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void AppendLine(this StringBuilder instance, string format, params object[] args)
        {
            var s = string.Format(format, args);
            instance.AppendLine(s);
        }
    }
}
