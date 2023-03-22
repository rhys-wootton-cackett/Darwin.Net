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
    /// Defines a train service with lists of <see cref="CallingPoint"/>
    /// </summary>
    [DebuggerDisplay("{Operator,nq} ({ServiceType,nq}) - {Destination[0].LocationName,nq}")]
    public class ServiceItemWithCallingPoints : ServiceItem
    {
        /// <summary>
        /// A <see cref="IList{T}"/> of previous <see cref="CallingPoint"/> objects relative to the location of this service.
        /// </summary>
        public IList<CallingPoint>? PreviousCallingPoints { get; internal set; }

        /// <summary>
        /// A <see cref="IList{T}"/> of subsequent <see cref="CallingPoint"/> objects relative to the location of this service.
        /// </summary>
        public IList<CallingPoint>? SubsequentCallingPoints { get; internal set; }
    }
}
