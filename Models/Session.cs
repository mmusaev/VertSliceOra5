using System;
using System.Collections.Generic;

#nullable disable

namespace VertSliceOra5.Models
{
    public partial class Session
    {
        public Session()
        {
            DegreeRequirements = new HashSet<DegreeRequirement>();
            Terms = new HashSet<Term>();
        }

        public string SessionCode { get; set; }
        public string SessionName { get; set; }

        public virtual ICollection<DegreeRequirement> DegreeRequirements { get; set; }
        public virtual ICollection<Term> Terms { get; set; }
    }
}
