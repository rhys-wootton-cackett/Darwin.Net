using Darwin.Net.Helpers;
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
    /// Defines a calling point of a station in a journey
    /// </summary>
    [DebuggerDisplay("{LocationName,nq} - {ScheduleTime?.Time?.ToString(\"HH:mm\"),nq}")]
    public class CallingPoint
    {
        /// <summary>
        /// The display name of this location.
        /// </summary>
        public string LocationName { get; internal set; }

        /// <summary>
        /// The station the train is scheduled at
        /// </summary>
        public Station Station { get; internal set; }

        /// <summary>
        /// The scheduled time of the service at this location. The time will be
        /// either an arrival or departure time, depending on whether it is in the
        /// subsequent or previous calling point list.
        /// </summary>
        public (string? Text, DateTime? Time)? ScheduleTime { get; internal set; }

        /// <summary>
        /// The estimated time of the service at this location. The time will be
        /// either an arrival or departure time, depending on whether it is in the
        /// subsequent or previous calling point list. Will only be present if
        /// ActualTime is not present.
        /// </summary>
        public (string? Text, DateTime? Time)? EstimatedTime { get; internal set; }

        /// <summary>
        /// The estimated time of the service at this location. The time will be
        /// either an arrival or departure time, depending on whether it is in the
        /// subsequent or previous calling point list. Will only be present if
        /// EstimatedTime is not present.
        /// </summary>
        public (string? Text, DateTime? Time)? ActualTime { get; internal set; }

        /// <summary>
        /// A flag to indicate that this service is cancelled at this location.
        /// </summary>
        public bool? IsCancelled { get; internal set; }

        /// <summary>
        /// The train length (number of units) at this location. If not supplied, or
        /// zero, the length is unknown.
        /// </summary>
        public int? TrainLength { get; internal set; }

        /// <summary>
        /// True if the service detaches units from the front at this location.
        /// </summary>
        public bool? DoesTrainDetachAtFront { get; internal set; }

        /// <summary>
        /// A list of Adhoc Alerts (strings) for this <see cref="CallingPoint"/>. If
        /// there are no alerts, it will be null.
        /// </summary>
        public IList<string>? AdhocAlerts { get; internal set; }
    }
}
