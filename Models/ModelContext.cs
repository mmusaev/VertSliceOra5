using Microsoft.EntityFrameworkCore;

#nullable disable

namespace VertSliceOra5.Models
{
    public partial class ModelContext : DbContext
    {

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<ApplicationsOneIndex> ApplicationsOneIndices { get; set; }
        public virtual DbSet<ApplicationsOverIndexed> ApplicationsOverIndexeds { get; set; }
        public virtual DbSet<ClassStanding> ClassStandings { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseEnrollment> CourseEnrollments { get; set; }
        public virtual DbSet<CourseOffering> CourseOfferings { get; set; }
        public virtual DbSet<Degree> Degrees { get; set; }
        public virtual DbSet<DegreeLevel> DegreeLevels { get; set; }
        public virtual DbSet<DegreeRequirement> DegreeRequirements { get; set; }
        public virtual DbSet<DegreeType> DegreeTypes { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<ImReconsignment> ImReconsignments { get; set; }
        public virtual DbSet<MlogTab1> MlogTab1s { get; set; }
        public virtual DbSet<PerfStat> PerfStats { get; set; }
        public virtual DbSet<PerformanceCaptureStat> PerformanceCaptureStats { get; set; }
        public virtual DbSet<RupdTab1> RupdTab1s { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Tab1> Tab1s { get; set; }
        public virtual DbSet<Tab1Mv> Tab1Mvs { get; set; }
        public virtual DbSet<Table2> Table2s { get; set; }
        public virtual DbSet<Term> Terms { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Test2> Test2s { get; set; }
        public virtual DbSet<Testtb> Testtbs { get; set; }
        public virtual DbSet<VStudentGrade> VStudentGrades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(Host=10.0.0.225)(Port=1521)))(CONNECT_DATA=(SERVICE_NAME=XE)));User Id=marat;Password=abcd1234;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("MARAT")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Application>(entity =>
            {
                entity.HasKey(e => e.ApplicantId);

                entity.ToTable("APPLICATIONS");

                entity.HasIndex(e => new { e.State, e.LastName, e.FirstName }, "IX_APPLICANTS_STATE");

                entity.Property(e => e.ApplicantId)
                    .HasPrecision(10)
                    .ValueGeneratedNever()
                    .HasColumnName("APPLICANT_ID");

                entity.Property(e => e.ApplicationStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("APPLICATION_STATUS")
                    .HasDefaultValueSql("'N'  ");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CITY");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE_OF_BIRTH");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Gpa)
                    .HasColumnType("NUMBER(2,1)")
                    .HasColumnName("GPA");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MIDDLE_NAME");

                entity.Property(e => e.Points)
                    .HasColumnType("NUMBER(10,2)")
                    .HasColumnName("POINTS");

                entity.Property(e => e.ReceivedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("RECEIVED_DATE");

                entity.Property(e => e.SatMathScore)
                    .HasPrecision(3)
                    .HasColumnName("SAT_MATH_SCORE");

                entity.Property(e => e.SatReadingScore)
                    .HasPrecision(3)
                    .HasColumnName("SAT_READING_SCORE");

                entity.Property(e => e.SatWritingScore)
                    .HasPrecision(3)
                    .HasColumnName("SAT_WRITING_SCORE");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("STATE");

                entity.Property(e => e.StreetAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STREET_ADDRESS");

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TELEPHONE");

                entity.Property(e => e.TermCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TERM_CODE");

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ZIP_CODE");

                entity.HasOne(d => d.TermCodeNavigation)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.TermCode)
                    .HasConstraintName("FK_APPLICATIONS_TERM_CODE");
            });

            modelBuilder.Entity<ApplicationsOneIndex>(entity =>
            {
                entity.HasKey(e => e.ApplicantId)
                    .HasName("PK_APPLICATIONS_ONE");

                entity.ToTable("APPLICATIONS_ONE_INDEX");

                entity.HasIndex(e => e.LastName, "IX_APPL_ONE_LAST_NAME");

                entity.Property(e => e.ApplicantId)
                    .HasPrecision(10)
                    .ValueGeneratedNever()
                    .HasColumnName("APPLICANT_ID");

                entity.Property(e => e.ApplicationStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("APPLICATION_STATUS")
                    .HasDefaultValueSql("'N'  ");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CITY");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE_OF_BIRTH");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Gpa)
                    .HasColumnType("NUMBER(2,1)")
                    .HasColumnName("GPA");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MIDDLE_NAME");

                entity.Property(e => e.Points)
                    .HasColumnType("NUMBER(10,2)")
                    .HasColumnName("POINTS");

                entity.Property(e => e.ReceivedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("RECEIVED_DATE");

                entity.Property(e => e.SatMathScore)
                    .HasPrecision(3)
                    .HasColumnName("SAT_MATH_SCORE");

                entity.Property(e => e.SatReadingScore)
                    .HasPrecision(3)
                    .HasColumnName("SAT_READING_SCORE");

                entity.Property(e => e.SatWritingScore)
                    .HasPrecision(3)
                    .HasColumnName("SAT_WRITING_SCORE");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("STATE");

                entity.Property(e => e.StreetAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STREET_ADDRESS");

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TELEPHONE");

                entity.Property(e => e.TermCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TERM_CODE");

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ZIP_CODE");

                entity.HasOne(d => d.TermCodeNavigation)
                    .WithMany(p => p.ApplicationsOneIndices)
                    .HasForeignKey(d => d.TermCode)
                    .HasConstraintName("FK_APPLICATIONS_ONE_TERM_CODE");
            });

            modelBuilder.Entity<ApplicationsOverIndexed>(entity =>
            {
                entity.HasKey(e => e.ApplicantId)
                    .HasName("PK_APPLICATIONS_OVR");

                entity.ToTable("APPLICATIONS_OVER_INDEXED");

                entity.HasIndex(e => e.City, "IX_APPL_OVR_CITY");

                entity.HasIndex(e => e.DateOfBirth, "IX_APPL_OVR_DOB");

                entity.HasIndex(e => e.Email, "IX_APPL_OVR_EMAIL");

                entity.HasIndex(e => e.FirstName, "IX_APPL_OVR_FIRST_NAME");

                entity.HasIndex(e => e.LastName, "IX_APPL_OVR_LAST_NAME");

                entity.HasIndex(e => e.MiddleName, "IX_APPL_OVR_MIDDLE_NAME");

                entity.HasIndex(e => e.Telephone, "IX_APPL_OVR_PHONE");

                entity.HasIndex(e => e.State, "IX_APPL_OVR_STATE");

                entity.HasIndex(e => e.StreetAddress, "IX_APPL_OVR_STREET");

                entity.HasIndex(e => e.ZipCode, "IX_APPL_OVR_ZIP_CODE");

                entity.Property(e => e.ApplicantId)
                    .HasPrecision(10)
                    .ValueGeneratedNever()
                    .HasColumnName("APPLICANT_ID");

                entity.Property(e => e.ApplicationStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("APPLICATION_STATUS")
                    .HasDefaultValueSql("'N'  ");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CITY");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE_OF_BIRTH");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Gpa)
                    .HasColumnType("NUMBER(2,1)")
                    .HasColumnName("GPA");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MIDDLE_NAME");

                entity.Property(e => e.Points)
                    .HasColumnType("NUMBER(10,2)")
                    .HasColumnName("POINTS");

                entity.Property(e => e.ReceivedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("RECEIVED_DATE");

                entity.Property(e => e.SatMathScore)
                    .HasPrecision(3)
                    .HasColumnName("SAT_MATH_SCORE");

                entity.Property(e => e.SatReadingScore)
                    .HasPrecision(3)
                    .HasColumnName("SAT_READING_SCORE");

                entity.Property(e => e.SatWritingScore)
                    .HasPrecision(3)
                    .HasColumnName("SAT_WRITING_SCORE");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("STATE");

                entity.Property(e => e.StreetAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STREET_ADDRESS");

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TELEPHONE");

                entity.Property(e => e.TermCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TERM_CODE");

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ZIP_CODE");

                entity.HasOne(d => d.TermCodeNavigation)
                    .WithMany(p => p.ApplicationsOverIndexeds)
                    .HasForeignKey(d => d.TermCode)
                    .HasConstraintName("FK_APPLICATIONS_OVR_TERM_CODE");
            });

            modelBuilder.Entity<ClassStanding>(entity =>
            {
                entity.HasKey(e => e.ClassStandingCode);

                entity.ToTable("CLASS_STANDINGS");

                entity.Property(e => e.ClassStandingCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("CLASS_STANDING_CODE");

                entity.Property(e => e.ClassStandingName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("CLASS_STANDING_NAME");

                entity.Property(e => e.DegreeLevelCode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DEGREE_LEVEL_CODE");

                entity.Property(e => e.RequiredCredits)
                    .HasPrecision(3)
                    .HasColumnName("REQUIRED_CREDITS");

                entity.HasOne(d => d.DegreeLevelCodeNavigation)
                    .WithMany(p => p.ClassStandings)
                    .HasForeignKey(d => d.DegreeLevelCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLASS_STDGS_DEGREE_LEVEL_CD");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => new { e.DepartmentCode, e.CourseNumber });

                entity.ToTable("COURSES");

                entity.Property(e => e.DepartmentCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_CODE");

                entity.Property(e => e.CourseNumber)
                    .HasPrecision(3)
                    .HasColumnName("COURSE_NUMBER");

                entity.Property(e => e.CourseDescription)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("COURSE_DESCRIPTION");

                entity.Property(e => e.CourseTitle)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("COURSE_TITLE");

                entity.Property(e => e.Credits)
                    .HasColumnType("NUMBER(3,1)")
                    .HasColumnName("CREDITS");

                entity.HasOne(d => d.DepartmentCodeNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.DepartmentCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COURSES_DEPARTMENT_CODE");
            });

            modelBuilder.Entity<CourseEnrollment>(entity =>
            {
                entity.ToTable("COURSE_ENROLLMENTS");

                entity.HasIndex(e => new { e.CourseOfferingId, e.StudentId }, "IX_COURSE_ENROLL_OFFERING");

                entity.Property(e => e.CourseEnrollmentId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COURSE_ENROLLMENT_ID");

                entity.Property(e => e.CourseOfferingId)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("COURSE_OFFERING_ID");

                entity.Property(e => e.GradeCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRADE_CODE");

                entity.Property(e => e.StudentId)
                    .HasPrecision(10)
                    .HasColumnName("STUDENT_ID");

                entity.HasOne(d => d.CourseOffering)
                    .WithMany(p => p.CourseEnrollments)
                    .HasForeignKey(d => d.CourseOfferingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ENROLLMENTS_OFFERINGS");

                entity.HasOne(d => d.GradeCodeNavigation)
                    .WithMany(p => p.CourseEnrollments)
                    .HasForeignKey(d => d.GradeCode)
                    .HasConstraintName("FK_ENROLLMENTS_GRADES");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.CourseEnrollments)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ENROLLMENTS_STUDENT");
            });

            modelBuilder.Entity<CourseOffering>(entity =>
            {
                entity.ToTable("COURSE_OFFERINGS");

                entity.Property(e => e.CourseOfferingId)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("COURSE_OFFERING_ID");

                entity.Property(e => e.Capacity)
                    .HasPrecision(3)
                    .HasColumnName("CAPACITY");

                entity.Property(e => e.CourseNumber)
                    .HasPrecision(3)
                    .HasColumnName("COURSE_NUMBER");

                entity.Property(e => e.DepartmentCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_CODE");

                entity.Property(e => e.Section)
                    .HasPrecision(3)
                    .HasColumnName("SECTION");

                entity.Property(e => e.TermCode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TERM_CODE");

                entity.HasOne(d => d.TermCodeNavigation)
                    .WithMany(p => p.CourseOfferings)
                    .HasForeignKey(d => d.TermCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COURSE_OFFERINGS_TERM");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseOfferings)
                    .HasForeignKey(d => new { d.DepartmentCode, d.CourseNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COURSE_OFFERINGS_COURSES");
            });

            modelBuilder.Entity<Degree>(entity =>
            {
                entity.ToTable("DEGREES");

                entity.Property(e => e.DegreeId)
                    .HasPrecision(6)
                    .ValueGeneratedNever()
                    .HasColumnName("DEGREE_ID");

                entity.Property(e => e.DegreeName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("DEGREE_NAME");

                entity.Property(e => e.DegreeTypeCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("DEGREE_TYPE_CODE");

                entity.Property(e => e.DepartmentCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_CODE");

                entity.HasOne(d => d.DegreeTypeCodeNavigation)
                    .WithMany(p => p.Degrees)
                    .HasForeignKey(d => d.DegreeTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DEGREES_DEGREE_TYPE_CODE");

                entity.HasOne(d => d.DepartmentCodeNavigation)
                    .WithMany(p => p.Degrees)
                    .HasForeignKey(d => d.DepartmentCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DEGREES_DEPARTMENT_CODE");
            });

            modelBuilder.Entity<DegreeLevel>(entity =>
            {
                entity.HasKey(e => e.DegreeLevelCode);

                entity.ToTable("DEGREE_LEVELS");

                entity.Property(e => e.DegreeLevelCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DEGREE_LEVEL_CODE");

                entity.Property(e => e.DegreeLevelName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEGREE_LEVEL_NAME");
            });

            modelBuilder.Entity<DegreeRequirement>(entity =>
            {
                entity.HasKey(e => e.RequirementId);

                entity.ToTable("DEGREE_REQUIREMENTS");

                entity.Property(e => e.RequirementId)
                    .HasPrecision(10)
                    .ValueGeneratedNever()
                    .HasColumnName("REQUIREMENT_ID");

                entity.Property(e => e.ClassStandingCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("CLASS_STANDING_CODE");

                entity.Property(e => e.CourseNumber)
                    .HasPrecision(3)
                    .HasColumnName("COURSE_NUMBER");

                entity.Property(e => e.DegreeId)
                    .HasPrecision(6)
                    .HasColumnName("DEGREE_ID");

                entity.Property(e => e.DepartmentCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_CODE");

                entity.Property(e => e.SessionCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SESSION_CODE");

                entity.HasOne(d => d.ClassStandingCodeNavigation)
                    .WithMany(p => p.DegreeRequirements)
                    .HasForeignKey(d => d.ClassStandingCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DEGREE_REQ_CLASS_STNDG_CD");

                entity.HasOne(d => d.Degree)
                    .WithMany(p => p.DegreeRequirements)
                    .HasForeignKey(d => d.DegreeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DEGREE_REQ_DEGREE_ID");

                entity.HasOne(d => d.SessionCodeNavigation)
                    .WithMany(p => p.DegreeRequirements)
                    .HasForeignKey(d => d.SessionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DEGREE_REQ_SESSION_CD");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.DegreeRequirements)
                    .HasForeignKey(d => new { d.DepartmentCode, d.CourseNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DEGREE_REQ_COURSES");
            });

            modelBuilder.Entity<DegreeType>(entity =>
            {
                entity.HasKey(e => e.DegreeTypeCode);

                entity.ToTable("DEGREE_TYPES");

                entity.Property(e => e.DegreeTypeCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("DEGREE_TYPE_CODE");

                entity.Property(e => e.DegreeLevelCode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DEGREE_LEVEL_CODE");

                entity.Property(e => e.DegreeTypeName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("DEGREE_TYPE_NAME");

                entity.HasOne(d => d.DegreeLevelCodeNavigation)
                    .WithMany(p => p.DegreeTypes)
                    .HasForeignKey(d => d.DegreeLevelCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DEGREE_TYPES_DEGREE_TYPE_CD");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepartmentCode);

                entity.ToTable("DEPARTMENTS");

                entity.Property(e => e.DepartmentCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_CODE");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_NAME");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasKey(e => e.GradeCode);

                entity.ToTable("GRADES");

                entity.Property(e => e.GradeCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRADE_CODE");

                entity.Property(e => e.IncludeInGpa)
                    .IsRequired()
                    .HasPrecision(1)
                    .HasColumnName("INCLUDE_IN_GPA")
                    .HasDefaultValueSql("1 ");

                entity.Property(e => e.Points)
                    .HasColumnType("NUMBER(2,1)")
                    .HasColumnName("POINTS");
            });

            modelBuilder.Entity<ImReconsignment>(entity =>
            {
                entity.HasKey(e => e.PtrRecons)
                    .HasName("IM_RECONSIGNMENT_PTR_RECONS");

                entity.ToTable("IM_RECONSIGNMENT");

                entity.Property(e => e.PtrRecons)
                    .HasPrecision(12)
                    .ValueGeneratedNever()
                    .HasColumnName("PTR_RECONS");

                entity.Property(e => e.CdeInvSelect)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CDE_INV_SELECT");

                entity.Property(e => e.CdeReconsContrlSelect)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CDE_RECONS_CONTRL_SELECT");

                entity.Property(e => e.CdeReconsType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CDE_RECONS_TYPE");

                entity.Property(e => e.CdeReserveSelect)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CDE_RESERVE_SELECT");

                entity.Property(e => e.CdeStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CDE_STATUS");

                entity.Property(e => e.DscCom)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DSC_COM");

                entity.Property(e => e.DscStatusDtl)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("DSC_STATUS_DTL");

                entity.Property(e => e.DteBusBooked)
                    .HasColumnType("DATE")
                    .HasColumnName("DTE_BUS_BOOKED");

                entity.Property(e => e.DtmBooked)
                    .HasColumnType("DATE")
                    .HasColumnName("DTM_BOOKED");

                entity.Property(e => e.DtmTrans)
                    .HasColumnType("DATE")
                    .HasColumnName("DTM_TRANS");

                entity.Property(e => e.DtmUpd)
                    .HasColumnType("DATE")
                    .HasColumnName("DTM_UPD");

                entity.Property(e => e.FlgDel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FLG_DEL");

                entity.Property(e => e.FlgIntrnl)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FLG_INTRNL");

                entity.Property(e => e.IdnInvOwner)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IDN_INV_OWNER");

                entity.Property(e => e.IdnUpdByUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IDN_UPD_BY_USER");

                entity.Property(e => e.PtrCo)
                    .HasPrecision(12)
                    .HasColumnName("PTR_CO");

                entity.Property(e => e.PtrFromLoc)
                    .HasPrecision(12)
                    .HasColumnName("PTR_FROM_LOC");

                entity.Property(e => e.PtrProd)
                    .HasPrecision(12)
                    .HasColumnName("PTR_PROD");

                entity.Property(e => e.PtrToLoc)
                    .HasPrecision(12)
                    .HasColumnName("PTR_TO_LOC");

                entity.Property(e => e.UomVol)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("UOM_VOL");

                entity.Property(e => e.ValRvp)
                    .HasColumnType("NUMBER(3,1)")
                    .HasColumnName("VAL_RVP");

                entity.Property(e => e.VolTrans)
                    .HasColumnType("NUMBER(14,2)")
                    .HasColumnName("VOL_TRANS");
            });

            modelBuilder.Entity<MlogTab1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MLOG$_TAB1");

                entity.HasIndex(e => e.Xid, "I_MLOG$_TAB1");

                entity.Property(e => e.ChangeVector)
                    .HasMaxLength(255)
                    .HasColumnName("CHANGE_VECTOR$$");

                entity.Property(e => e.Description)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Dmltype)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DMLTYPE$$");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID");

                entity.Property(e => e.MRow)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("M_ROW$$");

                entity.Property(e => e.Num)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUM");

                entity.Property(e => e.OldNew)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OLD_NEW$$");

                entity.Property(e => e.Snaptime)
                    .HasColumnType("DATE")
                    .HasColumnName("SNAPTIME$$");

                entity.Property(e => e.Xid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("XID$$");
            });

            modelBuilder.Entity<PerfStat>(entity =>
            {
                entity.HasKey(e => e.StatName)
                    .HasName("SYS_C007520");

                entity.ToTable("PERF_STATS");

                entity.Property(e => e.StatName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("STAT_NAME");

                entity.Property(e => e.DisplayOrder)
                    .HasPrecision(6)
                    .HasColumnName("DISPLAY_ORDER");

                entity.Property(e => e.Divisor)
                    .HasPrecision(10)
                    .HasColumnName("DIVISOR")
                    .HasDefaultValueSql("1 ");

                entity.Property(e => e.Units)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UNITS");
            });

            modelBuilder.Entity<PerformanceCaptureStat>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PERFORMANCE_CAPTURE_STATS");

                entity.Property(e => e.DataSequence)
                    .HasPrecision(5)
                    .HasColumnName("DATA_SEQUENCE");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.RunNumber)
                    .HasPrecision(10)
                    .HasColumnName("RUN_NUMBER");

                entity.Property(e => e.StatName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STAT_NAME");

                entity.Property(e => e.StatValue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STAT_VALUE");
            });

            modelBuilder.Entity<RupdTab1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("RUPD$_TAB1");

                entity.Property(e => e.ChangeVector)
                    .HasMaxLength(255)
                    .HasColumnName("CHANGE_VECTOR$$");

                entity.Property(e => e.Dmltype)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DMLTYPE$$");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID");

                entity.Property(e => e.Snapid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("SNAPID");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasKey(e => e.SessionCode)
                    .HasName("PL_SESSIONS");

                entity.ToTable("SESSIONS");

                entity.Property(e => e.SessionCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SESSION_CODE");

                entity.Property(e => e.SessionName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SESSION_NAME");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("STUDENTS");

                entity.HasIndex(e => e.State, "IX_STUDENTS_NAME_STATE")
                    .HasFilter("UPPER(\"LAST_NAME\")");

                entity.Property(e => e.StudentId)
                    .HasPrecision(10)
                    .ValueGeneratedNever()
                    .HasColumnName("STUDENT_ID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CITY");

                entity.Property(e => e.ClassStandingCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("CLASS_STANDING_CODE");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE_OF_BIRTH");

                entity.Property(e => e.DegreePursued)
                    .HasPrecision(6)
                    .HasColumnName("DEGREE_PURSUED");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.EnrollmentTerm)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("ENROLLMENT_TERM");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MIDDLE_NAME");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("STATE");

                entity.Property(e => e.StreetAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STREET_ADDRESS");

                entity.Property(e => e.StudentStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STUDENT_STATUS");

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TELEPHONE");

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ZIP_CODE");

                entity.HasOne(d => d.ClassStandingCodeNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassStandingCode)
                    .HasConstraintName("FK_STUDENTS_CLASS_STANING");

                entity.HasOne(d => d.DegreePursuedNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.DegreePursued)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STUDENTS_DEGREE_PURSUED");

                entity.HasOne(d => d.EnrollmentTermNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.EnrollmentTerm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STUDENTS_ENROLLMENT_TERM");
            });

            modelBuilder.Entity<Tab1>(entity =>
            {
                entity.ToTable("TAB1");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Num)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUM");
            });

            modelBuilder.Entity<Tab1Mv>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TAB1_MV");

                entity.Property(e => e.Description)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID");

                entity.Property(e => e.Num)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUM");
            });

            modelBuilder.Entity<Table2>(entity =>
            {
                entity.ToTable("TABLE2");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Testtbid)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TESTTBID");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Table2)
                    .HasForeignKey<Table2>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TABLE2_FK1");
            });

            modelBuilder.Entity<Term>(entity =>
            {
                entity.HasKey(e => e.TermCode);

                entity.ToTable("TERMS");

                entity.Property(e => e.TermCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TERM_CODE");

                entity.Property(e => e.SessionCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SESSION_CODE");

                entity.Property(e => e.Year)
                    .HasPrecision(4)
                    .HasColumnName("YEAR");

                entity.HasOne(d => d.SessionCodeNavigation)
                    .WithMany(p => p.Terms)
                    .HasForeignKey(d => d.SessionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SESSION_CODE");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TEST");

                entity.Property(e => e.Col1)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COL1");

                entity.Property(e => e.Col2)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COL2");
            });

            modelBuilder.Entity<Test2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TEST2");

                entity.Property(e => e.SessionCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SESSION_CODE");

                entity.Property(e => e.SessionName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SESSION_NAME");
            });

            modelBuilder.Entity<Testtb>(entity =>
            {
                entity.ToTable("TESTTB");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Column2)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COLUMN2");
            });

            modelBuilder.Entity<VStudentGrade>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_STUDENT_GRADES");

                entity.Property(e => e.CourseNumber)
                    .HasPrecision(3)
                    .HasColumnName("COURSE_NUMBER");

                entity.Property(e => e.CourseTitle)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("COURSE_TITLE");

                entity.Property(e => e.Credits)
                    .HasColumnType("NUMBER(3,1)")
                    .HasColumnName("CREDITS");

                entity.Property(e => e.DepartmentCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_CODE");

                entity.Property(e => e.GradeCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRADE_CODE");

                entity.Property(e => e.Points)
                    .HasColumnType("NUMBER(2,1)")
                    .HasColumnName("POINTS");

                entity.Property(e => e.StudentId)
                    .HasPrecision(10)
                    .HasColumnName("STUDENT_ID");

                entity.Property(e => e.TermCode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TERM_CODE");
            });

            modelBuilder.HasSequence("SEQ_PERFORMANCE_CAPTURE");

            modelBuilder.HasSequence("TABLE1_SEQ");

            modelBuilder.HasSequence("TABLE2_SEQ");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
