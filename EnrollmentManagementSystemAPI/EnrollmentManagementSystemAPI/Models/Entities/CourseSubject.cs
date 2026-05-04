namespace EnrollmentManagementSystemAPI.Models.Entities
{
    public class CourseSubject
    {
        public int CourseSubjectId { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }
        public int YearLevel { get; set; }
        public int TermNumber { get; set; }
        public bool IsRequired { get; set; } = true;
        public string Remarks { get; set; } = string.Empty;

        public ICollection<Section> Sections { get; set; } = new List<Section>();
    }
}
