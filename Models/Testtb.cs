using System;
using System.Collections.Generic;

#nullable disable

namespace VertSliceOra5.Models
{
    public partial class Testtb
    {
        public decimal Id { get; set; }
        public string Column2 { get; set; }

        public virtual Table2 Table2 { get; set; }
    }
}
