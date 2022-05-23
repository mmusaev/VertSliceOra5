using System;
using System.Collections.Generic;

#nullable disable

namespace VertSliceOra5.Models
{
    public partial class DegreeType
    {
        public DegreeType()
        {
            Degrees = new HashSet<Degree>();
        }

        public string DegreeTypeCode { get; set; }
        public string DegreeTypeName { get; set; }
        public string DegreeLevelCode { get; set; }

        public virtual DegreeLevel DegreeLevelCodeNavigation { get; set; }
        public virtual ICollection<Degree> Degrees { get; set; }
    }
}
