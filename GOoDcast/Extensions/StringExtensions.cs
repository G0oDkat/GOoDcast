namespace GOoDcast.Extensions
{
    using System.Text;

    /// <summary>
    ///     Extensions methods for <see cref="string" />
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///     Converts a camel case string to underscore notation
        /// </summary>
        /// <param name="value">string to convert</param>
        /// <returns>the converted string to underscore notation</returns>
        public static string ToUnderscoreUpperInvariant(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;

            var stringBuilder = new StringBuilder();
            bool first = true;
            foreach (char c in value)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    if (char.IsUpper(c))
                    {
                        stringBuilder.AppendFormat("_{0}", c);
                        continue;
                    }
                }

                stringBuilder.Append(char.ToUpperInvariant(c));
            }

            return stringBuilder.ToString();
        }

        public static string ToUnderscoreLowerInvariant(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;

            var stringBuilder = new StringBuilder();
            bool first = true;
            foreach (char c in value)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    if (char.IsUpper(c))
                    {
                        stringBuilder.AppendFormat("_{0}", char.ToLowerInvariant(c));
                        continue;
                    }
                }

                stringBuilder.Append(char.ToLowerInvariant(c));
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        ///     Converts a string to camel case notation
        /// </summary>
        /// <param name="value">string to convert</param>
        /// <returns>camel case notation</returns>
        public static string ToCamelCase(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;

            var stringBuilder = new StringBuilder();
            bool underscore = true;
            foreach (char c in value)
                if (underscore)
                {
                    underscore = false;
                    stringBuilder.Append(char.ToUpperInvariant(c));
                }
                else
                {
                    if (c == '_')
                        underscore = true;
                    else
                        stringBuilder.Append(char.ToLowerInvariant(c));
                }

            ;
            return stringBuilder.ToString();
        }
    }
}