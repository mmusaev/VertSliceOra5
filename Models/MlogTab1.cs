using System;
using System.Collections.Generic;

#nullable disable

namespace VertSliceOra5.Models
{
    public partial class MlogTab1
    {
        public decimal? Id { get; set; }
        public decimal? Num { get; set; }
        public string Description { get; set; }
        public string MRow { get; set; }
        public DateTime? Snaptime { get; set; }
        public string Dmltype { get; set; }
        public string OldNew { get; set; }
        public byte[] ChangeVector { get; set; }
        public decimal? Xid { get; set; }
    }
}
