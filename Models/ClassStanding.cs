using System;
using System.Collections.Generic;

#nullable disable

namespace VertSliceOra5.Models
{
    public partial class ClassStanding
    {
        public ClassStanding()
        {
            DegreeRequirements = new HashSet<DegreeRequirement>();
            Students = new HashSet<Student>();
        }

        public string ClassStandingCode { get; set; }
        public string ClassStandingName { get; set; }
        public string DegreeLevelCode { get; set; }
        public byte RequiredCredits { get; set; }

        public virtual DegreeLevel DegreeLevelCodeNavigation { get; set; }
        public virtual ICollection<DegreeRequirement> DegreeRequirements { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
