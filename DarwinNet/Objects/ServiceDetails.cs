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
    /// Defines a service details response
    /// </summary>    [DebuggerDisplay("{LocationName,nq} ({ServiceType,nq}) - {Station,nq}")]
    public class ServiceDetails
    {
        /// <summary>
        /// The time at which the <see cref="ServiceDetails"/> was generated
        /// </summary>        
        public DateTime GeneratedAt { get; internal set; }

        /// <summary>
        /// The Retail Service ID of the service, if known.
        /// </summary>        
        public string? RetailServiceId { get; internal set; }

        /// <summary>
        /// The type of service (train, bus, ferry) that this item represents. Note that real-time information (e.g. eta, etd, ata, atd, etc.) is only available and present for train services.
        /// </summary>        
        public ServiceType ServiceType { get; internal set; }

        /// <summary>
        /// The display name of the departure board location that these service details were accessed from.
        /// </summary>        
        public string LocationName { get; internal set; }

        /// <summary>
        /// The station in the service details.
        /// </summary>        
        public Station Station { get; internal set; }

        /// <summary>
        /// The name of the Train Operating Company that operates the service.
        /// </summary>        
        public string Operator { get; internal set; } = string.Empty;

        /// <summary>
        /// The code of the Train Operating Company that operates the service.
        /// </summary>        
        public string OperatorCode { get; internal set; } = string.Empty;

        /// <summary>
        /// A flag to indicate that this service is cancelled at this location.
        /// </summary>        
        public bool IsCancelled { get; internal set; }

        /// <summary>
        /// A cancellation reason for this service.
        /// </summary>        
        public string? CancellationReason { get; internal set; }

        /// <summary>
        /// A delay reason for this service.
        /// </summary>        
        public string? DelayReason { get; internal set; }

        /// <summary>
        /// True if the service detaches units from the front at this location.
        /// </summary>        
        public bool? DoesTrainDetachAtFront { get; internal set; }

        /// <summary>
        /// The reason for a diversion.
        /// </summary>        
        public string? DiversionReason { get; internal set; }

        /// <summary>
        /// The location of the diversion.
        /// </summary>        
        public string? DivertedVia { get; internal set; }

        /// <summary>
        /// If an expected movement report has been missed, this will contain a message describing the missed movement.
        /// </summary>        
        public string? OverdueMessage { get; internal set; }

        /// <summary>
        /// The train length (number of units) at this location. If not supplied, or zero, the length is unknown.
        /// </summary>        
        public int? TrainLength { get; internal set; }

        /// <summary>
        /// True if the service is operating in the reverse of its normal formation.
        /// </summary>        
        public bool? IsReverseFormation { get; internal set; }

        /// <summary>
        /// An optional platform number for the service at this location. This will only be present where available and where IsPlatformAvailable value is "true".
        /// </summary>        
        public string? Platform { get; internal set; }

        /// <summary>
        /// An optional <see cref="DateTime"/> specifying the Scheduled Time of Arrival (STA) of the service at the station board location.
        /// </summary>        
        public (string? Text, DateTime? Time)? ScheduledTimeArrival { get; internal set; }

        /// <summary>
        /// An optional <see cref="DateTime"/> specifying the Estimated Time of Arrival (ETA) of the service at the station board location.
        /// </summary>        
        public (string? Text, DateTime? Time)? EstimatedTimeArrival { get; internal set; }

        /// <summary>
        /// An optional <see cref="DateTime"/> specifying the Actual Time of Arrival (ATA) of the service at the station board location.
        /// </summary>        
        public (string? Text, DateTime? Time)? ActualTimeArrival { get; internal set; }

        /// <summary>
        /// An optional <see cref="DateTime"/> specifying the Scheduled Time of Departure (STD) of the service at the station board location.
        /// </summary>        
        public (string? Text, DateTime? Time)? ScheduledTimeDeparture { get; internal set; }

        /// <summary>
        /// An optional <see cref="DateTime"/> specifying the Estimated Time of Departure (ETD) of the service at the station board location.
        /// </summary>        
        public (string? Text, DateTime? Time)? EstimatedTimeDeparture { get; internal set; }

        /// <summary>
        /// An optional <see cref="DateTime"/> specifying the Actual Time of Departure (ATD) of the service at the station board location.
        /// </summary>        
        public (string? Text, DateTime? Time)? ActualTimeDeparture { get; internal set; }

        /// <summary>
        /// A list of Adhoc Alerts (strings) for this <see cref="CallingPoint"/>. If there are no alerts, it will be null.
        /// </summary>        
        public IList<string>? AdhocAlerts { get; internal set; }

        /// <summary>
        /// An <see cref="IList{T}"/> of <see cref="IList{T}"/> of previous <see cref="CallingPoint"/> objects relative to the location of this service.
        /// </summary>
        public IList<IList<CallingPoint>>? PreviousCallingPoints { get; internal set; }

        /// <summary>
        /// An <see cref="IList{T}"/> of <see cref="IList{T}"/> of subsequent <see cref="CallingPoint"/> objects relative to the location of this service.
        /// </summary>
        public IList<IList<CallingPoint>>? SubsequentCallingPoints { get; internal set; }

        /// <summary>
        /// Contains <see cref="FormationData"/> for this <see cref="ServiceDetails"/>, if any.
        /// </summary>        
        public FormationData? Formation { get; internal set; }
    }
}
