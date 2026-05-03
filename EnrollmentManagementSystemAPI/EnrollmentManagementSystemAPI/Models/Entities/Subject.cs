namespace EnrollmentManagementSystemAPI.Models.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public Department? Department { get; set; } = null;
        public string SubjectCode { get; set; } = string.Empty;
        public string CourseCode { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int Units { get; set; }
    }
}
