using System;
using System.Collections.Generic;

#nullable disable

namespace VertSliceOra5.Models
{
    public partial class Grade
    {
        public Grade()
        {
            CourseEnrollments = new HashSet<CourseEnrollment>();
        }

        public string GradeCode { get; set; }
        public decimal? Points { get; set; }
        public bool? IncludeInGpa { get; set; }

        public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; }
    }
}
