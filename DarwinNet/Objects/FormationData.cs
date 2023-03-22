using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DarwinNet.Objects
{
    /// <summary>
    /// Provides details about the formation of a train
    /// </summary>
    [DebuggerDisplay("{DebugString,nq}")]
    public class FormationData
    {
        /// <summary>
        /// A collection of <see cref="CoachData"/> objects related to this formation.
        /// </summary>
        public IList<CoachData> Coaches { get; internal set;} = new List<CoachData>();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebugString => string.Join(", ", Coaches.GroupBy(c => c.CoachClass).Select(c => $"{c.Key} - {c.Count()}"));
    }
}
