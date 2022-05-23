using System;
using System.Collections.Generic;

#nullable disable

namespace VertSliceOra5.Models
{
    public partial class CourseEnrollment
    {
        public decimal CourseEnrollmentId { get; set; }
        public decimal CourseOfferingId { get; set; }
        public int StudentId { get; set; }
        public string GradeCode { get; set; }

        public virtual CourseOffering CourseOffering { get; set; }
        public virtual Grade GradeCodeNavigation { get; set; }
        public virtual Student Student { get; set; }
    }
}
