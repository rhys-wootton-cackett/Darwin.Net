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
    /// Defines a departure board for a station
    /// </summary>
    [DebuggerDisplay("{LocationName,nq} - Departures: {Departures.Count,nq}")]
    public class DeparturesBoard
    {
        /// <summary>
        /// The time at which the <see cref="DeparturesBoard"/> was generated
        /// </summary>
        public DateTime GeneratedAt { get; internal set; }

        /// <summary>
        /// The name of the location that the station board is for.
        /// </summary>
        public string LocationName { get; internal set; }

        /// <summary>
        /// The station in the departures board.
        /// </summary>
        public Station Station { get; internal set; }

        /// <summary>
        /// If a filter was requested, the location name of the filter location.
        /// </summary>
        public string? FilterLocationName { get; internal set; }

        /// <summary>
        /// If a filter was requested, the CRS code of the filter location.
        /// </summary>
        public Station? FilterStation { get; internal set; }

        /// <summary>
        /// If a filter was requested, the type of filter.
        /// </summary>
        public FilterType? FilterType { get; internal set; }

        /// <summary>
        /// An optional list of textual messages that should be displayed with the station board.
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
        public bool AreServicesAvailable => this.Departures.Count > 0;

        /// <summary>
        /// An <see cref="IList{T}"/> of <see cref="DepartureItem"/> for each service that is to appear on the departures board. A <see cref="DepartureItem"/> will exist for each CRS code requested 
        /// in the filter but if no information is available the <see cref="ServiceItem"/> part will be empty.
        /// </summary>
        public IList<DepartureItem> Departures { get; internal set; }
    }
}
