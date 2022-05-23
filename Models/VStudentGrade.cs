using System;
using System.Collections.Generic;

#nullable disable

namespace VertSliceOra5.Models
{
    public partial class VStudentGrade
    {
        public int StudentId { get; set; }
        public string TermCode { get; set; }
        public string DepartmentCode { get; set; }
        public byte CourseNumber { get; set; }
        public string CourseTitle { get; set; }
        public decimal Credits { get; set; }
        public string GradeCode { get; set; }
        public decimal? Points { get; set; }
    }
}
