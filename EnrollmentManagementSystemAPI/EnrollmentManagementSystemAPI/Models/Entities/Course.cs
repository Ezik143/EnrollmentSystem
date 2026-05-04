namespace EnrollmentManagementSystemAPI.Models.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public string CourseCode { get; set; } = string.Empty;
        public int Credits { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool isActive { get; set; } = true;
        public int DepartmentId { get; set; }
        public Department? Department { get; set; } = null;

    }
}
