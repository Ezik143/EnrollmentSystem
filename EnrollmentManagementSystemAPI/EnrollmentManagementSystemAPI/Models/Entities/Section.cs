namespace EnrollmentManagementSystemAPI.Models.Entities
{
    public class Section
    {
        public int SectionId { get; set; }
        public int InstructorId { get; set; }
        public Instructor? Instructor { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public int CourseSubjectId { get; set; }
        public CourseSubject? CourseSubject { get; set; }
        public int TermId { get; set; }
        public Term? Term { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
