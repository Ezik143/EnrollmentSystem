using Microsoft.EntityFrameworkCore;

namespace EnrollmentManagementSystemAPI.data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Models.Entities.Course> Courses { get; set; } = null!;
        public DbSet<Models.Entities.Department> Departments { get; set; } = null!; 
        public DbSet<Models.Entities.Student> Students { get; set; } = null!;
        public DbSet<Models.Entities.Enrollment> Enrollments { get; set; } = null!;
        public DbSet<Models.Entities.Instructor> Instructors { get; set; } = null!;
        public DbSet<Models.Entities.Term> Term { get; set; } = null!;
        public DbSet<Models.Entities.CourseSubject> CourseSubjects { get; set; }
        public DbSet<Models.Entities.Subject> Subjects { get; set; } = null!;
        public DbSet<Models.Entities.Section> Sections { get; set; } = null!;
    }
}
