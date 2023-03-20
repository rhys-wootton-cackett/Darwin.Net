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
    /// Provides details about a specific coach on a train
    /// </summary>
    [DebuggerDisplay("{CoachNumber,nq} - {CoachClass,nq}")]
    public class CoachData
    {
        /// <summary>
        /// The class of coach, where known. First, Mixed or Standard. Other classes may be introduced in the future.
        /// </summary>
        public CoachClass CoachClass { get; internal set; }

        /// <summary>
        /// The loading value (0-100) for the coach.
        /// </summary>
        public int? Loading { get; internal set; }

        /// <summary>
        /// Specifies whether loading has been specified or not.
        /// </summary>
        public bool? LoadingSpecified { get; internal set; }

        /// <summary>
        /// The number/identifier for this coach, e.g. "A" or "12". Maximum of two characters.
        /// </summary>
        public string CoachNumber { get; internal set; } = string.Empty;

        /// <summary>
        /// A <see cref="ToiletAvailability"/> object representing toilet data. (2017-10-01 schema onwards)
        /// </summary>
        public Toilet? Toilet { get; internal set; }
    }

    public enum CoachClass
    {
        [StringValue("First")]
        First,
        [StringValue("Mixed")]
        Mixed,
        [StringValue("Standard")]
        Standard
    }
}
