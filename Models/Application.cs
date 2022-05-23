using System;
using System.Collections.Generic;

#nullable disable

namespace VertSliceOra5.Models
{
    public partial class Application
    {
        public int ApplicantId { get; set; }
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
        public decimal? Gpa { get; set; }
        public byte? SatMathScore { get; set; }
        public byte? SatReadingScore { get; set; }
        public byte? SatWritingScore { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string TermCode { get; set; }
        public string ApplicationStatus { get; set; }
        public decimal? Points { get; set; }

        public virtual Term TermCodeNavigation { get; set; }
    }
}
