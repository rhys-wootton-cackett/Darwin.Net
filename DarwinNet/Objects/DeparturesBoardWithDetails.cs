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
    /// Defines a departure board for station with additional details
    /// </summary>
    [DebuggerDisplay("{LocationName,nq} - Departures: {Departures.Count,nq}")]
    public class DeparturesBoardWithDetails : DeparturesBoard
    {
        /// <summary>
        /// An <see cref="IList{T}"/> of <see cref="DepartureItemWithCallingPoints"/> for each service that is to appear on the departures board. A <see cref="DepartureItemWithCallingPoints"/> will 
        /// exist for each CRS code requested in the filter but if no information is available the <see cref="ServiceItemWithCallingPoints"/> part will be empty.
        /// </summary>    
        public new IList<DepartureItemWithCallingPoints> Departures { get; internal set; } = new List<DepartureItemWithCallingPoints>();
    }
}
