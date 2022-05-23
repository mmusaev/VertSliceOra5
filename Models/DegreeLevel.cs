using System;
using System.Collections.Generic;

#nullable disable

namespace VertSliceOra5.Models
{
    public partial class DegreeLevel
    {
        public DegreeLevel()
        {
            ClassStandings = new HashSet<ClassStanding>();
            DegreeTypes = new HashSet<DegreeType>();
        }

        public string DegreeLevelCode { get; set; }
        public string DegreeLevelName { get; set; }

        public virtual ICollection<ClassStanding> ClassStandings { get; set; }
        public virtual ICollection<DegreeType> DegreeTypes { get; set; }
    }
}
