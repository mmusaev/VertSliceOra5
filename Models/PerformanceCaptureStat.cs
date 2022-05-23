using System;
using System.Collections.Generic;

#nullable disable

namespace VertSliceOra5.Models
{
    public partial class PerformanceCaptureStat
    {
        public int RunNumber { get; set; }
        public string Description { get; set; }
        public short DataSequence { get; set; }
        public string StatName { get; set; }
        public decimal StatValue { get; set; }
    }
}
