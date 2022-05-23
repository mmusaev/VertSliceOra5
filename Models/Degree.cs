using System;
using System.Collections.Generic;

#nullable disable

namespace VertSliceOra5.Models
{
    public partial class Degree
    {
        public Degree()
        {
            DegreeRequirements = new HashSet<DegreeRequirement>();
            Students = new HashSet<Student>();
        }

        public int DegreeId { get; set; }
        public string DepartmentCode { get; set; }
        public string DegreeTypeCode { get; set; }
        public string DegreeName { get; set; }

        public virtual DegreeType DegreeTypeCodeNavigation { get; set; }
        public virtual Department DepartmentCodeNavigation { get; set; }
        public virtual ICollection<DegreeRequirement> DegreeRequirements { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
