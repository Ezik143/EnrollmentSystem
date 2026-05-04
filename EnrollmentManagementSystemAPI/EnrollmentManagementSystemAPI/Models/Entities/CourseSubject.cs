namespace EnrollmentManagementSystemAPI.Models.Entities
{
    public class CourseSubject
    {
        public int CourseSubjectId { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; } = null;
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; } = null;
        public string Name { get; set; } = string.Empty;
        public int SemesterNo { get; set; }
    }
}
