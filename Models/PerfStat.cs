using System;
using System.Collections.Generic;

#nullable disable

namespace VertSliceOra5.Models
{
    public partial class PerfStat
    {
        public string StatName { get; set; }
        public int Divisor { get; set; }
        public string Units { get; set; }
        public int? DisplayOrder { get; set; }
    }
}
