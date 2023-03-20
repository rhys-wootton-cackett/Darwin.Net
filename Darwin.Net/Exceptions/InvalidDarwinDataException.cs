using Darwin.Net.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darwin.Net.Exceptions
{
    /// <summary>
    /// The exception that is thrown when an invalid value is encountered in a Darwin response.
    /// </summary>
    public class InvalidDarwinDataException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidDarwinDataException"/> class with a specified parameter.
        /// </summary>
        /// <param name="param">The name of the parameter that contains an invalid value.</param>
        public InvalidDarwinDataException(string param) : base($"{param} does not have a valid value in the Darwin response. Please contact the developer of Darwin.Net.")
        {
        }
    }

}
