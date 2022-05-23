using System;
using System.Collections.Generic;

#nullable disable

namespace VertSliceOra5.Models
{
    public partial class Term
    {
        public Term()
        {
            Applications = new HashSet<Application>();
            ApplicationsOneIndices = new HashSet<ApplicationsOneIndex>();
            ApplicationsOverIndexeds = new HashSet<ApplicationsOverIndexed>();
            CourseOfferings = new HashSet<CourseOffering>();
            Students = new HashSet<Student>();
        }

        public string TermCode { get; set; }
        public string SessionCode { get; set; }
        public byte Year { get; set; }

        public virtual Session SessionCodeNavigation { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<ApplicationsOneIndex> ApplicationsOneIndices { get; set; }
        public virtual ICollection<ApplicationsOverIndexed> ApplicationsOverIndexeds { get; set; }
        public virtual ICollection<CourseOffering> CourseOfferings { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
