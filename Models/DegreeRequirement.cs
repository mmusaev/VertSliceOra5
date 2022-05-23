using System;
using System.Collections.Generic;

#nullable disable

namespace VertSliceOra5.Models
{
    public partial class DegreeRequirement
    {
        public int RequirementId { get; set; }
        public int DegreeId { get; set; }
        public string ClassStandingCode { get; set; }
        public string SessionCode { get; set; }
        public string DepartmentCode { get; set; }
        public byte CourseNumber { get; set; }

        public virtual ClassStanding ClassStandingCodeNavigation { get; set; }
        public virtual Course Course { get; set; }
        public virtual Degree Degree { get; set; }
        public virtual Session SessionCodeNavigation { get; set; }
    }
}
