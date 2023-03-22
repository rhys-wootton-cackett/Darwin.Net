using DarwinNet.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DarwinNet.Exceptions
{
    /// <summary>
    /// The exception that is thrown when a CRS StringValue is not attached to a Station enumeration value.
    /// </summary>
    public class StationCrsNullException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StationCrsNullException"/> class with a specified Station enumeration value.
        /// </summary>
        /// <param name="station">The Station enumeration value that does not have a CRS StringValue.</param>
        public StationCrsNullException(Station station) : base($"Station.{Enum.GetName(typeof(Station), station)} does not have a CRS StringValue attached to it. Please contact the developer of DarwinNet.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StationCrsNullException"/> class with a nullable Station enumeration value.
        /// </summary>
        /// <param name="station">The nullable Station enumeration value that does not have a CRS StringValue.</param>
        public StationCrsNullException(Station? station) : base($"Station.{Enum.GetName(typeof(Station), station)} does not have a CRS StringValue attached to it. Please contact the developer of DarwinNet.")
        {
        }
    }
}
