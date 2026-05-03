namespace EnrollmentManagementSystemAPI.Models.Entities
{
    public class Section
    {
        public int SectionId { get; set; }
        public int InstructorId { get; set; }
        public required Instructor Instructor { get; set; }
        public int CourseId { get; set; }
        public required Course Course { get; set; }
        public int CourseSubjectId { get; set; } 
        public required CourseSubject CourseSubject { get; set; }
        public int TermId { get; set; }
        public required Term Term { get; set; }
        public int Capacity { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
