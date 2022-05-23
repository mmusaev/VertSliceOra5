using System;
using System.Collections.Generic;

#nullable disable

namespace VertSliceOra5.Models
{
    public partial class Department
    {
        public Department()
        {
            Courses = new HashSet<Course>();
            Degrees = new HashSet<Degree>();
        }

        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Degree> Degrees { get; set; }
    }
}
