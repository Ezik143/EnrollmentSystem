using EnrollmentManagementSystemAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnrollmentManagementSystemAPI.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Enrollment> Enrollments { get; set; } = null!;
        public DbSet<Instructor> Instructors { get; set; } = null!;
        public DbSet<Term> Term { get; set; } = null!;
        public DbSet<CourseSubject> CourseSubjects { get; set; } = null!;
        public DbSet<Subject> Subjects { get; set; } = null!;
        public DbSet<Section> Sections { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(x => x.DepartmentCode).HasMaxLength(30);
                entity.Property(x => x.Name).HasMaxLength(150);
                entity.Property(x => x.Campus).HasMaxLength(150);
                entity.HasIndex(x => x.DepartmentCode).IsUnique();
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(x => x.CourseName).HasMaxLength(150);
                entity.Property(x => x.CourseCode).HasMaxLength(30);
                entity.Property(x => x.CurriculumYear).HasMaxLength(20);
                entity.Property(x => x.ChedProgramCode).HasMaxLength(30);
                entity.Property(x => x.SeniorHighTrack).HasMaxLength(50);
                entity.Property(x => x.SeniorHighStrand).HasMaxLength(50);
                entity.HasIndex(x => x.CourseCode).IsUnique();
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(x => x.SubjectCode).HasMaxLength(30);
                entity.Property(x => x.Title).HasMaxLength(150);
                entity.HasIndex(x => x.SubjectCode).IsUnique();
                entity.HasOne(x => x.PrerequisiteSubject)
                    .WithMany(x => x.DependentSubjects)
                    .HasForeignKey(x => x.PrerequisiteSubjectId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CourseSubject>(entity =>
            {
                entity.Property(x => x.Remarks).HasMaxLength(250);
                entity.HasIndex(x => new { x.CourseId, x.SubjectId, x.YearLevel, x.TermNumber }).IsUnique();
            });

            modelBuilder.Entity<Term>(entity =>
            {
                entity.ToTable("Term");
                entity.Property(x => x.Name).HasMaxLength(100);
                entity.Property(x => x.AcademicYear).HasMaxLength(20);
                entity.HasIndex(x => new { x.AcademicYear, x.TermType }).IsUnique();
            });

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.Property(x => x.EmployeeNumber).HasMaxLength(30);
                entity.Property(x => x.FirstName).HasMaxLength(50);
                entity.Property(x => x.MiddleName).HasMaxLength(50);
                entity.Property(x => x.LastName).HasMaxLength(50);
                entity.Property(x => x.Suffix).HasMaxLength(15);
                entity.Property(x => x.Email).HasMaxLength(100);
                entity.Property(x => x.Rank).HasMaxLength(100);
                entity.Property(x => x.EmploymentType).HasMaxLength(50);
                entity.Property(x => x.ContactNumber).HasMaxLength(30);
                entity.HasIndex(x => x.EmployeeNumber).IsUnique();
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(x => x.StudentNumber).HasMaxLength(30);
                entity.Property(x => x.LearnerReferenceNumber).HasMaxLength(12);
                entity.Property(x => x.FirstName).HasMaxLength(50);
                entity.Property(x => x.MiddleName).HasMaxLength(50);
                entity.Property(x => x.LastName).HasMaxLength(50);
                entity.Property(x => x.Suffix).HasMaxLength(15);
                entity.Property(x => x.Gender).HasMaxLength(30);
                entity.Property(x => x.CivilStatus).HasMaxLength(30);
                entity.Property(x => x.Citizenship).HasMaxLength(60);
                entity.Property(x => x.BirthPlace).HasMaxLength(120);
                entity.Property(x => x.Email).HasMaxLength(100);
                entity.Property(x => x.PhoneNumber).HasMaxLength(30);
                entity.Property(x => x.HouseStreet).HasMaxLength(150);
                entity.Property(x => x.Barangay).HasMaxLength(100);
                entity.Property(x => x.CityMunicipality).HasMaxLength(100);
                entity.Property(x => x.Province).HasMaxLength(100);
                entity.Property(x => x.Region).HasMaxLength(100);
                entity.Property(x => x.PostalCode).HasMaxLength(15);
                entity.Property(x => x.GuardianName).HasMaxLength(150);
                entity.Property(x => x.GuardianRelationship).HasMaxLength(50);
                entity.Property(x => x.GuardianContactNumber).HasMaxLength(30);
                entity.Property(x => x.SeniorHighTrack).HasMaxLength(50);
                entity.Property(x => x.SeniorHighStrand).HasMaxLength(50);
                entity.Property(x => x.IndigenousGroup).HasMaxLength(100);
                entity.HasIndex(x => x.StudentNumber).IsUnique();
                entity.HasIndex(x => x.LearnerReferenceNumber).IsUnique();
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.Property(x => x.Name).HasMaxLength(50);
                entity.Property(x => x.Room).HasMaxLength(50);
                entity.Property(x => x.Schedule).HasMaxLength(120);
                entity.Property(x => x.Campus).HasMaxLength(150);
                entity.HasIndex(x => new { x.TermId, x.CourseSubjectId, x.Name }).IsUnique();
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.Property(x => x.ScholarshipType).HasMaxLength(100);
                entity.Property(x => x.Remarks).HasMaxLength(250);
                entity.HasIndex(x => new { x.StudentId, x.SectionId }).IsUnique();
            });
        }
    }
}
