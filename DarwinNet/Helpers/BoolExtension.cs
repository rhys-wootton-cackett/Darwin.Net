using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DarwinNet.Helpers
{
    internal static class BoolExtension
    {
        public static bool? TryParseBoolNullable(this string input)
        {
            if (input == null)
            {
                return null;
            }

            if (bool.TryParse(input, out bool result))
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
