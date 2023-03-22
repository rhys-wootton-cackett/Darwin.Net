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
    /// Defines a station board located at a station with additional details
    /// </summary>
    [DebuggerDisplay("{LocationName,nq} (Generated at: {GeneratedAt,nq})")]
    public class StationBoardWithDetails : StationBoard
    {
        /// <summary>
        /// An optional value that indicates if services are currently available for this station board. If this value is present with the value "false" then no services will be returned in the service lists. 
        /// This value may be set, for example, if access to a station has been closed to the public at short notice, even though the scheduled services are still running. 
        /// It would be usual in such cases for one of the nrccMessages to describe why the list of services has been suppressed.
        /// </summary>
        public new bool AreServicesAvailable => this.TrainServices?.Count > 0 || this.BusServices?.Count > 0 || this.FerryServices?.Count > 0;

        /// <summary>
        /// An <see cref="IList{T}"/> of <see cref="ServiceItemWithCallingPoints"/> objects for the train services appearing on the station board. If no services exist, this will contain zero items or be null.
        /// </summary>
        public new IList<ServiceItemWithCallingPoints>? TrainServices { get; internal set; }

        /// <summary>
        /// An <see cref="IList{T}"/> of <see cref="ServiceItemWithCallingPoints"/> objects for the bus services appearing on the station board. If no services exist, this will contain zero items or be null.
        /// </summary>
        public new IList<ServiceItemWithCallingPoints>? BusServices { get; internal set; }

        /// <summary>
        /// An <see cref="IList{T}"/> of <see cref="ServiceItemWithCallingPoints"/> objects for the ferry services appearing on the station board. If no services exist, this will contain zero items or be null.
        /// </summary>
        public new IList<ServiceItemWithCallingPoints>? FerryServices { get; internal set; }
    }
}
