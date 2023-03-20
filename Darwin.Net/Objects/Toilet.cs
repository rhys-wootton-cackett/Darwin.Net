using Darwin.Net.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darwin.Net.Objects
{
    public enum Toilet
    {      
        [StringValue("Unknown")]
        Unknown,
        [StringValue("None")]
        None,
        [StringValue("Standard")]
        Standard,
        [StringValue("Accessible")]
        Accessible
    }
}
