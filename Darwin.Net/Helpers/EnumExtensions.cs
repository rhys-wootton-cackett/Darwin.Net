using Darwin.Net.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Darwin.Net.Helpers
{
    internal static class EnumExtensions
    {
        public static string? GetStringValue(this Enum value)
        {
            Type type = value.GetType();
            FieldInfo? fieldInfo = type.GetField(value.ToString());
            StringValueAttribute[]? attribs = fieldInfo?.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];

            // Return the first if there was a match.
            return attribs?.Length > 0 ? attribs[0].StringValue : null;
        }

        public static T GetEnumFromStringValue<T>(this string stringValue) where T : Enum
        {
            var matchingEnumValues = Enum.GetValues(typeof(T))
            .Cast<T>()
            .Where(enumValue => {
                var stringValueAttribute = enumValue.GetType()
                    .GetField(enumValue.ToString())
                    .GetCustomAttributes(typeof(StringValueAttribute), false)
                    .SingleOrDefault() as StringValueAttribute;

                return stringValueAttribute != null && stringValueAttribute.StringValue.Equals(stringValue, StringComparison.OrdinalIgnoreCase);
            });

            if (matchingEnumValues.ToList().Count >= 1) return matchingEnumValues.First();
            else throw new ArgumentException($"Enum value not found for string value '{stringValue}'");
        }
    }
}
