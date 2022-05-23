using System;
using System.Collections.Generic;

#nullable disable

namespace VertSliceOra5.Models
{
    public partial class RupdTab1
    {
        public decimal? Id { get; set; }
        public string Dmltype { get; set; }
        public decimal? Snapid { get; set; }
        public byte[] ChangeVector { get; set; }
    }
}
