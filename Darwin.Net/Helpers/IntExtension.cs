using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darwin.Net.Helpers
{
    internal static class IntExtension
    {
        public static int? TryParseIntNullable(this string input)
        {
            if (input == null)
            {
                return null;
            }

            if (int.TryParse(input, out int result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
