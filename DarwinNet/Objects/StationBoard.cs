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
    /// Defines a station board located at a station
    /// </summary>    [DebuggerDisplay("{LocationName,nq} (Generated at: {GeneratedAt,nq})")]
    public class StationBoard
    {
        /// <summary>
        /// The time at which the <see cref="StationBoard"/> was generated
        /// </summary>        
        public DateTime GeneratedAt { get; internal set; }

        /// <summary>
        /// The name of the location that the station board is for.
        /// </summary>        
        public string LocationName { get; internal set; } = string.Empty;

        /// <summary>
        /// The station for the station board.
        /// </summary>        
        public Station Station { get; internal set; }

        /// <summary>
        /// If a filter was requested, the location name of the filter location.
        /// </summary>        
        public string? FilterLocationName { get; internal set; }

        /// <summary>
        /// If a filter was requested, the <see cref="Objects.Station"/> of the filter location.
        /// </summary>        
        public Station? FilterStation { get; internal set; }

        /// <summary>
        /// If a filter was requested, the type of filter.
        /// </summary>        
        public FilterType? FilterType { get; internal set; }

        /// <summary>
        /// An optional list of textual messages that should be displayed with the station board. The messages are typically used to display important disruption information 
        /// that applies to the location that the station board was for. 
        /// </summary>        
        public IList<string>? NrccMessages { get; internal set; }

        /// <summary>
        /// An optional value that indicates if platform information is available. If this value is present with the value "true" then platform information will be returned in the service lists. 
        /// If this value is not present, or has the value "false", then the platform "heading" should be suppressed in the user interface for this station board.
        /// </summary>         
        public bool? IsPlatformAvailable { get; internal set; }

        /// <summary>
        /// An optional value that indicates if services are currently available for this station board. If this value is present with the value "false" then no services will be returned in the service lists. 
        /// This value may be set, for example, if access to a station has been closed to the public at short notice, even though the scheduled services are still running. 
        /// It would be usual in such cases for one of the nrccMessages to describe why the list of services has been suppressed.
        /// </summary>
        public bool AreServicesAvailable => this.TrainServices?.Count > 0 || this.BusServices?.Count > 0 || this.FerryServices?.Count > 0;

        /// <summary>
        /// An <see cref="IList{T}"/> of <see cref="ServiceItem"/> objects for the train services appearing on the station board. If no services exist, this will contain zero items or be null.
        /// </summary>        
        public IList<ServiceItem>? TrainServices { get; internal set; }

        /// <summary>
        /// An <see cref="IList{T}"/> of <see cref="ServiceItem"/> objects for the bus services appearing on the station board. If no services exist, this will contain zero items or be null.
        /// </summary>        
        public IList<ServiceItem>? BusServices { get; internal set; }

        /// <summary>
        /// An <see cref="IList{T}"/> of <see cref="ServiceItem"/> objects for the ferry services appearing on the station board. If no services exist, this will contain zero items or be null.
        /// </summary>         
        public IList<ServiceItem>? FerryServices { get; internal set; }
    }
}