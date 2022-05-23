using System;
using System.Collections.Generic;

#nullable disable

namespace VertSliceOra5.Models
{
    public partial class ImReconsignment
    {
        public long PtrRecons { get; set; }
        public long? PtrProd { get; set; }
        public long? PtrCo { get; set; }
        public DateTime? DtmTrans { get; set; }
        public string IdnInvOwner { get; set; }
        public DateTime? DtmBooked { get; set; }
        public string CdeStatus { get; set; }
        public string CdeReconsType { get; set; }
        public long? PtrFromLoc { get; set; }
        public long? PtrToLoc { get; set; }
        public decimal? VolTrans { get; set; }
        public string UomVol { get; set; }
        public string CdeReconsContrlSelect { get; set; }
        public string CdeInvSelect { get; set; }
        public string CdeReserveSelect { get; set; }
        public string DscStatusDtl { get; set; }
        public DateTime? DtmUpd { get; set; }
        public string IdnUpdByUser { get; set; }
        public string FlgDel { get; set; }
        public string FlgIntrnl { get; set; }
        public DateTime? DteBusBooked { get; set; }
        public decimal? ValRvp { get; set; }
        public string DscCom { get; set; }
    }
}
