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
    /// Defines a service item
    /// </summary>    
    [DebuggerDisplay("{Operator,nq} ({ServiceType,nq}) - {Destination[0].LocationName,nq}")]
    public class ServiceItem
    {
        /// <summary>
        /// The Retail Service ID of the service, if known.
        /// </summary>        
        public string? RetailServiceId { get; internal set; }

        /// <summary>
        /// A <see cref="IList{}"/> of <see cref="ServiceLocation"/> giving original origins of this service.
        /// </summary>        
        public IList<ServiceLocation> Origin { get; internal set; }

        /// <summary>
        /// A <see cref="IList{}"/> of <see cref="ServiceLocation"/> giving original destinations of this service.
        /// </summary>        
        public IList<ServiceLocation> Destination { get; internal set; }

        /// <summary>
        /// An optional <see cref="IList{}"/> of <see cref="ServiceLocation"/> giving live/current origins of this service which is not starting at original cancelled origins.
        /// </summary>        
        public IList<ServiceLocation>? CurrentOrigins { get; internal set; }

        /// <summary>
        /// An optional <see cref="IList{}"/> of <see cref="ServiceLocation"/> giving live/current destinations of this service which is not starting at original cancelled destinations.
        /// </summary>         
        public IList<ServiceLocation>? CurrentDestinations { get; internal set; }

        /// <summary>
        /// An optional <see cref="Tuple"/> of <see cref="string"/> and <see cref="DateTime"/> specifying the Scheduled Time of Arrival (STA) of the service at the station board location.
        /// If not null, one of the value is present.
        /// </summary>        
        public (string? Text, DateTime? Time)? ScheduledTimeArrival { get; internal set; }

        /// <summary>
        /// An optional <see cref="Tuple"/> of <see cref="string"/> and <see cref="DateTime"/> specifying the Estimated Time of Arrival (ETA) of the service at the station board location.
        /// If not null, one of the value is present.
        /// </summary>        
        public (string? Text, DateTime? Time)? EstimatedTimeArrival { get; internal set; }

        /// <summary>
        /// An optional <see cref="Tuple"/> of <see cref="string"/> and <see cref="DateTime"/> specifying the Scheduled Time of Departure (STD) of the service at the station board location.
        /// If not null, one of the value is present.
        /// </summary>        
        public (string? Text, DateTime? Time)? ScheduledTimeDeparture { get; internal set; }

        /// <summary>
        /// An optional <see cref="Tuple"/> of <see cref="string"/> and <see cref="DateTime"/> specifying the Estimated Time of Departure (ETD) of the service at the station board location.
        /// If not null, one of the value is present.
        /// </summary>        
        public (string? Text, DateTime? Time)? EstimatedTimeDeparture { get; internal set; }

        /// <summary>
        /// An optional platform number for the service at this location. This will only be present where available and where the IsPlatformAvailable value is "true".
        /// </summary>        
        public string? Platform { get; internal set; }

        /// <summary>S
        /// The name of the Train Operating Company that operates the service.
        /// </summary>        
        public string Operator { get; internal set; } = string.Empty;

        /// <summary>
        /// The code of the Train Operating Company that operates the service.
        /// </summary>        
        public string OperatorCode { get; internal set; } = string.Empty;

        /// <summary>
        /// If this value is present and has the value "true" then the service is operating on a circular route through the network and will call again at this location later on its journey.
        /// </summary>        
        public bool? IsCircularRoute { get; internal set; }

        /// <summary>
        /// A flag to indicate that this service is cancelled at this location.
        /// </summary>        public bool IsCancelled => !string.IsNullOrEmpty(this.CancellationReason);

        /// <summary>
        /// A flag to indicate that this service is no longer stopping at the requested from/to filter location.
        /// </summary>        
        public bool? FilterLocationCancelled { get; internal set; }

        /// <summary>
        /// The type of service (train, bus, ferry) that this item represents. Note that real-time information (e.g. eta, etd, ata, atd, etc.) is only available and present for train services.
        /// </summary>        
        public ServiceType ServiceType { get; internal set; }

        /// <summary>
        /// The train length (number of units) at this location. If not supplied, or zero, the length is unknown.
        /// </summary>        
        public int? TrainLength { get; internal set; }

        /// <summary>
        /// True if the service detaches units from the front at this location.
        /// </summary>        
        public bool? DoesTrainDetachAtFront { get; internal set; }

        /// <summary>
        /// True if the service is operating in the reverse of its normal formation.
        /// </summary>        
        public bool? IsReverseFormation { get; internal set; }

        /// <summary>
        /// A cancellation reason for this service.
        /// </summary>        
        public string? CancellationReason { get; internal set; }

        /// <summary>
        /// A delay reason for this service.
        /// </summary>        
        public string? DelayReason { get; internal set; }

        /// <summary>
        /// The unique service identifier of this service relative to the station board on which it is displayed. This value can be passed to GetServiceDetails to obtain the full details of the individual service.
        /// </summary>        
        public string ServiceId { get; internal set; } = string.Empty;

        /// <summary>
        /// A list of Adhoc Alerts (strings) for this <see cref="CallingPoint"/>. If there are no alerts, it will be null.
        /// </summary>        
        public IList<string>? AdhocAlerts { get; internal set; }

        /// <summary>
        /// Contains <see cref="FormationData"/> for this <see cref="ServiceItem"/>, if any.
        /// </summary>        
        public FormationData? Formation { get; internal set; }
    }
}