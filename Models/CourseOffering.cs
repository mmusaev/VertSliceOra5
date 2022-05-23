using System;
using System.Collections.Generic;

#nullable disable

namespace VertSliceOra5.Models
{
    public partial class CourseOffering
    {
        public CourseOffering()
        {
            CourseEnrollments = new HashSet<CourseEnrollment>();
        }

        public decimal CourseOfferingId { get; set; }
        public string DepartmentCode { get; set; }
        public byte CourseNumber { get; set; }
        public string TermCode { get; set; }
        public byte Section { get; set; }
        public byte Capacity { get; set; }

        public virtual Course Course { get; set; }
        public virtual Term TermCodeNavigation { get; set; }
        public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; }
    }
}
