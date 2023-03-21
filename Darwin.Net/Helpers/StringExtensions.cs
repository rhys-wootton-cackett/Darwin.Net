using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Darwin.Net.Helpers
{
    internal static partial class StringExtensions
    {
        /// <summary>
        /// Removes HTML tags and newlines, and adds appropriate punctuation.
        /// </summary>
        /// <param name="input">The string to process.</param>
        /// <returns>The processed string.</returns>
        public static string CleanHtml(this string input)
        {
            // Remove HTML tags
            string output = Regex.Replace(input, "<.*?>", string.Empty);

            // Remove new lines
            output = output.Replace("\n", string.Empty).Replace("\r", string.Empty);

            // Remove extra spaces
            output = Regex.Replace(output, "\\s+", " ");

            // Add full stops after sentences if they are missing
            if (output.EndsWith(" "))
            {
                output = output.TrimEnd();
            }
            else if (!output.EndsWith("."))
            {
                output += ".";
            }

            // Remove any trailing spaces
            output = output.Trim();

            return output;
        }

        /// <summary>
        /// Parses a Darwin time value from the specified string.
        /// </summary>
        /// <param name="value">The string value to parse.</param>
        /// <returns>A tuple containing the parsed string value and the parsed <see cref="DateTime"/> value.</returns>
        public static (string? Text, DateTime? Time) ParseDarwinTime(this string value)
        {
            if (DateTime.TryParse(value, out var date))
                return (null, date);

            return (value, null);
        }
    }
}
