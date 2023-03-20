using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Darwin.Net.Objects
{
    /// <summary>
    /// Defines a departure item for a train
    /// </summary>
    [DebuggerDisplay("{Station,nq} - Services: {Services.Count,nq}")]
    public class DepartureItemWithCallingPoints : DepartureItem
    {
        /// <summary>
        /// A <see cref="IList{T}"/> of <see cref="ServiceItemWithCallingPoints"/> related to the Station.
        /// </summary>
        public new IList<ServiceItemWithCallingPoints> Services { get; internal set; }
    }
}
