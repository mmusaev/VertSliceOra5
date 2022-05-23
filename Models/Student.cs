using System;
using System.Collections.Generic;

#nullable disable

namespace VertSliceOra5.Models
{
    public partial class Student
    {
        public Student()
        {
            CourseEnrollments = new HashSet<CourseEnrollment>();
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int DegreePursued { get; set; }
        public string ClassStandingCode { get; set; }
        public string StudentStatus { get; set; }
        public string EnrollmentTerm { get; set; }

        public virtual ClassStanding ClassStandingCodeNavigation { get; set; }
        public virtual Degree DegreePursuedNavigation { get; set; }
        public virtual Term EnrollmentTermNavigation { get; set; }
        public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; }
    }
}
