using Darwin.Net.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darwin.Net.Objects
{
    public enum FilterType
    {
        [StringValue("to")]
        To,
        [StringValue("from")]
        From
    }
}
