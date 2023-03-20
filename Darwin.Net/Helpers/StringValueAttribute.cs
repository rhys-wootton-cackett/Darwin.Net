using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darwin.Net.Helpers
{
    /// <summary>
    /// Provides an attribute that allows you to store a string value with an enum value.
    /// </summary>
    internal class StringValueAttribute : Attribute
    {
        /// <summary>
        /// Gets the string value associated with the enum value
        /// </summary>
        public string StringValue { get; internal set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringValueAttribute"/> class.
        /// </summary>
        /// <param name="stringValue">The string value you wish to store with the enum value</param>
        public StringValueAttribute(string stringValue)
        {
            StringValue = stringValue;
        }
    }
}
