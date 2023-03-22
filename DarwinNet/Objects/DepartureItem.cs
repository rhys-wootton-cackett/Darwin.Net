using DarwinNet.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DarwinNet.Objects
{
    /// <summary>
    /// Defines a departure item for a train
    /// </summary>
    [DebuggerDisplay("{Station,nq} - Services: {Services.Count,nq}")]
    public class DepartureItem
    {

        /// <summary>
        /// The station that the <see cref="DepartureItem"/> represents
        /// </summary>
        public Station Station { get; internal set; }

        /// <summary>
        /// A <see cref="IList{T}"/> of <see cref="ServiceItem"/> related to the Station.
        /// </summary>
        public IList<ServiceItem> Services { get; internal set; }
    }
}
