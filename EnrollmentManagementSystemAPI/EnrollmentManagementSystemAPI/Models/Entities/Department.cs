using EnrollmentManagementSystemAPI.Models.Enums;

namespace EnrollmentManagementSystemAPI.Models.Entities
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public EducationAuthority EducationAuthority { get; set; } = EducationAuthority.CHED;
        public string Campus { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
        public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
