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
    /// Provides a service location for a train.
    /// </summary>    [DebuggerDisplay("{LocationName,nq} {Via ?? \"\",nq}")]
    public class ServiceLocation
    {
        /// <summary>
        /// The name of the location that the station board is for.
        /// </summary>        
        public string LocationName { get; internal set; } = string.Empty;

        /// <summary>
        /// The station in the service location.
        /// </summary>        
        public Station Station { get; internal set; }

        /// <summary>
        /// An optional via string that should be displayed after the location, to indicate further information about an ambiguous route. Note that vias are only present for <see cref="ServiceLocation"/> objects that appear in destination lists.
        /// </summary>        
        public string? Via { get; internal set; }

        /// <summary>
        /// A <see cref="ServiceType"/> specifying service type (Bus/Ferry/Train) to which will be changed in the future.
        /// </summary>        
        public ServiceType? FutureChangeTo { get; internal set; }

        /// <summary>
        /// Defines if the origin or destination can no longer be reached because the association has been cancelled.
        /// </summary>        
        public bool? AssocIsCancelled { get; internal set; }
    }

    public enum ServiceType
    {
        [StringValue("bus")]
        Bus,
        [StringValue("ferry")]
        Ferry,
        [StringValue("train")]
        Train
    }
}