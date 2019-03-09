namespace GOoDcast.Miscellaneous
{
    using System;
    using System.Drawing;


    /// <summary>
    /// Helper for <see cref="Color"/> class
    /// </summary>
    public static class ColorHelper
    {
        /// <summary>
        /// Converts a string to a <see cref="Color"/>
        /// </summary>
        /// <param name="color">color string to convert</param>
        /// <returns>the color object</returns>
        public static Color FromHexString(string color)
        {
            return Color.FromArgb(
                 Convert.ToInt32(color.Substring(7, 2), 16),
                 Convert.ToInt32(color.Substring(1, 2), 16),
                 Convert.ToInt32(color.Substring(3, 2), 16),
                 Convert.ToInt32(color.Substring(5, 2), 16));
        }

        /// <summary>
        /// Converts a string to a nullable <see cref="Color"/>
        /// </summary>
        /// <param name="color">color string to convert</param>
        /// <returns>the nullable color object</returns>
        public static Color? FromNullableHexString(string color)
        {
            return string.IsNullOrEmpty(color) ? (Color?) null : FromHexString(color);
        }

        /// <summary>
        /// Converts a color to an hexadecimal string (#RRGGBBAA)
        /// </summary>
        /// <param name="color">color to convert</param>
        /// <returns>the hexadecimal string</returns>
        public static string ToHexString(this Color color)
        {
            return $"#{color.R:X2}{color.G:X2}{color.B:X2}{color.A:X2}";
        }

        /// <summary>
        /// Converts a nullable color to an hexadecimal string (#RRGGBBAA)
        /// </summary>
        /// <param name="color">nullable color to convert</param>
        /// <returns>the hexadecimal string</returns>
        public static string ToHexString(this Color? color)
        {
            return color?.ToHexString();
        }
    }
}
