using System;
using System.Collections.Generic;

#nullable disable

namespace VertSliceOra5.Models
{
    public partial class Table2
    {
        public decimal Id { get; set; }
        public string Testtbid { get; set; }

        public virtual Testtb IdNavigation { get; set; }
    }
}
