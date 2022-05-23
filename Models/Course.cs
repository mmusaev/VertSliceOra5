using System;
using System.Collections.Generic;

#nullable disable

namespace VertSliceOra5.Models
{
    public partial class Course
    {
        public Course()
        {
            CourseOfferings = new HashSet<CourseOffering>();
            DegreeRequirements = new HashSet<DegreeRequirement>();
        }

        public string DepartmentCode { get; set; }
        public byte CourseNumber { get; set; }
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public decimal Credits { get; set; }

        public virtual Department DepartmentCodeNavigation { get; set; }
        public virtual ICollection<CourseOffering> CourseOfferings { get; set; }
        public virtual ICollection<DegreeRequirement> DegreeRequirements { get; set; }
    }
}
